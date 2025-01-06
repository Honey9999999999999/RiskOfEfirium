using Architecture;
using Assets.Scripts.InventorySystem;
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DropItem : MonoBehaviour
{
    public static event Action OnSomeDropGrabbed;
    public event Action OnDropGrabbed;

    public ItemNames DropName { get; set; }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.TryGetComponent<Player>(out _))
        {
            Game.GetInteractor<PlayerInteractor>().Player.Inventory.AddItem(DropName);
            Destroy(gameObject);

            OnDropGrabbed?.Invoke();
            OnSomeDropGrabbed?.Invoke();
        }
    }
}
