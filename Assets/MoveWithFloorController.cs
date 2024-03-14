using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloorController : MonoBehaviour
{

    private CapsuleCollider player;

    public string groundName;
    public Vector3 groundPosition;
    public string lastGroundName;
    public Vector3 lastGroundPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (isGrounded)
        //{
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
            {
                GameObject groundedIn = hit.collider.gameObject;

                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    transform.position += groundPosition - lastGroundPosition;
                }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }
        //}
        //else
        //{
        //    lastGroundName = null;
        //    lastGroundPosition = Vector3.zero;
        //}

    }

    //private void OnDrawGizmos()
    //{
    //    player = GetComponent<CapsuleCollider>();
    //    Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    //}

}
