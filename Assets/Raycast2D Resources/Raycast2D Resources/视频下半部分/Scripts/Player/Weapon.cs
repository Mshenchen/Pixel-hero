using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Rotation")]
    private Vector2 direction;
    public Transform firePoint;

    [SerializeField] private GameObject bullet;
    public float force = 15f;

    private void Update()
    {
        WeaponRotation();

        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void WeaponRotation()
    {
        //target Pos【即鼠标的当前位置】 - current weapon Pos【最好是枪口的位置，或者transform.position】
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//Mathf.Rad2Deg: Constant value 57
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    

    private void Fire()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right*force, ForceMode2D.Impulse);
        //TODO LATER Shot Effect
    }
}
