using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour
{
    [SerializeField] int score;
    
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
   // [SerializeField] Text nameTxt;
    [SerializeField] int level;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //PersistentData.Instance.GetScore();
        level = 1;
        //SceneManager.GetActiveScene().buildIndex;
       

        //display score
     //   DisplayScore();
       // DisplayLevel();
       // DisplayName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int addend)
    {
        score += addend;
        Debug.Log("score" + score);
        //display score
        DisplayScore();
        PersistentData.Instance.SetScore(score);

       
    }


    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level " + levelToDisplay;
    }

    public void DisplayName()
    {
        //nameTxt.text = "Hi, " + PersistentData.Instance.GetName();
    }
}
