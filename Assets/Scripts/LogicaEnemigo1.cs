using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo1 : MonoBehaviour
{
    public int hp;
    public int da�oPu�o;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)
            {
                anim.Play("AnimacionAlienNegro");
            }

            hp -= da�oPu�o;
        }

        if(hp <= 0)
        {
           Destroy(gameObject);
        }
    }
}
