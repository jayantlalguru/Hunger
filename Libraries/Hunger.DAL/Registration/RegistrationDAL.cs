using Dapper;
using Hunger.DAL.Configuration;
using System.Linq;
using Hunger.Domain.Registration;
using Hunger.DAL.Queries;
using System;
using System.Collections.Generic;
using RDomain = Hunger.Domain.Registration;

namespace Hunger.DAL.Registration
{
    public class RegistrationDAL : ConnectionProperties
    {
        /// <summary>
        /// Create new agreement for customers
        /// </summary>
        /// <param name="agreement">Object</param>
        /// <returns></returns>
        public int CreateAgreement(Agreement agreement)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Execute(RegistrationSQL.Agreement, new { agreement.AgreementText, agreement.CurrentDate, agreement.CreatedBy, agreement.CurrentIpAddress, agreement.CurrentSystemName, agreement.IsAgreementValid, agreement.ValidFrom, agreement.ValidTo } );
            }
        }

        /// <summary>
        /// Create new registration. A new registration id will be generated
        /// </summary>
        /// <param name="registration">Registration object</param>
        /// <returns>Registration id</returns>
        public int CreateRegistration(RDomain.Registration registration)
        {            
            using (var dbConnection = Connection)
            {
                return dbConnection.Query<int>(RegistrationSQL.Registration, new { registration.Name, registration.RegisteredPhoneNumber, registration.PhoneNumber, registration.EmailId, registration.Address, registration.Agreement.AgreementId, registration.HasAgreedToTermsAndCondition, registration.CurrentDate }).Single();
            }
                   
        }

        /// <summary>
        /// Accept registration for a new business
        /// </summary>
        /// <param name="registration">RDomain.Registration Object</param>
        /// <returns>Status</returns>
        public int AcceptRegistration(RDomain.Registration registration)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Execute(RegistrationSQL.AcceptRegistration, new { registration.ModifiedBy, registration.CurrentModificationDate, registration.RegistrationId });
            }   
        }

        /// <summary>
        /// Reject a registration request if it does not meet acceptance criteria
        /// </summary>
        /// <param name="registration">Registration Object</param>
        /// <param name="registrationRejectionReason">Rejection Reason object</param>
        /// <returns>1 for success or throws exception</returns>
        public int RejectRegistration(RDomain.Registration registration, RegistrationRejectionReason registrationRejectionReason)
        {
            int result;
            using (var dbConnection = Connection)
            {
                OpenConnection(dbConnection);
                #region TRAN
                using (var tran = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = dbConnection.Execute(RegistrationSQL.RejectRegistration, new { registration.CurrentModificationDate, registration.ModifiedBy, registration.RegistrationId, registration.CurrentIpAddress, registration.CurrentSystemName, registrationRejectionReason.RejectionReasonText }, transaction: tran);
                        tran.Commit();                        
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        CloseConnection(dbConnection);
                        throw ex;
                    }
                }
                #endregion TRAN
            }
            return result;   
        }

        /// <summary>
        /// Update a Registration with new agreement and move the old agreement to Mapping table
        /// </summary>
        /// <param name="registration">Registration Object</param>
        /// <param name="registrationAgreementMapping">RegistrationAgreementMapping Object</param>
        /// <returns>1 for success</returns>
        public int UpdateRegistrationAgreement(RDomain.Registration registration, RegistrationAgreementMapping registrationAgreementMapping)
        {
            using (var dbConnection = Connection)
            {
                OpenConnection(dbConnection);
                #region TRAN
                using (var tran = dbConnection.BeginTransaction())
                {
                    try
                    {
                        int newAgreementId = registration.Agreement.AgreementId;                        
                        int result = dbConnection.Execute(RegistrationSQL.UpdateRegistrationAgreement, new { registration.RegistrationId, registrationAgreementMapping.AgreementId, registrationAgreementMapping.AgreedFrom, registrationAgreementMapping.AgreedTill, newAgreementId, registration.CurrentModificationDate, registration.ModifiedBy, registration.AgreementAcceptedOn }, transaction: tran);
                        tran.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        CloseConnection(dbConnection);
                        throw ex;
                    }
                }
                #endregion TRAN
            }
        }
        
        /// <summary>
        /// Gets registraion details based on registration id
        /// </summary>
        /// <param name="id">registration Id</param>
        /// <returns>Registration Objects</returns>
        public RDomain.Registration GetRegistrationById(int id)
        {
            using (var dbConnection = Connection)
            {

                var result = dbConnection.QueryMultiple(RegistrationSQL.RegistrationById, new { RegistrationId = id });
                var registration = result.Read<RDomain.Registration, Agreement, RDomain.Registration>
                   (
                       (reg, agr) 
                       => { reg.Agreement = agr; return reg; },                       
                       splitOn: "AgreementId"                       
                   ).FirstOrDefault();
                
                var mapping = result.Read<RegistrationAgreementMapping, Agreement, RegistrationAgreementMapping>
                    (
                        (registrationAgreementMapping, agreement)
                        =>
                        {
                            registrationAgreementMapping.Agreement = agreement;
                            return registrationAgreementMapping;
                        }, splitOn: "AgreementId"
                    );
                registration.RegistrationAgreementMappings = (IEnumerable<RegistrationAgreementMapping>)mapping;
                return registration;

                //CODE FOR REFERENCE
                //return dbConnection.Query<RDomain.Registration, Agreement, IEnumerable<RegistrationAgreementMapping>
                //    , RDomain.Registration>
                //    (
                //    RegistrationSQL.RegistrationById, (registration, agreement, registrationAgreementMapping)
                //    =>
                //    {
                //        registration.Agreement = agreement;
                //        registration.RegistrationAgreementMappings = registrationAgreementMapping;
                //        return registration;
                //    },
                //    new { RegistrationId = id }, splitOn: "AgreementId,RegistrationId,AgreementId").FirstOrDefault();
            }
        }

        /// <summary>
        /// Activate multiple registrations
        /// </summary>
        /// <param name="registrationIds">registrationId's</param>
        /// <returns>greater than 0 if success else -1</returns>
        public int ActivateRegistration(IEnumerable<int> registrationIds)
        {
            bool IsActive = true;
            using (var dbConnection = Connection)
            {
                var query = DynamicQuery.BuildQuery(new QueryParameter { Column = "RegistrationId", Table = "Registration", Ids = registrationIds, FieldName = "@IsActive" , ColumnToUpdate = "IsActive" }, QueryType.UpdateOneColumnUsingSubQuery);
                return dbConnection.Execute(query, new { IsActive });
            }
        }

        /// <summary>
        /// Activate single registration
        /// </summary>
        /// <param name="registrationId">registrationId</param>
        /// <returns>1 if success else -1</returns>
        public int ActivateRegistration(int registrationId)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Execute(RegistrationSQL.ActivateRegistration, new { registrationId });
            }
        }

        /// <summary>
        /// Move data from registration table to chef table
        /// </summary>
        /// <param name="registration"></param>
        /// <returns>1 if success else -1</returns>
        public int CopyRegistrationToChef(RDomain.Registration registration)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Execute(RegistrationSQL.MoveToChef, new { registration.Name, registration.RegistrationId, registration.CreatedBy, registration.CurrentDate });
            }
        }

        /// <summary>
        /// Move data in bulk from registration table to chef table
        /// </summary>
        /// <param name="Ids">RegistrationId</param>
        /// <returns>greater than 1 for success</returns>
        public int CopyRegistrationToChef(IEnumerable<RDomain.Registration> registrations)
        {            
            foreach (var registration in registrations)
            {

            }

            using (var dbConnection = Connection)
            {
                return dbConnection.Execute(RegistrationSQL.MoveToChefInBulk);
            }
        }

        /// <summary>
        /// Deactivate single registration
        /// </summary>
        /// <param name="registrationId">registrationId</param>
        /// <returns>1 if success else -1</returns>
        public int DeactivateRegistration(int registrationId)
        {
            bool IsActive = false;
            using (var dbConnection = Connection)
            {
                var query = DynamicQuery.BuildQuery(new QueryParameter { Column = "RegistrationId", Table = "Registration", Id = registrationId, FieldName = "@IsActive", ColumnToUpdate = "IsActive" }, QueryType.UpdateSingleColumnById);
                return dbConnection.Execute(query, new { IsActive });
            }
        }

        /// <summary>
        /// Deactivate multiple registrations
        /// </summary>
        /// <param name="registrationIds">registrationId's</param>
        /// <returns>greater than 0 if success else -1</returns>
        public int DeactivateRegistration(IEnumerable<int> registrationIds)
        {
            bool IsActive = false;
            using (var dbConnection = Connection)
            {
                var query = DynamicQuery.BuildQuery(new QueryParameter { Column = "RegistrationId", Table = "Registration", Ids = registrationIds, FieldName = "@IsActive", ColumnToUpdate = "IsActive" }, QueryType.UpdateOneColumnUsingSubQuery);
                return dbConnection.Execute(query, new { IsActive });
            }
        }
        


    }
}
