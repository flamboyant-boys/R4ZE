using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R4ZE.ModularBlock
{
    public interface IDestrucible
    {
        float GetHealth();
        float SetHealth();


        void Damage(float damageAmount);
        void Heal(float healingAmount);


        void OnDestroy();
    }
}

