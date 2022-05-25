namespace ApplicationCore.Models
{
    public class PurchaseModel
    {


        public int Id { get; set; }
        public int UserId { get; set; }

        public List<PurchaseRequestModel> Details { get; set; }
        public string PaymentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }


    }


}
