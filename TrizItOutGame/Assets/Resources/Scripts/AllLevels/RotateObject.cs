using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour, IInteractable
{
    public delegate void RotateObjectAction();

    [SerializeField]
    private float m_SpeedRotation;
    [SerializeField]
    private float m_EndZ;

    public event RotateObjectAction OnRotateObject;

    public void Interact(DisplayManagerLevel1 currDisplay)
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        if (OnRotateObject != null)
        {
            OnRotateObject();
        }
        /*
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 32;  // this number is the degree of rotation around Z Axis
        transform.rotation = Quaternion.Euler(rotationVector);
        */
    }
}
