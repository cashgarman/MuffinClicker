using DG.Tweening;
using UnityEngine;

public class MainMuffin : MonoBehaviour
{
    private Vector3 initalScale;

    private bool animating;

    void Start()
    {
        initalScale = transform.localScale;
    }

    public void OnClicked()
    {
        if (!animating)
        {
            animating = true;
            transform.DOPunchScale(initalScale * 0.25f, 0.2f).OnComplete(() =>
            {
                animating = false;
            });
        }
    }
}
