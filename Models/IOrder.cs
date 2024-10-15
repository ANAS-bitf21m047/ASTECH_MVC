namespace OKTECH.Models
{
    public interface IOrder
    {
        public void Add(OrderDetail o);
        public OrderDetail getOrder(int id);
        public List<CartItems> getOrderProducts(string id);
        public void AddOrderProduct(List<OrderProduct> product);
        public void deleteCartItems(string userId);
    }
}
