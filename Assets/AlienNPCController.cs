using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;

    public int distanciaMetrosActivacion = 15;
    public int velocidadCorriendo = 3;
    public float distanciaAtaque = 1.3f;
    public float multiplicadorDanio = 1.0f;

    // NPC
    public int rutina;
    public float cronometro;
    public float distancia;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Soldado");
    }

    // Update is called once per frame
    void Update()
    {
        if (atacando)
        {
            AnimatorStateInfo animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
            float NTime = animStateInfo.normalizedTime;

            // Si la animación ya terminó, regresar variables a falso
            if (NTime > 1.0f)
            {
                anim.SetBool("Attack", false);
                atacando = false;
            }
        }

        Grounded();
        Comportamiento();
        //Jump();
        //Move();
    }

    private void Comportamiento()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > distanciaMetrosActivacion)
        {
            anim.SetBool("Run", false);
            CaminarPorElMapa();
        }
        else
        {
            SeguirAPersonaje();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
            this.grounded = true;
        else
            this.grounded = false;

        this.anim.SetBool("Jump", !this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.04f;
        this.anim.SetFloat("Vertical", verticalAxis);
        this.anim.SetFloat("Horizontal", horizontalAxis);
    }

    private void SeguirAPersonaje()
    {
        distancia = Vector3.Distance(transform.position, target.transform.position);
        bool estaSoloPersiguiendo = distancia > distanciaAtaque && !atacando;

        if (estaSoloPersiguiendo)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            anim.SetBool("Walk", false);

            anim.SetBool("Run", true);

            // x3 Velocidad corriendo
            transform.Translate(Vector3.forward * velocidadCorriendo * Time.deltaTime);

            anim.SetBool("Attack", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);

            anim.SetBool("Attack", true);

            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

            atacando = true;
        }

    }

    public void FinalizarAtaque()
    {
        anim.SetBool("Attack", false);
        atacando = false;
    }

    private void CaminarPorElMapa()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= (rutina == 2 ? 7 : 4))
        {
            rutina = UnityEngine.Random.Range(0, 2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                anim.SetBool("Walk", false);
                break;
            case 1:
                grado = UnityEngine.Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                anim.SetBool("Walk", true);
                break;
        }
    }

}
