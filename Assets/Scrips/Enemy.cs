using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [Header("Düşman Hareket noktaları")]
    [SerializeField] Transform start_position;
    [SerializeField] Transform end_position;
    [SerializeField] float speed = 1.0f;

    // GÖRÜNMEYEN DEĞİŞKENLER
    Vector3 CurrentPos;
    Vector3 TargetPos;

    Rigidbody2D enemy_rig;
    Transform position;

    void Start()
    {
        enemy_rig = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
        CurrentPos = start_position.position;
        TargetPos = end_position.position;
    }
  
    void FixedUpdate()
    {
        CurrentPos = position.position;
        if(CurrentPos.x == start_position.position.x || CurrentPos.x < start_position.position.x+0.5f)
        {
            TargetPos = end_position.position;
        }
        else if(CurrentPos.x == start_position.position.x || CurrentPos.x > start_position.position.x-0.5f)
        {
            TargetPos = start_position.position;
        }
        // Hedeflenen konum ile mevcut konum arasındaki mesafeyi ölç.
        Vector3 distance = (TargetPos - CurrentPos).normalized;
        enemy_rig.MovePosition(CurrentPos + distance * Time.deltaTime * speed);
        //Ölçülen bu mesafe kadar ilerle.Rigitbody
    }
}
