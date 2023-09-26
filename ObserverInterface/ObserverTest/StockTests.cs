using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    [TestClass]
    public class StockTests
    {
        // Вспомогательный класс для тестирования, реализует интерфейс
        public class TestObserver : IObserver
        {
            // Свойство для хранения последней цены

            public double LastPrice { get; private set; }
            // Свойство для хранения последнего имени биржи

            public string LastBurse { get; private set; }
            // Реализация метода Update интерфейса IObserver

            public void Update(double price, string burse)
            {
                LastPrice = price;
                LastBurse = burse;
            }
        }
        // Тест на добавление наблюдателя

        [TestMethod]
        public void AddObserverTest()
        {
            // Arrange
            //Создайте новый объект Stock с начальной ценой 100,0 и именем «Burse1».
            var stock = new Stock(100.0, "Burse1");
            var observer = new TestObserver();

            // Act
            // Добавляем наблюдателя в список наблюдателей стандартного объекта.
            stock.AddObserver(observer);

            // Assert
            // Используйте отражение, чтобы получить закрытое поле «наблюдатели» из класса Stock.
            FieldInfo observersField = typeof(Stock).GetField("observers", BindingFlags.Instance | BindingFlags.NonPublic);
            // Получаем значение поля "наблюдатели" для стандартного объекта и приводим его к соответствующему типу (List<IObserver>).
            var observers = (List<IObserver>)observersField.GetValue(stock);

            // Подтверждение, что наблюдатель был успешно добавлен в список наблюдателей, проверив, содержит ли список «наблюдатели» объект наблюдателя
            Assert.IsTrue(observers.Contains(observer));
        }

        // Тест на удаление наблюдателя

        [TestMethod]
        public void RemoveObserverTest()
        {
            // Arrange
            // Создаем новый экземпляр класса Stock с начальной ценой 100 и именем "Burse1"
            var stock = new Stock(100.0, "Burse1");
            // Создаем тестовый наблюдатель
            var observer = new TestObserver();
            // Регистрируем тестового наблюдателя в экземпляре класса Stock
            stock.AddObserver(observer);

            // Act
            // Удаляем тестового наблюдателя из экземпляра класса Stock
            stock.RemoveObserver(observer);

            // Assert
            // Возвращает поле-список "observers" из класса Stock с помощью рефлексии
            FieldInfo observersField = typeof(Stock).GetField("observers", BindingFlags.Instance | BindingFlags.NonPublic);
            // Получаем список наблюдателей из экземпляра класса Stock
            var observers = (List<IObserver>)observersField.GetValue(stock);
            // Проверяем, что удаленный наблюдатель отсутствует в списке наблюдателей
            Assert.IsFalse(observers.Contains(observer));
        }

        // Тест на уведомление наблюдателей

        [TestMethod]
        public void NotifyObserversTest()
        {
            // Arrange
            // Создаем новый экземпляр класса Stock с начальной ценой 100 и именем "Burse1"

            var stock = new Stock(100.0, "Burse1");
            // Создаем тестовый наблюдателей
            var observer1 = new TestObserver();
            var observer2 = new TestObserver();
            // Регистрируем тестового наблюдателя в экземпляре класса Stock
            stock.AddObserver(observer1);
            stock.AddObserver(observer2);
            //Добавляем новую цену
            double newPrice = 120.0;

            // Act
            // Обновляем цену акций и оповещаем наблюдателей об изменении
            stock.UpdatePrice(newPrice);

            // Assert
            // Проверяем, что оба наблюдателя получили новую цену и имя биржи
            Assert.AreEqual(newPrice, observer1.LastPrice);
            Assert.AreEqual("Burse1", observer1.LastBurse);
            Assert.AreEqual(newPrice, observer2.LastPrice);
            Assert.AreEqual("Burse1", observer2.LastBurse);
        }
    }
}