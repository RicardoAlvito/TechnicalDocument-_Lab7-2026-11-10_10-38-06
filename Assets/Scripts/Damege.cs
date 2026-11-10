using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Damege : MonoBehaviour
{
    public int AI = 1; 
    public AudioClip hitSfx;

    private void Awake()
    {
        //Obriga a colisão do objeto fique Trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Verefica se a colisão do obejto tem a tag "Player" se não ignorar 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        // Reduz a vida do jogador se a UI existir 
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddLives(-AI);
        }
        // Toca um som ao ser colidido com o "player"
        if (hitSfx != null)
        {
            AudioSource.PlayClipAtPoint(hitSfx, transform.position);
        }

        // Se Destrói ao ser colidido com o "player"
        Destroy(gameObject);
    }
}