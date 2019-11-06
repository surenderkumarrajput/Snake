using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodspawn : MonoBehaviour
{
    public GameObject Foodsprite;
    public GameObject snake;
    public GameObject upperwall, lowerwall, rightwall, leftwall;
    private List<GameObject> Food = new List<GameObject>();
    bool flag;
    
    void FoodInstance()
    {
         
            if (Food.Count < 5)
            {
            do
            {
               
                float x = Random.Range(leftwall.transform.position.x + 0.6f, rightwall.transform.position.x - 0.6f);
                float y = Random.Range(upperwall.transform.position.y - 0.6f, lowerwall.transform.position.y + 0.6f);
                Vector3 a = new Vector3(x, y, 0);
              
                    if (Vector3.Distance(snake.transform.position, a) <= 0.4)
                    {
                        flag = false;
                    }
                    for ( int i = 0; i < Player.Tail.Count; i++)
                    {
                        if (Vector3.Distance(Player.Tail[i].transform.position, a) <= 0.4f)
                        {
                            flag = false;
                        }
                    }
                    var temp = Instantiate(Foodsprite, new Vector2(x, y), Quaternion.identity);
                    Food.Add(temp);
                
            } while (flag==true);
            }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodInstance", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Removefood(GameObject food)
    {
        Food.Remove(food);
    }
}
