using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    public float goal = 10;
    float count = 0;
    public Text winText;
    public GameObject restart;
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Win();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            GameObject.Destroy(other.gameObject);
            count += 1;
        Debug.Log(count);
    }
    private void Win()
    {
        winText.text = "You Win!";
        restart.SetActive(true);
    }
}
