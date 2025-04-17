using UnityEngine;
 
public class ScoreScript : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem FruitCrash;
    private float xRange = 6;
    private float yPos = 7;
    private float zPos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -4.75)
        {
            Destroy(gameObject);
            Instantiate(FruitCrash, transform.position, FruitCrash.transform.rotation);
            gameManager.ChangeHealth(-1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Fruiit"))
        {
            gameManager.Score(+2);
        }
        if (gameObject.CompareTag("Vegetable"))
        {
            gameManager.Score(+1);
        }

    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange,xRange), yPos, 0);
    }

}
