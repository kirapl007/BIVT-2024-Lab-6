using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_5
    {
        public struct Match
        {
            //поля
            private int _goals;
            private int _misses;

            //свойства
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

            //конструкторы
            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"Забито: {_goals}, Пропущено: {_misses}, Очки: {Score}");
            }
            
            
            
        }

        //структура2
        public struct Team
        {
            //поля2
            private string _name;
            private Match[] _matches;

            //свойства2
            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore
            {
                get
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score; //общая сумма очков
                    }
                    return total;
                }
            }

            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;//разница голов
                    }
                    return total;
                }
            }

            //конструкторы2
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }

            public void PlayMatch(int goals, int misses)
            {
                if ( _matches==null) return;
                Match newMatch = new Match(goals, misses);
                Match[] newMatches = new Match[_matches.Length + 1];
                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }
                // Добавляем новый матч в конец массива
                newMatches[newMatches.Length - 1] = newMatch;
                _matches = newMatches;
            }

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
                }
            }
            public void Print()
            {
                Console.WriteLine($"Команда: {_name}, Очки: {TotalScore}, Разница голов: {TotalDifference}");
            }
        }

    }
}
