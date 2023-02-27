using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class grapplingHook : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LineRenderer lr;
    //kanca için distance joint kullanýlýyor. 
    [SerializeField] private DistanceJoint2D dj;
    // Start is called before the first frame update
    private bool hookOnFlag;
    private string tagOfObject=null;

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
            //raycast ile obje tipi seçtirip hooku ona göre attýracaðým
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            try
            {
                if (tagOfObject == null)
                {
                    tagOfObject = hit.collider.gameObject.tag;
                    target = hit.collider.gameObject.transform;
                }
            }
            catch
            {
                HookOff();
            }
            if (tagOfObject == "Hook" || hookOnFlag)
            {
                hookOnFlag = HookOn();
            }
        




    }
        else
        {
            HookOff();
            hookOnFlag= false;
            target= null;
            tagOfObject= null;
        }
           
    }
    public bool HookOn()
    {
        
        dj.enabled = true;
        lr.positionCount = 2;
        //lr.SetPosition(0, target.position+cameraOffset); 3 gün neden line renderer atmýyor diye aradým :):):):):):)):)::):):):):):):)
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, target.position);
      
        dj.connectedAnchor = target.position;
        return true;
    }
    public void HookOff()
    {
        dj.enabled = false;
        lr.positionCount = 0;
    }
}
