using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set;}

    public Weapon hoveredWeapon = null;

    private void Awake()
    {   
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    // {
    //     Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         GameObject objectHitByRaycast = hit.transform.gameObject;

    //         if (objectHitByRaycast.GetComponent<Weapon>() && objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false)
    //         {
    //             hoveredWeapon = objectHitByRaycast.gameObject.GetComponent<Weapon>();
    //             hoveredWeapon.GetComponent<Outline>().enabled = true;

    //             if(Input.GetKeyDown(KeyCode.F))
    //             {
    //                 WeaponManager.Instance.PickupWeapon(objectHitByRaycast.gameObject);
    //             }
    //         }
    //         else
    //         {
    //             if (hoveredWeapon)
    //             {
    //                 hoveredWeapon.GetComponent<Outline>().enabled = false;
    //             }
    //         }
    //     }
    // }
    {
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
        GameObject objectHitByRaycast = hit.transform.gameObject;
        Weapon weapon = objectHitByRaycast.GetComponent<Weapon>();

        if (weapon && !weapon.isActiveWeapon)
        {
            if (hoveredWeapon != weapon)
            {
                // Disable the outline of the previous hovered weapon
                if (hoveredWeapon != null)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled = false;
                }

                // Update hoveredWeapon and enable its outline
                hoveredWeapon = weapon;
                hoveredWeapon.GetComponent<Outline>().enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                WeaponManager.Instance.PickupWeapon(objectHitByRaycast);
            }
        }
        else
        {
            // Disable the outline if the current object is not a valid weapon or is the active weapon
            if (hoveredWeapon != null)
            {
                hoveredWeapon.GetComponent<Outline>().enabled = false;
                hoveredWeapon = null;
            }
        }
    }
    else
    {
        // Disable the outline if the raycast hits nothing
        if (hoveredWeapon != null)
        {
            hoveredWeapon.GetComponent<Outline>().enabled = false;
            hoveredWeapon = null;
        }
    }
}
}

