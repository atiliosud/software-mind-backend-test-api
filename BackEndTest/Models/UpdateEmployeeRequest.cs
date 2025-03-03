namespace BackEndTest.Models
{
    public class UpdateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
