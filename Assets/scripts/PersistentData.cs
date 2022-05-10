using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//lab
public class PersistentData : MonoBehaviour
{

    [SerializeField] int playerScore ;
    [SerializeField] string playerName;
 [SerializeField] float difficulty;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";
        difficulty = 1;
    }
 

    public void SetScore(int s)
    {
        playerScore = s;
    }


    public int GetScore()
    {
        return playerScore;
    }


    public void SetName(string s)
    {
        playerName = s;
    }

 public string GetName()
    {
        return playerName;
    }



    public void Setdifficulty(float s)
    {
        difficulty = s;
    }

 public float Getdifficulty()
    {
        return difficulty;
    }





}
