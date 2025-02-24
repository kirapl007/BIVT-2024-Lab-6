using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Павловская_Lab_6
{
    public class White_2
    {
        public struct Participant
        {
            // поля 
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;

            //свойства
            public string Surname => _surname;
            public string Name => _name;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => Math.Max(_firstJump, _secondJump); // Лучший прыжок

            // конструкторы
            public Participant(string surname, string name)
            {
                _surname = surname;
                _name = name;
                _firstJump = 0;
                _secondJump = 0;

            }
            public void Jump(double result)
            {
                if (_firstJump == 0)
                {
                    _firstJump = result;
                }
                else if (_secondJump == 0)
                {
                    _secondJump = result;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool sw;

                for (int i = 0; i < n - 1; i++)
                {
                    sw = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump) // сортировка по убыванию
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break; // перестановок не было, массив уже отсортирован
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, Лучший прыжок: {BestJump}");
            }
        }

    }
}

