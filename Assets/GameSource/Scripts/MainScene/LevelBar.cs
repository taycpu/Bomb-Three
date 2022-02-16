using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Prototype.UI
{
    public class LevelBar : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button lockedButton;
        [SerializeField] private Text text;
        [SerializeField] private List<Image> stars;

        public void LoadButton(string name, UnityAction buttonAct)
        {
            text.text = name;
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(buttonAct);
        }

        public void UnlockPlayButton()
        {
            lockedButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }

        public void LockedMode()
        {
            lockedButton.gameObject.SetActive(true);
            playButton.gameObject.SetActive(false);
        }

        public void SetStars(int starCount)
        {
            for (int i = 0; i < starCount; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
        }
    }
}