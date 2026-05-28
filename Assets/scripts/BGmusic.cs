using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class MusicCrossfade : MonoBehaviour
{
    public PlayableDirector director;

    public AudioSource cutsceneSource;
    public AudioSource gameplaySource;

    public AudioClip gameplayClip;

    public AudioClip cutsceneClip;

    void Start()
    {
        cutsceneSource.clip = cutsceneClip;
        cutsceneSource.Play();

        director.stopped += OnCutsceneEnd;
    }

    void OnCutsceneEnd(PlayableDirector pd)
    {
        StartCoroutine(Crossfade());
    }

    IEnumerator Crossfade()
    {
        gameplaySource.clip = gameplayClip;
        gameplaySource.Play();

        float t = 0f;
        float duration = 2f;

        float startCutsceneVol = cutsceneSource.volume;

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = t / duration;

            cutsceneSource.volume = Mathf.Lerp(startCutsceneVol, 0f, normalized);
            gameplaySource.volume = Mathf.Lerp(0f, 1f, normalized);

            yield return null;
        }

        cutsceneSource.Stop();
    }
}