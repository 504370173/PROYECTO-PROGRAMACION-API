namespace DataAccess.Entities.RequestObjects
{
    public class AcademicFormationVM
    {
        public string institution { get; set; }
        public string degree { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int candidateId { get; set; }

    }
}
