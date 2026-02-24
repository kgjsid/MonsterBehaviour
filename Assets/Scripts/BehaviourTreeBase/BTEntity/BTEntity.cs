using System.Collections.Generic;
using UnityEngine;

public class BTEntity : MonoBehaviour
{
    protected Node rootNode;

    private void Start()
    {
    }

    private void Update()
    {
        rootNode.Tick();
    }
}
