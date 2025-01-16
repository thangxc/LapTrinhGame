using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class SheepHandler : Singleton<SheepHandler>
{
    //public ScoreSystem scoreSystem;
    public List<Vector2> bornPos;
    public List<Sheep> sheeps;
    private Sheep targetSheep;
    public GameObject sheepArrow;
    UnityEngine.Vector2 vectorDir = new UnityEngine.Vector2(0,0);


    [HideInInspector]
    public int NumberSheepFlagged = 0;
    private bool DieFlagged = false;
    

    private void Awake()
    {

        //sinh cuu
        for (int i = 0; i < sheeps.Count; i++)
        { 
            sheeps[i]=GameObject.Instantiate(sheeps[i], bornPos[i], Quaternion.identity);
            sheeps[i].SetUp();
        }

        //gan cuu
        targetSheep = sheeps[0];

    }

   // control the sheep
    public void CharterInputControl()
    {
        targetSheep.Swimming();
        //Moving Left Right
        if (Input.GetKey(KeyCode.A))
            {
                targetSheep.Move("left");
            }
        if (Input.GetKey(KeyCode.D))
            {
                targetSheep.Move("right");
            }

        if (Input.GetKeyUp(KeyCode.A))
        {
            targetSheep.Stop();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            targetSheep.Stop();
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                
                targetSheep.Jump();
            }
        
        //Switching sheep
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            SwitchSheep(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchSheep(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchSheep(2);
        }

    }

    public void SwitchSheep(int sheepNumber)
    {
        ButtonController.Instance.ButtonSheepColor( sheepNumber);
        targetSheep = sheeps[sheepNumber];
    }

    public bool finishedFlagg = false;

    //Check if sheep hit the Flag
    public void CheckSheepsFlagged()
    {
        if( NumberSheepFlagged == 3&& !finishedFlagg)
        {
            
            GameManagement.Instance.EndGame();
            //scoreSystem.CalculateScore();
            print("gameComplete");
            finishedFlagg = true;
        }
    }
    public void CheckSheepsDied()
    {
        if(!DieFlagged)
        foreach (Sheep sheep in sheeps)
        {
            if (sheep.IsDestroyed())
            {
                DieFlagged=true;
                print("GameFail");
            }

        }
    }

    private void Update()
    {

        CheckSheepsDied();
        CharterInputControl();
        CheckSheepsFlagged();
        //dieu khien cuu duoc chon

        //print(targetSheep.sheepGameObject.transform.position);
    }

    
}
