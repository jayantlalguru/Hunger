using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Queries
{
    public static class DynamicQuery
    {    
        public static string BuildQuery(QueryParameter queryParameter, QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.SubQuery:
                    return SubQuery(queryParameter);
                    break;
                case QueryType.FindAllById:
                    break;
                case QueryType.FindSelectedColumnById:
                    break;
                case QueryType.UpdateOneColumnUsingSubQuery:
                    return UpdateSingleColumnByIdUsingSubQuery(queryParameter);
                    break;
                case QueryType.UpdateSingleColumnById:
                    return UpdateSingleColumnById(queryParameter);
                    break;
                case QueryType.Insert:
                    return Insert(queryParameter);
                    break;
                default:
                    break;
            }
            return string.Empty;
        }

        private static string SubQuery(QueryParameter queryParameter)
        {
            if(queryParameter.Columns != null && queryParameter.Columns.Count() > 0)
            {
                return string.Format("SELECT {0} FROM {1} WHERE {2} IN ({3}); ", string.Join(",", queryParameter.Columns), queryParameter.Table, queryParameter.Column, string.Join(",", queryParameter.Ids));
            }
            else
            {
                return string.Format("SELECT * FROM {0} WHERE {1} IN ({2}); ", queryParameter.Table, queryParameter.Column, string.Join(",", queryParameter.Ids));
            }
        }

        private static string UpdateSingleColumnByIdUsingSubQuery(QueryParameter queryParameter)
        {
            return string.Format("UPDATE {0} SET {1} = {2} WHERE {3} IN ({4}); ", queryParameter.Table, queryParameter.ColumnToUpdate, queryParameter.FieldName, queryParameter.Column, string.Join(",", queryParameter.Ids));
        }

        private static string UpdateSingleColumnById(QueryParameter queryParameter)
        {
            return string.Format("UPDATE {0} SET {1} = {2} WHERE {3} = {4}; ", queryParameter.Table, queryParameter.ColumnToUpdate, queryParameter.FieldName, queryParameter.Column, queryParameter.Id);
        }

        private static string Insert(QueryParameter queryParameter)
        {
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2}); ", queryParameter.Table, string.Join(",", queryParameter.Columns), string.Join(",@", queryParameter.Columns));
        }
    }
}
