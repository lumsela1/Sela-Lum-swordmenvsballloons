using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] InputField NameInput;   

public void ToMainMenu(){

SceneManager.LoadScene("MainMenu");
    
}

public void ToHighScore(){

SceneManager.LoadScene("Highscore");
  
}

public void ToOptions(){

SceneManager.LoadScene("Options");
 
}

public void ToInstructions(){

SceneManager.LoadScene("Intructions");
 
}

public void ToGame(){

SceneManager.LoadScene("SampleScene");
int score = 0;
        PersistentData.Instance.SetScore(score);

}

public void GetName(){

string name = NameInput.text;
        PersistentData.Instance.SetName(name);

}



}
