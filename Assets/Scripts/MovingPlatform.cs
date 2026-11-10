using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointA;
    [SerializeField] private float waitingTime = 0f;
    [SerializeField] private float movingSpeed = 2f;




    private Transform targetPoint;
    private float waitTimer;
    private bool isWaiting;
    private void Start()
    {
        // mover para direção do pointB sem tempo de espera
        targetPoint = pointB;
        transform.position = targetPoint.position;
        waitTimer = 0f;
        isWaiting = true;
    }
    private void Update()
    {
        if (isWaiting)
        {

            waitTimer += Time.deltaTime;
            // Verifica se o tempo decorrido atingiu o tempo de espera configurado
            if (waitTimer >= waitingTime)
            {
                //O targetPoint recebe o valor que a verificaçao retornar, primeiro e verificado se targetPoint é igual a pointA se sim, retorna pointB se nao, retorna pointA
                targetPoint = (targetPoint == pointA) ? pointB : pointA;
                isWaiting = false;
            }
        }
        else
        {
            //o moveTowards pega 3 parametro , primeiro pega posição atual do objeto, sengudo parametro vê a posição final que quer chegar, terceiro paramento a verifica a velociade que objeto vai do ponto A até o ponto B
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, movingSpeed * Time.deltaTime);
            // se a Distance do  inicial do objeto e posição final for menor que 0.01. se move até a posição final

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                transform.position = targetPoint.position;
                isWaiting = true;
                waitTimer = 0f;
            }
        }
    }


}
    