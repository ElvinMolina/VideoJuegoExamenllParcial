using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGolpeEnemigo : MonoBehaviour
{
    public int hp;
    public int dañoPuño;
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
        if(other.gameObject.tag == "GolpeImpactoEnemigo")
        {
            if (anim != null)
            {
               anim.Play("AnimacionAlienGrande");
           }

            hp -= dañoPuño;
        }

        if(hp <= 0)
        {
           Destroy(gameObject);
        }
    }
}
