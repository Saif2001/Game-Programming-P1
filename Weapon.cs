using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;

    public Camera playerCam;
    public Transform bulletSpawn;

    public float health = 50f;

    public float bulletForce;

    public int damage;

    public float firerate;

    public bool automaticWeapon;

    public int kills;

    bool shooting;



    private void fpsInput()
    {
        if (automaticWeapon) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (shooting)
        {
            Fire();
        }

    }

    // Update is called once per frame
    void Update()
    {
        fpsInput();
   
        if(health <= 0)
        {
            die_Player();
        }
    }

    void Fire()
    {
        firerate -= Time.deltaTime;

        if (firerate <= 0)
        {
            Ray raycastShot = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            Vector3 positionVector;
            if (Physics.Raycast(raycastShot, out hit))
            {
                positionVector = hit.point;
            }
            else
            {
                positionVector = raycastShot.GetPoint(200);
            }
            Vector3 direction = positionVector - bulletSpawn.position;
          


            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            newBullet.transform.forward = direction.normalized;

            newBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletForce, ForceMode.Impulse);


            firerate = 0.1f;
        }
    
        
    }

    void die_Player()
    {
        Debug.Log("DIED");
    }
    


}
