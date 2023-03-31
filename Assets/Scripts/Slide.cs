using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    public GameObject baseObject;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 controlPosition = transform.position;
        Vector3 basePosition = baseObject.transform.position;
        float distance = Vector3.Distance(controlPosition, basePosition);

        slider.value = distance;
        Debug.Log("Slider Value: " + slider.value);
    }
   
       
    

}
