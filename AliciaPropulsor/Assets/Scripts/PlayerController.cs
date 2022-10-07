using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;

    [SerializeField]
    TextMeshProUGUI labelFuel;
    float gasolinaActual = 100f;

    [SerializeField]
    GameObject prefabParticles;


    //Crear una variable de tipo float gasolinaActual
    //Inicialmente tendrá 100
    
    //Update se va a ir gastando
    //Time.deltaTime


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //obtengo datos de movimiento en el mando
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        gasolinaActual = gasolinaActual - 5f * Time.deltaTime;
        labelFuel.text = gasolinaActual.ToString("00.00") + "%";

        if (gasolinaActual <= 0f)
        {
            this.enabled = false;
        }

    }

    private void FixedUpdate()
    {
        //añadir fuerza a BODY a la derecha

        body.AddForce(direction, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel" && gasolinaActual > 0)
        {
            gasolinaActual = gasolinaActual + 10f;
            collision.gameObject.SetActive(false);
            if (gasolinaActual > 100f)
            {
                gasolinaActual = 100f;
            }
            collision.enabled = false;

            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject, 0.2f);
        }



    }
    public void ClickEnBoton()
    {
        Debug.Log("Ha clickado");
        SceneManager.LoadScene(0); 
    }
}



        //Crear un objeto que al colisionar con el sucedan dos cosas
        //Añadir gasolina
        //Destruir el objeto recogido -> Destroy //SetActive (false)
        //Parecido a recpger monedas.

    
 
