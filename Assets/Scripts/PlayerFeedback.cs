using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{

    [SerializeField] private ParticleSystem dustEffect;
    [SerializeField] private AudioClip jumpSfx;
    [SerializeField] private AudioClip landSfx;
    [SerializeField] private float minImpactSpeed = 3f;

    public void PlayJump()
    {
        if (dustEffect != null)
        {

            dustEffect.Play();

        }
        if(AudioManager.Instance != null && jumpSfx != null)
        {
            AudioManager.Instance.PlaySfx(jumpSfx);

        }



    }

    private void OnCollisionEnter(Collision collision)
    { 
        //So, when the player jumps, the collision is checked,
        // if the magnitude of the relative velocity is below a certain threshold,
        //  a jump sound is triggered, and `dustEffect.Play()` is called.

/*"The `OnCollisionEnter()` method should verify that the following conditions are met simultaneously (the player must have a `Rigidbody` and a `Collider` that is not set as a trigger):
The magnitude of the collision's relative velocity is greater than `minImpactSpeed`—meaning the impact was strong enough;
The first contact point is below the player's position—meaning the player made contact with their feet, rather than their head or sides:
`collision.GetContact(0).point.y < transform.position.y`
If both conditions are met, `dustEffect` should be played, along with `landSfx`, via the `AudioManager`." */
        if (collision.relativeVelocity.magnitude >minImpactSpeed && collision.GetContact(0).point.y < transform.position.y)
        {
            dustEffect.Play();
        }

        if(AudioManager.Instance !=null && landSfx != null)
        {
            AudioManager.Instance.PlaySfx(landSfx);

        }
    }
   
}
