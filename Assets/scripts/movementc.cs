using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementc : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Rigidbody2D seeker;
    [SerializeField] float speedx;
      [SerializeField] float speedy;
      [SerializeField] int growth =1;
      
      [SerializeField] float playerdiff ; 
      // balloon
         [SerializeField] GameObject controller;
   private int level;
    public AudioSource Pop;

   private float stop = 1;
       private Vector3 scaleChange;
   

   
   [SerializeField] Vector2 desiredVelocity;
     [SerializeField] Vector2 steeringVelocity;

  //  [SerializeField] bool shiftPressed = false;

   // Start is called before the first frame update
    void Start()
    {
       Pop.Play();
      
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speedx = 3 *stop;
         speedy = -3 *stop;
        InvokeRepeating("growprojectile", 2.0f, 3f);
        
        playerdiff = PersistentData.Instance.Getdifficulty() + 1;
         scaleChange = new Vector3(.04f/playerdiff, .04f/playerdiff, 0f);
         if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        level = SceneManager.GetActiveScene().buildIndex;
        if(level == 2){
            
             speedx = 9 *stop;
        } 
    }

    void FixedUpdate()
    { 

if(level ==1){
if(rigid.transform.position.x > 6){
speedx=-5 * stop;
}else if (rigid.transform.position.x < -6){
speedx =5 *stop;
      
} 
if(rigid.transform.position.y > 1.5){
speedy=-5 * stop;
}  
rigid.velocity = new Vector2(speedx, rigid.velocity.y);
  
  rigid.velocity = new Vector2(rigid.velocity.x, speedy);

    } else if(level ==2){
     
if(rigid.transform.position.x > 8){
speedx=-9 * stop;
}else if (rigid.transform.position.x < -6){
speedx =9 *stop;
      
} 
if(rigid.transform.position.y < .5){
speedy=5 * stop;
}  else if(rigid.transform.position.y > 3.5) {speedy=-5 * stop;}

rigid.velocity = new Vector2(speedx, rigid.velocity.y);
  
  rigid.velocity = new Vector2(rigid.velocity.x, speedy);
    
    }else{
 
if(Vector2.Distance(transform.position, seeker.position) < 6){
desiredVelocity = ((Vector2)transform.position - seeker.position).normalized;
desiredVelocity *= 8;//maxVelocity;
steeringVelocity = desiredVelocity - rigid.velocity;
rigid.velocity += steeringVelocity;

}

    }

      
        
    }

       void growprojectile()
    {
       
       transform.localScale += scaleChange;
        Debug.Log( growth);     
 growth += 1;
     if(growth>= (12-playerdiff)){
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
         
    }

      private void OnTriggerEnter2D(Collider2D collision)// Check collision with ladder
    {
        
        if(growth <(12-playerdiff)){
      nextslide();
    }

    }

    public void nextslide(){
 
           Pop.Play();
      
       controller.GetComponent<scoreeditor>().UpdateScore((14-growth)*10);

 	  SceneManager.LoadScene(level + 1);
   
    }



}
