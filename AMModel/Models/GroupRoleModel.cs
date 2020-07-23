using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupRoleModel : AbstractModel {
        public override int ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string GROUP_NAME { get; set; }

        public override string TABLE_NAME => "GROUP_ROLES";

        public GroupRoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new GroupRoleModel[table.Rows.Count];
            
            for(int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GROUP_NAME = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].ROLE_NAME = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].ID = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }


        public object DeleteByGROUP_NAME() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM "+ TABLE_NAME +" WHERE GROUP_NAME=?", GROUP_NAME);
            return result;
        }

        public object DeleteByROLE_NAME() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM " + TABLE_NAME + " WHERE ROLE_NAME=?", ROLE_NAME);
            return result;
        }

        public GroupRoleModel[] SearchByGROUP_NAME() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE GROUP_NAME=?", GROUP_NAME);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GROUP_NAME = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].ROLE_NAME = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].ID = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public GroupRoleModel[] SearchByROLE_NAME() {
            var table = DefaultConnection.Instance.Query("SELECT ID,ROLE_NAME,GROUP_NAME FROM " + TABLE_NAME + " WHERE ROLE_NAME=?", ROLE_NAME);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GROUP_NAME = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].ROLE_NAME = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].ID = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (GROUP_NAME,ROLE_NAME) VALUES (?,?)", GROUP_NAME, ROLE_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT ID,ROLE_NAME,GROUP_NAME FROM " + TABLE_NAME + " WHERE (GROUP_NAME=? AND ROLE_NAME=?) OR ID=?", GROUP_NAME, ROLE_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                ROLE_NAME = table.Rows[0]["ROLE_NAME"].ToString();
                GROUP_NAME = table.Rows[0]["GROUP_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET GROUP_NAME=? , [ROLE_NAME=? WHERE ID=?", GROUP_NAME, ROLE_NAME, ID);
        }

        public override bool Validate() {
            return !(ROLE_NAME.Trim().Equals("") || GROUP_NAME.Trim().Equals(""));
        }
    }
}
