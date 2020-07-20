using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class UserModel : AbstractModel {
        public override int Id { get; set; }
        public string UserName { get; set; }
        public string UserPswd { get; set; }
        public string GroupName { get; set; }
        public override string TABLE_NAME => "[USERS]";

        public UserModel() {

        }

        public UserModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[USER_NAME],[USER_PSWD],[GROUP_NAME] FROM " + TABLE_NAME + ";");
            var result = new UserModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new UserModel() {
                    UserName = table.Rows[i]["USER_NAME"].ToString()
                };
            }
            return result;
        }

        public bool Authenticate(string username, string password) {
            UserName = username;
            Select();
            return UserPswd.Equals(password) && GroupName.Length > 0;
        }

        public override void Select() {
            UserPswd = "";
            GroupName = "";
            DataTable table = DefaultConnection.Instance.Query("SELECT [ID],[USER_PSWD],[GROUP_NAME] FROM " + TABLE_NAME + " WHERE [USER_NAME]=?", UserName);
            if(table.Rows.Count == 1 && table.Columns.Count > 1) {
                UserPswd = table.Rows[0]["USER_PSWD"].ToString();
                GroupName = table.Rows[0]["GROUP_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }


        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET [USER_NAME]=?,[USER_PSWD]=?,[GROUP_NAME]=? WHERE [ID]=?", UserName, UserPswd,GroupName, Id);
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " ([USER_NAME],[USER_PSWD],[GROUP_NAME]) values (?,?,?)",  UserName, UserPswd, GroupName);
        }

        public override bool Validate() {
            return ! (UserName.Trim().Equals("")
                || UserPswd.Trim().Equals("")
                || GroupName.Trim().Equals(""));
        }
    }
}
