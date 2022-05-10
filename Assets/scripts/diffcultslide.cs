using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffcultslide : MonoBehaviour
{
    
 public Slider mainSlider;

    public void Start()
    {
     
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
Debug.Log(mainSlider.value);
       
float diff = mainSlider.value;
  PersistentData.Instance.Setdifficulty(diff);
       // PersistentData.Instance.(diff);

    }
}
