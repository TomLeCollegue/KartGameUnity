using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;
    private float currentBreakForce;
    [SerializeField] private bool isBreaking;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider rearLeft;
    [SerializeField] private WheelCollider rearRight;
    
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform rearRightTransform;
    [SerializeField] private Rigidbody carRb;



    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWeels();
    }

    public void ResetCar()
    {
        frontLeft.brakeTorque = 100000;
        frontRight.brakeTorque = 100000;
        rearLeft.brakeTorque = 100000;
        rearRight.brakeTorque = 100000;
        frontLeft.motorTorque = 0;
        frontRight.motorTorque = 0;
        carRb.velocity = new Vector3(0, 0, 0);
    }

    private void HandleMotor()
    {
        frontLeft.motorTorque = verticalInput * motorForce;
        frontRight.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontLeft.brakeTorque = currentBreakForce;
        frontRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;

    }

    private void HandleSteering()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontLeft.steerAngle = steeringAngle;
        frontRight.steerAngle = steeringAngle;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void UpdateWeels()
    {
        UpdatesingleWheel(frontRight, frontRightTransform);
        UpdatesingleWheel(frontLeft, frontLeftTransform);
        UpdatesingleWheel(rearLeft, rearLeftTransform);
        UpdatesingleWheel(rearRight, rearRightTransform);
    }

    private void UpdatesingleWheel(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        transform.rotation = rot;
        transform.position = pos;
    }
}
