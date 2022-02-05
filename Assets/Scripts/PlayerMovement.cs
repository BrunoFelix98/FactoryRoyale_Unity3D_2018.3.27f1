using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float h;
    public float v;
    Rigidbody2D playerBody;

    public GameObject Journalist;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        Journalist = GameObject.Find("Journalist");
    }
    public float speed = 0.1f;
    public Transform obj;


    // Update is called once per frame
    public void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        /*if (Mathf.Abs(h) < 0.1f && Mathf.Abs(v) < 0.1f)
            return;

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed;

        obj.transform.position += tempVect;*/

        playerBody.velocity = new Vector2(h * speed, v * speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Journalist")
        {
            SceneManager.LoadScene("Journalist");
        }
    }
}
