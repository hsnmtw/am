using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupRoleModel : AbstractModel {
        public override int Id { get; set; }
        public string RoleName { get; set; }
        public string GroupName { get; set; }

        public override string TABLE_NAME => "[GROUP_ROLES]";

        public GroupRoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME],[GROUP_NAME] FROM " + TABLE_NAME + ";");
            var result = new GroupRoleModel[table.Rows.Count];
            
            for(int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }


        public object DeleteByGroupName() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM "+ TABLE_NAME +" WHERE [GROUP_NAME]=?", GroupName);
            return result;
        }

        public object DeleteByRoleName() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM " + TABLE_NAME + " WHERE [ROLE_NAME]=?", RoleName);
            return result;
        }

        public GroupRoleModel[] SearchByGroupName() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME],[GROUP_NAME] FROM " + TABLE_NAME + " WHERE [GROUP_NAME]=?", GroupName);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public GroupRoleModel[] SearchByRoleName() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME],[GROUP_NAME] FROM " + TABLE_NAME + " WHERE [ROLE_NAME]=?", RoleName);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " ([GROUP_NAME],[ROLE_NAME]) VALUES (?,?)", GroupName, RoleName);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[ROLE_NAME],[GROUP_NAME] FROM " + TABLE_NAME + " WHERE ([GROUP_NAME]=? AND [ROLE_NAME]=?) OR [ID]=?", GroupName, RoleName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                RoleName = table.Rows[0]["ROLE_NAME"].ToString();
                GroupName = table.Rows[0]["GROUP_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET [GROUP_NAME]=? , [ROLE_NAME]=? WHERE [ID]=?", GroupName, RoleName, Id);
        }

        public override bool Validate() {
            return !(RoleName.Trim().Equals("") || GroupName.Trim().Equals(""));
        }
    }
}
