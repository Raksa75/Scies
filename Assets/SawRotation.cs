using UnityEngine;

public class SawRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Faire tourner la scie sur elle-même autour de l'axe Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
