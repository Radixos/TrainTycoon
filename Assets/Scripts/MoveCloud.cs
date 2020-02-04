using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float forceMultiplier;
    public Vector3 scaleFactorMin;
    public Vector3 scaleFactorMax;

    //work on making sure that random.range is not less that 1
    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(scaleFactorMin.x, scaleFactorMax.x), Random.Range(scaleFactorMin.y, scaleFactorMax.y), Random.Range(scaleFactorMin.z, scaleFactorMax.z));
    }

    void Update()
    {
        transform.position += transform.right * forceMultiplier * Time.deltaTime;
        //transform.TransformDirection(0f, 90f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CloudsDestroyer")
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
