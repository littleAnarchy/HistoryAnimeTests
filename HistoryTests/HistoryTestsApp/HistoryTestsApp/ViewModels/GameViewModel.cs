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
        private bool _isAnswering;
        private bool _isHelpShowing;

        public event EventHandler<int> GameEnded;
        public event EventHandler<bool> HelpFrameVisibleChanged;
        public event EventHandler<bool> AnswerPushed;
        public event EventHandler<HelperType> HelperInfoChanged;

        public ICommand SelectAnswerCommand { get; }
        public ICommand GetNextQuestionCommand { get; }
        public ICommand ShowHideHelpFrameCommand { get; }

        [Reactive]
        public int Score { get; set; }
        [Reactive]
        public bool[] SelectedAnswerIndexes { get; set; } = new bool[4];
        [Reactive]
        public Question CurrentQuestion { get; set; }

        [Reactive] public bool IsHelpShowed { get; set; } = false;

        public List<Question> Questions { get; set; }
        [Reactive]
        public string HelpText { get; set; }

        public GameViewModel () { }

        public GameViewModel(SubjectType type)
        {
            _filePath = Directory.GetCurrentDirectory() + @"\" + Options.QuestionsFolderName + @"\" + type + ".txt";
            LoadData();
            Next();

            SelectAnswerCommand = new CommandHandler(o => true, SelectAnswer);
            GetNextQuestionCommand = new CommandHandler(o => true, GetNextQuestion);
            ShowHideHelpFrameCommand = new CommandHandler(o => true, ShowHideHelpFrame);
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

                var indexes = new List<int>();
                var rand = new Random();

                if (questions.Count > 10)
                {
                    while (indexes.Count != 10)
                    {
                        var index = rand.Next(0, questions.Count);
                        if (!indexes.Any(x => x == index))
                            indexes.Add(index);
                    }
                }

                foreach (var index in indexes)
                {
                    Questions.Add(questions[index]);
                }
            }
        }

        private void SelectAnswer(object index)
        {
            if (_isAnswering) return;
            if (index == null) return;
            SelectedAnswerIndexes[(int) index] = !SelectedAnswerIndexes[(int) index];

            //notificate ui, because [Reactive] works bad with array
            this.RaisePropertyChanged(nameof(SelectedAnswerIndexes));
        }

        private void GetNextQuestion(object state)
        {
            if (_isAnswering) return;

            _isAnswering = true;

            if (IsHelpShowed)
            {
                _isHelpShowing = true;
                IsHelpShowed = !IsHelpShowed;
                HelpFrameVisibleChanged?.Invoke(this, IsHelpShowed);
            }

            AnswerPushed?.Invoke(this, Enumerable.SequenceEqual(CurrentQuestion.CorrectIndexes, SelectedAnswerIndexes));
        }

        public void Next()
        {
            if (_questionIndex > 0 && Enumerable.SequenceEqual(CurrentQuestion.CorrectIndexes, SelectedAnswerIndexes))
                Score++;

            if (Questions == null) return;

            if (Questions.Count <= _questionIndex)
            {
                GameEnded?.Invoke(this, Score);
                return;
            }

            CurrentQuestion = Questions[_questionIndex++];

            for (var i = 0; i < SelectedAnswerIndexes.Length; i++)
            {
                SelectedAnswerIndexes[i] = false;
            }

            //notificate ui, because [Reactive] works bad with array
            this.RaisePropertyChanged(nameof(SelectedAnswerIndexes));

            _isAnswering = false;
        }

        private void ShowHideHelpFrame(object state)
        {
            if (_isHelpShowing) return;

            _isHelpShowing = true;

            if (!IsHelpShowed)
            {
                if (CurrentQuestion.Helps == null) return;
                var helps = CurrentQuestion.Helps.Split(';');
                var rand = new Random();
                var index = rand.Next(0, helps.Length);

                HelperInfoChanged?.Invoke(this, (HelperType)index);

                HelpText = helps[index];
            }

            IsHelpShowed = !IsHelpShowed;

            HelpFrameVisibleChanged?.Invoke(this, IsHelpShowed);
        }

        public void OnHelpShovingEnded(object sender, EventArgs args)
        {
            _isHelpShowing = false;
        }
    }
}
