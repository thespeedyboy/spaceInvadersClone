using UnityEngine;

public class CursorController : MonoBehaviour
{
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
