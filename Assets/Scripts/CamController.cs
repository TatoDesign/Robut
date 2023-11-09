using UnityEngine;

public class ResorteraController : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoLanzamiento;
    public float fuerzaLanzamiento = 10f;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer == null)
        {
            Debug.LogError("El GameObject no tiene un componente MeshRenderer.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            meshRenderer.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            meshRenderer.enabled = false;
        }

        if (meshRenderer != null && meshRenderer.enabled && Input.GetMouseButtonDown(0))
        {
            LanzarProyectil();
        }   

        // Actualiza la rotación del punto de lanzamiento para mirar hacia la posición del mouse
        if (meshRenderer != null && meshRenderer.enabled)
        {
            ActualizarPuntoDeLanzamiento();
        }
    }

    void ActualizarPuntoDeLanzamiento()
    {
        // Lanza un raycast desde la cámara hacia la posición del mouse en el mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Calcula la dirección desde el punto de lanzamiento hacia la posición del mouse
            Vector3 direccionHaciaMouse = hit.point - puntoLanzamiento.position;
            puntoLanzamiento.rotation = Quaternion.LookRotation(direccionHaciaMouse, Vector3.up);
        }
    }

    void LanzarProyectil()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, puntoLanzamiento.position, puntoLanzamiento.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direccionLanzamiento = puntoLanzamiento.forward;
            rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
        }
    }
}
