using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Project.Systems.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Card
{
    public class CardSlot : MonoBehaviour
    {
        [SerializeField] private Button _selectButton;
        [SerializeField] private CardView _cardView;

        private bool _isCorrectAnswer;

        private void Awake()
        {
            _selectButton.onClick.AddListener(OnCardSelected);
        }
        
        private void OnDestroy()
        {
            _selectButton.onClick.RemoveListener(OnCardSelected);
        }

        public void Initialize(Sprite sprite, bool isCorrectAnswer)
        {
            _isCorrectAnswer = isCorrectAnswer;
            _cardView.Set(sprite);
        }

        private void OnCardSelected()
        {
            if (_isCorrectAnswer)
            {
                _cardView.PlayCorrectAnimation();
            }
            else
            {
                _cardView.PlayIncorrectAnimation();
            }
        }
    }
}