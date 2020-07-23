using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class RoomModel : AbstractModel {
        public string ROOM_NAME { get; set; }
        public string BUILDING_NAME { get; set; }
        public string LOCATION_NAME { get; set; }
        public override int ID { get; set; }
        public override string TABLE_NAME => "ROOMS";

        public RoomModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new RoomModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new RoomModel() {
                    ROOM_NAME     = table.Rows[i]["ROOM_NAME"].ToString(),
                    BUILDING_NAME = table.Rows[i]["BUILDING_NAME"].ToString(),
                    LOCATION_NAME = table.Rows[i]["LOCATION_NAME"].ToString()
                };
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (ROOM_NAME,BUILDING_NAME,LOCATION_NAME) VALUES (?,?,?)", ROOM_NAME,BUILDING_NAME,LOCATION_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE (ROOM_NAME=? AND BUILDING_NAME=? AND LOCATION_NAME=?) OR ID=?", ROOM_NAME, BUILDING_NAME, LOCATION_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                ROOM_NAME = table.Rows[0]["ROOM_NAME"].ToString();
                BUILDING_NAME = table.Rows[0]["BUILDING_NAME"].ToString();
                LOCATION_NAME = table.Rows[0]["LOCATION_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET ROOM_NAME=?, BUILDING_NAME=?, LOCATION_NAME=? WHERE ID=?", ROOM_NAME,BUILDING_NAME,LOCATION_NAME, ID);
        }

        public override bool Validate() {
            return "".Equals((BUILDING_NAME+"").Trim()) == false
                && "".Equals((LOCATION_NAME+"").Trim()) == false
                && "".Equals((ROOM_NAME + "").Trim()) == false;
        }
    }
}
