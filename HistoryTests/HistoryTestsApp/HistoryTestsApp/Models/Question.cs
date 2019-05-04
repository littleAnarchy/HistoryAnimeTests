using System.Collections.Generic;
using System.Collections.Specialized;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HistoryTestsApp.Models
{
    public class Question
    {

        public string QuestionText { get; set; }

        public string[] Answerts { get; set; } = new string[4];

        public bool[] CorrectIndexes { get; set; } = new bool[4];

        public string Helps { get; set; }
    }
}
