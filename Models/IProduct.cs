namespace OKTECH.Models
{
    public interface IProduct
    {
        public void Add(Product product);
        public Product detail(int ID);
        public Product Edit(int ID);
        public void Update(Product product);
        public void Remove(int ID);
        public List<Product> get(string categry);
        public IEnumerable<Product> GetAll();
        public Product GetItem(int ID);
        public int GetStockQuantity(int productId);
        public void UpdateStockQuantity(int productId, int newQuantity);
    }
}
