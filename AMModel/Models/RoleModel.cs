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
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME] FROM ROLES");
            var result = new RoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new RoleModel();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM ROLES WHERE [ID]=?", Id);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO ROLES ([ID],[ROLE_NAME]) VALUES (?,?)",Id, RoleName);
        }

        public void Select() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME] FROM ROLES WHERE [ROLE_NAME]=? OR [ID]=?", RoleName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                RoleName = table.Rows[0]["ROLE_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE ROLES SET [ROLE_NAME]=? WHERE [ID]=?", RoleName, Id);
        }

        public bool Validate() {
            return !RoleName.Trim().Equals("");
        }
    }
}
