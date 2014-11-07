using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase.Database
{
    public class Utils
    {
        public static DataTable ConvertToDatatable<T>(IList<T> data)
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            
            // create the columns
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);

                // cant be null
                table.Columns[i].AllowDBNull = false;
            }

            // fills the table
            var values = new object[props.Count];
            foreach (var item in data)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            // set the primary key using DataColumn
            table.PrimaryKey = new[]
            {
                table.Columns["Sala"],
                table.Columns["HorarioIni"],
                table.Columns["HorarioFin"]
            };

            return table;
        }
    }
}
