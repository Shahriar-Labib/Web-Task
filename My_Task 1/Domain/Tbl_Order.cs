namespace Domain
{
    public class Tbl_Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
