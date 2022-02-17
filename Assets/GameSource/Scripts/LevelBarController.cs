using System;
using System.Collections;
using System.Collections.Generic;
using Prototype.Core;
using Prototype.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBarController : MonoBehaviour
{
    [SerializeField] private LevelBar levelBarPrefab;
    [SerializeField] private LevelStarMapping starMapping;

    [SerializeField] private int levelCount;
    [SerializeField] private FloatVariable levelIndex;
    [SerializeField] private Transform contentPanel;
    [SerializeField] private string levelName;

    private void Start()
    {
        GenerateLevelBars();
    }

    public void GenerateLevelBars()
    {
        for (int i = 0; i < levelCount; i++)
        {
            var levelBar = Instantiate(levelBarPrefab, contentPanel);
            var i1 = i;
            levelBar.SetStars(starMapping.starAmount[i]);
            levelBar.LoadButton($"{levelName} {i + 1}", () =>
            {
                levelIndex.Value = i1;
                SceneManager.LoadScene(1);
            });
            if (i == 0)
            {
                levelBar.UnlockPlayButton();
            }
            else
            {
                if (starMapping.starAmount[i - 1] > 0)
                {
                    float currentLoop = (i + 1) * 2;
                    currentLoop /= 5f;
                    var coefficient = (currentLoop * i) ;
                    if (currentLoop % 2f == 0)
                    {
                        int totalStar = 0;
                        for (int j = 0; j < i; j++)
                        {
                            totalStar += starMapping.starAmount[j];
                        }

                        if (totalStar >= coefficient)
                        {
                            levelBar.UnlockPlayButton();
                        }
                        else
                        {
                            levelBar.LockedMode();
                        }
                    }
                    else
                    {
                        levelBar.UnlockPlayButton();
                    }
                }
                else
                {
                    levelBar.LockedMode();
                }
            }
        }
    }
}