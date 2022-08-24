using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    [MetadataType(typeof(UserMasterData))]
   public partial class User
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }

    }
   [MetadataType(typeof(ProductMasterData))]
   public partial class ProductMasterData
   {
       [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
   }
}