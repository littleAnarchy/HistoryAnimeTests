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
                    NPCName = "Цнотлива монашка";
                    AnimeText = new List<string>()
                    {
                        $"хник-хник-хник... \n {PlayerController.Instance.PlayerName}, ти тільки не тупи, будь ласка."
                    };
                    break;
                case SubjectType.Subject2:
                    NPCName = "Помічниця Сатрапа";
                    AnimeText = new List<string>()
                    {
                        $"Привіт, {PlayerController.Instance.PlayerName}! Мене попросили бути твоїм властеліном сьогодні. \n" +
                        "Готовий до веселих та повних болі та вселенських мук питань?"
                    };
                    break;
                case SubjectType.Subject3:
                    NPCName = "Ісус";
                    AnimeText = new List<string>()
                    {
                        $"Здраствуй, сину мій, {PlayerController.Instance.PlayerName}. Коли ти останній раз ходив до церкви?"
                    };
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
