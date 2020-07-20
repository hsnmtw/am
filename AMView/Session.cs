using AMModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMView {
    public class Session {
        private static Session _instance = null;
        public static Session Instance { 
            get {
                if (_instance == null) _instance = new Session();
                return _instance;
            } 
        }
        private Session() {

        }
        public UserModel CurrentUser { get; set; }
    }
}
