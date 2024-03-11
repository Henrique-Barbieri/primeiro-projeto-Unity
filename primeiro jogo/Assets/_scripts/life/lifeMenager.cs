using UnityEngine;
using System;
using System.Collections;

public class lifeMenager : MonoBehaviour
{
    [SerializeField] private caracterlifeData caracterlifeData;
    public event Action<int> onLifeChanged;
    public event Action onTakeDamage; 
    public event Action onEndTakeDamage;
    public event Action OnDie;
    private int life;
    public int Life
    {
        get { return life; }
        set {
            if( life < 0) return; 
            life = value;
            Debug.Log("life: " + life);
            onLifeChanged?.Invoke(life); 
            if (life == 0){
                OnDie?.Invoke();
            }
            }
    }
    private DateTime lastTimeDamage;
    private WaitForSeconds endTakingDamageDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        Life = caracterlifeData.fullLife;
        endTakingDamageDelay = new WaitForSeconds(caracterlifeData.timeBetwenDamage);
    }
    public bool IsFullLife(){
        return life == caracterlifeData.fullLife;
    }
    public float GetLifeNormalize(){
        return (float)life / caracterlifeData.fullLife;
    }
    public bool TakDamage(int power){
        if (!CanTakeDamage()) return false;
        this.Life -= power;
        onTakeDamage?.Invoke();
        StartCoroutine(EndTakeDamage());
        lastTimeDamage = DateTime.UtcNow;
        return true;
    }
    private IEnumerator EndTakeDamage() {
        yield return endTakingDamageDelay;
        onEndTakeDamage?.Invoke();
    }
    private bool CanTakeDamage(){
        if (!caracterlifeData.invulnerableOnDamage) return true;
        if (caracterlifeData.timeBetwenDamage > 0){
            TimeSpan timeSpan = DateTime.UtcNow - lastTimeDamage;
            return timeSpan.TotalSeconds > caracterlifeData.timeBetwenDamage;
        }
        return true;
    }
}
