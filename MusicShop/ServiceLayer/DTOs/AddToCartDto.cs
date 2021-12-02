namespace MusicShop.ServiceLayer.DTOs
{
    public class AddToCartDto
    {
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
    }
}
