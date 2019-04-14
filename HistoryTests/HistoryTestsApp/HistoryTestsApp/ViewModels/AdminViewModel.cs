using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using HistoryTestsApp.Enums;
using HistoryTestsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace HistoryTestsApp.ViewModels
{
    public class AdminViewModel : ReactiveObject
    {
        private string _filePath;
        private readonly SynchronizationContext _context = SynchronizationContext.Current;

        public ICommand AddNewQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }

        [Reactive]
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        [Reactive]
        public Question NewQuestion { get; set; } = new Question();

        [Reactive]
        public int CurrentIndex { get; set; }

        public AdminViewModel(SubjectType type)
        {
            AddNewQuestionCommand = new CommandHandler(o => true, AddNewQuestion);
            DeleteQuestionCommand = new CommandHandler(o => true, DeleteQuestion);

            _filePath = Directory.GetCurrentDirectory() + @"\" + Options.QuestionsFolderName + @"\" + type + ".txt";
            Questions.CollectionChanged += QuestionsOnCollectionChanged;
            LoadData();
        }

        private void QuestionsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteAsync(JArray.FromObject(Questions.ToList()).ToString());
            }
        }

        public AdminViewModel() { }

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

                _context.Send(o =>
                {
                    Questions = new ObservableCollection<Question>();
                    foreach (var question in questions)
                    {
                        Questions.Add(question);
                    }
                    Questions.CollectionChanged += QuestionsOnCollectionChanged;
                }, null);
            }
        }

        private void AddNewQuestion(object state)
        {
            Questions.Add(NewQuestion);
        }

        private void DeleteQuestion(object state)
        {
            if (Questions.Count == 0) return;
            Questions.RemoveAt(CurrentIndex);
        }
    }
}
