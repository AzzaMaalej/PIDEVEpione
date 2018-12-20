using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum AssetType
    {
        credit,
        loan,
        material,
        room,
        other
    }
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public AssetType AssetType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime SaleDate { get; set; }
        public double Value { get; set; }
        public int Office_Id { get; set; }
        [ForeignKey("Office_Id")]
        public virtual MedicalOffice MedicalOffice { get; set; }

    }
}
