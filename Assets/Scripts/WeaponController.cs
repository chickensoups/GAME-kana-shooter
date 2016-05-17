﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    private GameObject weapon1;
    private GameObject weapon2;
    private GameObject weapon3;
    private GameObject weapon4;
    private static GameObject choosenWeapon;
    public static bool hadTarget;

    void Awake()
    {
        WeaponChoosen.WeaponChanged += ChooseWeapon;
        EnemyController.TargetFound += ChangeWeaponLabel;
    }

    void Start()
    {
        weapon1 = GameObject.Find("Weapon1");
        weapon2 = GameObject.Find("Weapon2");
        weapon3 = GameObject.Find("Weapon3");
        weapon4 = GameObject.Find("Weapon4");
        ChooseWeapon(weapon1);
        hadTarget = false;
    }

    public static string GetChoosenWeaponName()
    {
        return choosenWeapon.GetComponentInChildren<TextMesh>().text;
    }

    private void ChooseWeapon(GameObject weapon)
    {
        weapon.GetComponent<MeshRenderer>().enabled = true;
        switch (weapon.name)
        {
            case "Weapon1":
                choosenWeapon = weapon1;
                weapon2.GetComponent<MeshRenderer>().enabled = false;
                weapon3.GetComponent<MeshRenderer>().enabled = false;
                weapon4.GetComponent<MeshRenderer>().enabled = false;
                break;
            case "Weapon2":
                choosenWeapon = weapon2;
                weapon1.GetComponent<MeshRenderer>().enabled = false;
                weapon3.GetComponent<MeshRenderer>().enabled = false;
                weapon4.GetComponent<MeshRenderer>().enabled = false;
                break;
            case "Weapon3":
                choosenWeapon = weapon3;
                weapon1.GetComponent<MeshRenderer>().enabled = false;
                weapon2.GetComponent<MeshRenderer>().enabled = false;
                weapon4.GetComponent<MeshRenderer>().enabled = false;
                break;
            case "Weapon4":
                choosenWeapon = weapon4;
                weapon1.GetComponent<MeshRenderer>().enabled = false;
                weapon2.GetComponent<MeshRenderer>().enabled = false;
                weapon3.GetComponent<MeshRenderer>().enabled = false;
                break;
            default:
                choosenWeapon = weapon1;
                break;
        }

        //Display change weapon sound
        GetComponent<AudioSource>().Play();
        //show mesh renderer

    }

    private void ChangeWeaponLabel(GameObject newTarget)
    {
        if (newTarget != null)
        {
            int questionPosition = newTarget.GetComponent<EnemyController>().labelIndex;
            string[] labels = new string[4];
            int trueIndex = Mathf.CeilToInt(Random.Range(0, 3)); //random index with true value
            string trueText = GameController.answers[questionPosition];
            labels[trueIndex] = trueText;
            for (int j = 0; j < labels.Length; j++)
            {
                if (labels[j] == null)
                {
                    int position = Mathf.CeilToInt(Random.Range(0, Constants.ENG_CHARS.Length - 1));
                    labels[j] = GameController.answers[position];
                }
            }

            weapon1.GetComponentInChildren<TextMesh>().text = labels[0];
            weapon2.GetComponentInChildren<TextMesh>().text = labels[1];
            weapon3.GetComponentInChildren<TextMesh>().text = labels[2];
            weapon4.GetComponentInChildren<TextMesh>().text = labels[3];
            hadTarget = true;
        }
        else
        {
            weapon1.GetComponentInChildren<TextMesh>().text = "+";
            weapon2.GetComponentInChildren<TextMesh>().text = "+";
            weapon3.GetComponentInChildren<TextMesh>().text = "+";
            weapon4.GetComponentInChildren<TextMesh>().text = "+";
            hadTarget = false;
        }

    }
}
