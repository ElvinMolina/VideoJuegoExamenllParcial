using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPiesSoldado : MonoBehaviour
{

    public PlayerSoldado soldadoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        soldadoPlayer.puedoSaltar = true;

    }

    private void OnTriggerExit(Collider other)
    {
        soldadoPlayer.puedoSaltar = false;
    }
}
