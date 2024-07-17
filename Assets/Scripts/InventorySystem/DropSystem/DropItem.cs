using Architecture;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.InventorySystem.DropSystem;
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DropItem : MonoBehaviour
{
    public static event Action OnSomeDropGrabbed;
    public event Action OnDropGrabbed;

    [SerializeField] private NamesOfDrop _nameOfDrop;

   

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger && other.TryGetComponent<Player>(out _))
        {
            Game.GetInteractor<InventoryInteractor>().AddItem(_nameOfDrop);
            Destroy(gameObject);

            OnDropGrabbed?.Invoke();
            OnSomeDropGrabbed?.Invoke();
        }
    }
}
