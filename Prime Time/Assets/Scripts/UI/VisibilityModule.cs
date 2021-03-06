using UnityEngine;

public enum FadeDirection { None, FadeIn, FadeOut }

public class VisibilityModule : MonoBehaviour
{
    private const float FadeSpeed = 2f;

    private FadeDirection fadeDirection;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        switch (fadeDirection)
        {
            case FadeDirection.FadeIn:
                AnimateFadeIn();
                break;
            case FadeDirection.FadeOut:
                AnimateFadeOut();
                break;
        }
    }

    private void SetActive(bool isActive)
    {
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
    }

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        SetActive(true);
        fadeDirection = FadeDirection.FadeIn;
    }

    public void SetVisibleImmediately()
    {
        canvasGroup.alpha = 1;
        SetActive(true);
    }

    public void FadeOut()
    {
        canvasGroup.alpha = 1;
        SetActive(false);
        fadeDirection = FadeDirection.FadeOut;
    }

    public void SetInvisibleImmediately()
    {
        canvasGroup.alpha = 0;
        SetActive(false);
    }

    private void AnimateFadeIn()
    {
        canvasGroup.alpha += Time.deltaTime * FadeSpeed;
        if (canvasGroup.alpha >= 1) StopFading();
    }

    private void AnimateFadeOut()
    {
        canvasGroup.alpha -= Time.deltaTime * FadeSpeed;
        if (canvasGroup.alpha <= 0) StopFading();
    }

    private void StopFading()
    {
        fadeDirection = FadeDirection.None;
    }
}
