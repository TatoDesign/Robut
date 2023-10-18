using UnityEngine;

public class Comer : MonoBehaviour
{
    public string tagName = "AreaTag";
    public float speed = 10f;
    public bool puedeComer = false;
    private Transform target;
    private bool colisionConProyectil = false;
    private bool colisionConProyectil1 = false;
    void Start()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(tagName);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            puedeComer = false;
            GetComponent<RobutController>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            puedeComer = true;
            GetComponent<RobutController>().enabled = false;
        }

        if (target != null && puedeComer)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0f; // Ignorar el eje Y
            if (direction.magnitude > 0.1f)
            {
                direction.Normalize();
                GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            }

  
     
        }
    }

    // Método para detectar colisiones con objetos que tengan el tag "ProyectilTag"
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ProyectilTag"))
        {
            colisionConProyectil = true;
        }
        if(gameObject.CompareTag(tagName))
        {
            Debug.Log("tocó");
        }
        if (collision.gameObject.CompareTag("ProyectilTag") && gameObject.CompareTag(tagName))
        {
            Saltar();
        }
    }
    public void Saltar()
    {
        Debug.Log("Saltó");
        Vector3 newPosition = transform.position;
        newPosition.y = target.position.y;
        GetComponent<Rigidbody>().MovePosition(newPosition);
    }
    // Método para detectar el fin de colisiones con objetos que tengan el tag "ProyectilTag"
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ProyectilTag"))
        {
            colisionConProyectil = false;
        }
    }
}
