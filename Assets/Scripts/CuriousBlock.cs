using UnityEngine;
using System.Collections;

public class CuriousBlock : MonoBehaviour, IHittable
{



    public enum Contained
    {
        None,
        Coin,
        PowerUp

    }
    //para blocos
    public Contained contained = Contained.Coin;
    public GameObject coinPrefab;
    public GameObject powerUpPrefab;
    public ParticleSystem popEffect;
    //para animações/efeitos
    public float coinLaunchForce = 6f;
    public float powerUpRiseEffect = 1f;
    public float popAnimationTime = 0.25f;
    //visual?
    public Material usedMaterial;
    public AudioClip popSfx;
    //...
    private AudioSource audioSource;
    private bool used = false;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void SpawnCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position + Vector3.up, Quaternion.identity);

        Rigidbody coinRB = coin.GetComponent<Rigidbody>();
        if (coinRB != null)
        {
            coinRB.AddForce(Vector3.up * coinLaunchForce, ForceMode.Impulse);
        }
        Destroy(coin, 0.5f);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddScore(1);
        }
    }


    private IEnumerator Pop()
    {
        Vector3 start = transform.position;
        Vector3 top = start + Vector3.up * 0.3f;
        float t = 0f;
        while (t < popAnimationTime)
        {

            t += Time.deltaTime;  // Incrementa o tempo no frame atual
            float k = t / popAnimationTime;
            transform.position = Vector3.Lerp(start, top, Mathf.Sin(k * Mathf.PI)); // A posição se move usando  (k \* PI) para subir e descer 
            yield return null; // Pausa o while e retoma no frame seguinte
        }
        // O gameObject regressa posição original no final 
        transform.position = start;
    }

    private IEnumerator RisePowerUp()
    {
        GameObject powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        Vector3 start = transform.position;
        Vector3 end = (start + Vector3.up) * powerUpRiseEffect;
        float t = 0f;
        float duration = 1f; // Duração da animação de subida do PowerUp
        while (t < duration)
        {

            t += Time.deltaTime;  // Incrementa o tempo no frame atual
            float k = t / duration;
            powerUp.transform.position = Vector3.Lerp(start, end, k);
            yield return null; // Pausa o while e retoma no frame seguinte
        }
        powerUp.transform.position = end;
    }

    [ContextMenu("Hit From Below")]
    public void HitFromBelow()
    {
        if (used)
        {
            return;
        }

        used = true;

        GetComponent<Renderer>().material = usedMaterial;
        if (popEffect != null)
        {
            //"o efeito"
            ParticleSystem fx = Instantiate(popEffect, transform.position, Quaternion.identity);
            fx.Play();
            Destroy(fx.gameObject, 2f);



        }
        if (popSfx != null)
        {
            audioSource.PlayOneShot(popSfx);
        }

        switch (contained)
        {
            case Contained.Coin:
                SpawnCoin();
                break;
            case Contained.PowerUp:
                StartCoroutine(RisePowerUp());
                break;
            case Contained.None: // Não faz nada, mas não a mesma coisa para defult?
                break;
        }
        StartCoroutine(Pop());
    }


}
