using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    // public weapon

    //Logic
    public int money;
    public int experience;

    // Save state
    /*
    * INT PreferedSkin
    * INT Money
    * INT Experience
    * INT WeaponLevel
    */
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += money.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //  "0|10|15|2" 
        /*
        * 0
        * 10
        * 15
        * 2
        */

        // Change Player Skin
        money = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        // Change Weapon Level 
        Debug.Log("Load State");
    }
}
