using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRadius : MonoBehaviour
{

    public GameObject targetGroup;
    private CinemachineTargetGroup ctg;

    public Transform cameraMarker;

    public float focusDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        ctg = targetGroup.GetComponent<CinemachineTargetGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateFocusPoints();

    }

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.GetComponent<FocusPoint>()) {

            var found = false;

            for (int i = 0; i < ctg.m_Targets.Length; i++) {

                if (ctg.m_Targets[i].target == col.transform) {

                    found = true;

                }

            }

            if (!found) {

                ctg.AddMember(col.transform, 1f, 0f);

            }

        }

    }

    void UpdateFocusPoints() {

        if (ctg.m_Targets.Length > 2) {

            if (ctg.FindMember(cameraMarker) > 0) {

                ctg.RemoveMember(cameraMarker);

            }

        }

        if (ctg.m_Targets.Length <= 1) {

            Debug.Log("attempting to add marker...");

            ctg.AddMember(cameraMarker, 1f, 0f);

        }

        for (int i = 0; i < ctg.m_Targets.Length; i++) {

            var currTarget = ctg.m_Targets[i].target;

            if (Vector3.Distance(transform.position, currTarget.position) > focusDistance) {

                Debug.Log("TOO FAR");
                ctg.RemoveMember(currTarget);

            }

        }

    }

}
