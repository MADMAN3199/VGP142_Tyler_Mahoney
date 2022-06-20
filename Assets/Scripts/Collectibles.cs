using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Collectibles : MonoBehaviour
{

    enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }

    [SerializeField] CollectibleType curCollectible;
    [SerializeField] AudioClip pickupSound;
    public AudioMixerGroup soundFXGroup;

    AudioSource myAudioSource;
    public int ScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        if (!myAudioSource)
            myAudioSource = GetComponent<AudioSource>();

        if (curCollectible == CollectibleType.LIFE)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            switch (curCollectible)
            {
                case CollectibleType.POWERUP:
                    //collision.gameObject.GetComponent<Player>().StartJumpForceChange();
                    //curPlayerScript.score += ScoreValue;
                    GameManager.instance.score += ScoreValue;
                    break;
                case CollectibleType.LIFE:
                    //curPlayerScript.lives++;
                    //curPlayerScript.score += ScoreValue;
                    GameManager.instance.lives++;
                    break;
                case CollectibleType.SCORE:
                    GameManager.instance.score += ScoreValue;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
