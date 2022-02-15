using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Core
{
    public class Board : MonoBehaviour
    {
        public List<List<Piece>> BoardItems => boardItems;
        private List<List<Piece>> boardItems = new List<List<Piece>>();

        private int row;
        private int column;
        private int wall;


        public void AddRow()
        {
            boardItems.Add(new List<Piece>());
        }

        public void AddColumn(int row, Piece piece)
        {
            boardItems[row].Add(piece);
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


        public void OnBombExplodeInBoard(GridPosition boardPos)
        {
            if (boardPos.column - 1 >= 0)
            {
                var piece = BoardItems[boardPos.row][boardPos.column - 1];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                }
            }

            if (boardPos.column + 1 < BoardItems[boardPos.row].Count)
            {
                var piece = BoardItems[boardPos.row][boardPos.column + 1];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                }
            }

            if (boardPos.row - 1 >= 0)
            {
                var piece = BoardItems[boardPos.row - 1][boardPos.column];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                }
            }

            if (boardPos.row + 1 < BoardItems.Count)
            {
                var piece = BoardItems[boardPos.row + 1][boardPos.column];
                if (piece.HaveWall())
                {
                    piece.DemolishWall();
                }
            }
        }
    }
}