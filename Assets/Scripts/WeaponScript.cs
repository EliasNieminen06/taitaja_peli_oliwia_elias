using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] GameObject[] weaponSlot;
    [SerializeField] ShowelWeaponScript sws;
    [SerializeField] BowWeaponScript bws;
    public int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
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
        if (Input.GetKeyDown(KeyCode.F) && sws.canAttack && bws.canAttack)
        {
            if (currentWeapon == 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon = 1;
            }
        }
    }
}
