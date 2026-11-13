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
    //When the camera gets closer to the "brick block", the songs are louder.
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
            //because now the song id generate in the worlf a round and before the song is
            //in rhe unique place of the world.
            AudioManager.Instance.PlaySfx(breakSfx);
        }
         Destroy(gameObject);
    }

    
}
