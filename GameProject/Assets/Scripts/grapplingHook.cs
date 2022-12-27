using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingHook : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LineRenderer lr;
    //kanca i�in distance joint kullan�l�yor. 
    [SerializeField] private DistanceJoint2D dj;
    // Start is called before the first frame update
    void Start()
    {
        dj.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mausePos= Input.mousePosition;
            //raycast ile obje tipi se�tirip hooku ona g�re att�raca��m

            HookOn();

        }
        else
        {
            HookOff();
        }
           
    }
    public void HookOn()
    {
        dj.enabled = true;
        lr.positionCount = 2;
        lr.SetPosition(0, target.position);
        lr.SetPosition(1, target.position);
        dj.connectedAnchor = target.position;
    }
    public void HookOff()
    {
        dj.enabled = false;
        lr.positionCount = 0;
    }
}
