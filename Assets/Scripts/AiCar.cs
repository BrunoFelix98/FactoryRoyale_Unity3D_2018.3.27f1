using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AiCar : MonoBehaviour
{
    private struct StruckAi
    {
        public Transform AICheckpoints;
        public int idx;
        public Vector2 dirSteer;
        public Quaternion rotationSteer;
    }
    public float moveSpeed;
    public float TurnSpeed;
    private Rigidbody2D rb = null;

    private StruckAi ai;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();


        ai.AICheckpoints = GameObject.FindWithTag("AiCheckpoints").transform;
        ai.idx = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //MoveTowards(Where i want to move from , where i want to move To,speed character to move)
        //AI.AICHECKPOINTS.GETCHILD gets all the childs positions from AICheckpoints tag 
        transform.position = Vector2.MoveTowards(transform.position, ai.AICheckpoints.GetChild(ai.idx).position, moveSpeed * Time.deltaTime);
        Debug.Log(ai.idx);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if it collided with a wall if it did it keeps going
        if (other.CompareTag("AiWalls") == true )
        {
            ai.idx = CalcNextCheckPoint();
        }
        
        Debug.Log(other);


    }
    private int CalcNextCheckPoint()
    {
       //Calculates the next checkpoint 
       //gets the current checkpoint
        int curr = ExtractNumberFromString(ai.AICheckpoints.GetChild(ai.idx).name);
        //the next checkpoint is the current checkpoint + 1
        int next = curr + 1;
        //if the next checkpoint is bigger than the AiCheckpoints childcount 
        //Resets the next checkpoint
        if(next > ai.AICheckpoints.childCount - 1)
        {
            next = 0;
        }
        //Int return Next
        return next;
    }
    private int ExtractNumberFromString(string s1)
    {
        return System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(s1, "[^0-9]", ""));
    }
}
