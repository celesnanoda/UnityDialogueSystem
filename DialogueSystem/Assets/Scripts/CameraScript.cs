using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    private void OnEnable() => CameraSwitcher.Register( gameObject.GetComponent<CinemachineVirtualCamera>() );
    private void OnDisable() => CameraSwitcher.Unregister( gameObject.GetComponent<CinemachineVirtualCamera>() );

}
