
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip pickup;
    public AudioClip interaction;
    public AudioClip damage;
    private AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudio(int audio)
    {
        if (audio == 0)
        {
            source.PlayOneShot(pickup);
        }

        if (audio == 1)
        {
            source.PlayOneShot(interaction);
        }

        if (audio == 2)
        {
            source.PlayOneShot(damage);
        }
    }


}
