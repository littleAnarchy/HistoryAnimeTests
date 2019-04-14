using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryTestsApp.Enums;
using ReactiveUI;

namespace HistoryTestsApp.ViewModels
{
    public class DialogViewModel : ReactiveObject
    {
        public string NPCName { get; set; }

        public List<string> AnimeText { get; set; } 

        public DialogViewModel(SubjectType type)
        {
            switch (type)
            {
                case SubjectType.Subject1:
                    NPCName = "Помічниця Сатрапа";
                    AnimeText = new List<string>()
                    {
                        "Привіт, [username]! Мене попросили бути твоїм властеліном сьогодні. \n" +
                        "Готовий до веселих та повних болі вселенських мук питань?"
                    };
                    break;
                case SubjectType.Subject2:
                    break;
                case SubjectType.Subject3:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public DialogViewModel()
        {
        }
    }
}
