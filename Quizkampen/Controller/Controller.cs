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
        private ScoreScreenView scoreScreenView;

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
            InitializeStartScreen();
            startScreenView.Display();
        }
        private void GoToLogIn()
        {
            InitializeLoginView();
            logInView.Display();
        }
        private void GoToMainMenu()
        {
            InitializeMainMenu();
            mainMenuView.Display();
        }
        private void GoToAnswerQuestion()
        {
            InitializeAnswerQuestion();
            answerQuestionView.Display();
        }
        private void GoToAddQuestion()
        {
            InitializeAddQuestionView();
            addQuestionView.Display();
        }
        private void GoToScoreScreen()
        {
            InitializeScoreScreen();
            queryHandler.CheckIfNewHighScore(userManager.CurrentUser, scoreManager.GetScore());
            scoreScreenView.Display();
        }

        private void InitializeStartScreen()
        {
            startScreenView = new StartScreenView();
            startScreenView.Message = "Welcome to Quizkampen 2.0";
            startScreenView.LogInCallback = GoToLogIn;
        }
        private void InitializeLoginView()
        {
            logInView = new LogInView();
            logInView.AvailableUsers = queryHandler.GetAllUsers();
            logInView.TryLogInCallback = queryHandler.TryLogIn;
            logInView.AddUserCallback = queryHandler.AddUser;
            logInView.SucessfulLoginCallback = GoToMainMenu;
            logInView.ValidateInputParse = logInView.ValidateParse;
            logInView.RefreshView = GoToLogIn;
        }
        private void InitializeMainMenu()
        {
            mainMenuView = new MainMenuView();
            mainMenuView.ActiveUser = userManager.CurrentUser;
            mainMenuView.NumberOfQuestionsInDatabase = queryHandler.GetNumberOfQuestions();
            mainMenuView.DisplayQuestion = GoToAnswerQuestion;
            mainMenuView.EnterQuestion = GoToAddQuestion;
            mainMenuView.LogOut = GoToLogIn;
            mainMenuView.InputValidation = mainMenuView.ValidateParse;
        }
        private void InitializeAnswerQuestion()
        {
            answerQuestionView = new AnswerQuestionView();
            answerQuestionView.GeneratedQuestion = queryHandler.GetRandomQuestion();
            answerQuestionView.ScoreScreenCallback = GoToScoreScreen;
            answerQuestionView.IncreaseScoreCallback = scoreManager.IncreaseScore;
            answerQuestionView.MainMenuCallback = GoToMainMenu;
        }
        private void InitializeAddQuestionView()
        {
            addQuestionView = new AddQuestionView();
            addQuestionView.ParseToInt = addQuestionView.ValidateParse;
            addQuestionView.StringInputValidation = addQuestionView.ValidateInputString;
            addQuestionView.AddQuestionCallback = queryHandler.AddQuestion;
            addQuestionView.ReturnCallback = GoToMainMenu;

        }
        private void InitializeScoreScreen()
        {
            scoreScreenView = new ScoreScreenView();
            scoreScreenView.CurrentScore = scoreManager.GetScore();
            scoreScreenView.User = userManager.CurrentUser;
            scoreScreenView.MainMenuCallback = GoToMainMenu;
            scoreScreenView.NextQuestionCallback = GoToAnswerQuestion;
            scoreScreenView.InputValidation = scoreScreenView.ValidateInputString;
        }
        public void Config()
        {
            model.Database.EnsureCreated();
            queryHandler = new QueryManager(model, userManager);
            scoreManager = new ScoreManager();
        }
    }
}