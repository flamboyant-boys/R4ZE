using R4ZE.Extensions;
using R4ZE.ModularBlock.Blocks;
using R4ZE.ModularBlock.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject objForCreation;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == null) return;
                createNewBlock(hit.transform.position, hit.normal, objForCreation, hit.transform);
            }  
        }
    }

    private GameObject createNewBlock(Vector3 initCubePosition, Vector3 direction, GameObject obj, Transform parent)
    {
        Vector3 newPosition = initCubePosition + direction;
        GameObject instantiatedObj = GameObject.Instantiate(obj, newPosition, Quaternion.identity, parent);

        BaseBlock newModularBlock = instantiatedObj.GetComponent<BaseBlock>();
        BaseBlock parentModularBlock = parent.GetComponent<BaseBlock>();

        if (newModularBlock != null && parentModularBlock != null)
        {
            newModularBlock.AddBlock(parentModularBlock, (direction * -1).ConvertToEDirection());
            parentModularBlock.AddBlock(newModularBlock, direction.ConvertToEDirection());

            if(newModularBlock is TestBlock && parentModularBlock is TestBlock)
            {
                (newModularBlock as TestBlock).UpdateBaseBlockDebug();
                (parentModularBlock as TestBlock).UpdateBaseBlockDebug();
            }
        }

        return instantiatedObj;
    }

}
