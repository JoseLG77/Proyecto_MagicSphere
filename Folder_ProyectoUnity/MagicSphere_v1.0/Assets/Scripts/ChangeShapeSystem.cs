using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeShapeSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] ShapePrefags;
    private DoublyLinkedCircularList ShapeList = new DoublyLinkedCircularList();
    private NodeShape currentShapePlayer;
    void Start()
    {
        //Primero se llena la lista con las formas que va a tener el player
        foreach (GameObject shape in ShapePrefags)
        {
            GameObject shapeSave = Instantiate(shape, transform.position, Quaternion.identity);
            shapeSave.SetActive(false);//Lo ocultamos
            ShapeList.Add(shapeSave);
        }
        currentShapePlayer = ShapeList.head;
        currentShapePlayer.currentShape.SetActive(true);//Activamos la forma inicial
    }
    public void ChangeNextShape(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentShapePlayer.currentShape.SetActive(false);
            currentShapePlayer = currentShapePlayer.next;
            currentShapePlayer.currentShape.SetActive(true);
        }
    }
    public void ChangePrevShape(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentShapePlayer.currentShape.SetActive(false);
            currentShapePlayer = currentShapePlayer.prev;
            currentShapePlayer.currentShape.SetActive(true);
        }
    }
}
