using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class PlaneController : MonoBehaviour
{
    [SerializeField] private Gyroscope gyro;
    [SerializeField] private Airplane plane;
    [SerializeField] private GameObject shield;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float responsiveness;     // Responsivit� del joystick
    [SerializeField] private float gyroResponsiveness; // Responsivit� del gyro 

    private Rigidbody rb;
    public static float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private float currentHorizontalVelocity;
    private float currentVerticalVelocity;
    public float smoothTime;
    
    private bool isFiring;
    private float nextFireTime;
    private Gun[] guns;
    private int gunIndex;
    private int invertFactor = 1;
    private Vector3 force1;
    private Vector3 force2;

    private void Awake() {
        gyro = Input.gyro;
        gyro.enabled = true;
        rb = this.GetComponent<Rigidbody>();
        guns = plane.getGuns();
    }
    private void HandleInputs() {
        float targetHorizontal = joystick.Horizontal * responsiveness;
        float targetVertical = joystick.Vertical * responsiveness * invertFactor;
        yaw = gyro.rotationRate.y * gyroResponsiveness;
        roll = Mathf.SmoothDamp(roll, targetHorizontal, ref currentHorizontalVelocity, smoothTime);
        pitch = Mathf.SmoothDamp(pitch, targetVertical + (-gyro.rotationRate.x * gyroResponsiveness), ref currentVerticalVelocity, smoothTime);
    }
    private void Update() { HandleInputs(); }
    private void FixedUpdate() {
        if (isFiring && Time.time >= nextFireTime){
            FireGuns();
            nextFireTime = Time.time + 1f / plane.getGuns()[0].getFireRate();
        }
        force1 = transform.forward * plane.getMaxThrust() * throttle;
        force2 = Vector3.up * rb.velocity.magnitude;
        rb.AddForce(force1);
        rb.AddForce(force2);
        rb.rotation *= Quaternion.Euler(pitch, yaw, -roll);         // Rotazione dell'aereo basata su roll e pitch e yaw    
    }

    public Vector3 getForce1() { return force1; }
    public Vector3 getForce2() { return force2; }
    public float getThrottle() { return throttle; }
    public void setThrottleFromSlider(float sliderValue) { throttle = sliderValue; }
    public void OnPointerDown() { isFiring = true; }
    public void OnPointerUp() { isFiring = false; }
    public void SwitchGun() {  gunIndex++; }
    public void FireGuns() {
        int currIndex = gunIndex % guns.Length;
        guns[currIndex].Fire(guns[currIndex].getBulletSpawnPoints());
    }
    public void InvertControls() {
        invertFactor *= -1;
        Debug.Log(invertFactor);
        
    }
}