using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Token : MonoBehaviour
{
    public int value = 1; 
    public AudioClip pickupSfx;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {


        // Verefica se a colisão do obejto tem a tag "Player" se não ignorar 
        if (!other.CompareTag("Player"))
        {
            return;
        }

        //Adiciona pontos ao Score se a UI existir 
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddScore(value);
        }
            
        // Toca um som ao ser colidido com o "player"
        if (pickupSfx != null)
        {   //because now the song id generate in the worlf a round and before the song is
            //in rhe unique place of the world
            AudioManager.Instance.PlaySfx(pickupSfx);
        }

        // Se Destrói ao ser colidido com o "player"
        Destroy(gameObject);
    }
}