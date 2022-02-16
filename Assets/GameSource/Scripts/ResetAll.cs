using System.Collections;
using System.Collections.Generic;
using Prototype.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAll : MonoBehaviour
{
    [SerializeField] private FloatVariable levelIndex;
    [SerializeField] private LevelStarMapping levelStarMapping;

    public void Reset()
    {
        levelIndex.Value = 0;
        levelStarMapping.Clear();
        SceneManager.LoadScene(0);
    }
}