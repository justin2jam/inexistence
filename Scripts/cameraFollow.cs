using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    public GameObject player;
    public bool bounds;
    float posX;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public float offset = 0;
    PlayerHealth playerHealth;
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y, transform.position.z);
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp(player.transform.position.y, minCameraPos.y, maxCameraPos.y), transform.position.z);    //Sets a min and max for camera position
        }
        

    }
    void dead()
    {
        transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y, transform.position.z);
        if( playerHealth.currentHealth<=0 && !playerHealth.isDead)
            Camera.main.orthographicSize = 4;
    }
}
