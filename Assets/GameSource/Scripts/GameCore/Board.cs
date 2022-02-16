using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype.Core
{
    public class Board : MonoBehaviour
    {
        public List<List<Piece>> BoardItems => boardItems;
        private List<List<Piece>> boardItems = new List<List<Piece>>();
        public UnityEvent WhenAllWallsDemolished;
        public UnityEvent WhenBombInvokeOnBoard;
        private int row;
        private int column;
        private int wall;

        private Dictionary<GridPosition, Piece> wallPositions = new Dictionary<GridPosition, Piece>();


        public void AddRow()
        {
            boardItems.Add(new List<Piece>());
        }

        public void AddColumn(int row, Piece piece)
        {
            boardItems[row].Add(piece);
        }

        public void AddWall(GridPosition pos, Piece piece)
        {
            wallPositions.Add(pos, piece);
        }

        public void ClearBoard()
        {
            boardItems.Clear();
            for (int i = 0; i < transform.childCount;)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        public void FinishBuilding(int row, int column, int wall)
        {
            this.row = row;
            this.column = column;
            this.wall = wall;
        }


        public void OnBombExplodeInBoard(GridPosition bombPos)
        {
            if (bombPos.column - 1 >= 0)
            {
                var piece = BoardItems[bombPos.row][bombPos.column - 1];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                    CheckWalls(piece.GridPosition);
                }
            }

            if (bombPos.column + 1 < BoardItems[bombPos.row].Count)
            {
                var piece = BoardItems[bombPos.row][bombPos.column + 1];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                    CheckWalls(piece.GridPosition);
                }
            }

            if (bombPos.row - 1 >= 0)
            {
                var piece = BoardItems[bombPos.row - 1][bombPos.column];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                    CheckWalls(piece.GridPosition);
                }
            }

            if (bombPos.row + 1 < BoardItems.Count)
            {
                var piece = BoardItems[bombPos.row + 1][bombPos.column];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                    CheckWalls(piece.GridPosition);
                }
            }

            WhenBombInvokeOnBoard?.Invoke();
        }

        private void CheckWalls(GridPosition wallPos)
        {
            if (wallPositions.ContainsKey(wallPos))
                wallPositions.Remove(wallPos);

            if (wallPositions.Count < 1)
            {
                WhenAllWallsDemolished?.Invoke();
            }
        }
    }
}