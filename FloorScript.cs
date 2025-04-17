using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private Rigidbody targetrb;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetrb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (gameObject.CompareTag("Fruiit"))
        {
            print("The floor has got hit");
            gameManager.ChangeHealth(-1);
        }
        if(gameObject.CompareTag("Vegetable"))
        {
            print("The floor has got hit");
            gameManager.ChangeHealth(-1);
        }
    }
}
