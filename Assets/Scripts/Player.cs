using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Color disabledColor;
    public Color defaultColour;
    public AudioSource gunShotSound;
    public AudioSource reloadSound;
    private int ammo = 0;
    private GameObject ammoObj;
    private Text ammoTxt;

    private GameObject shootButtonObj;
    private Button shootButton;
    private Image shootButtonColour;

    private GameObject target;
    private Enemy targetScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoObj = GameObject.Find("AmmoTxt");
        if (ammoObj != null) { ammoTxt = ammoObj.GetComponent<Text>(); }
        if (ammoTxt != null) { ammoTxt.text = ammo.ToString(); }

        shootButtonObj = GameObject.Find("ShootButton");
        if (shootButtonObj != null) { shootButton = shootButtonObj.GetComponent<Button>(); shootButtonColour = shootButtonObj.GetComponent<Image>(); }

        if (ammo <= 0)
        {
            if (shootButtonColour != null) { shootButtonColour.color = disabledColor; }
            if (shootButton != null) { shootButton.enabled = false; }
        }
        else if (ammo > 0)
        {
            if (shootButtonColour != null) { shootButtonColour.color = defaultColour; }
            if (shootButton != null) { shootButton.enabled = true; }
        }
    }

    public void Shoot()
    {
        RaycastHit rayHit;
        ammo--;
        gunShotSound.Play();
        if (Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, 100))
        {
            if (rayHit.transform.gameObject.name == "Enemy" || rayHit.transform.gameObject.name == "Enemy(Clone)")
            {
                target = rayHit.transform.gameObject;
                if (target != null) { targetScript = target.GetComponent<Enemy>(); }
                if (targetScript != null) { targetScript.TakeDamage(100); }
            }
        }
    }

    public void Reload()
    {
        ammo = 36;
    }
}
