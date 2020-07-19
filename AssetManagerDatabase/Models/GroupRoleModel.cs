using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupRoleModel : IModel {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string GroupName { get; set; }

        public GroupRoleModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ROLE_NAME],[GROUP_NAME] FROM GROUP_ROLES");
            var result = new GroupRoleModel[table.Rows.Count];
            
            for(int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
            }
            return result;
        }


        public object DeleteByGroupName() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM GROUP_ROLES WHERE [GROUP_NAME]=?", GroupName);
            return result;
        }

        public object DeleteByRoleName() {
            var result = DefaultConnection.Instance.Execute("DELETE FROM GROUP_ROLES WHERE [ROLE_NAME]=?", RoleName);
            return result;
        }

        public GroupRoleModel[] SearchByGroupName() {
            var table = DefaultConnection.Instance.Query("SELECT [ROLE_NAME],[GROUP_NAME] FROM GROUP_ROLES WHERE [GROUP_NAME]=?",GroupName);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
            }
            return result;
        }

        public GroupRoleModel[] SearchByRoleName() {
            var table = DefaultConnection.Instance.Query("SELECT [ROLE_NAME],[GROUP_NAME] FROM GROUP_ROLES WHERE [ROLE_NAME]=?", RoleName);
            var result = new GroupRoleModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupRoleModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].RoleName = table.Rows[i]["ROLE_NAME"].ToString();
            }
            return result;
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM GROUP_ROLES WHERE [GROUP_NAME]=? AND [ROLE_NAME]=?",GroupName,RoleName);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO GROUP_ROLES ([GROUP_NAME],[ROLE_NAME]) VALUES (?,?)", GroupName, RoleName);
        }

        public void Select() {
            throw new NotImplementedException();
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public bool Validate() {
            return !(RoleName.Trim().Equals("") || GroupName.Trim().Equals(""));
        }
    }
}
