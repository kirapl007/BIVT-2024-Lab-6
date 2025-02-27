using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_4
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _scores;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Scores
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                        return null;

                    double[] copscores = new double[_scores.Length];//создаем новый массив,копию массива _scores
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        copscores[i] = _scores[i];//передаем ссылку на массив
                    }
                    return copscores;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                    {
                        return 0;
                    }
                    return Sum(_scores);
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];


            }

            //методы
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Очки: {TotalScore:F1}");
            }
            
            public void PlayMatch(double result)
            {
                if (_scores == null) return;
                double[] newScores = new double[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }

                // Добавляем новый результат в конец массива
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
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

            private  double Sum(double[] array)
            {
                double s = 0;
                if (array.Length == 0) return 0;
                if (array == null) return 0;
                for (int i = 0; i < array.Length; i++)
                {
                    s += array[i];
                }
                return s;
            }


        }
        
    }
}
