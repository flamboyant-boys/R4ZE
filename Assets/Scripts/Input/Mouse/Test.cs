using R4ZE.Extensions;
using R4ZE.ModularBlock;
using R4ZE.ModularBlock.Blocks;
using R4ZE.ModularBlock.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject objForCreation;

    public GameObject testObj;

    private void Update()
    {
        if (testObj != null)
        {
            DebugDirections(testObj.transform);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == null) return;
                testObj = ModularBlockPlacer.CreateNewBlock(hit.transform.position, hit.normal, objForCreation, hit.transform);
            }  
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == null) return;
                ModularBlockPlacer.RemoveModularBlock(hit.transform.gameObject);
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void DebugDirections(Transform newBlock)
    {
        Debug.DrawRay(newBlock.position, newBlock.up * 0.65f, Color.red);
        Debug.DrawRay(newBlock.position, -newBlock.up * 0.65f, Color.red);
        Debug.DrawRay(newBlock.position, newBlock.right * 0.65f, Color.red);
        Debug.DrawRay(newBlock.position, -newBlock.right * 0.65f, Color.red);
        Debug.DrawRay(newBlock.position, newBlock.forward * 0.65f, Color.red);
        Debug.DrawRay(newBlock.position, -newBlock.forward * 0.65f, Color.red);
    }

}
