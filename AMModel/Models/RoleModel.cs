using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class RoleModel : AbstractModel {
        public override int Id { get; set; }
        public string RoleName { get; set; }

        public override string TABLE_NAME => "[ROLES]";

        public RoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME] FROM " + TABLE_NAME + ";");
            var result = new RoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new RoleModel();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }


        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " ([ROLE_NAME]) VALUES (?)", RoleName);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME] FROM " + TABLE_NAME + " WHERE [ROLE_NAME]=? OR [ID]=?", RoleName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                RoleName = table.Rows[0]["ROLE_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET [ROLE_NAME]=? WHERE [ID]=?", RoleName, Id);
        }

        public override bool Validate() {
            return !RoleName.Trim().Equals("");
        }
    }
}
