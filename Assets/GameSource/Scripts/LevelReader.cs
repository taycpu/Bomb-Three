using UnityEditor;
using UnityEngine;

namespace Prototype.Core
{
    public class LevelReader : MonoBehaviour
    {
        [SerializeField] private Object[] levelFiles;


        [ContextMenu("Read")]
        public void Read()
        {
            string[] Lines = System.IO.File.ReadAllLines(AssetDatabase.GetAssetPath(levelFiles[0]));
            string[][] Columns = new string[Lines.Length][];
            for (int i = 0; i <= Lines.Length - 1; i++)
            {
                Columns[i] = Lines[i].Split(',');
                print(Columns[i][0]);
            }
        }

        public string[][] GetLevelMap(int index)
        {
            string[] Lines = System.IO.File.ReadAllLines(AssetDatabase.GetAssetPath(levelFiles[index]));
            string[][] Columns = new string[Lines.Length][];
            for (int i = 0; i <= Lines.Length - 1; i++)
            {
                Columns[i] = Lines[i].Split(',');
                print(Columns[i][0]);
            }

            return Columns;
        }
    }
}