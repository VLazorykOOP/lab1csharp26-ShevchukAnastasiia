using System;

namespace Lab1Charp
{
    public class Program
    {
        public static void Main()
        {
            // Налаштування для коректного відображення української мови у консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n================ МЕНЮ ================");
                Console.WriteLine("1. Завд. 1.1 (Площа квадрата)");
                Console.WriteLine("2. Завд. 2.1 (Максимум двох чисел)");
                Console.WriteLine("3. Завд. 3.1 (Точка у фігурі)");
                Console.WriteLine("4. Завд. 4.2 (Дні до кінця місяця)");
                Console.WriteLine("5. Завд. 5.21 (Куб суми)");
                Console.WriteLine("6. Завд. 6.6 (Обчислення виразу)");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("======================================");
                Console.Write("Оберіть номер завдання: ");

                string choice = Console.ReadLine();
                Console.WriteLine(); // Порожній рядок для краси

                switch (choice)
                {
                    case "1": Task1_1(); break;
                    case "2": Task2_1(); break;
                    case "3": Task3_1(); break;
                    case "4": Task4_2(); break;
                    case "5": Task5_21(); break;
                    case "6": Task6_6(); break;
                    case "0":
                        Console.WriteLine("Роботу завершено. До побачення!");
                        return;
                    default:
                        Console.WriteLine("Помилка: Невірний пункт меню. Спробуйте ще раз.");
                        break;
                }
            }
        }

        // ================= ЗАВДАННЯ 1.1 =================
        public static void Task1_1()
        {
            Console.Write("Введіть периметр квадрата (a): ");
            if (double.TryParse(Console.ReadLine(), out double a) && a >= 0)
            {
                double side = a / 4.0;
                double area = side * side;
                Console.WriteLine($"Площа квадрата дорівнює: {area}");
            }
            else
            {
                Console.WriteLine("Помилка: Введіть коректне додатне число.");
            }
        }

        // ================= ЗАВДАННЯ 2.1 =================
        public static void Task2_1()
        {
            Console.Write("Введіть перше число: ");
            double.TryParse(Console.ReadLine(), out double num1);
            
            Console.Write("Введіть друге число: ");
            double.TryParse(Console.ReadLine(), out double num2);

            double max = Math.Max(num1, num2);
            Console.WriteLine($"Максимальне значення: {max}");
        }

        // ================= ЗАВДАННЯ 3.1 =================
        public static void Task3_1()
        {
            Console.Write("Введіть координату x: ");
            double.TryParse(Console.ReadLine(), out double x);
            
            Console.Write("Введіть координату y: ");
            double.TryParse(Console.ReadLine(), out double y);

            // Рівняння кола: x^2 + y^2 = R^2, де R = 9
            double radiusSquared = 81; 
            double value = x * x + y * y;

            // Використовуємо Math.Abs для порівняння дійсних чисел з похибкою
            bool onCircleBorder = Math.Abs(value - radiusSquared) < 0.001;
            bool onYAxisBorder = (x == 0 && y >= -9 && y <= 9);

            if (value < radiusSquared && x > 0)
            {
                Console.WriteLine("Результат: Так (всередині)");
            }
            else if ((onCircleBorder && x >= 0) || onYAxisBorder)
            {
                Console.WriteLine("Результат: На межі");
            }
            else
            {
                Console.WriteLine("Результат: Ні (поза областю)");
            }
        }

        // ================= ЗАВДАННЯ 4.2 =================
        public static void Task4_2()
        {
            Console.Write("Введіть порядковий номер дня поточного місяця: ");
            if (int.TryParse(Console.ReadLine(), out int day) && day > 0)
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int daysInMonth = DateTime.DaysInMonth(year, month);

                if (day <= daysInMonth)
                {
                    int remainingDays = daysInMonth - day;
                    Console.WriteLine($"До кінця місяця залишилося днів: {remainingDays}");
                }
                else
                {
                    Console.WriteLine($"Помилка: У поточному місяці лише {daysInMonth} днів.");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Введіть коректний день (ціле число більше нуля).");
            }
        }

        // ================= ЗАВДАННЯ 5.21 =================
        public static void Task5_21()
        {
            Console.Write("Введіть перше число: ");
            double.TryParse(Console.ReadLine(), out double a);
            
            Console.Write("Введіть друге число: ");
            double.TryParse(Console.ReadLine(), out double b);

            double result = CubeOfSum(a, b);
            Console.WriteLine($"Куб суми чисел ({a} + {b})^3 = {result}");
        }

        // Функція для завдання 5.21
        public static double CubeOfSum(double num1, double num2)
        {
            return Math.Pow(num1 + num2, 3);
        }

        // ================= ЗАВДАННЯ 6.6 =================
        public static void Task6_6()
        {
            Console.Write("Введіть значення x: ");
            double.TryParse(Console.ReadLine(), out double x);
            
            Console.Write("Введіть значення y: ");
            double.TryParse(Console.ReadLine(), out double y);

            // Обчислення виразу: x*y + (x + y^2 + 3) / (x^2 + 5)
            double numerator = x + Math.Pow(y, 2) + 3;
            double denominator = Math.Pow(x, 2) + 5;
            double result = (x * y) + (numerator / denominator);

            Console.WriteLine($"Результат виразу: {result}");
        }
    }
}