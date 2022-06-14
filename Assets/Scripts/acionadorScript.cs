using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acionadorScript : MonoBehaviour
{
    float poder;
    public float poderMaximo = 100f;
    public float adicionaPoder = 100f;
    public Slider poderSlider;
    Rigidbody bola;

    void Start()
    {
        poderSlider.minValue = 0f;
        poderSlider.maxValue = poderMaximo;
    }

    private float GetPoderMaximo()
    {
        return poderMaximo;
    }

    void FixedUpdate()
    {
        poderSlider.value = poderMaximo;
        if (bola != null)
        {
            if(Input.GetAxis("Shoot") == 1){
                if(poder <= poderMaximo)
                {
                    poder = adicionaPoder * Time.deltaTime;
                }
            }
        }
        else
        {
            bola.AddForce(poder * Vector3.left);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            poderSlider.gameObject.SetActive(true);
            bola = other.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            poderSlider.gameObject.SetActive(false);
            bola = null;
            poder = 0f;
        }
    }

}
