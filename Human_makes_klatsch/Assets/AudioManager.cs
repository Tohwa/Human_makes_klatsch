using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] eggDamageSound = new AudioClip[3];

    [SerializeField]
    private AudioClip falconDistance, falconAttack, winSound, looseSound;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        GameManager.PlayerDamaged += PlayEggSound;
    }

    private void OnDisable()
    {
        GameManager.PlayerDamaged -= PlayEggSound;
    }

    public void PlayEggSound(float playerHealth)
    {
        if(playerHealth == 3)
        {
            audioSource.PlayOneShot(eggDamageSound[0]);
            Debug.Log("PlayEggSound1");
        }
        else if(playerHealth == 2)
        {
            audioSource.PlayOneShot(eggDamageSound[1]);
            Debug.Log("PlayEggSound2");
        }
        else if(playerHealth == 1)
        {
            audioSource.PlayOneShot(eggDamageSound[2]);
            Debug.Log("PlayEggSound3");
        }
    }

    public void FalconSound()
    {
        audioSource.PlayOneShot(falconDistance);
    }

    public void FalconAttack()
    {
        audioSource.PlayOneShot(falconAttack);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayLooseSound()
    {
        audioSource.PlayOneShot(looseSound);
    }
}
