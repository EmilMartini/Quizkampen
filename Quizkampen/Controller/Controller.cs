using System;

namespace Quizkampen
{
    internal class Controller
    {
        private QuizkampenContext model;
        private UserManager userManager;
        private QueryManager queryHandler;
        private ScoreManager scoreManager;
        private MainMenuView mainMenuView;
        private StartScreenView startScreenView;
        private AnswerQuestionView answerQuestionView;
        private AddQuestionView addQuestionView;
        private LogInView logInView;

        public Controller(QuizkampenContext model, UserManager userManager)
        {
            this.model = model;
            this.userManager = userManager;
        }
        internal void Run()
        {
            GoToStartScreen();
        }
        private void GoToStartScreen() 
        {
            if (startScreenView == null) startScreenView = new StartScreenView
            {
                Message = "Welcome to Quizkampen 2.0",
                Callback = GoToLogIn
            };
            startScreenView.Display();
        }
        private void GoToLogIn()
        {
            logInView = new LogInView
            {
                AvailableUsers = queryHandler.GetAllUsers(),
                TryLogInCallback = queryHandler.TryLogIn,
                AddUserCallback = queryHandler.AddUser,
                SucessfulLoginCallback = GoToMainMenu,
                RefreshView = GoToLogIn
            };
            logInView.Display();
        }
        private void GoToMainMenu()
        {
            mainMenuView = new MainMenuView
            {
                ActiveUser = userManager.CurrentUser,
                NumberOfQuestionsInDatabase = queryHandler.GetNumberOfQuestions(),
                DisplayQuestion = GoToAnswerQuestion,
                EnterQuestion = GoToAddQuestion
            };
            mainMenuView.Display();
        }
        private void GoToAnswerQuestion()
        {
            answerQuestionView = new AnswerQuestionView
            {
                GeneratedQuestion = queryHandler.GetRandomQuestion()
            };
            answerQuestionView.Display();
        }
        private void GoToAddQuestion()
        {
            addQuestionView = new AddQuestionView
            {
                AddQuestionCallback = queryHandler.AddQuestion,
                ReturnCallback = GoToMainMenu
            };
            addQuestionView.Display();
        }
        private void GoToScoreScreen(int inputScore)
        {
            GoToMainMenu();
        }
        internal void Config()
        {
            model.Database.EnsureCreated();
            queryHandler = new QueryManager(model, userManager);
            scoreManager = new ScoreManager(model);
        }
    }
}