using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{
    private Quaternion correctionQuaternion;

    //Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Debug.Log("Gyro Enabled");
        correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
    }

    //Update is called once per frame
    private void Update()
    {
        transform.rotation = correctionQuaternion * GyroToUnity(Input.gyro.attitude);
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
