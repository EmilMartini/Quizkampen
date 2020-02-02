using System;

namespace Quizkampen
{
    internal class Controller
    {
        private QuestionContext model;
        private QueryManager queryHandler;
        private MainMenuView mainMenuView;
        private StartScreenView startScreenView;
        private AnswerQuestionView answerQuestionView;
        private AddQuestionView addQuestionView;
        private LogInView logInView;

        public Controller(QuestionContext model)
        {
            this.model = model;
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

            }
        }

        private void GoToMainMenu()
        {
            mainMenuView = new MainMenuView
            {
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
            queryHandler = new QueryManager();
        }
    }
}