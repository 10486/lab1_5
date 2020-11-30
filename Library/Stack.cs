using System.Collections.Generic;
using System;

namespace Library
{
    public class Stack<T>
    {
        private List<T> Container;
        public Stack()
        {
            Container = new List<T>();
        }
        /// <summary>
        /// Количество элементов в стеке
        /// </summary>
        public int Count {
            get {
                return Container.Count;
            } 
        }
        /// <summary>
        /// Получаем значение последнего элемента в стеке
        /// </summary>
        /// <returns>ПОследний элемент в стеке</returns>
        public T Check()
        {
            return Count != 0 ? Container[0] : throw new Exception("Нет элементов в стеке");
        }
        /// <summary>
        /// Удаляет последний элемент в стеке и возвращает его
        /// </summary>
        /// <returns>последний элемент в стеке</returns>
        public T Pop()
        {
            var tmp = Check();
            Container.Remove(tmp);
            return tmp;
        }
        /// <summary>
        /// Добавление элемента в стек
        /// </summary>
        /// <param name="item">элемент который добавляем</param>
        public void Push(T item)
        {
            Container.Insert(0, item);
        }
        /// <summary>
        /// Проверка на наличие элемента в стеке
        /// </summary>
        /// <param name="item">непосредственно элемент</param>
        /// <returns>true если есть такой элемент в стеке</returns>
        public bool Contains(T item)
        {
            return Container.Contains(item);
        }
    }
}
