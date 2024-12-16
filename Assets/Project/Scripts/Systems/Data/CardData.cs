using System;
using UnityEngine;

namespace Project.Systems.Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private bool _isFlipped;

        public string Identifier => _identifier;
        public Sprite Sprite => _sprite;
        public bool IsFlipped => _isFlipped;
    }
}