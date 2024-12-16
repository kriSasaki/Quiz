using DG.Tweening;
using UnityEngine;

namespace Project.Infrastructure
{
    public class GameplayUIHandler
    {
        private GameObject _restartButton;
        private CanvasGroup _fadeOverlay;
        
        private TMPro.TextMeshProUGUI _taskText;

        public GameplayUIHandler(TMPro.TextMeshProUGUI taskText)
        {
            _taskText = taskText;
        }

        public void Show()
        {
            
        }

        public void UpdateTaskText(string taskText)
        {
            _taskText.text = taskText;
        }
        
        public void ShowEndGameScreen(System.Action onRestart)
        {
            _fadeOverlay.DOFade(0.5f, 0.5f).SetEase(Ease.InOutQuad);
            _restartButton.SetActive(true);
            _restartButton.transform.DOScale(1f, 0.5f).From(0f).SetEase(Ease.OutBounce);

            _restartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                _fadeOverlay.DOFade(0f, 0.5f).SetEase(Ease.InOutQuad);
                _restartButton.SetActive(false);
                onRestart?.Invoke();
            });
        }
    }
}