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

    //Several variables relating to weapon handling and player characteristics

    private void fpsInput()
    {
        if (automaticWeapon) shooting = Input.GetKey(KeyCode.Mouse0);       //Separation between automatic and semi-auto weapons
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (shooting)
        {
            Fire();
        }

    }

    // Update is called once per frame
    void Update()
    {
        fpsInput();         //Input handler for different weapon types
   
        if(health <= 0)
        {
            die_Player();           //Death subroutine
        }
    }

    void Fire()
    {
        Debug.Log("Firing");
        firerate -= Time.deltaTime;

        if (firerate <= 0)
        {
            Ray raycastShot = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));         //Raycast to center screen
            RaycastHit hit;

            Vector3 positionVector;
            if (Physics.Raycast(raycastShot, out hit))
            {
                positionVector = hit.point;             //Hitting objects nearby or a distant point if no objects in range
            }
            else
            {
                positionVector = raycastShot.GetPoint(200);
            }
            Vector3 direction = positionVector - bulletSpawn.position;      //Position vector to center screen
          


            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            newBullet.transform.forward = direction.normalized;         //Instantiating and adding force to bullet - believable mechanics with AddForce

            newBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletForce, ForceMode.Impulse);


            firerate = 0.1f;            //Firerate of M4
        }
    
        
    }

    void die_Player()
    {
        Debug.Log("DIED");          //Kill player
    }
    


}
