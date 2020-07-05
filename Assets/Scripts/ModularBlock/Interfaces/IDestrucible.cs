using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using R4ZE.Utilities.Events;

namespace R4ZE.ModularBlock.Interfaces
{
    public interface IDestructible
    {
        float Health { get; set; }


        void Damage(float damageAmount);
        void Heal(float healingAmount);


        IDestructibleUnityEvent DestructionEvent { get; }

        void OnDestruction();
    }
}

