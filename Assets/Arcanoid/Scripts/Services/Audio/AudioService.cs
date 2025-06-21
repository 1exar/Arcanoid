using System.Collections.Generic;
using Arcanoid.Scripts.Configs;
using UnityEngine;

namespace Arcanoid.Scripts.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly GameObject _audioRoot;
        private readonly List<AudioSource> _audioSources = new();
        private int _poolSize = 5;

        private AudioLibrarySO _audioLibrary;

        public AudioService(AudioLibrarySO audioLibrary)
        {
            _audioLibrary = audioLibrary;

            _audioRoot = new GameObject("AudioService");
            Object.DontDestroyOnLoad(_audioRoot);

            for (int i = 0; i < _poolSize; i++)
            {
                var source = _audioRoot.AddComponent<AudioSource>();
                _audioSources.Add(source);
            }
        }

        public void PlaySound(Sound soundName)
        {
            var entry = _audioLibrary.GetClip(soundName);

            var source = _audioSources.Find(s => !s.isPlaying);
            if (source == null)
            {
                source = _audioSources[0];
                source.Stop();
            }

            source.clip = entry.clip;
            
            if(entry.pitch)
                source.pitch = Random.Range(.8f, 1.2f);
            
            if(entry.dontDestroyOnLoad)
                Object.DontDestroyOnLoad(source.gameObject);
            
            source.Play();
        }

        public void StopAllSounds()
        {
            foreach (var source in _audioSources)
                source.Stop();
        }
    }

}