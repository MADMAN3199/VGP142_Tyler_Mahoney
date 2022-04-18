using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    enum CollectibleType
    {
        COLLECTIBLE1,
        COLLECTIBLE2,
        COLLECTIBLE3
    }

    [SerializeField] CollectibleType curCollectible;

    //private void Start()
    //{
    //    if (curCollectible == CollectibleType.COLLECTIBLE3)
    //    {
    //        Rigidbody rb = GetComponent<Rigidbody>();
    //        rb.velocity = new Vector3(0, rb.velocity.y);
    //    }
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (curCollectible)
            {
                case CollectibleType.COLLECTIBLE1:
                    break;
                case CollectibleType.COLLECTIBLE3:
                    break;
                case CollectibleType.COLLECTIBLE2:
                    break;
            }
            Destroy(gameObject);
        }
    }
}

