using Microsoft.AspNetCore.Identity;
using soppi.Models;

namespace soppi.Data {
    public class ApplicationUser : IdentityUser {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}