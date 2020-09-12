using System.Collections.Generic;

namespace webapi_tokenauth.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ParentId { get; set; } = 0;
        public bool HaveChild { get; set; } = false;

        public string Img { get; set; }
        // public string Pic => string.IsNullOrEmpty(Img) ? "/img/no-image.png" : "/" + Img;

        public virtual IList<Product> Products { get; set; }
    }
}
