using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prototype.Core
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private Piece piecePrefab;
        [SerializeField] private Transform startPos;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Board board;
        [SerializeField] private GameCamera gameCam;

        [SerializeField] private LevelReader levelReader;
        [SerializeField] private FloatVariable levelIndex;
        [SerializeField] private FloatVariable bombAmount;

        private int wallCount;
        private string[][] map;
        private int row, column;

        private void Start()
        {
            SetBoardSettings(levelReader.GetLevelMap(levelIndex.Value));
            GenerateBoard();
            SetCam();
            SetBombAmount();
            board.FinishBuilding(row, column, wallCount);
        }

        public void SetBombAmount()
        {
            bombAmount.Value = wallCount + 2;
        }

        public void SetBoardSettings(string[][] map)
        {
            this.map = map;
            row = map.Length;
            column = map[0].Length;
        }


        [ContextMenu("Generate Board")]
        public void GenerateBoard()
        {
            ClearBoard();
            for (int i = 0; i < row; i++)
            {
                board.AddRow();
                for (int j = 0; j < column; j++)
                {
                    var piece = Instantiate(piecePrefab, board.transform);
                    piece.transform.position = startPos.position + new Vector3(i * offset.x, j * offset.y, 0);
                    piece.SetPosition(i, j);
                    piece.SetBombAction(board.OnBombExplodeInBoard);
                    board.AddColumn(i, piece);

                    SetPieceType(piece, i, j);
                }
            }
        }

        [ContextMenu("Clear Board")]
        public void ClearBoard()
        {
            board.ClearBoard();
        }

        private void SetCam()
        {
            var lastRow = board.BoardItems.Count - 1;
            var lastCell = board.BoardItems[lastRow].Count - 1;


            Collider2D[] cols = new Collider2D[]
            {
                board.BoardItems[0][0].Collider2d,
                board.BoardItems[lastRow][lastCell].Collider2d,
            };
            gameCam.InjectObjects(cols);
        }


        private void SetPieceType(Piece piece, int row, int column)
        {
            switch (map[row][column])
            {
                case "0":

                    break;
                case "1":
                    wallCount++;
                    board.AddWall(piece.GridPosition, piece);
                    piece.PlaceWall();
                    break;
                case "2":

                    break;
            }
        }
    }
}