using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] GameObject[] weaponSlot;
    public int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon == 0)
        {
            weaponSlot[0].SetActive(true);
            weaponSlot[1].SetActive(false);
        }
        if (currentWeapon == 1)
        {
            weaponSlot[0].SetActive(false);
            weaponSlot[1].SetActive(true);
        }
    }
}
