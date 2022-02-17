using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Core
{
    public class LevelReader : MonoBehaviour
    {
        [SerializeField] private TextAsset[] levelFiles;


        

        public string[][] GetLevelMap(int index)
        {
            string[] Lines = levelFiles[index].text.Split('\n');
            string[][] Columns = new string[Lines.Length][];
            for (int i = 0; i <= Lines.Length - 1; i++)
            {
                Columns[i] = Lines[i].Split(',');
            }

            return Columns;
        }
    }
}
