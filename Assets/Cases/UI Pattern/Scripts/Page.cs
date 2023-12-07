using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource), typeof(CanvasGroup))]
[DisallowMultipleComponent]
public class Page : MonoBehaviour {
    private AudioSource AudioSource;
    private RectTransform RectTransform;
    private CanvasGroup CanvasGroup;

    [SerializeField] private float AnimationSpeed = 1.0f;

    public bool ExitOnNewPagePush = false;

    [SerializeField]
    private AudioClip EntryClip;
    [SerializeField]
    private AudioClip ExitClip;
    [SerializeField]
    private EntryMode EntryMode = EntryMode.SLIDE;
    [SerializeField]
    private Direction EntryDirection = Direction.LEFT;
    [SerializeField]
    private EntryMode ExitMode = EntryMode.SLIDE;
    [SerializeField]
    private Direction ExitDirection = Direction.LEFT;

    private Coroutine AnimationCoroutine;
    private Coroutine AudioCoroutine;

    private void Awake() {
        RectTransform = GetComponent<RectTransform>();
        CanvasGroup = GetComponent<CanvasGroup>();
        AudioSource = GetComponent<AudioSource>();

        AudioSource.playOnAwake = false;
        AudioSource.loop = false;
        AudioSource.spatialBlend = 0;
        AudioSource.enabled = false;
    }

    public void Enter(bool PlayAudio) {
        switch (EntryMode) {
            case EntryMode.SLIDE:
                SliderIn(PlayAudio);
                break;

            case EntryMode.ZOOM:
                ZoomIn(PlayAudio);
                break;

            case EntryMode.FADE:
                FadeIn(PlayAudio);
                break;
        }
    }

    public void Exit(bool PlayAudio) {
        switch (ExitMode) {
            case EntryMode.SLIDE:
                SliderOut(PlayAudio);
                break;

            case EntryMode.ZOOM:
                ZoomOut(PlayAudio);
                break;

            case EntryMode.FADE:
                FadeOut(PlayAudio);
                break;
        }
    }

    private void SliderIn(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.SlideIn(RectTransform, EntryDirection, AnimationSpeed, null));

        PlayEntryClip(PlayAudio);
    }

    private void SliderOut(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.SlideOut(RectTransform, ExitDirection, AnimationSpeed, null));

        PlayExitClip(PlayAudio);
    }

    private void ZoomIn(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.ZoomIn(RectTransform, AnimationSpeed, null));

        PlayEntryClip(PlayAudio);
    }

    private void ZoomOut(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.ZoomOut(RectTransform, AnimationSpeed, null));

        PlayExitClip(PlayAudio);
    }

    private void FadeIn(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.FadeIn(CanvasGroup, AnimationSpeed, null));

        PlayEntryClip(PlayAudio);
    }

    private void FadeOut(bool PlayAudio) {
        if (AnimationCoroutine != null) {
            StopCoroutine(AnimationCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.FadeOut(CanvasGroup, AnimationSpeed, null));

        PlayExitClip(PlayAudio);
    }

    private void PlayEntryClip(bool PlayAudio) {
        if (PlayAudio && EntryClip != null && AudioSource != null) {
            if (AudioCoroutine != null) {
                StopCoroutine(AudioCoroutine);
            }

            AudioCoroutine = StartCoroutine(PlayClip(EntryClip));
        }
    }

    private void PlayExitClip(bool PlayAudio) {
        if (PlayAudio && ExitClip != null && AudioSource != null) {
            if (AudioCoroutine != null) {
                StopCoroutine(AudioCoroutine);
            }

            AudioCoroutine = StartCoroutine(PlayClip(ExitClip));
        }
    }

    private IEnumerator PlayClip(AudioClip Clip) {
        AudioSource.enabled = true;

        WaitForSeconds Wait = new WaitForSeconds(Clip.length);

        AudioSource.PlayOneShot(Clip);

        yield return Wait;

        AudioSource.enabled = false;
    }
}
