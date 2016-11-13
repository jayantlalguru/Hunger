using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Queries
{
    public class QueryParameter
    {
        /// <summary>
        /// Table name on which query is to be run
        /// </summary>
        internal string Table { get; set; }
        /// <summary>
        /// Table column name on which where condition will be applied
        /// </summary>
        internal string Column { get; set; }
        /// <summary>
        /// If you don't want to select all columns of table then send a list of columns names
        /// </summary>
        internal IEnumerable<string> Columns { get; set; }
        /// <summary>
        /// values for IN query
        /// </summary>
        internal IEnumerable<int> Ids { get; set; }
        /// <summary>
        /// Name of the variable to update. Ex: @EmployeeName
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Column name to be updated
        /// </summary>
        public string ColumnToUpdate { get; set; }
        /// <summary>
        /// Id Value of the column
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Which type of query should be formed
    /// </summary>
    public enum QueryType
    {
        SubQuery,
        FindAllById,
        FindSelectedColumnById,
        UpdateOneColumnUsingSubQuery,
        UpdateSingleColumnById,
        Insert
    }
}
