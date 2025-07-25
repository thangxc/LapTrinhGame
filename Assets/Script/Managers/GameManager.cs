using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void Initialize();
    void UpdateManager(); // Call in Unity's Update() if necessary
}

public abstract class BaseManager : Singleton<BaseManager>, IManager
{
    public virtual void Initialize() { }
    public virtual void UpdateManager() { }
}

public class GameManager : Singleton<GameManager>
{
    private List<IManager> managers = new List<IManager>();

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        //managers.Add(new InventoryManager());
        managers.Add(FindObjectOfType<SheepHandler>());
        managers.Add(FindObjectOfType<ButtonController>());
        // Add other managers here

        foreach (var manager in managers)
        {
            manager.Initialize();
        }
    }

    private void Update()
    {
        foreach (var manager in managers)
        {
            manager.UpdateManager();
        }
    }
}
