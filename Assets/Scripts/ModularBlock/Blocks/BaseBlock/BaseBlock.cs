using R4ZE.Extensions;
using R4ZE.ModularBlock.Enums;
using R4ZE.ModularBlock.Interfaces;
using UnityEngine;

namespace R4ZE.ModularBlock.Blocks
{
    public abstract class BaseBlock : MonoBehaviour, IBlock
    {
        [SerializeField] protected IBlock[] connectedBlocks = new IBlock[6];

        public IBlock[] ConnectedBlocks {
            get => connectedBlocks;
        }

        public virtual void AddBlock(IBlock block, EDirection direction)
        {
            if (direction == EDirection.NONE || block == null) return;

            int index = (int)direction;

            if (connectedBlocks[index] == null && connectedBlocks[index] != block)
            {
                connectedBlocks[index] = block;
            }
        }
    }
}
