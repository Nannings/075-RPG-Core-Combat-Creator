using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    CameraRaycaster cameraRaycaster;

    private void Start()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
    }

    private void Update()
    {
        print(cameraRaycaster.layerHit);
    }
}
