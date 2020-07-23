using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMModel.Models {
    public class ProductTypeModel : AbstractModel {
        public override int ID { get; set; }
        public string PRODUCT_TYPE_NAME { get; set; }

        public override string TABLE_NAME => "PRODUCT_TYPES";

        public ProductTypeModel[] All() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + ";");
            var result = new ProductTypeModel[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++) {
                result[i] = new ProductTypeModel {
                    PRODUCT_TYPE_NAME = table.Rows[i]["PRODUCT_TYPE_NAME"].ToString(),
                    ID = int.Parse(table.Rows[i]["ID"].ToString())
                };
            }
            return result;
        }


        public override void Insert() {
            DefaultConnection.Instance.Execute("INSERT INTO " + TABLE_NAME + " (PRODUCT_TYPE_NAME) VALUES (?)", PRODUCT_TYPE_NAME);
        }

        public override void Select() {
            var table = DefaultConnection.Instance.Query("SELECT * FROM " + TABLE_NAME + " WHERE PRODUCT_TYPE_NAME=? OR ID=?", PRODUCT_TYPE_NAME, ID);
            if (table.Rows.Count == 1 && table.Columns.Count > 1) {
                PRODUCT_TYPE_NAME = table.Rows[0]["PRODUCT_TYPE_NAME"].ToString();
                ID = int.Parse(table.Rows[0]["ID"].ToString());
            }
        }

        public override void Update() {
            DefaultConnection.Instance.Execute("UPDATE " + TABLE_NAME + " SET PRODUCT_TYPE_NAME=? WHERE ID=?", PRODUCT_TYPE_NAME, ID);
        }

        public override bool Validate() {
            return !PRODUCT_TYPE_NAME.Trim().Equals("");
        }
    }
}
