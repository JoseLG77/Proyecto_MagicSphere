using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class AnimationButtons : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private float scaleStart = 1;
    [SerializeField] private float scaleEnd = 2;
    [SerializeField] private AnimationCurve curve;

    private RectTransform rectTransformButton;
    private void Awake()
    {
        rectTransformButton = GetComponent<RectTransform>();
    }
    public void EnterButton()
    {
        rectTransformButton.DOScale(scaleStart, duration).SetEase(curve);
    }

    public void ExitButton()
    {
        rectTransformButton.DOScale(scaleEnd, duration).SetEase(curve);
    }
}

