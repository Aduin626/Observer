using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverLib;
using System;
using System.IO;

namespace ObserverTest
{
    [TestClass]
    public class InvestorTests
    {
        // Используйте атрибут TestMethod для тестирования метода Update класса Investor

        [TestMethod]
        public void Update_ShouldPrintCorrectMessage()
        {
            // Arrange: Инициализация инвестора, цены, биржи и ожидаемого сообщения для сравнения
            Investor investor = new Investor("John");
            double price = 10.5;
            string burse = "NASDAQ";
            string expectedMessage = $"Цена акций биржи {burse} была изменена на {price} для John";

            // Перехватить стандартный вывод: Подмена стандартного вывода на StringWriter для проверки вывода
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act: Вызов метода Update и передача аргументов для дальнейшей проверки
                investor.Update(price, burse);

                // Assert: Сравнение фактического вывода с ожидаемым сообщением, чтобы убедиться в корректной работе метода Update
                Assert.AreEqual(expectedMessage, sw.ToString().Trim());
            }

            // Восстановить стандартный вывод: Возвращение стандартного вывода после завершения теста
            TextWriter originalOutput = Console.Out;
            Console.SetOut(originalOutput);
        }
    }

}