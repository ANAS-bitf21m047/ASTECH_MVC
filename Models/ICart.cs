namespace OKTECH.Models
{
    public interface ICart
    {
        public CartItems GetItem(int productId, string userId);
        public void Add(CartItems cartItem);
        public void Update(CartItems cartItem);
        public List<CartItems> GetItemsByUser(string userId);
        public void Remove(CartItems cartItem);
        }
}
