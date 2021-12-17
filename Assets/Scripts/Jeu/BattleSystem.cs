using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleState { START, FAVEUR, TURNPLAYER1, TURNPLAYER2, FORGER, EXPLOIT, NEWACTION, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;

    public static BattleSystem Instance
    {
        get { return instance ?? (instance = new GameObject("BattleSystem").AddComponent<BattleSystem>()); }
        private set { instance = value; }
    }


    public BattleState state;

    public Text dialogueText;
    
    public Camera cameraStart;
    public Camera cameraDice;
    public Camera cameraTemple;
    public Camera cameraBattle;
    public Camera cameraMap;

    public Button buttonPlay;

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public Transform player1BattleStation;
    public Transform player2BattleStation;

    public BattleHUD player1HUD;
    public BattleHUD player2HUD;

    public bool emplacementPlayer1 /*{ public get; public set; }*/ = false;
    public bool emplacementPlayer2 /*{ public get; public set; }*/ = false;

    Unit player1Unit;
    Unit player2Unit;

    void Start()
    {
        cameraStart.gameObject.SetActive(true);
        cameraBattle.gameObject.SetActive(false);
        cameraTemple.gameObject.SetActive(false);
        cameraDice.gameObject.SetActive(false);
        cameraMap.gameObject.SetActive(false);
        buttonPlay.gameObject.SetActive(false);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    void Update()
    { 
        if(state == BattleState.START)
        {
            cameraStart.gameObject.SetActive(true);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.FAVEUR)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(true);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.TURNPLAYER1)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(true);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.TURNPLAYER2)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(true);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.FORGER)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(true);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.EXPLOIT)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(true);
        }

        if(state == BattleState.NEWACTION)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.WON)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }

        if(state == BattleState.LOST)
        {
            cameraStart.gameObject.SetActive(false);
            cameraBattle.gameObject.SetActive(false);
            cameraTemple.gameObject.SetActive(false);
            cameraDice.gameObject.SetActive(false);
            cameraMap.gameObject.SetActive(false);
        }
    }

    IEnumerator SetupBattle()
    {
        GameObject player1Go = Instantiate(player1Prefab, player1BattleStation);
        player1Unit = player1Go.GetComponent<Unit>();
        GameObject player2Go = Instantiate(player2Prefab, player2BattleStation);
        player2Unit = player2Go.GetComponent<Unit>();

        //dialogueText.text = "C'est le tour de " + player1Unit.unitName + " !";

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);

        yield return new WaitForSeconds(1f);

        /*state = BattleState.TURNPLAYER1;

        yield return new WaitForSeconds(0.5f);

        state = BattleState.TURNPLAYER2;*/

        buttonPlay.gameObject.SetActive(true);

    }


    public void FaveurButton()
    {
        state = BattleState.FAVEUR;
        dialogueText.text = "Tout les joueurs lancent leurs dés !";
        cameraStart.gameObject.SetActive(false);
        cameraDice.gameObject.SetActive(true);
        Back();
    }

    public void Faveur()
    {

    }

    public void OnForgeButton()
    {
        cameraBattle.gameObject.SetActive(false);
        if(state == BattleState.FORGER)
        {
            cameraTemple.gameObject.SetActive(true);
        }
    }

    public void OnExploitButton()
    {
        cameraBattle.gameObject.SetActive(false);
        if (state == BattleState.EXPLOIT)
        {
            cameraMap.gameObject.SetActive(true);
        }
    }

    public void Back()
    {
        //state == BattleState.TURNPLAYER1;
    }
}
