using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Scripts.Configs
{
    [CreateAssetMenu(fileName = "AudioLibrary", menuName = "Audio/AudioLibrary")]
    public class AudioLibrarySO : ScriptableObject
    {
        [System.Serializable]
        public struct AudioEntry
        {
            public Sound key;
            public AudioClip clip;
            public bool pitch;
            public bool dontDestroyOnLoad;
        }

        public List<AudioEntry> sounds = new List<AudioEntry>();

        private Dictionary<Sound, AudioClip> _clipDict;

        public void Init()
        {
            if (_clipDict == null)
            {
                _clipDict = new Dictionary<Sound, AudioClip>();
                foreach (var entry in sounds)
                {
                    if (!_clipDict.ContainsKey(entry.key))
                        _clipDict.Add(entry.key, entry.clip);
                }
            }
        }

        public AudioEntry GetClip(Sound key)
        {
            Init();
            return sounds.Find(x => x.key == key);
        }
    }
}