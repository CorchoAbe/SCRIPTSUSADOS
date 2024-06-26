using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaControlarJugador : MonoBehaviour
{
     public List<WeaponController> startingWeapons = new List<WeaponController>();

    public Transform weaponParentSocket;
    public Transform defaultWeaponPosition; //Posicion inicial del arma
    public Transform aimingPosition; //Poscion cuando apuntamos

    public int activeWeaponIndex { get; private set; } //Arma equipada cualquier script puede acceder a ella, pero no modificarla

    private WeaponController[] weaponSlots = new WeaponController[5]; //armas maximas

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponIndex = -1; //Iniciar sin armas

        foreach (WeaponController startingWeapon in startingWeapons) //Por cada startingWeapon llamamos la funcion AddWeapon
        {
            AddWeapon(startingWeapon);
        }
    }

    // Update is called once per frame
    void Update()
    {   //Tecla numero 1 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
    }
    //Cambiar el arma con el indece de nuestra
    private void SwitchWeapon(int p_weaponIndex)
    {       //If para que no cambie nuestra arma y que sea mayor a nuestro indece de armas maxima osea 5
        if (p_weaponIndex != activeWeaponIndex && p_weaponIndex >= 0)
        {
            weaponSlots[p_weaponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_weaponIndex;
        }
    }


    //Anadir una arma 
    private void AddWeapon(WeaponController p_weaponPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;

        //Añadir arma al jugador pero no mostrarla
        for (int i = 0; i<weaponSlots.Length; i++) // si encuentra un slot vacio agregar un armma
        {
            if (weaponSlots[i] == null)
            {
                WeaponController weaponClone = Instantiate(p_weaponPrefab, weaponParentSocket);
                weaponClone.gameObject.SetActive(false);

                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }
}