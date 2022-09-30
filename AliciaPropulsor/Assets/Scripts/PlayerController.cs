using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;

    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //obtengo datos de movimiento en el mando
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        

    }

    private void FixedUpdate()
    {
        //a�adir fuerza a BODY a la derecha
        body.AddForce(direction, ForceMode2D.Impulse);
    }

    
}
