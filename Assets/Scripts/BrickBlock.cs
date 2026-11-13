using UnityEngine;


[RequireComponent(typeof(Collider))]


public class BrickBlock : MonoBehaviour,IHittable
{
        


    public ParticleSystem breakEffect;
    public AudioClip breakSfx;

    private bool destroyed = false;
   
    void Awake() {
        // Garante que o Collider do bloco não é um Trigger
        GetComponent<Collider>().isTrigger = false;
    }
    [ContextMenu("Hit From Below")]
    public void HitFromBelow() {
        if (destroyed) { return; }
        destroyed = true;
        if (breakEffect != null) {
            ParticleSystem fx = Instantiate(breakEffect, transform.position, Quaternion.identity);
            fx.Play();
            Destroy(fx.gameObject,3f);
        }
        if (breakSfx != null)
        {
            AudioSource.PlayClipAtPoint(breakSfx, transform.position);
        }
         Destroy(gameObject);
    }

    
}
