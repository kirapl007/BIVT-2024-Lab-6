using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Павловская_Lab_6
{
    public class White_4
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _scores;

            //конструкторы
            public string Name => _name;
            public string Surname => _surname;
            public double[] Scores => _scores;
            public double TotalScore => _scores.Sum(); // Общий результат участника

            public Participant(string surname, string name)
            {
                _surname = surname;
                _name = name;
                _scores = new double[0];
                

            }
            public void PlayMatch(double result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[-1] = result; // Добавляем новый результат в  конец массива
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
                        if (array[j].TotalScore < array[j + 1].TotalScore) // Сортировка по убыванию очков
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break; // Если перестановок не было, массив уже отсортирован
                }
            }


        }
    }
}
