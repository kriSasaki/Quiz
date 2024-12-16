namespace Project.Infrastructure
{
    public class StartScreenHandler
    {
        private readonly StartButton _startButton;

        public StartScreenHandler(StartButton startButton)
        {
            _startButton = startButton;
            _startButton.Bind(Open);
        }

        private void Open()
        {
            
        }

        public void Show(System.Action onStart)
        {
            onStart?.Invoke();
        }
    }
}