using System.Collections.Generic;
using DG.Tweening;
using Project.Configs.Game;
using Project.Configs.Sprite;
using Project.Systems.Data;
using Project.UI.Card;
using UnityEngine;

namespace Project.Spawner
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private CardSlot _prefab;

        public void SpawnGrid(Difficulty difficulty, CardsConfig cardsConfig, string correctAnswer)
        {
            ClearGrid();

            int index = 0;
            for (int row = 0; row < difficulty.Rows; row++)
            {
                for (int col = 0; col < difficulty.Columns; col++)
                {
                    var cell = Instantiate(_prefab, transform);
                    cell.transform.localPosition = new Vector3(col * 100, -row * 100, 0);
                    
                    var gridCell = cell.GetComponent<CardSlot>();
                    bool isCorrectAnswer = cardsConfig.CardData[index].Identifier == correctAnswer;
                    gridCell.Initialize(cardsConfig.CardData[index].Sprite, isCorrectAnswer);

                    index++;
                }
            }
        }
        
        public void ClearGrid()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}