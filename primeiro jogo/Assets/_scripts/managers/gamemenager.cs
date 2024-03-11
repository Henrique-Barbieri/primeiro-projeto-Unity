using System.Collections.Generic;
using UnityEngine;

public class gameme : MonoBehaviour
{
    [SerializeField] private GameObject collectableitemParent;
    private List<collectableitem> collectableitems = new List<collectableitem>();
    [SerializeField] List<room> rooms;
    [SerializeField] NewBehaviourScript barco;
    [field:SerializeField]private room currentRoom;
    public room MyProperty
    {
        get { return currentRoom; }
        set {
            currentRoom?.DisableCamera(); 
            currentRoom = value;
            currentRoom.EnableCamera(barco.transform);
            }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rooms.ForEach(room => room.onRoomActivated += HandleRoomActivated);
        var items = collectableitemParent.GetComponentsInChildren<collectableitem>();
        foreach (var item in items){
            item.onitemcollected += HandItemCollected;
            collectableitems.Add(item);
        }
    }
    private void OnDestroy() {
        rooms.ForEach(room => room.onRoomActivated -= HandleRoomActivated);
        collectableitems.ForEach(item => item.onitemcollected -= HandItemCollected);
    }
    private void HandItemCollected(collectableitemData collectableitemData){
        switch(collectableitemData.type){
            case collectableitemType.Cannon:
                barco.ennablecannon();
            break;
            case collectableitemType.Health:
            break;
            case collectableitemType.survivor:
            break;
            default:
            Debug.LogError("Item invalido" + collectableitemData.type);
            break;
        }
    }
    private void HandleRoomActivated(room room)
    {
        MyProperty = room;
    }
}
