//Kütüphaneler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steveman : MonoBehaviour
{
    // Start is called before the first frame update
    //oyunun ilk ekran güncellemesi geldiğinde bir kere çalışır.Bir daha çalışmaz
    SpriteRenderer Stevmen_render;// değişkendir ve bomboş 
    float hareket_deger = 0.1f;
    Transform Steveman_tarnsform;

//Unity'i geliştirenle Unityde fiziki görselliği sağlamak adına kendileri için sınıflar tasarlanmıştır.
//Bu sınıfların toplandığı ana sınıfa MonoBehaviour adını verilmiştir.

    void Start()

    {
          //SpriteRender'ı karakjterlerimizin özeliğini bulacağız.
        Stevmen_render = GetComponent<SpriteRenderer>();
        Steveman_tarnsform = GetComponent<Transform>();
 
       string isim = "Goktuğ Ari";
       Debug.Log(isim);
       Debug.Log("Bu start Calisir ");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Stevmen_render.flipX = false;
            Steveman_tarnsform.position = new Vector2(Steveman_tarnsform.position.x - hareket_deger,
                                                        Steveman_tarnsform.position.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Stevmen_render.flipX = true;
            Steveman_tarnsform.position = new Vector2(Steveman_tarnsform.position.x + hareket_deger,
                                                        Steveman_tarnsform.position.y);
        }




    }


}
