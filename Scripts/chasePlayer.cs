using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {
    public Transform player;
    public GameObject target;
    public float moveSpeed = 4;
    public float maxDist = 10;
    public float minDist = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(player);

        //if (Vector2.Distance(transform.position, player.position) <= minDist)
        //{
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            
        if (Vector2.Distance(transform.position,player.position) <= maxDist)
        {
            //Debug.Log("Trigger movment");
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        //}

    }
}
