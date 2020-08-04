using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager _UIManager;
    public UIManager _UIManagerProperty
    {
        set
        {
            _UIManager = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUIManagerSet()
    {
        UIManager.instance.RequestScreen("CurrencyCounterScreen", true);
        UIManager.instance.RequestScreen("InventoryScreen", true);
    }

    public void OnOpenStore()
    {
        _UIManager.RequestScreen("StoreScreen", true);
    }

    public void OnCloseStore()
    {
        _UIManager.RequestScreen("StoreScreen", false);
    }
}
