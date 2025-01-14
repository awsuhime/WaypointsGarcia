using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crush : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FollowWaypoint fwp;
            if (collision.GetComponent<FollowWaypoint>() != null)
            {
                collision.transform.localScale = new(collision.transform.localScale.x, collision.transform.localScale.y / 5, collision.transform.localScale.z);
                fwp = collision.GetComponent<FollowWaypoint>();
                Destroy(fwp);
            }
        }
    }

    
}
