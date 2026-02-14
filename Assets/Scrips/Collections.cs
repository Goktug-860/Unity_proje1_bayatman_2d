using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;// UI'dan metin düzenlemesi yapar
using UnityEngine.UI;//Arayüz kütüphane ulaşımı sağlar
using UnityEngine.SceneManagement;//DSahne yöneticisi

public class Collections : MonoBehaviour
{
    int health = 3;
    int point = 0;
    [Header("Arayüz nesnelertim")]
    [SerializeField] TMP_Text coin_text;
    [SerializeField] GameObject[] HealthImages;//Kalp listem
    Image[] HealthImages_renderer;
    [SerializeField] AudioSource CoinSound; //Kalp listesindeki her bir resim.
    // Triger'ları çalıştırmak için OnTrigger komutu kullanılır

    void Start()
    {
        //Image'lerimiz GameObject olan Health'lerden alma işlemi yapacağız.
        HealthImages_renderer = new Image[HealthImages.Length];//Lenght = uzunluk
        for (int i = 0; i <HealthImages.Length; i++)
        {
            HealthImages_renderer[i] = HealthImages[i].GetComponent<Image>();
        }
    }




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinSound.Play();
            point += 10;
            coin_text.text = "Coin:" + point.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
    void Update()
    {
        if(health == 2)
        {
            HealthImages_renderer[2].color = new Color(0.1f,0.1f,0.1f);
            
        }
        if(health == 1)
        {
            HealthImages_renderer[1].color = new Color(0.1f,0.1f,0.1f);
            
        }
        if(health == 0)
        {
            HealthImages_renderer[0].color = new Color(0.1f,0.1f,0.1f);
            SceneManager.LoadScene("game_over");
            
        }
    }
}


