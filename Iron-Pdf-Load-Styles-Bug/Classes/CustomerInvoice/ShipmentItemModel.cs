using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPdfConsoleApp.Classes.CustomerInvoice
{
    public class ShipmentItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PieceCount { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string NMFC { get; set; }

        public string DimensionsFormatted
        {
            get
            {
                return $"{Length}\" x {Width}\" x {Height}\"";
            }
        }
        public string WeightFormatted
        {
            get
            {
                return $"{Weight} lbs";
            }
        }
        public string TypeHumanized { get; set; }
        public string FreightClassHumanized { get; set; }
    }
}
