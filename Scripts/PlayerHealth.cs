using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{ 
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.2f);     // The colour the damageImage is set to, to flash.
    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    public Text loseText;
    public Text winText;
    public bool isDead;                                                // Whether the player is dead.
    bool damaged;
    public GameObject Healthbar;
    public GameObject restart;
    public AudioSource GameMusic;
    public AudioSource DeathMusic;
    public AudioSource dead;
    // Use this for initialization
    void Start ()
    {
        loseText.text = "";
        restart.SetActive(false);
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else if (isDead == false)
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();

        if (currentHealth == 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        GameMusic.Stop();
        DeathMusic.Play();
        dead.Play();
        Healthbar.SetActive(false);
        isDead = true;
        damageImage.color = new Color(1f, 0f, 0f, 0.6f);
        //anim.SetTrigger("Die");
        anim.Play("Hero_Dead");
        loseText.text = "YOU DIED!";
        restart.SetActive(true);
        playerAudio.clip = deathClip;
        playerAudio.Play();
        Camera.main.orthographicSize = 4;
        playerMovement.enabled = false;
    }
}
