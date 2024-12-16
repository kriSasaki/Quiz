using UnityEngine;

namespace Project.Systems.Data
{
    [System.Serializable]
    public class Difficulty
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;

        public int Rows => _rows;
        public int Columns => _columns;
    }
}