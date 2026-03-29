using DG.Tweening;
using UnityEngine;

namespace DancingLineFanmade.Level
{
    public static class AudioManager
    {
        public static void PlayClip(AudioClip clip, float volume)
        {
            AudioSource audioSource = new GameObject("One shot sound: " + clip.name).AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();
            Object.Destroy(audioSource.gameObject, clip.length);
        }

        public static AudioSource PlayTrack(AudioClip clip, float volume, bool play = true)
        {
            AudioSource audioSource = new GameObject(clip.name).AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            if (play) audioSource.Play();
            return audioSource;
        }

        public static float Time
        {
            get
            {
                if (!Player.Instance.SoundTrack) return 0f;
                return Player.Instance.SoundTrack.time;
            }

            set
            {
                Player.Instance.SoundTrack.time = value;
            }
        }

        public static float Pitch
        {
            get
            {
                if (!Player.Instance.SoundTrack) return 0f;
                return Player.Instance.SoundTrack.pitch;
            }

            set
            {
                if (Player.Instance.SoundTrack) Player.Instance.SoundTrack.pitch = value;
            }
        }

        public static float Volume
        {
            get
            {
                if (!Player.Instance.SoundTrack) return 0f;
                return Player.Instance.SoundTrack.volume;
            }

            set
            {
                if (Player.Instance.SoundTrack) Player.Instance.SoundTrack.volume = value;
            }
        }

        public static float Progress
        {
            get
            {
                if (!Player.Instance.SoundTrack) return 0f;
                return Player.Instance.levelData.useCustomLevelTime
                    ? Player.Instance.SoundTrack.time / Player.Instance.levelData.levelTotalTime
                    : Player.Instance.SoundTrack.time / Player.Instance.SoundTrack.clip.length;
            }
        }

        public static void Stop()
        {
            Player.Instance.SoundTrack.Stop();
        }

        public static void Play()
        {
            Player.Instance.SoundTrack.Play();
        }

        public static Tween FadeOut(float volume, float duration)
        {
            return Player.Instance.SoundTrack.DOFade(volume, duration).SetEase(Ease.Linear).OnComplete(new TweenCallback(Stop));
        }
    }
}