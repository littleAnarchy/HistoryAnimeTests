using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using HistoryTestsApp.Enums;
using HistoryTestsApp.Models;
using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;

namespace HistoryTestsApp.ViewModels
{
    public class GameViewModel
    {
        private readonly string _filePath;
        [Reactive]
        public bool[] SelectedAnswerIndexes { get; set; } = new bool[4];
        [Reactive]
        public Question CurrentQuestion { get; set; }
        public List<Question> Questions { get; set; }

        public GameViewModel () { }

        public GameViewModel(SubjectType type)
        {
            _filePath = Directory.GetCurrentDirectory() + @"\" + Options.QuestionsFolderName + @"\" + type + ".txt";
            LoadData();
            CurrentQuestion = Questions[0];
        }

        private void LoadData()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
                return;
            }

            using (var sr = new StreamReader(_filePath))
            {
                var data = sr.ReadToEnd();
                var questions = JsonConvert.DeserializeObject<List<Question>>(data);
                if (questions == null) return;

                Questions = new List<Question>();
                foreach (var question in questions)
                {
                    Questions.Add(question);
                }
            }
        }
    }
}
