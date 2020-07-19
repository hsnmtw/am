using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class RoleModel : IModel {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public RoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ROLE_NAME] FROM ROLES");
            var result = new RoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new RoleModel();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
            }
            return result;
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM ROLES WHERE [ROLE_NAME]=?", RoleName);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO ROLES ([ROLE_NAME]) VALUES (?)", RoleName);
        }

        public void Select() {
            
            DataTable table = DefaultConnection.Instance.Query("SELECT [ROLE_NAME] FROM ROLES WHERE [ROLE_NAME]=?", RoleName);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                RoleName = table.Rows[0]["RoleName"].ToString();
            }
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public bool Validate() {
            return !RoleName.Trim().Equals("");
        }
    }
}
