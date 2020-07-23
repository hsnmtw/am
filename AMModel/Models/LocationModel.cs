using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class LocationModel : AbstractModel {
        
        public string LOCATION_NAME { get; set; }
        public override int ID { get; set; }
        public override string TABLE_NAME => "LOCATIONS";

        public LocationModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new LocationModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new LocationModel() {
                    LOCATION_NAME = table.Rows[i]["LOCATION_NAME"].ToString()
                };
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (LOCATION_NAME) VALUES (?)", LOCATION_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE LOCATION_NAME=? OR ID=?", LOCATION_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                LOCATION_NAME = table.Rows[0]["LOCATION_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET LOCATION_NAME=? WHERE ID=?", LOCATION_NAME, ID);
        }

        public override bool Validate() {
            return "".Equals(LOCATION_NAME) == false;
        }
    }
}
