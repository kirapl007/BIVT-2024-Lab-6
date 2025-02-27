using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class White_3
    {
        public struct Student
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skipped;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skipped;
            public double AvgMark 
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0;
                    }
                    return (double)Sum(_marks) / _marks.Length; // Средняя оценка
                }
            }

            //конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            //методы
            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++; // Увеличиваем количество пропусков
                }
                else
                {
                    if (_marks == null ) return;
                    int[] newMarks = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        newMarks[i] = _marks[i];
                    }

                    // Добавляем новый результат в конец массива
                    newMarks[newMarks.Length - 1] = mark;
                    _marks = newMarks;
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
            private int Sum(int[] array)
            {
                int s = 0;
                if (array.Length == 0) return 0;
                if (array==null) return 0;
                for (int i = 0; i < array.Length; i++)
                {
                    s += array[i];
                }
                return s;
            }

        }

    }

}


