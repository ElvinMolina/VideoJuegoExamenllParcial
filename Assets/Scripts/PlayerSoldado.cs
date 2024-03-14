using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerSoldado : MonoBehaviour
{
    public float velocidadMovimiendo = 5.0f;
    public float velicidadRotacion = 200.0f;
   
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8.0f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;

    public bool atacando;
    public bool avance;
    public float impulso = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
     
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiendo;
        velocidadAgachado = velocidadMovimiendo * 0.5f;
      
    }

    void FixedUpdate()
    {

        if (!atacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velicidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiendo);
        }
       
        if (avance)
        {
            rb.velocity = transform.forward * impulso;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !atacando)
        {
            anim.SetTrigger("Golpeo");
            atacando = true;
        }

        //anim.SetFloat("VelX", x);
        //anim.SetFloat("VelY", y);


        if(puedoSaltar)
        {
            if (!atacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("Salte", true);
                    rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("Agachado", true);
                    velocidadMovimiendo = velocidadAgachado;
                }
                else
                {
                    anim.SetBool("Agachado", false);
                    velocidadMovimiendo = velocidadInicial;
                }
            }
            
            anim.SetBool("TocoSuelo", true);

        }
        else
        {
            EstoyCayendo();
        }
    }


    public void EstoyCayendo()
    {
        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Salte", false);
    }


    public void DejarGolpe()
    {
        atacando = false;
    }

    public void Avanzo()
    {
        avance = true;
    }

    public void dejoAvance()
    {
        avance = false;

    }
}
