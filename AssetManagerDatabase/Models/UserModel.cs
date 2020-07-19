using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class UserModel : IModel {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPswd { get; set; }
        public string GroupName { get; set; }

        
        public UserModel() {

        }

        public UserModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [USER_NAME],[USER_PSWD],[GROUP_NAME] FROM USERS");
            var result = new UserModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new UserModel();
                result[i].UserName = table.Rows[i]["USER_NAME"].ToString();
            }
            return result;
        }

        public bool Authenticate(string username, string password) {
            UserName = username;
            Select();
            return UserPswd.Equals(password) && GroupName.Length > 0;
        }

        public void Select() {
            UserPswd = "";
            GroupName = "";
            DataTable table = DefaultConnection.Instance.Query("SELECT [USER_PSWD],[GROUP_NAME] FROM USERS WHERE [USER_NAME]=?", UserName);
            if(table.Rows.Count == 1 && table.Columns.Count > 1) {
                UserPswd = table.Rows[0]["USER_PSWD"].ToString();
                GroupName = table.Rows[0]["GROUP_NAME"].ToString();
            }
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM USERS WHERE [USER_NAME]=?",UserName);
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE USERS SET [USER_PSWD]=?,[GROUP_NAME]=? WHERE [USER_NAME]=?", UserPswd,GroupName, UserName);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO USERS ([USER_NAME],[USER_PSWD],[GROUP_NAME]) values (?,?,?)", UserName, UserPswd, GroupName);
        }

        public bool Validate() {
            return ! (UserName.Trim().Equals("")
                || UserPswd.Trim().Equals("")
                || GroupName.Trim().Equals(""));
        }
    }
}
