using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombText : MonoBehaviour, IListener
{
    [SerializeField] private FloatVariable bombCount;
    [SerializeField] private Text text;

    private void Start()
    {
        bombCount.Register(this);
    }

    public void Raise()
    {
        if (text == null)
            bombCount.RemoveMe(this);
        else
        {
            text.text = bombCount.Value.ToString();
        }
    }
}