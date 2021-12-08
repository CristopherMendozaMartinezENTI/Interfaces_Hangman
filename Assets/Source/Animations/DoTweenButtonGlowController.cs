using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class DoTweenButtonGlowController : MonoBehaviour
{
    [SerializeField] private Outline _outline;
    [SerializeField] private Image _glowImage;
    public void Animate() {
        _outline.DOColor(new Color(0f, 1f, 0.7535582f, 1f), 0f);
        _outline.DOColor(new Color(0f, 0f, 0f, 1f), 0.6f);

        _glowImage.DOFade(0.35f, 0f);
        _glowImage.DOFade(0f, 0.6f);
    }
}
