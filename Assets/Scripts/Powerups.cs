using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    
    public GameObject HealthPower,SpeedBooster;
    public GameObject upperwall, lowerwall, rightwall, leftwall;
    public bool speedspawn = true, healthspawn = true;
    private GameObject powerup = null;
    // Start is called before the first frame update
    void Health()
    {
        if (powerup)
            Destroy(powerup);
       
        float x = Random.Range(leftwall.transform.position.x + 0.6f, rightwall.transform.position.x - 0.6f);
        float y = Random.Range(upperwall.transform.position.y - 0.6f, lowerwall.transform.position.y + 0.6f);
        powerup = Instantiate(HealthPower, new Vector2(x, y), Quaternion.identity);
       
     }
    void Speed()
    {
        if (powerup)
            Destroy(powerup);

        float x = Random.Range(leftwall.transform.position.x + 0.6f, rightwall.transform.position.x - 0.6f);
        float y = Random.Range(upperwall.transform.position.y - 0.6f, lowerwall.transform.position.y + 0.6f);
        powerup = Instantiate(SpeedBooster, new Vector2(x, y), Quaternion.identity);
       
    }
    void Start()
    {
       InvokeRepeating("Randomfunction", 5, Random.Range(10,15));
    }
    

    // Update is called once per frame
    void Randomfunction()
    {
        int f = Random.Range(1, 6);        
        if (f == 1 || f == 2)
        {
                Health();
        }
        else
        {
                Speed();
        }
      // Invoke("Randomfunction", Random.Range(5, 11));
    }
}
