using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class GroupModel : AbstractModel {
        public override int ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string GROUP_DESC { get; set; }

        public override string TABLE_NAME => "GROUPS";

        public GroupModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new GroupModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new GroupModel {
                    GROUP_NAME = table.Rows[i]["GROUP_NAME"].ToString(),
                    GROUP_DESC = table.Rows[i]["GROUP_DESC"].ToString(),
                    ID = int.Parse(table.Rows[i]["ID"].ToString())
                };
            }
            return result;
        }

        

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO "+ TABLE_NAME +" (GROUP_NAME,GROUP_DESC) VALUES (?,?)", GROUP_NAME,GROUP_DESC);
        }

        public override void Select() {
            
            DataTable table = DefaultConnection.Instance.Query("SELECT * FROM "+ TABLE_NAME +" WHERE ID=? OR GROUP_NAME=?", ID, GROUP_NAME);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                GROUP_DESC = table.Rows[0]["GROUP_DESC"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE "+ TABLE_NAME +" SET GROUP_DESC=? , GROUP_NAME=? WHERE ID=?", GROUP_DESC, GROUP_NAME, ID);
        }

        public override bool Validate() {
            return !GROUP_NAME.Trim().Equals("");
        }
    }
}
