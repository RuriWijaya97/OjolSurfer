using UnityEngine;

 public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource sfxSource;

        public AudioClip bgm;
        public AudioClip coinCollect;
        public AudioClip jump;
        public AudioClip run;

        private void Start()
        {
        musicSource.volume = 1.0f;
        sfxSource.volume = 0.3f;
        
            musicSource.clip = bgm;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }

        public void setSFXVolume(float vol)
        {
            sfxSource.volume = vol;
        }

    public void muteBGM()
        {
        musicSource.volume = 0.0f;
    }
    }
