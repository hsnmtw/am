using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class UserModel : AbstractModel {
        public override int ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PSWD { get; set; }
        public string GROUP_NAME { get; set; }
        public override string TABLE_NAME => "USERS";

        public UserModel() {

        }

        public UserModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new UserModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new UserModel() {
                    USER_NAME = table.Rows[i]["USER_NAME"].ToString()
                };
            }
            return result;
        }

        public bool Authenticate(string username, string password) {
            USER_NAME = username;
            Select();
            return USER_PSWD.Equals(password) && GROUP_NAME.Length > 0;
        }

        public override void Select() {
            USER_PSWD = "";
            GROUP_NAME = "";
            DataTable table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE (USER_NAME=?) OR ID=?", USER_NAME, ID);
            if(table.Rows.Count == 1 && table.Columns.Count > 1) {
                USER_PSWD  = table.Rows[0]["USER_PSWD"].ToString();
                GROUP_NAME = table.Rows[0]["GROUP_NAME"].ToString();
                ID         = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }


        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET USER_NAME=?, USER_PSWD=?, GROUP_NAME=? WHERE ID=?", USER_NAME, USER_PSWD,GROUP_NAME, ID);
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (USER_NAME,USER_PSWD,GROUP_NAME) values (?,?,?)",  USER_NAME, USER_PSWD, GROUP_NAME);
        }

        public override bool Validate() {
            return ! (USER_NAME .Trim().Equals("")
                ||    USER_PSWD .Trim().Equals("")
                ||    GROUP_NAME.Trim().Equals(""));
        }
    }
}
