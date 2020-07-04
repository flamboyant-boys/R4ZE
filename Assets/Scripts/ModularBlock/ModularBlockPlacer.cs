using R4ZE.Extensions;
using R4ZE.ModularBlock.Blocks;
using R4ZE.ModularBlock.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R4ZE.ModularBlock
{
    public static class ModularBlockPlacer
    {
        public static float raycastForCheckLength = 0.65f;

        public static GameObject CreateNewBlock(Vector3 initCubePosition, Vector3 direction, GameObject obj, Transform parent)
        {
            Vector3 newPosition = initCubePosition + direction;
            GameObject instantiatedObj = GameObject.Instantiate(obj, newPosition, Quaternion.identity, parent);

            addModularBlock(instantiatedObj.transform);

            return instantiatedObj;
        }

        public static void RemoveModularBlock(GameObject removedBlock)
        {
            removeModularBlock(removedBlock.transform);
            // TODO: Call destroy method of BaseBlock 
        }

        private static void combineModularBlocks(Transform b1, Transform b2, Vector3 direction)
        {
            var b1BaseBlock = b1.GetComponent<BaseBlock>();
            var b2BaseBlock = b2.GetComponent<BaseBlock>();

            if (b1BaseBlock != null && b2BaseBlock != null)
            {
                b1BaseBlock.AddBlock(b2BaseBlock, (direction * -1).ConvertToEDirection());
                b2BaseBlock.AddBlock(b1BaseBlock, direction.ConvertToEDirection());

                // Debugging 
#if UNITY_EDITOR
                if (b1BaseBlock is TestBlock && b2BaseBlock is TestBlock)
                {
                    (b1BaseBlock as TestBlock).UpdateBaseBlockDebug();
                    (b2BaseBlock as TestBlock).UpdateBaseBlockDebug();
                }
#endif
            }
        }

        private static void seperateModularBlocks(Transform b1, Transform b2, Vector3 direction)
        {
            var b1BaseBlock = b1.GetComponent<BaseBlock>();
            var b2BaseBlock = b2.GetComponent<BaseBlock>();

            if (b1BaseBlock != null && b2BaseBlock != null)
            {
                b1BaseBlock.RemoveBlock(b2BaseBlock, (direction * -1).ConvertToEDirection());
                b2BaseBlock.RemoveBlock(b1BaseBlock, direction.ConvertToEDirection());

                // Debugging 
#if UNITY_EDITOR
                if (b1BaseBlock is TestBlock && b2BaseBlock is TestBlock)
                {
                    (b1BaseBlock as TestBlock).UpdateBaseBlockDebug();
                    (b2BaseBlock as TestBlock).UpdateBaseBlockDebug();
                }
#endif
            }
        }

        private static void addModularBlock(Transform newBlock)
        {
            var directions = Enum.GetValues(typeof(EDirection));

            foreach(EDirection dir in directions)
            {
                if (Physics.Raycast(newBlock.position, dir.ConvertToVector3(), out RaycastHit hit, raycastForCheckLength))
                {
                    if (hit.transform == null && hit.transform.GetComponent<BaseBlock>() == null) return;
                    combineModularBlocks(hit.transform, newBlock, -hit.normal);
                }
            }
        }

        private static void removeModularBlock(Transform removedBlock)
        {
            var directions = Enum.GetValues(typeof(EDirection));

            foreach (EDirection dir in directions)
            {
                if (Physics.Raycast(removedBlock.position, dir.ConvertToVector3(), out RaycastHit hit, raycastForCheckLength))
                {
                    if (hit.transform == null && hit.transform.GetComponent<BaseBlock>() == null) return;
                    seperateModularBlocks(hit.transform, removedBlock, -hit.normal);
                }
            }
        }
    }
}

