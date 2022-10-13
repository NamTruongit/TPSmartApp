using System;

namespace TPApi.Entites
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string NativePlace { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public string PassWord { get; set; }
    }
}
