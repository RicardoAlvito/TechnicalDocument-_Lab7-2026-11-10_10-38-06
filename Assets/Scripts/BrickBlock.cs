using UnityEngine;


[RequireComponent(typeof(Collider))]
public class BrickBlock : MonoBehaviour,IHittable
{
        


    public ParticleSystem breakEffect;
    public AudioClip breakSfx;

    private bool destroyed = false;

    void Awake() {
        GetComponent<Collider>().isTrigger = false;
    }

    public void HitFromBelow() { 
    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
