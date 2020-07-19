using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class LocationModel : IModel {
        
        public string LocationName { get; set; }
        public int Id { get; set; }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM LOCATIONS WHERE Id=?",Id);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO LOCATIONS (LOCATION_NAME) VALUES (?)", LocationName);
        }

        public void Select() {
            throw new NotImplementedException();
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE LOCATIONS SET LOCATION_NAME=? WHERE Id=?", LocationName, Id);
        }

        public bool Validate() {
            return "".Equals(LocationName) == false;
        }
    }
}
