using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f; //adjustable ammount of damage dealt
    public float range = 100f; //adjustable range before raycast stopped

    public Camera fpsCam; //player camera
    void Update()
    {
        //if click call Shoot function
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    //Shoots a line that detects objects that can be shot; if hits it does damage
    void Shoot ()
    {
        RaycastHit hit; //info about the hit (position, what was hit, etc)

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //shoots raycast, outputs to hit, evaluates to bool 
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
            }
        }
    }
}
