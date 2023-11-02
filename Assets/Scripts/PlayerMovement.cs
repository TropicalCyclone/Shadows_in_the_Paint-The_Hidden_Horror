using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _crouchSpeed = 3f;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private float _turnSmoothVel;
    private bool _isCrouching = false;

    public bool GetCrouchStatus()
    {
        return _isCrouching;
    }
    private float _walkingSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        _walkingSpeed = _speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool playerCrouch = Input.GetButtonDown("Fire2");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = (Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref _turnSmoothVel,_turnSmoothTime));
            transform.rotation = Quaternion.Euler( 0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            rb.velocity = moveDir.normalized * GetPlayerSpeed();  
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (playerCrouch)
        {
            Debug.Log("button pressed");
            _isCrouching = !_isCrouching;
            Debug.Log(_speed);
        }
    }

    public float GetPlayerSpeed()
    {
        if (!_isCrouching)
        {
            return _walkingSpeed;
        }
        else
        {
            return _crouchSpeed;
        }
    }
}
