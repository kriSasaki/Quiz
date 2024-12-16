using System;
using System.Collections.Generic;
using System.Linq;
using Project.Configs.Game;
using Project.Configs.Sprite;

namespace Project.Systems.Data
{
    public class LevelDataProvider
    {
        private readonly GameConfig _config;

        private int _randomConfigIndex;

        public LevelDataProvider(GameConfig config)
        {
            _config = config;
        }

        public int GetCardConfigsAmount()
        {
            return _config.CardsConfigs.Count;
        }

        public Difficulty GetLevelData(int difficulty)
        {
            return _config.Difficulties[difficulty];
        }

        public CardsConfig GetRandomConfig()
        {
            Random random = new Random();
            _randomConfigIndex = random.Next(GetCardConfigsAmount()); 
            
            return _config.CardsConfigs[_randomConfigIndex];
        }
        
        public List<string> GetConfigIdentifiers()
        {
            // Извлекаем список CardData из указанного CardsConfig
            var cardDataList = _config.CardsConfigs[_randomConfigIndex].CardData;
    
            // Возвращаем список идентификаторов из CardData
            return cardDataList.ConvertAll(card => card.Identifier);
        }

        public int GetInitialLevelIndex()
        {
            return _config.InitialLevelIndex;
        }

        public int GetTotalLevels()
        {
            return _config.Difficulties.Count;
        }
    }
}