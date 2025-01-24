using UnityEngine;

public class BulletLife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit gumsssss");

        if (collision.gameObject.tag == "Gum")
        {
            Debug.Log("Bullet hit gum");
            collision.gameObject.GetComponent<BubbleGumGenerator>().ResetScale();
            Destroy(gameObject);
        }
    }
}
