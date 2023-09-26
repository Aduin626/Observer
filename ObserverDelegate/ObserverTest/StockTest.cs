using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib.ObserverLibTest
{
    // Используется атрибут [TestClass] для обозначения класса, содержащего тесты

    [TestClass]
    public class StockTests
    {
        // Тестовый метод для проверки события изменения цены акции

        [TestMethod]
        public void TestPriceChangeEvent()
         {
            // Раздел Arrange определяет начальное состояние объектов и переменных для теста
            var stock = new Stock("ABC", 100.0);
            var eventWasRaised = false;
            double newPrice = 120.0;
            string symbol = string.Empty;

            // Подписка на событие PriceChanged с использованием лямбда-выражения для проверки события
            stock.PriceChanged += (price, stockSymbol) =>
            {
                eventWasRaised = true;
                symbol = stockSymbol;
                Assert.AreEqual(newPrice, price);
            };

            // Раздел Act выполняет операцию, которую нужно протестировать
            stock.Price = newPrice;

            // Раздел Assert проверяет, что код выполнился правильно, проверяя состояния и значения объектов
            Assert.IsTrue(eventWasRaised, "Событие не было поднято");
            Assert.AreEqual("ABC", symbol, "Символ не соответствует");
        }
        // Тестовый метод для проверки события неизменной цены акции

        [TestMethod]
        public void TestPriceNotChangedEvent()
        {
            // Раздел Arrange определяет начальное состояние объектов и переменных для теста

            var stock = new Stock("ABC", 100.0);
            var eventWasRaised = false;

             // Подписка на событие PriceChanged с использованием лямбда-выражения
            stock.PriceChanged += (price, stockSymbol) =>
            {
                eventWasRaised = true;
            };

            // Раздел Act выполняет операцию, которую нужно протестировать
            stock.Price = 100.0;

            // Раздел Assert проверяет, что код выполнился правильно, проверяя состояния и значения объектов
            Assert.IsFalse(eventWasRaised, "Событие не должно было возникнуть");
        }
    }
}