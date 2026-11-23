using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private static readonly int PlayerProximityHash = Animator.StringToHash("PlayerProximity");
    public Animator anim;
    public AudioSource doorAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger(PlayerProximityHash);
            doorAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger(PlayerProximityHash);
            // doorAudio.Play();
        }
    }
}
