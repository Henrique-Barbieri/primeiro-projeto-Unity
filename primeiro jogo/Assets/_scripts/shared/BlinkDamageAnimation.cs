using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkDamageAnimation : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField] private float BlinkDuration = .7f;
    private SpriteRenderer spriteRenderer;
    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();
    public void StartAnimation(){
       tweener = spriteRenderer.DOFade(0, BlinkDuration).SetLoops(-1);
    }
    public void EndAnimation(){
        tweener?.KillIfActive();
        spriteRenderer.color = Color.white;
    }
}