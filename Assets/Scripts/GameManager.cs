using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Intro, Jeu, Dés, Temple }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public int nbPlayer;
    public bool victoire;
    public bool defaite;


    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if(GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Player()
    {
        nbPlayer = 2;
    }

    public void Victoire()
    {

    }

    public void Defaite()
    {

    }

    public void PremierJoueur()
    {

    }

    public void FaveurDesDieux()
    {

    }

    public void Forger()
    {

    }

    public void Exploit()
    {

    }

    public void Chasser()
    {

    }
}
