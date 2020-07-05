using System.Collections;
using System.Collections.Generic;
using R4ZE.Extensions;
using R4ZE.ModularBlock.Enums;
using R4ZE.ModularBlock.Interfaces;
using R4ZE.Utilities.Events;
using UnityEngine;

namespace R4ZE.ModularBlock.Blocks
{
    public class DestructibleTestBlock : TestBlock, IDestructible
    {
        [SerializeField]
        private IDestructibleUnityEvent destructionEvent = new IDestructibleUnityEvent();

        public float Health { get; set; } = 10;

        public IDestructibleUnityEvent DestructionEvent => destructionEvent;

        public void Damage(float damageAmount)
        {
            Health -= damageAmount;
        }

        public void Heal(float healingAmount)
        {
            Health += healingAmount;
        }

        public void OnDestruction()
        {
            destructionEvent?.Invoke(this);
            Destroy(gameObject);
        }
        public override void AddBlock(IBlock block, EDirection direction)
        {
            base.AddBlock(block, direction);
            destructionEvent.AddListener(((DestructibleTestBlock)block).OnConnectedBlockDestroyed);
        }

        private void OnConnectedBlockDestroyed(IDestructible destroyedObject)
        {
            if (destroyedObject != null)
            {
                if (destroyedObject is IBlock && destroyedObject is MonoBehaviour)
                {
                    MonoBehaviour dO = (MonoBehaviour)destroyedObject;

                    Vector3 delPos = dO.transform.position;

                    RemoveBlock(delPos);
                    UpdateBaseBlockDebug();
                }
            }
            Debug.Log("Connected Block destroyed.");
        }

        public virtual void RemoveBlock(Vector3 posOfRemovedBlock)
        {
            Vector3 dirVec = posOfRemovedBlock - transform.position;
            EDirection direction = dirVec.ConvertToEDirection();

            if (direction != EDirection.NONE)
            {
                int index = (int)direction;

                connectedBlocks[index] = null;
            }
        }
    }
}

