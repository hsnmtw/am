using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel {
    public class DefaultConnection {
        public static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["AMCS"].ConnectionString; //@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Data\AssetManager.mdb";
        private static DefaultConnection _instance = null;
        public static DefaultConnection Instance 
        {
            get {
                if(_instance==null) { _instance = new DefaultConnection(); }
                return _instance;
            }
        }
        private OleDbConnection connection;

        private DefaultConnection() {
            connection = new OleDbConnection(CONNECTION_STRING);
            connection.Open();
        }

        public DataTable Query(string sql, params object[] parameters) {
            
            DataTable table = new DataTable();
            try {
                var cmd = new OleDbCommand(sql, connection);
                var adp = new OleDbDataAdapter(cmd);
                if(parameters != null) {
                    foreach(string prm in parameters) {
                        cmd.Parameters.Add(new OleDbParameter() { Value = prm });
                    }
                }
                adp.Fill(table);
            } catch (Exception e){
                table.Columns.Add("ERROR");
                table.Rows.Add(e.Message);
            }
            return table;
        }

        public object Execute(string sql,params object[] parameters) {
            try {
                var cmd = new OleDbCommand(sql, connection);
                if (parameters != null) {
                    foreach (string prm in parameters) {
                        cmd.Parameters.Add(new OleDbParameter() { Value = prm });
                    }
                }
                return cmd.ExecuteNonQuery();
            } catch (Exception e) {
                return e.Message;
            }
        }


        public string GetCSV(string sql, List<int> columnWidths = null) {
            var stringBuilder = new StringBuilder();
            var dataTable = Query(sql);
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


    }
}
