# Web bán hàng online Soppi

## 1. Giới thiệu chung:
**Tổng quan:** Soppi là một ứng dụng web cho phép người dùng mua và bán hàng trực tuyến trực tiếp tại đây.  
**Các công nghệ được sử dụng:**
- ASP.NET MVC
- Entity Framework Core
- MySQL
- Toast Notification
- AspNetCore Identity

## 2. Chức năng chính:
Soppi được chia thành ba quyền chính là Admin, User và Shop, mỗi quyền sẽ tương ứng với một Area và có các chức năng khác nhau.

### Chức năng chung:
- Đăng ký
- Đăng nhập

### Admin:
**Chức năng:**
- Hiển thị danh sách, thêm, sửa các Danh mục (Category).
- Hiển thị danh sách, sửa các User khác.  
**View:**
- Home: Hiển thị tổng số lượng về User và Category
- Category: Hiển thị danh sách Category
- Account: Hiển thị danh sách tài khoản và thông tin người dùng

### User:
**Chức năng:**
- Hiển thị danh sách sản phẩm (Product)
- Hiển thị các sản phẩm theo danh mục
- Mua hàng
- Quản lý và hủy đơn hàng đã đặt
- Tìm kiếm theo tên sản phẩm  
**View:**
- Home: Hiển thị các sản phẩm có thể mua
- Product/Detail: Hiển thị chi tiết sản phẩm
- Category/CategoryProducts: Hiển thị các sản phẩm theo danh mục
- Order: Hiển thị các đơn hàng đã đặt

### Shop:
**Chức năng:**
- Hiển thị tổng số lượng về sản phẩm và đơn hàng của Shop
- Hiển thị danh sách, thêm, sửa, xóa sản phẩm
- Hiển thị danh sách đơn hàng
- Thay đổi trạng thái đơn hàng  
**View:**
- Home: Hiển thị tổng số lượng về sản phẩm và đơn hàng
- Product: Hiển thị danh sách các sản phẩm
- Product/Detail: Hiển thị chi tiết, chỉnh sửa, xóa sản phẩm
- Order: Hiển thị danh sách các đơn hàng
- Order/Detail: Hiển thị chi tiết và chỉnh sửa trạng thái đơn hàng

## 3. Hướng dẫn sử dụng
1. Clone project theo đường link Github.
2. Tạo Migration và update database.
3. Có 5 tài khoản đã được tạo sẵn bao gồm:
   - admin (password: admin1234) - Role: Admin
   - user (password: user1234) - Role: User
   - user1 (password: user1234) - Role: User
   - shop (password: shop1234) - Role: Shop
   - shop1 (password: shop1234) - Role: Shop  
   Đăng nhập vào các tài khoản có Role khác nhau sẽ dẫn tới các Area tương ứng với mỗi Role đó.
