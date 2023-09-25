using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{ 
    
    // Назначение класса: быть основой для объектов, которые нуждаются в оповещении других объектов об изменении свойства "Price"
    public class Observable
    {
        // Событие для оповещения подписчиков об изменении свойства "Price"
        public event EventHandler PriceChanged;
        // Защищенный метод, оповещающий всех подписчиков об изменении свойства "Price"
        protected void Notify()
        {
            // Проверка на наличие подписчиков
            if (PriceChanged != null)
            {
                // Оповещение всех подписчиков об изменении свойства "Price"
                PriceChanged(this, EventArgs.Empty);
            }
        }
    }
}
