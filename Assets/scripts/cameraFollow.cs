using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform followTransform;
    //public Vector3 offset;

    // This function is what helps the camera follow Caesar/The Player.
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        //transform.position = followTransform.position+offset;
    }
}