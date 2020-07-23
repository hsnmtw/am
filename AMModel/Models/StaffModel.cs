using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class StaffModel : AbstractModel {
        public string STAFF_NAME { get; set; }
        public string STAFF_EMAIL { get; set; }
        public string STAFF_CONTACT { get; set; }
        public string ROOM_NAME { get; set; }
        public string BUILDING_NAME { get; set; }
        public string LOCATION_NAME { get; set; }
        public override int ID { get; set; }
        public override string TABLE_NAME => "STAFF";

        public StaffModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new StaffModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new StaffModel() {
                    STAFF_NAME    = table.Rows[i]["STAFF_NAME"].ToString(),
                    STAFF_EMAIL   = table.Rows[i]["STAFF_EMAIL"].ToString(),
                    STAFF_CONTACT = table.Rows[i]["STAFF_CONTACT"].ToString(),
                    ROOM_NAME     = table.Rows[i]["ROOM_NAME"].ToString(),
                    BUILDING_NAME = table.Rows[i]["BUILDING_NAME"].ToString(),
                    LOCATION_NAME = table.Rows[i]["LOCATION_NAME"].ToString()
                };
            }
            return result;
        }

        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (STAFF_NAME,STAFF_EMAIL,STAFF_CONTACT,ROOM_NAME,BUILDING_NAME,LOCATION_NAME) VALUES (?,?,?,?,?,?)", STAFF_NAME, STAFF_EMAIL, STAFF_CONTACT, ROOM_NAME, BUILDING_NAME, LOCATION_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE (STAFF_EMAIL=?) OR ID=?", STAFF_EMAIL, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                ROOM_NAME     = table.Rows[0]["ROOM_NAME"].ToString();
                BUILDING_NAME = table.Rows[0]["BUILDING_NAME"].ToString();
                LOCATION_NAME = table.Rows[0]["LOCATION_NAME"].ToString();
                STAFF_NAME    = table.Rows[0]["STAFF_NAME"].ToString();
                STAFF_EMAIL   = table.Rows[0]["STAFF_EMAIL"].ToString();
                STAFF_CONTACT = table.Rows[0]["STAFF_CONTACT"].ToString();
                ID            = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + @" SET 
             STAFF_NAME=?
           , STAFF_EMAIL=?
           , STAFF_CONTACT=? 
           , ROOM_NAME=?
           , BUILDING_NAME=?
           , LOCATION_NAME=? 
           WHERE ID=?", STAFF_NAME, STAFF_EMAIL, STAFF_CONTACT, ROOM_NAME,BUILDING_NAME,LOCATION_NAME, ID);
        }

        public override bool Validate() {
            return "".Equals((BUILDING_NAME + "").Trim()) == false
                && "".Equals((LOCATION_NAME + "").Trim()) == false
                && "".Equals((ROOM_NAME     + "").Trim()) == false
                && "".Equals((STAFF_NAME    + "").Trim()) == false
                && "".Equals((STAFF_CONTACT + "").Trim()) == false
                && "".Equals((STAFF_EMAIL   + "").Trim()) == false;
        }
    }
}
