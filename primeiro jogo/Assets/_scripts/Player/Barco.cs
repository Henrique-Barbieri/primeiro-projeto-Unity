using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private List<cannon> cannons;
    private lifeMenager lifeMenager;
    private BlinkDamageAnimation blinkDamageAnimation;
    private void Awake() {
        blinkDamageAnimation = GetComponent<BlinkDamageAnimation>();
        lifeMenager = GetComponent<lifeMenager>();
        lifeMenager.onTakeDamage += HandleTakeDamage;
        lifeMenager.onEndTakeDamage += HandleEndTakeDamage;
        lifeMenager.OnDie += HandleOnDie;
    }
    private void OnDestroy() {
        lifeMenager.onTakeDamage -= HandleTakeDamage;
        lifeMenager.onEndTakeDamage -= HandleEndTakeDamage;
        lifeMenager.OnDie -= HandleOnDie;
    }
    public bool TakeDamage(int power) => lifeMenager.TakDamage(power);

    private void HandleOnDie()
    {
        Debug.Log("Player Dead");
    }

    private IEnumerable<cannon> GetActiveCannons() => cannons.Where(cannon => cannon.isActiveAndEnabled);
    
    private void HandleTakeDamage()
    {
       blinkDamageAnimation.StartAnimation();
       foreach(var cannon in GetActiveCannons()){
        cannon.TakeAnimation();
        }
    }

    private void HandleEndTakeDamage()
    {
        blinkDamageAnimation.EndAnimation();
        foreach(var cannon in GetActiveCannons()){
            cannon.EndTakeAnimation();
        }
    }

    public void ennablecannon(){
        var cannonNotInUse = cannons.Find(cannon => !cannon.gameObject.activeSelf);
        if (cannonNotInUse != null){
            cannonNotInUse.gameObject.SetActive(true);
        }
    }
}

