using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walking_speed = 1.0f;
    public float running_speed = 3.0f;
    public float player_speed = 0f;
    public bool is_running = false;

    public float max_sprint = 5f; // Five seconds of sprint
    public float sprint_meter = 5f; // How much sprint currently
    public bool is_recovering = false; // Has become exhausted and cannot sprint

    public float rotation = 0f;
    public float rotation_speed = 1f;
    public float cam_rotation = 0f;
    public float cam_rotation_speed = 1f;


    GameObject cam;
    Transform cam_transform;
    Rigidbody my_rigidbody;

    public GameObject ground_detector;
    public LayerMask ground_is;
    public bool is_on_ground = false;
    public float jump_height = 10.0f;
    public float ground_range = 1f;

    public GameObject aura_controller;

    public bool control_state = true;
    public Vector3 zero;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Player Camera");
        my_rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cam_transform = cam.GetComponent<Transform>();
    }

    public void change_control_state(bool new_state)
    {
        control_state = new_state;
    }

    public void force_to_look(Vector3 looking_at)
    {
        cam_transform.LookAt(looking_at);
    }

    // Update is called once per frame
    void Update()
    {

        if (control_state)
        {

            is_on_ground = Physics.CheckSphere(ground_detector.transform.position, ground_range, ground_is);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                aura_controller.GetComponent<Aura>().switch_state();
            }

            if (Input.GetKey(KeyCode.LeftShift) && is_recovering == false)
            {
                is_running = true;
            } else
            {
                is_running = false;
            }

            if (!is_running)
            {
                player_speed = walking_speed;

                if (sprint_meter < max_sprint)
                {
                    sprint_meter = sprint_meter + Time.deltaTime;
                }
            }
            if (is_running)
            {
                player_speed = running_speed;
                sprint_meter = sprint_meter - Time.deltaTime;
            }

            if (sprint_meter < 0f)
            {
                is_recovering = true;
                is_running = false;
            }

            if (sprint_meter >= max_sprint)
            {
                is_recovering = false;
            }

            if (is_on_ground == true && Input.GetKeyDown(KeyCode.Space))
            {
                my_rigidbody.AddForce(transform.up * jump_height);
            }

            Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * player_speed + transform.right * Input.GetAxis("Horizontal") * player_speed;
            my_rigidbody.velocity = new Vector3(newVelocity.x, my_rigidbody.velocity.y, newVelocity.z);

            rotation = rotation + Input.GetAxis("Mouse X") * rotation_speed;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

            cam_rotation = cam_rotation + Input.GetAxis("Mouse Y") * cam_rotation_speed * -1.0f;
            cam_rotation = Mathf.Clamp(cam_rotation, -40f, 40f);
            cam.transform.localRotation = Quaternion.Euler(new Vector3(cam_rotation * cam_rotation_speed, 0.0f, 0.0f));
        } else
        {
            my_rigidbody.velocity = new Vector3(0f, 0f, 0f);
            transform.position = zero;
        }
    }
}
