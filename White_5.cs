using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Павловская_Lab_6
{
    public class White_5
    {
        public struct Match
        {
            //поля
            private int _goals;
            private int _misses;

            //конструкторы
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => _goals - _misses;
            public int Score // Очки за матч
            {
                get
                {
                    if (_goals > _misses) return 3; // Победа
                    if (_goals == _misses) return 1; // Ничья
                    return 0; // Поражение
                }
            }

            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"Забито: {_goals}, Пропущено: {_misses}, Очки: {Score}");
            }

           

           //методы
            
            public static void SortTeams(Team[] teams)
            {
                int n = teams.Length;
                bool sw;

                for (int i = 0; i < n - 1; i++)
                {
                    sw = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore || (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j].TotalDifference < teams[j + 1].TotalDifference))
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break;
                    if (!sw) break;
                }
            }
        }

        //структура2
        public struct Team
        {
            private string _name;
            private Match[] _matches;

            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore => _matches.Sum(m => m.Score); // Суммарные очки
            public int TotalDifference => _matches.Sum(m => m.Difference); // Общая разница голов

            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }

            public void PlayMatch(int goals, int misses)
            {
                Array.Resize(ref _matches, _matches.Length + 1);
                _matches[-1] = new Match(goals, misses);
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {_name}, Очки: {TotalScore}, Разница голов: {TotalDifference}");
            }
        }

    }
}
