using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public abstract class AbstractModel : IModel {
        public abstract int ID { get; set; }
        public abstract string TABLE_NAME { get; }
        public int Count() {
            return int.Parse(DefaultConnection.Instance.Query("SELECT COUNT(*) FROM " + TABLE_NAME + ";").Rows[0][0].ToString());
        }
        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM " + TABLE_NAME + " WHERE ID=?", ID);
        }

        public void Save() {
            if (ID < 1) Insert();
            else Update();
            Select();
        }

        public abstract void Insert();
        public abstract void Select();
        public abstract void Update();
        public abstract bool Validate();


        //protected string GetSelectStatementAll() {
        //    return string.Format("SELECT * FROM {0} ",TABLE_NAME);
        //}

        //protected string GetSelectStatement() {
        //    return string.Format("SELECT * FROM {0} WHERE ID=?", TABLE_NAME);
        //}

        //protected string GetInsertStatement() {
        //    string FIELDS = "";
        //    string VALUES = "";
        //    foreach (var pinfo in this.GetType().GetProperties()) {
        //        if (pinfo.Name.Equals("TABLE_NAME") || pinfo.Name.Equals("ID")) continue;
        //        FIELDS += string.Format("{0},", pinfo.Name);
        //        VALUES += "?,";
        //    }
        //    FIELDS = FIELDS.Substring(0, FIELDS.Length - 1);
        //    VALUES = VALUES.Substring(0, VALUES.Length - 1);
        //    return string.Format("INSERT INTO {0} ({1}) VALUES ({2})", TABLE_NAME, FIELDS, VALUES);
        //}

        //protected string GetUpdateStatement() {
        //    string FIELDS = "";
        //    foreach(var pinfo in this.GetType().GetProperties()) {
        //        if (pinfo.Name.Equals("TABLE_NAME") || pinfo.Name.Equals("ID")) continue;
        //        FIELDS += string.Format("{0}=?,",pinfo.Name);
        //    }
        //    FIELDS = FIELDS.Substring(0, FIELDS.Length - 1);
        //    return string.Format("UPDATE {0} SET {1} WHERE ID=?", TABLE_NAME, FIELDS);
        //}

        //protected string GetDeleteStatement() {
        //    return string.Format("DELETE FROM {0} WHERE ID=?", TABLE_NAME);
        //}

    }
}
