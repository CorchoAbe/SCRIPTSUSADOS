using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swait : MonoBehaviour
{
    private Quaternion originLocalRotation;
    private void Start()
    {
        originLocalRotation = transform.localRotation;
    }

    void Update()
    {
        updateSway();      
    }

private void updateSway(){
    // Sacamos los valores del mouse con el getAxis para acomodarlos en el eje de la pistola
    float t_xLookInput = Input.GetAxis("Mouse X");
    float t_yLookInput = Input.GetAxis("Mouse Y");
    //Calculamos la rotacion del arma
    //Quaternion guarda variables de rotacion del mouse y las aplicamos en el updateSway
    Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(t_xLookInput = 1.45f, Vector3.up);
    Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput = 1.45f, Vector3.right);
    Quaternion t_targerRotation = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;
    //se rota
    transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targerRotation, Time.deltaTime * 10f);
}
}