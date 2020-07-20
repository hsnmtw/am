using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class LocationModel : AbstractModel {
        
        public string LocationName { get; set; }
        public override int Id { get; set; }
        public override string TABLE_NAME => "[LOCATIONS]";

        public LocationModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[LOCATION_NAME] FROM " + TABLE_NAME + ";");
            var result = new LocationModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new LocationModel() {
                    LocationName = table.Rows[i]["LOCATION_NAME"].ToString()
                };
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " ([LOCATION_NAME]) VALUES (?)", LocationName);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT [ID],[LOCATION_NAME] FROM " + TABLE_NAME + " WHERE [LOCATION_NAME]=? OR [ID]=?", LocationName, Id);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                LocationName = table.Rows[0]["LOCATION_NAME"].ToString();
                Id = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET [LOCATION_NAME]=? WHERE [ID]=?", LocationName, Id);
        }

        public override bool Validate() {
            return "".Equals(LocationName) == false;
        }
    }
}
