using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class RoleModel : AbstractModel {
        public override int ID { get; set; }
        public string ROLE_NAME { get; set; }

        public override string TABLE_NAME => "ROLES";

        public RoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new RoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new RoleModel();
                result[i].ROLE_NAME = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].ID = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }


        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (ROLE_NAME) VALUES (?)", ROLE_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE ROLE_NAME=? OR ID=?", ROLE_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                ROLE_NAME = table.Rows[0]["ROLE_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET ROLE_NAME=? WHERE ID=?", ROLE_NAME, ID);
        }

        public override bool Validate() {
            return !ROLE_NAME.Trim().Equals("");
        }
    }
}
