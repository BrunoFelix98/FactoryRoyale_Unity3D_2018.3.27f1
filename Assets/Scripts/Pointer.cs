using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform player;
    public Transform minimap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position;
        Vector3 minimapPosition = new Vector3(minimap.position.x - 5, minimap.position.y - 2, 0);
        transform.position = new Vector3(playerPosition.x / 63, playerPosition.y / 77.5f, 0);
        transform.position = minimapPosition + transform.position;
    }
}
