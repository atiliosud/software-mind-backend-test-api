using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndTest.Domain.TestDatabase
{

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [JsonIgnore]
        public Department Department { get; set; }
        public DateTime HireDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
    }
}
