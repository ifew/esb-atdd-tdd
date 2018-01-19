using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("members")]
    public class Member
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fullname")]
        public string Fullname { get; set; }

        [Column("card_no")]
        public string Card_no { get; set; }

        [Column("personal_id")]
        public string Personal_id { get; set; }

        [Column("birthday")]
        public DateTime Birthday { get; set; }

        [Column("mobilephone")]
        public string Mobilephone { get; set; }

    }



}
