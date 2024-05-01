using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    // player prefs

    private const string POINTS = "Points";
    public int puntuation;
   
    // player controller reference

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }


    // for the first data to save, i will save the last player puntuation, and in main menu i will show in a panel the last puntuation 
    // I will save the points every time that you get one point ( when a enemy dies ) and i will load it on the menu on clic the button to check the puntuation
    // i will save this information with playerPrefs

    public void Save ()
    {
        int points = playerController.points;
        PlayerPrefs.SetInt(POINTS, points);


    }
    public void Load()
    {
        if (PlayerPrefs.HasKey(POINTS))
        {
            int points = PlayerPrefs.GetInt(POINTS);
            points = puntuation;

        }
        else
        {
            puntuation = 0;
            Debug.LogError("there is no puntuation");

        }
    }






}
