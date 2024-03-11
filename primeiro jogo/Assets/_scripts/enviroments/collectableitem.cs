using UnityEngine;
using System;

public class collectableitem : MonoBehaviour
{
    [SerializeField] collectableitemData collectableitemData;
    [SerializeField] SpriteRenderer spriteRenderer;
    public event Action<collectableitemData> onitemcollected;
    // Start is called before the first frame update
    void OnValidate()
    {
        if (collectableitemData != null){
            spriteRenderer.sprite = collectableitemData.sprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            onitemcollected?.Invoke(collectableitemData);
            Destroy(gameObject);
        }
    }
}
