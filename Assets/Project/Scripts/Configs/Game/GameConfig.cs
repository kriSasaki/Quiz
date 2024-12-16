using System.Collections.Generic;
using Project.Configs.Sprite;
using Project.Systems.Data;
using UnityEngine;

namespace Project.Configs.Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public int InitialLevelIndex = 0;

        [SerializeField] private List<Difficulty> _difficulties;
        [SerializeField] private List<CardsConfig> _cardsConfigs;

        public List<Difficulty> Difficulties => _difficulties;
        public List<CardsConfig> CardsConfigs => _cardsConfigs;
    }
}