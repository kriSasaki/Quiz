using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using Project.Systems.Data;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class CardView : MonoBehaviour
{
    [SerializeField] private Image _cardImage;

    public void Set(Sprite sprite)
    {
        _cardImage.sprite = sprite;
    }

    public void PlayCorrectAnimation()
    {
        transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            transform.DOScale(1f, 0.2f).SetEase(Ease.InBounce);
        });
    }

    public void PlayIncorrectAnimation()
    {
        transform.DOLocalMoveX(transform.localPosition.x + 10f, 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
