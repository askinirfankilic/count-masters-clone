using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BuzzSawAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        transform.DOLocalRotate(new Vector3(90, 0, 360), 0.3f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
    
}
