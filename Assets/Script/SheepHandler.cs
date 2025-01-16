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
            targetSheep = sheeps[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetSheep = sheeps[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetSheep = sheeps[2];
        }

    }

    //Check if sheep hit the Flag
    public void CheckSheepsFlagged()
    {
        if( NumberSheepFlagged == 3)
        {
            print("gameComplete");
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
