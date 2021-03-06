using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputs : MonoBehaviour
{
    //private Touch touch;
    //private float speedModifier;

    //private void Start()
    //{
    //    speedModifier = 0.01f;
    //}

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            transform.position = new Vector3(
    //                transform.position.x + touch.deltaPosition.x * speedModifier,
    //                transform.position.y + touch.deltaPosition.y * speedModifier,
    //                transform.position.z
    //                );
    //        }
    //    }
    //}

    [SerializeField]
    Vector3 pointTouch;
    [SerializeField]
    GameObject gObject = null;
    Plane planeObj;
    Vector3 nO;

    Ray GenerateMousRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMousRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {

                gObject = hit.transform.gameObject;


                planeObj = new Plane(Camera.main.transform.forward * -1, gObject.transform.position);

                //calculate mouse offset
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                planeObj.Raycast(mRay, out rayDistance);
                nO = gObject.transform.position - mRay.GetPoint(rayDistance);
            }
        }
        else if (Input.GetMouseButton(0) && gObject)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;

            if (gObject.gameObject.CompareTag("Input"))
            {



                if (planeObj.Raycast(mRay, out rayDistance))
                {
                    pointTouch = mRay.GetPoint(rayDistance) + nO;
                    if (pointTouch.y <= 1.3)
                    {
                        gObject.transform.position = new Vector3(pointTouch.x, 0.6f, pointTouch.z);
                    }
                    else
                    {
                        gObject.transform.position = new Vector3(pointTouch.x, pointTouch.y, pointTouch.z);

                    }

                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && gObject)
        {
            gObject = null;
        }
    }


}
