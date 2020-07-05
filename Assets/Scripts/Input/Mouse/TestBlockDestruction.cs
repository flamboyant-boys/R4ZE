using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R4ZE.ModularBlock.Blocks;

public class TestBlockDestruction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == null) return;
                DestroyBlock(hit.transform);
            }
        }
    }

    private void DestroyBlock(Transform blockToDestroy)
    {
        DestructibleTestBlock btd = blockToDestroy.gameObject.GetComponent<DestructibleTestBlock>();

        btd?.OnDestruction();
    }
}
