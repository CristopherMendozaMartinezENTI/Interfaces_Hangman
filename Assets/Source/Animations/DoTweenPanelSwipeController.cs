using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class DoTweenPanelSwipeController : MonoBehaviour
{
    public enum StartingSide
    {
        RIGHT,
        LEFT
    }
    [SerializeField] private RectTransform _panelToSwipe;

    public void Animate(StartingSide startingSide) {
        int sideMultiplier = (startingSide == StartingSide.RIGHT) ? 1 : -1;

        _panelToSwipe.DOAnchorPosX(sideMultiplier * 1.1f *_panelToSwipe.rect.width, 0f); //Place panel outside screen, left or right
        _panelToSwipe.DOAnchorPosX(0, 0.2f);
    }
}


