using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputMouseDebug : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null)
        {
            Debug.Log("No Mouse.current detected");
            return;
        }
        Vector2 pos = Mouse.current.position.ReadValue();
        Debug.Log("Mouse.current.position = " + pos);
    }
}
