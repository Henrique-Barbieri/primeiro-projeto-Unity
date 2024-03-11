using System;
using UnityEngine;
using Cinemachine;

public class room : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera virtualcamera;
    public event Action<room> onRoomActivated;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<NewBehaviourScript>(out var boat)){
            onRoomActivated?.Invoke(this);
            Debug.Log("colisor quarto " + gameObject.name);
        }
    }
    public void DisableCamera() {
        virtualcamera.enabled = false;
    }
    public void EnableCamera(Transform target){
        virtualcamera.enabled = true;
        virtualcamera.Follow = target;
    }
}

