namespace webapi_tokenauth.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Img { get; set; }
        // public string Pic => string.IsNullOrEmpty(Img) ? "/img/no-image.png" : "/" + Img;

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
