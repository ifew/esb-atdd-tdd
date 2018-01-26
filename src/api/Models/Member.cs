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
        [Required(ErrorMessage = "กรุณาระบุหมายเลขบัตรยูเมะพลัสค่ะ")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "หมายเลขบัตรยูเมะพลัสไม่ถูกต้อง กรุณาระบุ 16 หลักค่ะ")]
        public string Card_no { get; set; }

        [Column("personal_id")]
        [Required(ErrorMessage = "กรุณาระบุหมายเลขบัตรประชาชนค่ะ")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "หมายเลขบัตรประชาชนไม่ถูกต้อง กรุณาระบุ 13 หลักค่ะ")]
        public string Personal_id { get; set; }

        [Column("birthday")]
        [Required(ErrorMessage = "กรุณาระบุวันเดือนปีเกิดค่ะ")]
        public DateTime Birthday { get; set; }

        [Column("mobilephone")]
        [Required(ErrorMessage = "กรุณาระบุหมายเลขเบอร์โทรศัพท์ค่ะ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "หมายเลขเบอร์โทรศัพท์ไม่ถูกต้อง กรณาระบุ 10 หลัก ขึ้นต้นด้วย 08")]
        public string Mobilephone { get; set; }

    }



}
