using UnityEngine;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private lifeMenager lifeMenager;
    [SerializeField] private Transform BarTransform;
    [SerializeField] private GameObject root;
    [SerializeField] private float duration = 1;
    private Tweener lifeTweener; 
    // Start is called before the first frame update
    void Awake()
    {
        lifeMenager.onLifeChanged += Handlelifechanged;
        root.gameObject.SetActive(false);
    }

    private void Handlelifechanged(int obj)
    {
        root.gameObject.SetActive(true);
        lifeTweener.KillIfActive();
        lifeTweener = BarTransform.DOScale(lifeMenager.GetLifeNormalize(), duration).OnComplete(() => {
            root.gameObject.SetActive(!lifeMenager.IsFullLife());
        });
    }
    private void OnDestroy() {
        lifeMenager.onLifeChanged -= Handlelifechanged;
       lifeTweener.KillIfActive();
    }
}
