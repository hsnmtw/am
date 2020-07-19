using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupModel : IModel {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }

        public GroupModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [GROUP_NAME],[GROUP_DESC] FROM USER_GROUPS");
            var result = new GroupModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].GroupDesc = table.Rows[i]["GROUP_DESC"].ToString();
            }
            return result;
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM USER_GROUPS WHERE [GROUP_NAME]=?", GroupName);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO USER_GROUPS ([GROUP_NAME],[GROUP_DESC]) VALUES (?,?)", GroupName,GroupDesc);
        }

        public void Select() {
            GroupDesc = "";
            DataTable table = DefaultConnection.Instance.Query("SELECT [GROUP_NAME],[GROUP_DESC] FROM USER_GROUPS WHERE [GROUP_NAME]=?", GroupName);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                GroupDesc = table.Rows[0]["GROUP_DESC"].ToString();
            }
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE USER_GROUPS SET [GROUP_DESC]=? WHERE [GROUP_NAME]=?", GroupDesc, GroupName);
        }

        public bool Validate() {
            return !GroupName.Trim().Equals("");
        }
    }
}
