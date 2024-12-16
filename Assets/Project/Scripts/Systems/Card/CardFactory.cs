using Project.Configs.Sprite;
using Project.Systems.Data;
using Project.UI.Card;
using UnityEngine;

namespace Project.Systems.Card
{
    public class CardFactory
    {
        private readonly CardSlot _prefab;
        private readonly LevelDataProvider _levelDataProvider;

        public CardFactory(CardSlot prefab, LevelDataProvider levelDataProvider)
        {
            _prefab = prefab;
        }

        // public CardSlot Create(CardData cardData, Vector3 position, Transform parent = null)
        // {
        //     CardSlot cardSlot = Object.Instantiate(_prefab, position, Quaternion.identity, parent);
        //     cardSlot.Initialize(cardData);
        // }
    }
}