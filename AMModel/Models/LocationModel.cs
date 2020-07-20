using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class LocationModel : IModel {
        
        public string LocationName { get; set; }
        public int Id { get; set; }

        public LocationModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[LOCATION_NAME] FROM LOCATIONS");
            var result = new LocationModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new LocationModel();
                result[i].LocationName = table.Rows[i]["LOCATION_NAME"].ToString();
                result[i].Id = int.Parse(table.Rows[i]["ID"].ToString());
            }
            return result;
        }

        public void Delete() {
            DefaultConnection.Instance.Execute("DELETE FROM LOCATIONS WHERE [ID]=?", Id);
        }

        public void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO LOCATIONS ([ID],[LOCATION_NAME]) VALUES (?,?)", Id, LocationName);
        }

        public void Select() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[LOCATION_NAME] FROM LOCATIONS WHERE [LOCATION_NAME]=? OR [ID]=?", LocationName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                LocationName = table.Rows[0]["LOCATION_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public void Update() {
            DefaultConnection.Instance.Execute("UPDATE LOCATIONS SET [LOCATION_NAME]=? WHERE [ID]=?", LocationName, Id);
        }

        public bool Validate() {
            return "".Equals(LocationName) == false;
        }
    }
}
