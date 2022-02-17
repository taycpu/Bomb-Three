using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Text header;
    [SerializeField] private List<Image> stars;

    public void Configure(string text, int star)
    {
        header.text = text;
        for (int i = 0; i < star; i++)
        {
            stars[i].gameObject.SetActive(true);
        }
    }


}