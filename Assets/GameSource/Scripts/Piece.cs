using System;
using System.Collections;
using System.Collections.Generic;
using CustomFeatures.Timer;
using UnityEngine;

namespace Prototype.Core
{
    public enum Objects
    {
        Empty,
        Wall,
        Bomb,
    }

    [Serializable]
    public class GridPosition
    {
        public int row;
        public int column;
    }

    public class Piece : MonoBehaviour
    {
        public Collider2D Collider => collider;
        public GridPosition GridPosition => gridPosition;
        [SerializeField] private GridPosition gridPosition;
        [SerializeField] private Collider2D collider;

        [SerializeField] private Objects holdedObject;

        [SerializeField] private Wall wall;
        [SerializeField] private Bomb bomb;

        private Action<GridPosition> OnBombExplode;

        public void SetPosition(int r, int c)
        {
            gridPosition.row = r;
            gridPosition.column = c;
        }

        public void SetBombAction(Action<GridPosition> onBombInvoke)
        {
            OnBombExplode = onBombInvoke;
        }


        public bool IsEmpty()
        {
            return holdedObject == Objects.Empty;
        }

        public void PlaceBomb()
        {
            holdedObject = Objects.Bomb;
            bomb.SetBomb();
            TimerProcessor.Instance.AddTimer(0.5f, ExplodeBomb);
        }

        public void PlaceWall()
        {
            holdedObject = Objects.Wall;
            wall.SetWall();
        }


        public void ExplodeBomb()
        {
            holdedObject = Objects.Empty;
            bomb.InvokeBomb();
            OnBombExplode?.Invoke(GridPosition);
        }

        public void DemolishWall()
        {
            holdedObject = Objects.Empty;
            wall.Demolish();
        }

        public bool HaveWall()
        {
            return holdedObject == Objects.Wall;
        }
    }
}