using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    public int playerScore = 0;
    private SpawnObjects spawnObjects;

    public UIManager uiManager;
    private GameManager gameManager;
    
    void Start()
    {
        transform.position = new Vector3(0, -2f, 0);
        spawnObjects = GameObject.Find("SpawnObjects").GetComponent<SpawnObjects>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (spawnObjects == null)
        {
            Debug.LogError("SpawnObjects is NULL.");
        }

        if (uiManager == null)
        {
            Debug.LogError("UIManager is NULL.");
        }
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.5f, 5.5f), transform.position.y, transform.position.z);
    }

    public void AddScore(int points)
    {
        playerScore += points;
        uiManager.UpdateScore(playerScore);
    }
    public void DecreaseLives()
    {
        uiManager.currentLives--;
        uiManager.UpdateHearts();

        if (uiManager.currentLives == 0)
        {
            spawnObjects.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
