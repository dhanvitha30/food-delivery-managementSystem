namespace FoodDelivery.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }

        public int MenuItemId { get; set; }

        public int Quantity { get; set; }
    }
}