using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace R4ZE.ModularBlock.Blocks
{
    public class TestBlock : BaseBlock
    {
        public BaseBlock[] baseBlockDebug = new BaseBlock[6];

        public void UpdateBaseBlockDebug()
        {
            var baseBlockArray = ConnectedBlocks;
            for (int i = 0; i < baseBlockArray.Length; i++)
            {
                baseBlockDebug[i] = baseBlockArray[i] as BaseBlock;
            }
        }
    }
}