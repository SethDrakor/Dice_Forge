using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public BattleState state;

    public Camera cameraStart;
    public Camera cameraDice;
    public Camera cameraTemple;
    public Camera cameraBattle;
    public Camera cameraMap;
    public Dice dice;

    public void Throw()
    {
        GameObject[] dices = GameObject.FindGameObjectsWithTag("Dice");
        foreach(GameObject dic in dices){
            dice = dic.GetComponent<Dice>();
            dice.RollDice();
        }
    }
}
