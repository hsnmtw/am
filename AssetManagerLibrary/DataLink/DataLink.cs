using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMModel;
using System.Data;

namespace AMController.DataLink {
    public class DataLink {
        private DefaultConnection connection;
        public DataLink() {
            this.connection = DefaultConnection.Instance;
        }

        public DataTable GetDataTable(string sql) {
            return connection.Query(sql);
        }

        public string GetCSV(string sql, List<int> columnWidths = null) {
            var stringBuilder = new StringBuilder();
            var dataTable = connection.Query(sql);
            if (columnWidths == null) {
                columnWidths = new List<int>();
                for (int i = 0; i < dataTable.Columns.Count; i++) {
                    columnWidths.Add(20);
                }
            }
            for (int i = 0; i < dataTable.Columns.Count; i++) {
                stringBuilder.Append(String.Format(" {0,-" + columnWidths[i] + "},", dataTable.Columns[i].ColumnName));
            }
            stringBuilder.Length--;
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < dataTable.Columns.Count; i++) {
                stringBuilder.Append(String.Format(" {0,-" + columnWidths[i] + "},", "==================="));
            }
            stringBuilder.Length--;
            stringBuilder.Append(Environment.NewLine);
            for (int r = 0; r < dataTable.Rows.Count; r++) {
                for (int i = 0; i < dataTable.Columns.Count; i++) {
                    stringBuilder.Append(String.Format(" {0,-" + columnWidths[i] + "},", dataTable.Rows[r][i]));
                }
                stringBuilder.Length--;
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }




        public object RunNonQuery(string sql) {
            return connection.Execute(sql);
        }
        
    }
}
