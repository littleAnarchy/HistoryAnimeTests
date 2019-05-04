using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using HistoryTestsApp.Enums;
using HistoryTestsApp.Models;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HistoryTestsApp.ViewModels
{
    public class GameViewModel : ReactiveObject
    {
        private readonly string _filePath;
        private int _questionIndex;

        public event EventHandler<int> GameEnded;

        public ICommand SelectAnswerCommand { get; }
        public ICommand GetNextQuestionCommand { get; }

        [Reactive]
        public int Score { get; set; }
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
            GetNextQuestion(null);

            SelectAnswerCommand = new CommandHandler(o => true, SelectAnswer);
            GetNextQuestionCommand = new CommandHandler(o => true, GetNextQuestion);
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

        private void SelectAnswer(object index)
        {
            if (index == null) return;
            SelectedAnswerIndexes[(int) index] = !SelectedAnswerIndexes[(int) index];

            //notificate ui, because [Reactive] works bad with array
            this.RaisePropertyChanged(nameof(SelectedAnswerIndexes));
        }

        private void GetNextQuestion(object state)
        {
            if (_questionIndex > 0 && Enumerable.SequenceEqual(CurrentQuestion.CorrectIndexes, SelectedAnswerIndexes))
                Score++;

            if (Questions.Count <= _questionIndex)
            {
                GameEnded?.Invoke(this, Score);
                return;
            }

            CurrentQuestion = Questions[_questionIndex++];
        }
    }
}
