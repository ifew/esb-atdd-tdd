using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("um_tb21_zipcode")]
    public class Zipcode
    {
        public int PROVINCE_CODE { get; set; }
        public int AMPHUR_CODE { get; set; }
        public int TAMBOL_CODE { get; set; }
        public int ZIP_CODE { get; set; }
        public string REGION_CODE { get; set; }
        public string THAI_DESCRIPTION { get; set; }
        public string FILLER { get; set; }
        public string STATUS { get; set; }

    }



}
