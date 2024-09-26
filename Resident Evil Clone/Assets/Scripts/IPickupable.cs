using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    int AmmoCount { get; set; }
    int AmmoCapacity { get; set; }
    string MagType { get; set; }

    void OnPickup(PlayerController player);
    void OnDrop();
}
