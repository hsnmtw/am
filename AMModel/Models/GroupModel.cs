using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupModel : AbstractModel {
        public override int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }

        public override string TABLE_NAME => "[GROUPS]";

        public GroupModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[GROUP_NAME],[GROUP_DESC] FROM " + TABLE_NAME + ";");
            var result = new GroupModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupModel {
                    GroupName = table.Rows[i]["GROUP_NAME"].ToString(),
                    GroupDesc = table.Rows[i]["GROUP_DESC"].ToString(),
                    Id = int.Parse(table.Rows[i]["ID"].ToString())
                };
            }
            return result;
        }

        

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO "+ TABLE_NAME +" ([GROUP_NAME],[GROUP_DESC]) VALUES (?,?)", GroupName,GroupDesc);
        }

        public override void Select() {
            
            DataTable table = DefaultConnection.Instance.Query("SELECT [ID],[GROUP_NAME],[GROUP_DESC] FROM "+ TABLE_NAME +" WHERE [ID]=?", Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                GroupDesc = table.Rows[0]["GROUP_DESC"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE "+ TABLE_NAME +" SET [GROUP_DESC]=? , [GROUP_NAME]=? WHERE [ID]=?", GroupDesc, GroupName, Id);
        }

        public override bool Validate() {
            return !GroupName.Trim().Equals("");
        }
    }
}
