namespace MusicShop.ServiceLayer.DTOs
{
    public class CartItemDto
    {
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
    }
}
