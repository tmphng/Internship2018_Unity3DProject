using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour
{
    public Transform target;
    [Range (-10, 10)] public float speedRotation = 0;
    [Range (0, 10)] public float speedTranslation = 0;

    private bool SphereMovementState = true;

    void Update()
    {
        if (SphereMovementState)
        {
            SpinToWin();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SphereMovementState = !SphereMovementState;
        }
    }

    public void SpinToWin()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * speedRotation);
        transform.Translate(0, 0, 3 * Time.deltaTime * speedTranslation);
    }

}