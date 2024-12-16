using System.Collections.Generic;
using Project.Systems.Data;
using UnityEngine;

namespace Project.Configs.Sprite
{
    [CreateAssetMenu(fileName = "NewCardsConfig", menuName = "Configs/Cards/CardsConfig")]
    public class CardsConfig : ScriptableObject
    {
        [SerializeField] private List<CardData> _cardData;

        public List<CardData> CardData => _cardData;
    }
}