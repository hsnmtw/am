using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class BuildingModel : AbstractModel {
        
        public string BUILDING_NAME { get; set; }
        public string LOCATION_NAME { get; set; }
        public override int ID { get; set; }
        public override string TABLE_NAME => "BUILDINGS";

        public BuildingModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new BuildingModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new BuildingModel() {
                    BUILDING_NAME = table.Rows[i]["BUILDING_NAME"].ToString(),
                    LOCATION_NAME = table.Rows[i]["LOCATION_NAME"].ToString()
                };
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (BUILDING_NAME,LOCATION_NAME) VALUES (?,?)", BUILDING_NAME,LOCATION_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE (LOCATION_NAME=? AND BUILDING_NAME=?) OR ID=?", LOCATION_NAME,BUILDING_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                BUILDING_NAME = table.Rows[0]["BUILDING_NAME"].ToString();
                LOCATION_NAME = table.Rows[0]["LOCATION_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET BUILDING_NAME=?, LOCATION_NAME=? WHERE ID=?", BUILDING_NAME,LOCATION_NAME, ID);
        }

        public override bool Validate() {
            return "".Equals((BUILDING_NAME+"").Trim()) == false
                && "".Equals((LOCATION_NAME+"").Trim()) == false;
        }
    }
}
