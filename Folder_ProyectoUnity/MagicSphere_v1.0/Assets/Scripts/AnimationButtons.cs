using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class AnimationButtons : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private float scaleStart = 1;
    [SerializeField] private float scaleEnd = 2;
    [SerializeField] private AnimationCurve curveStart;
    [SerializeField] private AnimationCurve curveExit;

    private RectTransform rectTransformButton;
    private void Awake()
    {
        if (rectTransformButton == null)
            rectTransformButton = GetComponent<RectTransform>();
    }
    public void EnterButton()
    {
        rectTransformButton.DOScale(scaleStart, duration).SetEase(curveStart);
    }

    public void ExitButton()
    {
        rectTransformButton.DOScale(scaleEnd, duration).SetEase(curveExit);
    }
}

