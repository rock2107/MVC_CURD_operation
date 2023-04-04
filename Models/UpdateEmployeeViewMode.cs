using Microsoft.AspNetCore.Mvc;

namespace ASPWEBAPP.Models
{
    public class updateviewmodel 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DOB { get; set; }

        public string Department { get; set; }

    }
}
