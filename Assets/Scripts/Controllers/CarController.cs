using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;

public class CarController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    PhotonView view;
    public enum Axel
    {
        Front,
        Rear
    }
    private int _speed = 600;

    public int speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
        }
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;
    }

    [SerializeField] private float maxAcceleration = 30.0f;

    [SerializeField] private float turnSensitivity = 1.0f;
    [SerializeField] private float maxSteerAngle = 30.0f;

    [SerializeField] private Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    [HideInInspector] public float steerInput;

    public Rigidbody carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        GetInputs();
        AnimateWheels();
        WheelEffects();
    }

    void LateUpdate()
    {
        //if (view.IsMine)
        //{
            Move();
            Steer();
        //}
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {
        moveInput = _floatingJoystick.Vertical;
        steerInput = _floatingJoystick.Horizontal;
    }

    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * _speed * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.smokeParticle.Emit(1);
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }
}