using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    //тестируемый класс, содержащий тестовый метод.
    [TestClass]
public class StockTests
    {
        //тестовый метод, который проверяет, что изменение цены акции вызывает оповещение наблюдателей.
        [TestMethod]
        public void PriceSet_NotifiesObservers()
        {
            // Arrange
            var stock = new Stock("AAPL", 100.0);//Создается новый экземпляр класса Stock с названием "AAPL" и начальной ценой 100.0.
            var observer = new MockObserver();//Создается новый экземпляр "mock" (подставной) наблюдатель MockObserver.
            stock.PriceChanged += observer.HandleEvent;//mock наблюдатель подписывается на событие PriceChanged класса Stock. 

            // Act
            stock.Price = 110.0;//Изменяется цена акции с 100.0 на 110.0.

            // Assert
            Assert.IsTrue(observer.IsNotified, "Наблюдатель не был уведомлен");//Проверяется, что наблюдатель был оповещен об изменении цены акции (свойство IsNotified установлено в true).
        }
    }

    //MockObserver - "mock" (подставной) класс наблюдателя, имитирующий реального наблюдателя для тестирования оповещений.
    public class MockObserver
    {
        //Свойство IsNotified показывает, был ли наблюдатель оповещен.
        public bool IsNotified { get; private set; }
        //Метод HandleEvent вызывается при оповещении. В нем устанавливается свойство IsNotified в true.
        public void HandleEvent(object sender, EventArgs args)
        {
            IsNotified = true;
        }
    }
}