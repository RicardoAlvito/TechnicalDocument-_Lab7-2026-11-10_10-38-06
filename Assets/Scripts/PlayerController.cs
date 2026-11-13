using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float groundCheckRadius;
    public float horizantallnput;
    private bool isGrounded = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody rb;
    private PlayerFeedback playerFeedback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //Congela a rotação dos eixos X, Y e Z
        playerFeedback = GetComponent<PlayerFeedback>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Lê o input do eixo horizontal
        horizantallnput = Input.GetAxisRaw("Horizontal");
        //Deteta se o butão "Jump" foi premido quando o "Player" estiver no chão
        if (Input.GetAxisRaw("Jump") == 1)
        {
            if (isGrounded == true)
            {
                
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {   //Verificar se o jogador está a tocar na camada do chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        //velocidade horizontal
        Vector3 Velocity = rb.linearVelocity;
        float targetVelX = horizantallnput * moveSpeed;
        float newVelx = Mathf.MoveTowards(Velocity.x,targetVelX,50f*Time.fixedDeltaTime);
        //Aplica uma velocidade maxima no eixo do Y mas matedo as fisicas
        rb.linearVelocity = new Vector3(Mathf.Clamp(newVelx, -maxSpeed, maxSpeed), Velocity.y, 0f);
    }

    void Jump() { 
        //Resenta a velocidade antes de salta "Jump" para ter sempre a mesma altura
    Vector3 VelocityLRd = rb.linearVelocity;
        VelocityLRd.y = 0f;
        rb.linearVelocity = VelocityLRd;
        //Addiciona força vertical para não ser um teletransporte  
        rb.AddForce(transform.up * jumpForce);
        if (playerFeedback != null)
        {
            playerFeedback.PlayJump();//13/11/2026 23:22

        }
    }
}

