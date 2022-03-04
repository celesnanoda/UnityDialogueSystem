using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimplePlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] CinemachineVirtualCamera mainCam;

    private void Start()
    {
        SwitchToPlayerCamera();
    }

    public void SwitchToPlayerCamera()
    {
        CameraSwitcher.SwitchCamera( mainCam );
    }

    private void Update()
    {

        float horizontal = Input.GetAxis( "Horizontal" );

        if ( Input.GetButtonDown("Jump") )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.up * 5f, ForceMode.Impulse );
        }

        transform.Translate( transform.right * horizontal * speed * Time.deltaTime, Space.World );

    }
}
