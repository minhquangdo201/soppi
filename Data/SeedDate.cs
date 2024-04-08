using Microsoft.EntityFrameworkCore;
using soppi.Models;

namespace soppi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            AddCategories(serviceProvider);
            AddProducts(serviceProvider);
        }

        private static void AddCategories(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddRange(
                new Category
                {
                    Id = 1,
                    CategoryName = "Đồ chơi"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Quần áo"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Giày dép"
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Đồ gia dụng"
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Đồ điện tử"
                },
                new Category
                {
                    Id = 6,
                    CategoryName = "Đồ thể thao"
                }
            );
            context.SaveChanges();
        }
        private static void AddProducts(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Products.Any())
            {
                return;
            }
            context.Products.AddRange(
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Bóng đá",
                    Description = "Bóng đá",
                    Price = 100000,
                    Image = "https://file3.qdnd.vn/data/images/0/2022/11/14/vietcuong/1-%201.jpg?dpi=150&quality=100&w=870",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Áo bóng đá",
                    Description = "Áo bóng đá",
                    Price = 200000,
                    Image = "https://www.sport9.vn/images/thumbs/002/0021481_bo-quan-ao-bong-da-doi-tuyen-quoc-gia-duc-mau-xam.jpeg?preset=large&watermark=default",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Quần thể thao",
                    Description = "Quần thể thao",
                    Price = 150000,
                    Image = "https://cf.shopee.vn/file/ce3abaf6fd09b578fd1bcd3f023d0bd5",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Giày bóng đá",
                    Description = "Giày bóng đá",
                    Price = 300000,
                    Image = "https://pos.nvncdn.com/b0b717-26181/ps/20200703_FGNYnIKW9iFUVfhsWMkgyBPz.jpg",
                    Category = context.Categories.Find(6),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Giày sneaker",
                    Description = "Giày sneaker",
                    Price = 400000,
                    Image = "https://salt.tikicdn.com/cache/w1200/ts/product/65/3d/f7/a1ef28544ed76d91ecd1e4ee1826310d.jpg",
                    Category = context.Categories.Find(3),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Lego",
                    Description = "Đồ chơi lego",
                    Price = 500000,
                    Image = "https://www.mykingdom.com.vn/cdn/shop/files/e5444fd0985d2e00f7950fcc39f8e437.jpg?v=1706855111",
                    Category = context.Categories.Find(1),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Chổi lau nhà",
                    Description = "Chổi lau nhà",
                    Price = 600000,
                    Image = "https://bizweb.dktcdn.net/thumb/grande/100/425/687/products/choi-lau-nha-kangaroo-kg35sm-500x500.jpg?v=1698998460753",
                    Category = context.Categories.Find(4),
                    StockQuantity = 100,
                    User = context.Users.Find("4")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Iphone 14 Pro",
                    Description = "Iphone 14 Pro",
                    Price = 20000000,
                    Image = "https://mtstore.vn/wp-content/uploads/2016/03/220908113533-iphone-14-pro-256gb2.jpg",
                    Category = context.Categories.Find(5),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Hộp cầu lông Thành Công",
                    Description = "Hộp cầu lông Thành Công",
                    Price = 250000,
                    Image = "https://hvshop.vn/wp-content/uploads/2022/12/ong-cau-long-thanh-cong.jpg",
                    Category = context.Categories.Find(6),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Bóng rổ",
                    Description = "Bóng rổ",
                    Price = 100000,
                    Image = "https://contents.mediadecathlon.com/p2154428/8a29661a780b5f6bf01d2dd15efef451/p2154428.jpg",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Áo bóng rổ",
                    Description = "Áo bóng rổ",
                    Price = 200000,
                    Image = "https://giaybongro.vn/upload/img/3612_1507404077.jpg",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Quần thể thao",
                    Description = "Quần thể thao",
                    Price = 150000,
                    Image = "https://down-vn.img.susercontent.com/file/3ba824ff58a473fdf10abff053eeaa7d",
                    Category = context.Categories.Find(2),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Giày bóng rổ",
                    Description = "Giày bóng rổ",
                    Price = 300000,
                    Image = "https://neverstopshop.com/image/catalog/Nike-Jordan-37/Giay-bong-ro-Nike-Air-Jordan-37-Black-White-Red-co-cao-chuyen-indoor-outdoor-sfake-replica-1-1-chinh-hang-real-gia-re-HCM-NK2140-1.jpg",
                    Category = context.Categories.Find(6),
                    StockQuantity = 100,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Giày sneaker",
                    Description = "Giày sneaker",
                    Price = 400000,
                    Image = "https://giaysneaker.com.vn/public/media/giay-sneaker-mlb-chunky-liner-ny-trang-got-xanh-den-3_result.jpg",
                    Category = context.Categories.Find(3),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Bóng chuyền",
                    Description = "Bóng chuyền",
                    Price = 100000,
                    Image = "https://thethaominhphu.com/wp-content/uploads/2018/04/Qua-bong-chuyen-Thang-Long-thi-dau-VB7700-600x600.jpg",
                    Category = context.Categories.Find(2),
                    StockQuantity = 1750,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Áo bóng chuyền",
                    Description = "Áo bóng chuyền",
                    Price = 200000,
                    Image = "https://bulbal.vn/wp-content/uploads/2023/03/BO-QUAN-AO-BONG-CHUYEN-NU-BULBAL-AURA-TRANG-8-scaled.jpg",
                    Category = context.Categories.Find(2),
                    StockQuantity = 140,
                    User = context.Users.Find("3")
                },
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Iphone 15 Pro",
                    Description = "Iphone 15 Pro",
                    Price = 20000000,
                    Image = "https://cdn.hoanghamobile.com/i/preview/Uploads/2023/09/13/iphone-15-pro-white-titanium-pure-back-iphone-15-pro-white-titanium-pure-front-2up-screen-usen.png",
                    Category = context.Categories.Find(5),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                },
                // tivi
                new Product
                {
                    Id = new Guid(),
                    ProductName = "Tivi Samsung 43 inch 43T6500",
                    Description = "Tivi Samsung 43 inch 43T6500",
                    Price = 20000000,
                    Image = "https://cdn.mediamart.vn/images/product/smart-tivi-samsung-43-inch-43t6500-8SLPw5.png",
                    Category = context.Categories.Find(5),
                    StockQuantity = 100,
                    User = context.Users.Find("5")
                }

            );
            context.SaveChanges();

        }

    }
}