using UnityEngine;
using System.Collections;

public class WeaponChoosen : MonoBehaviour {

    void OnMouseDown()
    {
        if (WeaponController.GetChoosenWeaponName() != GetComponentInChildren<TextMesh>().text && !GameController.pause)
        {
            if (WeaponChanged != null)
            {
                WeaponChanged(gameObject);
            }
        }
    }

    public delegate void ChangeWeapon(GameObject weapon);

    public static event ChangeWeapon WeaponChanged;
}
