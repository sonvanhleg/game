using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float rotate;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmo = 24;
    public int currentAmo;
    private bool isReloading = false;
    [SerializeField] private TextMeshProUGUI ammoText;

    public bool IsReloading { get => isReloading; set => isReloading = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentAmo = maxAmo;
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }
    void RotateGun()
    {
        if(Input.mousePosition.x < 0 ||  Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y,displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotate);
        if(angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if (isReloading) return;
        if(Input.GetMouseButtonDown(0) && currentAmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmo--;
            UpdateAmmoText();
        }
    }
    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmo < maxAmo && !isReloading)
        {
            StartCoroutine(ReloadDelay());
        }else if(Input.GetMouseButtonDown(0) && currentAmo == 0 && !isReloading)
        {
            StartCoroutine(ReloadDelay());
        }
    }
    IEnumerator ReloadDelay()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        currentAmo = maxAmo;
        UpdateAmmoText();
        isReloading = false;
    }
    private void UpdateAmmoText()
    {
        if(ammoText != null)
        {
            if(currentAmo > 0)
            {
                ammoText.text = currentAmo.ToString();
            }
            else
            {
                ammoText.text = "Empty";
            }
        }
    }
}
