using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP_Lab18
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public DateTime Bdate { get; set; } = DateTime.Now;
        public string Date { get { return Bdate.ToShortDateString(); } }
        public Gender Gender { get; set; }
        public bool Cats { get; set; }
        public string Phone { get; set; }
    }
}
