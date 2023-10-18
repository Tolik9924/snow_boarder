using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool isCrashed = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !isCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();            
            crashEffect.Play();            
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            isCrashed = true;            
            Invoke("ReloadScene", loadDelay);
        }
    }

    private void ReloadScene()
    {
        isCrashed = false;
        SceneManager.LoadScene(0);
    }
}
