using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RasPacJam.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance => instance;
        private static AudioManager instance;

        [SerializeField] private List<Sound> sounds = null;
        [SerializeField] private List<AudioClip> musics = null;
        [SerializeField] private AudioSource currentMusic = null;
        private Dictionary<string, AudioSource> sources;
        private Dictionary<string, float> lastPlayedTimes;

        public void Play(string soundName, float delay = 0f)
        {
            if(CanPlay(soundName, delay))
            {
                if(!sources.TryGetValue(soundName, out AudioSource source))
                {
                    source = new GameObject("SoundPlayer").AddComponent<AudioSource>();
                    sources.Add(soundName, source);
                    DontDestroyOnLoad(source);
                }
                if(source.isPlaying)
                {
                    source.Stop();
                }
                Sound sound = GetSoundByName(soundName);
                source.volume = sound.Volume;
                source.pitch = sound.Pitch;
                source.PlayOneShot(sound.Clip);
            }
        }

        public void Stop(string soundName)
        {
            if(sources.TryGetValue(soundName, out AudioSource source))
            {
                source.Stop();
            }
        }

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            sources = new Dictionary<string, AudioSource>();

            lastPlayedTimes = new Dictionary<string, float>();
            foreach(Sound sound in sounds)
            {
                lastPlayedTimes[sound.Name] = 0f;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            // TODO choisir une nouvelle musique après un délai aléatoire
        }

        private Sound GetSoundByName(string soundName)
        {
            List<Sound> similarSounds = sounds.FindAll(sound => sound.Name == soundName);
            return similarSounds[Random.Range(0, similarSounds.Count - 1)];
        }

        private bool CanPlay(string soundName, float delay)
        {
            if(lastPlayedTimes[soundName] == 0f || Time.time > lastPlayedTimes[soundName] + delay)
            {
                lastPlayedTimes[soundName] = Time.time;
                return true;
            }
            return false;
        }

        private void PickNewMusic()
        {
            // TODO empêcher la lecture du même morceau deux fois d’affilée
            currentMusic.clip = musics[Random.Range(0, musics.Count)];
            currentMusic.Play();
        }
    }



    [System.Serializable]
    public class Sound
    {
        public string Name => name;
        public AudioClip Clip => clip;
        public float Volume => volume;
        public float Pitch => pitch;

        [SerializeField] private string name = null;
        [SerializeField] private AudioClip clip = null;
        [SerializeField] [Range(0f, 1f)] private float volume = 1f;
        [SerializeField] [Range(0.1f, 3f)] private float pitch = 1f;
    }
}
