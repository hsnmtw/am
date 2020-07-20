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

        public string TABLE_NAME => "[USER_GROUPS]";

        public GroupModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[GROUP_NAME],[GROUP_DESC] FROM " + TABLE_NAME);
            var result = new GroupModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupModel();
                result[i].GroupName = table.Rows[i]["GROUP_NAME"].ToString();
                result[i].GroupDesc = table.Rows[i]["GROUP_DESC"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public int Count() {
            return int.Parse(DefaultConnection.Instance.Query("SELECT COUNT(*) FROM "+ TABLE_NAME +";").Rows[0][0].ToString());
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM "+ TABLE_NAME +" WHERE [GROUP_NAME]=? OR [ID]=?", GroupName, Id);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO "+ TABLE_NAME +" ([ID],[GROUP_NAME],[GROUP_DESC]) VALUES (?,?,?)", GroupName,GroupDesc);
        }

        public void Select() {
            GroupDesc = "";
            DataTable table = DefaultConnection.Instance.Query("SELECT [ID],[GROUP_NAME],[GROUP_DESC] FROM "+ TABLE_NAME +" WHERE [GROUP_NAME]=? OR [ID]=?", GroupName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                GroupDesc = table.Rows[0]["GROUP_DESC"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE "+ TABLE_NAME +" SET [GROUP_DESC]=? , [GROUP_NAME]=? WHERE [ID]=?", GroupDesc, GroupName, Id);
        }

        public bool Validate() {
            return !GroupName.Trim().Equals("");
        }
    }
}
