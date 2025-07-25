using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
//using static UnityEditor.Timeline.TimelinePlaybackControls;


public class SheepHandler : Singleton<SheepHandler>, IManager
{
    //public ScoreSystem scoreSystem;
    
    public List<Sheep> sheeps;
    private Sheep _targetSheep;

    //public SheepSpawnConfig config;

    [HideInInspector]   public int NumberSheepFlagged = 0;
    [HideInInspector]   public bool finishedFlagg = false;
    private bool DieFlagged = false;
    public Vector3[] bornPos;

    public void Initialize()
    {
        //print("a");
        //sinh cuu
        for (int i = 0; i < sheeps.Count; i++)
        {
            sheeps[i] = GameObject.Instantiate(sheeps[i], bornPos[i], Quaternion.identity);
            sheeps[i].SetUp();
        }

        //gan cuu
        _targetSheep = sheeps[0];

    }
    public void UpdateManager()
    {

        CheckSheepsDied();
        CharterInputControl();
        CheckSheepsFlagged();
        //dieu khien cuu duoc chon

        //print(targetSheep.sheepGameObject.transform.position);
    }

    // control the sheep
    public void CharterInputControl()
    {
        _targetSheep.Swimming();
        //Moving Left Right
        if (Input.GetKey(KeyCode.A))
            {
            _targetSheep.Move("left");
            }
        if (Input.GetKey(KeyCode.D))
            {
            _targetSheep.Move("right");
            }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _targetSheep.Stop();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _targetSheep.Stop();
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {

            _targetSheep.Jump();
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
        _targetSheep = sheeps[sheepNumber];
    }


    //Check if sheep hit the Flag
    public void CheckSheepsFlagged()
    {
        if( NumberSheepFlagged == 3&& !finishedFlagg)
        {
            
            
            //scoreSystem.CalculateScore();
            print("gameComplete");
            finishedFlagg = true;
            GameManagement.Instance.EndGame();
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

    
}
