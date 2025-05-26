using UnityEngine;

public class DetecteMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDetecteMouse();
    }
    public void OnDetecteMouse()
    {
        // Crear el rayo desde la cámara hacia el mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verificar si el rayo golpea algo
        if (Physics.Raycast(ray, out hit))
        {
            // Verifica si el objeto tocado es este mismo
            if (hit.transform == transform)
            {
                Debug.Log("El mouse está sobre el objeto 3D.");

                // Verifica si se ha hecho clic izquierdo
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("¡Objeto clickeado!");
                    // Aquí puedes poner lo que quieras que pase con el clic
                }
            }
        }
    }
}
