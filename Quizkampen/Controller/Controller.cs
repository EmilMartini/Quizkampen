
namespace Quizkampen
{
    internal class Controller
    {
        private QuizkampenContext model;
        private UserManager userManager;
        private QueryManager query;
        private LogInView logInView;
        private ScoreManager scoreManager;
        private MainMenuView mainMenuView;
        private StartScreenView startScreenView;
        private AnswerQuestionView answerQuestionView;
        private AddQuestionView addQuestionView;
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
            scoreManager.ResetScore();
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
            query.CheckIfNewHighScore(userManager.CurrentUser, scoreManager.GetScore());
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
            logInView.AvailableUsers = query.GetAllUsers();
            logInView.TryLogInCallback = query.TryLogIn;
            logInView.AddUserCallback = query.AddUser;
            logInView.IsUniqueCallback = query.IsUniqueId;
            logInView.SucessfulLoginCallback = GoToMainMenu;
            logInView.ParseInputValidation = logInView.ValidateInputParse;
            logInView.RefreshView = GoToLogIn;
        }
        private void InitializeMainMenu()
        {
            mainMenuView = new MainMenuView();
            mainMenuView.ActiveUser = userManager.CurrentUser;
            mainMenuView.NumberOfQuestionsInDatabase = query.GetNumberOfQuestions();
            mainMenuView.DisplayQuestion = GoToAnswerQuestion;
            mainMenuView.EnterQuestion = GoToAddQuestion;
            mainMenuView.LogOut = GoToLogIn;
            mainMenuView.ParseInputValidation = mainMenuView.ValidateInputParse;
        }
        private void InitializeAnswerQuestion()
        {
            answerQuestionView = new AnswerQuestionView();
            answerQuestionView.GeneratedQuestion = query.GetRandomQuestion();
            answerQuestionView.ScoreScreenCallback = GoToScoreScreen;
            answerQuestionView.IncreaseScoreCallback = scoreManager.IncreaseScore;
            answerQuestionView.ParseInputValidation = answerQuestionView.ValidateInputParse;
            answerQuestionView.MainMenuCallback = GoToMainMenu;
        }
        private void InitializeAddQuestionView()
        {
            addQuestionView = new AddQuestionView();
            addQuestionView.ParseToInt = addQuestionView.ValidateInputParse;
            addQuestionView.StringInputValidation = addQuestionView.ValidateInputString;
            addQuestionView.AddQuestionCallback = query.AddQuestion;
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
        public void Config(Seed seed)
        {
            model.Database.EnsureCreated();
            query = new QueryManager(model, userManager);
            scoreManager = new ScoreManager();
            if(query.GetNumberOfQuestions() <= 0) seed.AddQuestions();
        }
    }
}