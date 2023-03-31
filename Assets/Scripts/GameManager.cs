using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    //Zmienna Live
    [SerializeField]
    private int live;

    public int Live
    {
        get
        {
            return live;
        }
        private set
        {
            Debug.Log("Live zwiekszony");
            live = value;
        }
    }

    //Dodanie Live do zmiennej
    public void AddLive(int liveToAdd)
    {
        Live += liveToAdd;
    }


    //Zmienna Mana
    [SerializeField]
    private int mana;

    public int Mana
    {
        get
        {
            return mana;
        }
        private set
        {
            Debug.Log("Mana zwiekszona");
            mana = value;
        }
    }

    //Dodanie Mana do zmiennej
    public void AddMana(int manaToAdd)
    {
        Mana += manaToAdd;
    }

    //Zmienna Experience
    [SerializeField]
    private int experience;

    public int Experience
    {
        get 
        { 
            return experience; 
        }
        private set 
        {
            Debug.Log("Exp zwiekszony");
            experience = value; 
        }
    }

    //Dodanie Experience do zmiennej
    public void AddExperience(int experienceToAdd)
    {
        Experience += experienceToAdd;
    }

    

    //Po "wybudzeniu" obiektu
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Subskrybcja metody przechodzenia na inn¹ scenê
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    


    //Metoda wywo³ywana po przejœciu na inn¹ scenê
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        
        
            
    }

    //Metoda wywo³ywana po uruchomieniu nowej gry
    public void NewGame()
    {

    }

    

    //Metoda wywo³ywana po przegranej
    private void GameOver()
    {


    }


}
