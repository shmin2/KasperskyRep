using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaspersky
{
    //Надо сделать очередь с операциями push(T) и T pop().
    //Операции должны поддерживать обращение с разных потоков.
    //В качестве контейнера внутри можно использовать только стандартную очередь (Queue).
    //Операция push всегда вставляет и выходит.
    //Операция pop ждет пока не появится новый элемент. 
    class Queue<T>
    {
        private T[] _collection;
        private int _head;
        private int _tail;
        private int _size;
        private float _resize;
        private Object queueLocker;
        public Queue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity", capacity, "Емкость не может быть меньше 0");

            _collection = new T[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _resize = 2f;
            queueLocker = new object();
        }

        public void Push(T element)
        {
            lock (queueLocker)
            {
                if (_size == _collection.Length)
                {
                    int NewSize;
                    NewSize = (int)(_collection.Length * (long)_resize);
                    ResizeMassive(NewSize);
                }
                Console.WriteLine("Push start: Добавляю элемент {0}", element);
                _collection[_tail] = element;
                _tail = (_tail + 1) % _collection.Length;
                _size++;
            }
        }

        public T Pop()
        {
            Console.WriteLine("DoPop thread started:");
            while (_size == 0)
            { Thread.Sleep(500); Console.WriteLine("В очереди нет элементов"); }
            lock (queueLocker)
            {
                Console.WriteLine("Удаляю элемент {0}", _collection[_head]);
                T temp = _collection[_head];
                _collection[_head] = default(T);
                _head = (_head + 1) % _collection.Length;
                _size--;

                return temp;
            }
        }

        private void ResizeMassive(int newSize)
        {
            lock (queueLocker)
            {
                Console.WriteLine(new string('-', 40));
                Console.Write("Необходимо расширить массив с {0}", _collection.Length);
                T[] newCollection = new T[newSize];
                if (_size > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_collection, _head, newCollection, 0, _size);
                    }
                    else
                    {
                        Array.Copy(_collection, _head, newCollection, 0, _collection.Length - _head);
                        Array.Copy(_collection, 0, newCollection, _collection.Length - _head, _tail);
                    }
                }
                _collection = newCollection;
                _head = 0;
                _tail = (_size == newSize) ? 0 : _size;
                Console.Write(" до {0}", _collection.Length);
                Console.WriteLine();
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
