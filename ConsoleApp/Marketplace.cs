using Azure;
using ConsoleApp.DB;
using System.Drawing;

namespace ConsoleApp
{
    internal class Marketplace
    {
        private const string MARKETPLACE_NAME = "GMWOG||GG.MOW||WONGG";
        private User _user = null;
        private bool _isAnonymous => _user == null;
        public void Start()
        {
            do
            {
                Console.Clear();
            } while (MainPage());
        }
        private bool MainPage()
        {
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В " + MARKETPLACE_NAME);
            Console.WriteLine("");
            if (_isAnonymous)
            {
                Menu.Write("Войти", "Зарегестрироваться", "Посмотреть товары");
                Console.WriteLine("\n0. Назад");

                switch (Menu.Input(3, true))
                {
                    case Menu.Numbers.D1:
                        SignInPage();
                        break;
                    case Menu.Numbers.D2:
                        SignUpPage();
                        break;
                    case Menu.Numbers.D3:
                        ProductsPage();
                        break;
                    case Menu.Numbers.D0:
                        return false;
                }
            }
            else
            {
                Console.WriteLine($"Вы вошли как {_user.FirstName} {_user.LastName}\n");
                Menu.Write("Профиль", "Предыдущие заказы", "Корзина");
                Console.WriteLine("\n4. Посмотреть товары");
                Console.WriteLine("\n0. Выход");

                switch (Menu.Input(4, true))
                {
                    case Menu.Numbers.D1:
                        UserPage();
                        break;
                    case Menu.Numbers.D2:
                        OrdersHistoryPage();
                        break;
                    case Menu.Numbers.D3:
                        CartPage();
                        break;
                    case Menu.Numbers.D4:
                        ProductsPage();
                        break;
                    case Menu.Numbers.D0:
                        return false;
                }
            }

            return true;
        }
        private void ProductsPage()
        {
            Category selectedCategory = null;
            int pageNumber = 1;
            while (true)
            {
                List<Product> products = selectedCategory != null ? Core.Context.Products.Where(p => p.CategoryId == selectedCategory.CategoryId).ToList() : Core.Context.Products.ToList();
                int maxPageNumber = Convert.ToInt32(Math.Ceiling(products.Count / 6f));
                Console.Clear();
                Console.WriteLine("==ТОВАРЫ==");
                Console.WriteLine("1. Выбрать категорию");
                Console.WriteLine("Выбранная категория: " + (selectedCategory?.Name ?? "Все товары"));

                Console.WriteLine($"\n--СТРАНИЦА {pageNumber}--");
                WriteProducts(pageNumber, products);

                if (pageNumber > 1)
                    Console.WriteLine("\n8. Предыдущая страница");
                else
                    Console.WriteLine("\n");

                if (pageNumber < maxPageNumber)
                    Console.WriteLine("9. Следующая страница");
                else
                    Console.WriteLine("");
                Console.WriteLine("\n0. Выход");

                switch (Menu.Input(9, true))
                {
                    case Menu.Numbers.D1:
                        selectedCategory = SelectCategoryPage();
                        break;
                    case Menu.Numbers.D2:
                        ProductPage(products[0 + (pageNumber - 1)* 6]);
                        break;
                    case Menu.Numbers.D3:
                        ProductPage(products[1 + (pageNumber - 1) * 6]);
                        break;
                    case Menu.Numbers.D4:
                        ProductPage(products[2 + (pageNumber - 1) * 6]);
                        break;
                    case Menu.Numbers.D5:
                        ProductPage(products[3 + (pageNumber - 1) * 6]);
                        break;
                    case Menu.Numbers.D6:
                        ProductPage(products[4 + (pageNumber - 1) * 6]);
                        break;
                    case Menu.Numbers.D7:
                        ProductPage(products[5 + (pageNumber - 1) * 6]);
                        break;
                    case Menu.Numbers.D8:
                        if (pageNumber > 1)
                            pageNumber--;
                        break;
                    case Menu.Numbers.D9:
                        if (pageNumber < maxPageNumber)
                            pageNumber++;
                        break;
                    case Menu.Numbers.D0:
                        return;
                }
            }
        }
        private Category SelectCategoryPage()
        {
            List<Category> categories = Core.Context.Categories.ToList();
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(i + ". Все товары");
            foreach (Category category in categories)
            {
                i++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine(i + ". " + category.Name);
                Console.ResetColor();
                Console.WriteLine(category.Description);
            }

            switch (Menu.Input(categories.Count + 1))
            {
                case Menu.Numbers.D1:
                    return null;
                case Menu.Numbers.D2:
                    return categories[0];
                case Menu.Numbers.D3:
                    return categories[1];
                case Menu.Numbers.D4:
                    return categories[2];
                case Menu.Numbers.D5:
                    return categories[3];
                case Menu.Numbers.D6:
                    return categories[4];
                case Menu.Numbers.D7:
                    return categories[5];
                case Menu.Numbers.D8:
                    return categories[6];
                case Menu.Numbers.D9:
                    return categories[7];
            }

            return null;
        }
        private void ProductPage(Product product)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==ТОВАР==");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНазвание: ");
                Console.ResetColor();
                Console.WriteLine(product.Name);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nОписание: ");
                Console.ResetColor();
                Console.WriteLine(product.Description);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nЦена: ");
                Console.ResetColor();
                Console.WriteLine(product.Price);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nВ наличии: ");
                Console.ResetColor();
                Console.WriteLine(product.StockQuantity);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nКатегория: ");
                Console.ResetColor();
                Console.WriteLine(Core.Context.Categories.First(c => c.CategoryId == product.CategoryId).Name);

                Console.WriteLine("");
                if (_isAnonymous)
                    Console.WriteLine("");
                else
                    Console.WriteLine("1. Добавить в корзину");

                Console.WriteLine("\n0. Выход");
                switch (Menu.Input(1, true))
                {
                    case Menu.Numbers.D1:
                        if (_isAnonymous) continue;
                        else AddProductToCart(product);
                            break;
                    case Menu.Numbers.D0:
                        return;
                }
            }
        }
        private void OrdersHistoryPage()
        {

        }
        private void CartPage()
        {
            int pageNumber = 1;
            while (true)
            {
                List<CartItem> cartItems = Core.Context.CartItems.Where(c => c.UserId == _user.UserId).ToList();
                if (cartItems == null || cartItems.Count <= 0)
                {
                    Console.WriteLine("Корзина пуста");
                    Console.ReadKey(true);
                    return;
                }
                else
                {
                    int maxPageNumber = Convert.ToInt32(Math.Ceiling(cartItems.Count / 6f));
                    Console.Clear();
                    Console.WriteLine("==КОРЗИНА==\n");

                    Console.WriteLine($"\n--СТРАНИЦА {pageNumber}--");
                    WriteCartItems(pageNumber, cartItems);

                    if (pageNumber > 1)
                        Console.WriteLine("\n7. Предыдущая страница");
                    else
                        Console.WriteLine("\n");

                    if (pageNumber < maxPageNumber)
                        Console.WriteLine("8. Следующая страница");
                    else
                        Console.WriteLine("");


                    Console.WriteLine("\n9. Купить все товары");
                    Console.WriteLine("\n0. Выход");

                    switch (Menu.Input(9, true))
                    {
                        case Menu.Numbers.D1:
                            SelectCartItem(cartItems[0 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D2:
                            SelectCartItem(cartItems[1 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D3:
                            SelectCartItem(cartItems[2 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D4:
                            SelectCartItem(cartItems[3 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D5:
                            SelectCartItem(cartItems[4 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D6:
                            SelectCartItem(cartItems[5 + (pageNumber - 1) * 6]);
                            break;
                        case Menu.Numbers.D7:
                            if (pageNumber > 1)
                                pageNumber--;
                            break;
                        case Menu.Numbers.D8:
                            if (pageNumber < maxPageNumber)
                                pageNumber++;
                            break;
                        case Menu.Numbers.D9:
                            OrderPage(cartItems);
                            return;
                        case Menu.Numbers.D0:
                            return;
                    }
                }
            }
        }

        private void SelectCartItem(CartItem item)
        {
            Product product = Core.Context.Products.First(p => p.ProductId == item.ProductId);
            Console.Clear();
            Console.WriteLine("ТОВАР В КОРЗИНЕ\n");
            Console.Write("Название: ");
            Console.WriteLine(product.Name);
            Console.Write("Цена: ");
            Console.WriteLine(product.Price);
            Console.Write("Количество: ");
            Console.WriteLine(item.Quantity);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nИтоговая стоимость: " + item.Quantity * product.Price);
            Console.ResetColor();

            Console.WriteLine("\n1. Удалить из корзины");
            Console.WriteLine("2. Купить");
            Console.WriteLine("\n0. Выход");

            switch (Menu.Input(2, true))
            {
                case Menu.Numbers.D0:
                    return;
                case Menu.Numbers.D1:
                    {
                        Console.Clear();
                        Core.Context.CartItems.Remove(item);
                        Core.Context.SaveChanges();
                        Console.WriteLine("ТОВАР УСПЕШНО УДАЛЁН");
                        Console.ReadKey(true);
                        return;
                    }
                case Menu.Numbers.D2:
                    OrderPage(item);
                    break;
            }
            
        }

        private void OrderPage(params List<CartItem> items)
        {
            int pageNumber = 1;
            while (true)
            {
                int maxPageNumber = Convert.ToInt32(Math.Ceiling(items.Count / 6f));
                Console.Clear();
                Console.WriteLine("==ПОКУПКА ТОВАРОВ==");

                Console.WriteLine($"\n--СТРАНИЦА {pageNumber}--");
                WriteOrderItems(pageNumber, items);

                if (pageNumber > 1)
                    Console.WriteLine("\n7. Предыдущая страница");
                else
                    Console.WriteLine("\n");

                if (pageNumber < maxPageNumber)
                    Console.WriteLine("8. Следующая страница");
                else
                    Console.WriteLine("");

                decimal totalAmount = 0;
                foreach (CartItem item in items)
                {
                    totalAmount += item.Quantity * Core.Context.Products.First(p => p.ProductId == item.ProductId).Price;
                }
                Console.WriteLine("\nИтоговая стоимость: " + totalAmount);
                Console.WriteLine("9. Продолжить оформление заказа");
                Console.WriteLine("\n0. Выход");

                switch (Menu.Input(9, true))
                {
                    case Menu.Numbers.D1:
                    case Menu.Numbers.D2:
                    case Menu.Numbers.D3:
                    case Menu.Numbers.D4:
                    case Menu.Numbers.D5:
                    case Menu.Numbers.D6:
                        break;
                    case Menu.Numbers.D7:
                        if (pageNumber > 1)
                            pageNumber--;
                        break;
                    case Menu.Numbers.D8:
                        if (pageNumber < maxPageNumber)
                            pageNumber++;
                        break;
                    case Menu.Numbers.D9:
                        {
                            ExecuteOrder(totalAmount, items);
                        }
                        return;
                    case Menu.Numbers.D0:
                        return;
                }
            }
        }
        private void ExecuteOrder(decimal totalAmount, params List<CartItem> items)
        {
            PickupPoint point = null;
            while (true)
            {
                Console.WriteLine("1. Выбрать ПВЗ");
                Console.WriteLine("Выбранный ПВЗ: ");
                Console.WriteLine("Авдрес: " + (point?.Addres ?? "ПВЗ не выбран"));
                Console.WriteLine("Телефон: " + (point?.PhoneNumber ?? "ПВЗ не выбран"));

                Console.WriteLine("\nИтоговая сумма: " + totalAmount);
                if (point == null)
                {
                    Console.WriteLine("Чтобы оформить заказ выберите ПВЗ!");
                }
                else
                {
                    Console.WriteLine("2. Оформить заказ");
                }
                switch (Menu.Input(1, true))
                {
                    case Menu.Numbers.D0:
                        return;
                    case Menu.Numbers.D1:
                        point = ChoosePointPage();
                        break;
                    case Menu.Numbers.D2:
                        if (point != null)
                        {
                            CalculateOrder(totalAmount, point, items);
                            return;
                        }
                        else
                            break;
                }
            }
        }
        private void CalculateOrder(decimal totalAmount, PickupPoint point, params List<CartItem> items)
        {
            Order newOrder = new Order()
            {
                UserId = _user.UserId,
                PointId = point.PointId,
                TotalAmount = totalAmount,
                CreatedAt = DateTime.Now
            };
            Core.Context.Orders.Add(newOrder);

            foreach (CartItem item in items)
            {
                OrderItem newOrderItem = new OrderItem()
                {
                    OrderId = newOrder.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = Core.Context.Products.First(p => p.ProductId == item.ProductId).Price
                };
                Core.Context.OrderItems.Add(newOrderItem);
                Core.Context.CartItems.Remove(item);
            }

            Core.Context.SaveChanges();

            Console.WriteLine("Заказ успешно оформлен!!");
            Console.ReadKey(true);
        }
        private PickupPoint ChoosePointPage()
        {
            List<PickupPoint> points = Core.Context.PickupPoints.ToList();
            Console.WriteLine("ВЫБОР ПВЗ\n");
            int i = 1;
            foreach (PickupPoint point in points)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine(i + ". " + point.Addres);
                Console.ResetColor();
                Console.WriteLine(point.PhoneNumber);
                i++;
            }

            switch (Menu.Input(points.Count + 1))
            {
                case Menu.Numbers.D1:
                    return points[1];
                case Menu.Numbers.D2:
                    return points[2];
                case Menu.Numbers.D3:
                    return points[3];
                case Menu.Numbers.D4:
                    return points[4];
                case Menu.Numbers.D5:
                    return points[5];
                case Menu.Numbers.D6:
                    return points[6];
                case Menu.Numbers.D7:
                    return points[7];
                case Menu.Numbers.D8:
                    return points[8];
                case Menu.Numbers.D9:
                    return points[9];
            }

            return null;
        }
        private void WriteOrderItems(int page, List<CartItem> cartItems)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i + (page - 1) * 6 < cartItems.Count)
                {
                    CartItem item = cartItems[i + (page - 1) * 6];
                    Product product = Core.Context.Products.First(p => p.ProductId == item.ProductId);
                    Console.WriteLine($"{product.Name} - ({product.Price} руб. x {item.Quantity} шт.) = {product.Price * item.Quantity} руб.");
                }
                else
                    Console.WriteLine("");
            }
        }
        private void WriteCartItems(int page, List<CartItem> cartItems)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i + (page - 1) * 6 < cartItems.Count)
                {
                    CartItem item = cartItems[i + (page - 1) * 6];
                    Console.WriteLine($"{i + 1}. {Core.Context.Products.First(p => p.ProductId == item.ProductId).Name} - {item.Quantity} шт.");
                }
                else
                    Console.WriteLine("");
            }
        }
        private void AddProductToCart(Product product)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"В наличии: {product.StockQuantity}");
                Console.WriteLine("Введите количество товра для добавления (введите 0, если не хотите): ");
                string countStr = Console.ReadLine();
                if (int.TryParse(countStr, out int count))
                {
                    if (count == 0) return;
                    if (count <= 1)
                    {
                        Console.WriteLine("\nОшибка добавления в корзину!!");
                        Console.WriteLine("Число не может быть отрицательным.");
                        Console.ReadKey();
                        continue;
                    }
                    else if (count >= product.StockQuantity)
                    {
                        Console.WriteLine("\nОшибка добавления в корзину!!");
                        Console.WriteLine("Вы хотите добавить больше, чем есть на складе.");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        CartItem productItem = new CartItem()
                        {
                            Product = product,
                            Quantity = count,
                            User = _user,
                            AddedAt = DateTime.Now
                        };

                        Core.Context.CartItems.Add(productItem);
                        Core.Context.SaveChanges();

                        Console.WriteLine("Товар успешно добавлен в корзину!!");
                        Console.ReadKey();
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("\nОшибка добавления в корзину!!");
                    Console.WriteLine("Вы должны ввести число.");
                    Console.ReadKey();
                }
            }
        }
        private void UserPage()
        {
            Console.WriteLine("==ПРОФИЛЬ==\n");
            Console.WriteLine($"Имя: {_user.FirstName}");
            Console.WriteLine($"Фамиляи: {_user.LastName}");
            Console.WriteLine($"Логин: {_user.Username}");
            Console.WriteLine($"Почта: {_user.Email}");
            Console.WriteLine($"Аккаунт создан: {_user.CreatedAt}");

            Console.WriteLine("\nнажмите любую клавишу для выхода");
            Console.ReadKey(true);
        }
        private void WriteProducts(int page, List<Product> products)
        {

            for (int i = 0; i < 6; i++)
            {
                if (i + (page - 1) * 6 < products.Count)
                    Console.WriteLine($"{i + 2}. {products[i + (page - 1) * 6].Name}");
                else
                    Console.WriteLine("");
            }
        }
        private void SignInPage()
        {
            Console.WriteLine("==ВХОД==\n");
            Console.Write("Логин: ");
            string username = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            User user = Core.Context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВХОДА!!");
                Console.ResetColor();
                Console.WriteLine("Пользователь с таким логином не найден!");
            } 
            else if (user.Password != password)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВХОДА!!");
                Console.ResetColor();
                Console.WriteLine("Неверный пароль!");
            }
            else
            {
                _user = user;
            }
        }
        private void SignUpPage()
        {
            Console.WriteLine("==Регистрация==");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();
            Console.Write("Логин: ");
            string username = Console.ReadLine();
            Console.Write("Почта: ");
            string email = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            Console.Write("Повторите пароль: ");
            string repeatpassword = Console.ReadLine();

            if (password != repeatpassword)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА РЕГИСТРАЦИИ!!");
                Console.ResetColor();
                Console.WriteLine("Пароли не совпадают!");
            }
            else if (Core.Context.Users.Any(u => u.Username == username))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА РЕГИСТРАЦИИ!!");
                Console.ResetColor();
                Console.WriteLine("Пользователь с таким логином уже существует!!");
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("РЕГИСТРАЦИЯ ПРОШЛА УСПЕШНА!!");
                Console.ResetColor();

                User newUser = new User()
                {
                    Username = username,
                    FirstName = name,
                    LastName = surname,
                    Email = email,
                    Password = password,
                    CreatedAt = DateTime.Now,
                };

                _user = newUser;
                Core.Context.Users.Add(newUser);
                Core.Context.SaveChanges();

            }
            Console.ReadKey();
        }
    }
}
