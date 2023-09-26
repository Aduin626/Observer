using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ObserverTest
{
    // Класс для тестирования функционала Observer

    [TestClass]
    public class ObserverTests
    {
        // Тестирование метода OnPriceChanged функции наблюдателя
        // для корректной работы с допустимым символом акции
        [TestMethod]
        public void OnPriceChanged_ValidStockSymbol_PrintsPriceChangeInfo()
        {
            // Arrange
            // Создаем экземпляры наблюдателя и акций с передачей допустимого символа акции и начальной цены
            var observer = new Observer();
            var stock = new Stock("AAPL", 150.0);
            var args = new EventArgs();
            // Создаем объект StringWriter для перехвата вывода консоли
            var consoleOutput = new StringWriter();


            // Act
            // Перехватываем вывод консоли, вызываем метод OnPriceChanged и записываем вывод в переменную output
            Console.SetOut(consoleOutput);
            observer.OnPriceChanged(stock, args);
            var output = consoleOutput.ToString();


            // Assert
            // Проверяем, содержит ли вывод сообщение об изменении цены акций указанного предприятия
            Assert.IsTrue(output.Contains("Предприятие AAPL цена акций изменена на 150"));
        }
    }

}