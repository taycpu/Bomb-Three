using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Core
{
    [CreateAssetMenu(menuName = "Cpu/Create LevelStarMapping", fileName = "LevelStarMapping", order = 0)]
    public class LevelStarMapping : ScriptableObject
    {
        public List<int> starAmount;

        public void Clear()
        {
            for (int i = 0; i < starAmount.Count; i++)
            {
                starAmount[i] = 0;
            }
        }
    }
}