using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // O GameObject  têm como um Rigidbody a um Collider como fosse umTrigger.
    void OnTriggerEnter(Collider other)
    {
        // Obtém o Rigidbody do objeto que colidiu
        Rigidbody body = other.attachedRigidbody;

        // Se o objeto que colidiu não tem Rigidbody, ou não é o Player, ou está se movendo para cima, ignora a colisão
        if (body !=null && other.CompareTag("Player") && body.linearVelocity.y <= 0f)
        {
            return;

        }
        // Procura o IHittable neste objeto
        IHittable block = GetComponentInParent<IHittable>();
        // Se o bloco existir e implementar IHittable, ativa a ação
        if (block != null)
        {
            // Chama o método HitFromBelow do bloco
            block.HitFromBelow();
        }

    }
}
