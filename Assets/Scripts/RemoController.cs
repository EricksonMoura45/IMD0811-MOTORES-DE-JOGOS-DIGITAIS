using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoController : MonoBehaviour
{
    public float posicaoDescanso = 0f;
    public float posicaoPressionado = 45f;
    public float forca = 10000f;
    public float angRemo = 150f;

    public string nome;
    HingeJoint hinge;


    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {


        JointSpring spring = new JointSpring();
        spring.spring = forca;
        spring.damper = angRemo;
                        
        if(Input.GetAxis(nome) == 1)
        {
            spring.targetPosition = posicaoPressionado;
        }
        else
        {
            spring.targetPosition = posicaoDescanso;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
