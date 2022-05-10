using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_fire : MonoBehaviour
{
 public Animator aniamator; 
    public Transform position;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("statrt");
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("left ctrl")){
           aniamator.SetBool("attacking", true);
Instantiate(projectile, position.position, Quaternion.identity);
 aniamator.SetBool("attacking", false);
        }
        
    }
}

