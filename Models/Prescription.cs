namespace Walgreens.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public required string MedicationName { get; set; }

        public required string FillStatus { get; set; }

        public decimal Cost { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
