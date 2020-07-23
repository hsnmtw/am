using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class ManufacturerModel : AbstractModel {
        public override int ID { get; set; }
        public string MANUFACTURER_NAME { get; set; }

        public override string TABLE_NAME => "MANUFACTURERS";

        public ManufacturerModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new ManufacturerModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new ManufacturerModel {
                    MANUFACTURER_NAME = table.Rows[i]["MANUFACTURER_NAME"].ToString(),
                    ID = int.Parse(table.Rows[i]["ID"].ToString())
                };
            }
            return result;
        }


        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (MANUFACTURER_NAME) VALUES (?)", MANUFACTURER_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE MANUFACTURER_NAME=? OR ID=?", MANUFACTURER_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                MANUFACTURER_NAME = table.Rows[0]["MANUFACTURER_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET MANUFACTURER_NAME=? WHERE ID=?", MANUFACTURER_NAME, ID);
        }

        public override bool Validate() {
            return !MANUFACTURER_NAME.Trim().Equals("");
        }
    }
}
