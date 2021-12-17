using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
   Rigidbody rb;
   public Text ressourceText;
   private int ressource;
   bool hasLanded;
   bool thrown;
   Vector3 initPos;
   public float torque;

   public int diceValue;

   public DiceSide[] diceSides;
   
   private void Start(){
        rb = GetComponent<Rigidbody>();
        ressource = 0;
        RessourceText();
        initPos = transform.position;
        rb.useGravity = false;    
   }


    private void Update(){
        /*if(Input.GetKeyDown(KeyCode.T)){
            RollDice();
        }*/

        if(rb.IsSleeping() && !hasLanded && thrown){
            hasLanded = true;
            rb.useGravity = true;
            rb.isKinematic = true;

            SideValueCheck();
        }
        /*else if(rb.IsSleeping() && hasLanded && diceValue == 0){
            Debug.Log("RollAgain");
            RollAgain();
        }*/
    }

    public void RollDice(){

        if(!thrown && !hasLanded){
            Debug.Log("RollDice");
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0,1000.0f), Random.Range(0, 1000.0f), Random.Range(0, 1000.0f));

        }
        else if(thrown && hasLanded){
            Reset();
        }
    }

    void Reset(){
        Debug.Log("Reset");
        transform.position = initPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    /*void RollAgain(){
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0,500), Random.Range(0,500), Random.Range(0,500));
    }*/

    void SideValueCheck(){
        diceValue = 0;
        foreach(DiceSide side in diceSides){
            
            if(side.OnGround()){
                diceValue = side.sideValue;
                Debug.Log("Le dés est tombé sur " + diceValue + " !");
                RessourceText();
            }
        }
    }

    void RessourceText()
    {
        ressourceText.text = "Ressource: " + ressource.ToString();
        Debug.Log("RessourceText");
    }

}
