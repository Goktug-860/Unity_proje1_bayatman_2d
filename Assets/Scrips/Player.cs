using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Görsel hareket için SpriteRenderer

    SpriteRenderer player_sprite;
    Rigidbody2D player_rig;
    Animator player_animator;//Kraktere animator ekledik ve seçtik
    bool walking = false;
    [Header("Karekter yönlendirme")]//Editöre başlık oluştururuz
    //SerializeField private olanama Editor'deInspector penceresinde görünmeyi sağlayankod.
    [SerializeField] float speed = 0.2f;
    [SerializeField] float jump_power = 1.0f;
    [SerializeField] bool jumping = false;
    [SerializeField] bool ground = true;
    [Header("Spawn Noktasi")]
    [SerializeField] Transform SpawnPoint;//doğum noktası
    float direction = 1.0f;



    void Start()
    {
        //BU karakterin başladığı andan Pozisyonu al ve Spawn Noktasına eşitle,
        this.gameObject.transform.position = SpawnPoint.position;
        player_sprite = GetComponent<SpriteRenderer>();
        player_rig = GetComponent<Rigidbody2D>();
        player_animator=GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //SetBool -> Animatordeki değişkemi ayarlar
        //Çift tırnakal yazılan animatordeki virgül sonrası koddaki bool değişkenidir.
        player_animator.SetBool("walking", walking);
        player_animator.SetBool("ground", ground);
        player_animator.SetTrigger("jumping");

        if (walking == true)
        {
            player_rig.velocity = new Vector2(speed * direction, player_rig.velocity.y);
        }
        if(jumping == true)
        {
            player_rig.velocity = new Vector2(player_rig.velocity.x, jump_power  * Time.deltaTime);
            ground = true;
            jumping = false;
        }
    }


    // Karakter eylemlerinin kontrol edildiği yerdir
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
        {
            player_sprite.flipX = true;
            direction = -3.0f;
            walking = true; 
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player_sprite.flipX = false;
            direction = 3.0f;
            walking = true; 
        }
        }
        else
            {
                walking = false;
            }
        if(Input.GetKeyDown(KeyCode.UpArrow) && ground == true)
        {
            jumping = true;
            ground = false;
        }    

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Enemy")
        {
            this.gameObject.transform.position = SpawnPoint.position;
        }
    }
}
