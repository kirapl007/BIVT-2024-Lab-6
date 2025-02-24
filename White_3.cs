using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Павловская_Lab_6
{
    public class White_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skipped;

            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skipped;
            public double AvgMark => Sum(_marks) / _marks.Length; // Средняя оценка

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++; // Увеличиваем количество пропусков
                }
                else
                {
                    Array.Resize(ref _marks, _marks.Length + 1);
                    _marks[-1] = mark; // Добавляем новую оценку
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool sw;

                for (int i = 0; i < n - 1; i++)
                {
                    sw = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped) // Сортировка по убыванию пропусков
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break; // Если перестановок не было, массив уже отсортирован
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Средняя оценка: {AvgMark:F2}, Пропуски: {_skipped}");
            }
            public int Sum(int[] array)
            {
                int s = 0;
                if (array.Length == 0) return 0;
                for (int i = 0; i < array.Length; i++)
                {
                    s += array[i];
                }
                return s;
            }

        }

    }

}


