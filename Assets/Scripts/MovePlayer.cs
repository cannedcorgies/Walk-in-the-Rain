using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private Camera cam;

    private Rigidbody rb;
    public float walkSpeed = 10f;

    [SerializeField] private float horizontalAxis;
    [SerializeField] private float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {

        var dir = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")).normalized;

        rb.MovePosition(transform.position 
            + (Vector3.forward * Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime) 
            + (Vector3.right * Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime));

        if (dir.x != 0 || dir.z != 0) { transform.rotation = Quaternion.LookRotation(dir); }

    }

}
