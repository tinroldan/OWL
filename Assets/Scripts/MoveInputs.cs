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

    public Vector3 pointTouch;
    public GameObject gObject = null;
    Plane planeObj;
    Vector3 nO;

    [SerializeField]
    float closePos, snapPos;

    public GameObject inputInstance;

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

    void UpdateTouch()
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
        else if (Input.GetMouseButton(0) && (gObject))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;


            if (gObject.gameObject.tag != "Input")
            {
                return;
            }



            if (planeObj.Raycast(mRay, out rayDistance))
            {
                pointTouch = mRay.GetPoint(rayDistance) + nO;

                if (gObject.GetComponent<FindSnap>() != null && gObject.GetComponent<FindSnap>().snap != null)
                {
                    snapPos = gObject.GetComponent<FindSnap>().snap.transform.position.y;
                    closePos = snapPos + 0.5f;
                    //snap machete
                    if (pointTouch.y <= closePos)
                    {
                        gObject.transform.position = new Vector3(pointTouch.x, snapPos, gObject.transform.position.z);
                    }
                    else
                    {
                        gObject.transform.position = new Vector3(pointTouch.x, pointTouch.y, gObject.transform.position.z);

                    }

                }
                else
                {
                    gObject.transform.position = new Vector3(pointTouch.x, pointTouch.y, gObject.transform.position.z);

                }


                //snap menos machete

            }




        }
        else if (Input.GetMouseButtonUp(0) && gObject)
        {
            gObject = null;
        }
    }

    public Vector3 touchPos;
    void Update()
    {
        //touchPos = Input.mousePosition;
        //touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        //if (inputInstance != null)
        //{
        //    Instantiate(inputInstance);
        //    inputInstance = null;
        //}
        UpdateTouch();

    }


}
