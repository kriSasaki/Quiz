using System;
using System.Collections.Generic;
using Project.Spawner;
using Project.Systems.Data;
using Project.Utils.Extensions;

namespace Project.Infrastructure
{
    public class GameStateHandler
    {
        private readonly CardSpawner _cardSpawner;
        private readonly StartScreenHandler _startScreenHandler;
        private readonly GameplayUIHandler _gameplayUIHandler;
        private readonly LevelDataProvider _levelDataProvider;
        
        private int _currentLevelIndex;
        private HashSet<string> _usedTargets;

        public GameStateHandler(CardSpawner cardSpawner, StartScreenHandler startScreenHandler, GameplayUIHandler gameplayUIHandler, LevelDataProvider levelDataProvider)
        {
            _cardSpawner = cardSpawner;
            _startScreenHandler = startScreenHandler;
            _gameplayUIHandler = gameplayUIHandler;
            _levelDataProvider = levelDataProvider;
            
            _usedTargets = new HashSet<string>();
            StartGame();
        }

        public void StartGame()
        {
            _currentLevelIndex = _levelDataProvider.GetInitialLevelIndex();
            _startScreenHandler.Show(() => LoadLevel(_currentLevelIndex));
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex >= _levelDataProvider.GetTotalLevels())
            {
                _gameplayUIHandler.ShowEndGameScreen(() => RestartGame());
                return;
            }

            _currentLevelIndex = levelIndex;
            Difficulty difficulty = _levelDataProvider.GetLevelData(levelIndex);

            var contentPool = _levelDataProvider.GetRandomConfig();
            
            var (cellContents, targetContent) = GenerateUniqueLevelContent(_levelDataProvider.GetConfigIdentifiers());
            
            _gameplayUIHandler.UpdateTaskText($"Find {targetContent}");
            
            _cardSpawner.SpawnGrid(difficulty, contentPool, targetContent);
        }
        
        public void RestartGame()
        {
            _usedTargets.Clear();
            _currentLevelIndex = _levelDataProvider.GetInitialLevelIndex();
            LoadLevel(_currentLevelIndex);
        }
        
        public void TransitToNextLevel(int levelIndex)
        {
            _cardSpawner.ClearGrid();
            
            LoadLevel(levelIndex);
        }

        private (List<string> cellContents, string targetContent) GenerateUniqueLevelContent(List<string> contentPool)
        {
            var shuffledContent = new List<string>(contentPool);
            shuffledContent.Shuffle();

            Random random = new Random();

            string targetContent;
            do
            {
                targetContent = shuffledContent[random.Next(0, shuffledContent.Count)];
            } while (_usedTargets.Contains(targetContent));

            _usedTargets.Add(targetContent);

            return (
                shuffledContent.GetRange(0,
                    _levelDataProvider.GetLevelData(_currentLevelIndex).Rows *
                    _levelDataProvider.GetLevelData(_currentLevelIndex).Columns), targetContent);
        }
    }
}