using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScore : MonoBehaviour
{
    Text text;
    public static int diceScore;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = diceScore.ToString();
    }
}
