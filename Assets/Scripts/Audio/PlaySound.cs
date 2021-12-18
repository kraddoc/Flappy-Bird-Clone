using UnityEngine;

namespace FlappyClone.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class PlaySound : MonoBehaviour
    {
        [SerializeField] protected AudioClip sound;
        private AudioSource _audioSource;

        private void Start()
        {
            TryGetComponent(out _audioSource);
        }

        protected void Play()
        {
            _audioSource.PlayOneShot(sound);
        }
    }
}