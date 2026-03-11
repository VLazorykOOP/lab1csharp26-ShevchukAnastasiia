using System;
using System.IO;
using Xunit;
// Не забудь додати using твого основного проєкту, якщо він в іншому просторі імен
using Lab1Charp; 

namespace Lab1Charp.Tests
{
    public class ProgramTests
    {
        // Допоміжний метод для підміни введення/виведення консолі
        private string RunWithConsoleMock(Action taskAction, string input)
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            using var stringWriter = new StringWriter();
            using var stringReader = new StringReader(input);
            
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            try
            {
                taskAction();
                return stringWriter.ToString();
            }
            finally
            {
                // Повертаємо консоль до нормального стану
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [Fact]
        public void Task1_1_ValidPerimeter_CalculatesAreaCorrectly()
        {
            // Arrange (Підготовка): периметр 16 (сторона 4, площа 16)
            string input = "16\n";

            // Act (Дія)
            string output = RunWithConsoleMock(Program.Task1_1, input);

            // Assert (Перевірка)
            Assert.Contains("Площа квадрата дорівнює: 16", output);
        }

        [Fact]
        public void Task1_1_NegativePerimeter_ShowsError()
        {
            string output = RunWithConsoleMock(Program.Task1_1, "-5\n");
            Assert.Contains("Помилка", output);
        }

        [Fact]
        public void Task2_1_TwoNumbers_ReturnsMax()
        {
            // Передаємо 10 та 25 (кожен з нового рядка)
            string input = "10\n25\n"; 
            string output = RunWithConsoleMock(Program.Task2_1, input);
            Assert.Contains("Максимальне значення: 25", output);
        }

        [Theory] // Theory дозволяє запустити один тест з різними параметрами
        [InlineData("5", "0", "Так (всередині)")]  // Точка всередині
        [InlineData("9", "0", "На межі")]          // Точка на межі кола
        [InlineData("10", "10", "Ні (поза областю)")] // Точка далеко за межами
        public void Task3_1_VariousPoints_ChecksPositionCorrectly(string x, string y, string expectedResult)
        {
            string input = $"{x}\n{y}\n";
            string output = RunWithConsoleMock(Program.Task3_1, input);
            Assert.Contains(expectedResult, output);
        }

        [Fact]
        public void Task4_2_ValidDay_CalculatesRemainingDays()
        {
            int currentDay = 15;
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int expectedRemaining = daysInMonth - currentDay;

            string input = $"{currentDay}\n";
            string output = RunWithConsoleMock(Program.Task4_2, input);

            Assert.Contains($"До кінця місяця залишилося днів: {expectedRemaining}", output);
        }

        [Fact]
        public void CubeOfSum_TwoNumbers_CalculatesCorrectly()
        {
            // Оскільки ти виніс логіку в окремий метод CubeOfSum, 
            // ми можемо тестувати його безпосередньо, без милиць із консоллю!
            // (2 + 3)^3 = 125
            
            double result = Program.CubeOfSum(2, 3);
            
            Assert.Equal(125, result);
        }

        [Fact]
        public void Task6_6_ValidInputs_CalculatesExpression()
        {
            // Для x = 2, y = 3
            // Вираз: x*y + (x + y^2 + 3) / (x^2 + 5)
            // 2*3 + (2 + 9 + 3) / (4 + 5) = 6 + 14/9 ≈ 7.5555...
            
            string input = "2\n3\n";
            string output = RunWithConsoleMock(Program.Task6_6, input);
            
            // Оскільки це double, перевіряємо, чи є частина результату у виводі
            Assert.Contains("7,555", output.Replace(".", ",")); // Враховуємо можливі налаштування локалі (кома чи крапка)
        }
    }
}