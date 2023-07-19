using UnityEngine;
using UnityEngine.UI;

public class UIRotation : MonoBehaviour
{
    public Image image;
    public float rotationSpeed = 90f; // Change this value to adjust the rotation speed (degrees per second)

    private bool isRotating = false;

    private void Start()
    {
        isRotating = true;
    }

    private void Update()
    {
        if (isRotating)
        {
            RotateImage();
        }
    }

    private void StartRotation()
    {
        isRotating = true;
    }

    private void RotateImage()
    {
        image.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
