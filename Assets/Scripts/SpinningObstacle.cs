using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{

    [SerializeField] private float xAngle = 0f;
    [SerializeField] private float yAngle = 0f;
    [SerializeField] private float zAngle = 0f;
    private void Update()
    {
        // Aplica a rotação a cada frame usando as variáveis como argumentos
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}

