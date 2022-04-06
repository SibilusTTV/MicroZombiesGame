using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool isGrounded;
    public LayerMask platformLayerMask;

    private void OnTriggerStay(Collider other)
    {
        isGrounded = other != null && (((1 << other.gameObject.layer) & platformLayerMask) != 0);
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }


}
