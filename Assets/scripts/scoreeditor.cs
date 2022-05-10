using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreeditor : MonoBehaviour
{

     [SerializeField] int score;
     [SerializeField] int level;
    [SerializeField] Text scorefeild;
    [SerializeField] Text levelfeild;
      [SerializeField] Text nameTxt;
    // Start is called before the first frame update
    void Start()
    {
         score = PersistentData.Instance.GetScore();
          level = SceneManager.GetActiveScene().buildIndex;
           
Debug.Log(score);
         DisplayScore();
          DisplayLevel();
             DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void UpdateScore(int points)
    {
        score += points;
        Debug.Log("score" + score);
        //display score
        DisplayScore();
        PersistentData.Instance.SetScore(score);
        
    }

    public void DisplayScore()
    {
        scorefeild.text = "Score: " + score;
    }

       public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelfeild.text = "Level " + levelToDisplay;
    }

       public void DisplayName()
    {
      nameTxt.text = "Player: " + PersistentData.Instance.GetName();
    }


}
