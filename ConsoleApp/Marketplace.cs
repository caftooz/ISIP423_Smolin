using ConsoleApp.DB;

namespace ConsoleApp
{
    internal class Marketplace
    {
        private const string NAME = "GMWOG||GG.MOW||WONGG";
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
                Console.WriteLine("\n4. Товары");
                Console.WriteLine("\n0. Выход");

                switch (Menu.Input(4, true))
                {
                    case Menu.Numbers.D1:
                        UserPage();
                        break;
                    case Menu.Numbers.D2:
                        OrdersPage();
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
                Console.WriteLine("\nКатегория");
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
                        if(_isAnonymous) continue;
                        break;
                    case Menu.Numbers.D0:
                        return;
                }
            }
        }
        private void OrdersPage()
        {

        }
        private void CartPage()
        {

        }
        private void UserPage()
        {

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
            Console.WriteLine("==ВХОД==");
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
