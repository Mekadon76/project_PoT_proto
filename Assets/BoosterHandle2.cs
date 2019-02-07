using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterHandle2 : MonoBehaviour
{
    public GameObject origin_obj;
    public float circle_radius;
    public Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 v = touchpos - origin;
        Vector3 new_pos = origin + v.normalized * circle_radius;
    }
}
