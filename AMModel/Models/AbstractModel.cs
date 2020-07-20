using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public abstract class AbstractModel : IModel {
        public abstract int Id { get; set; }
        public abstract string TABLE_NAME { get; }
        public int Count() {
            return int.Parse(DefaultConnection.Instance.Query("SELECT COUNT(*) FROM " + TABLE_NAME + ";").Rows[0][0].ToString());
        }
        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM " + TABLE_NAME + " WHERE [ID]=?", Id);
        }

        public abstract void Insert();
        public abstract void Select();
        public abstract void Update();
        public abstract bool Validate();
    }
}
