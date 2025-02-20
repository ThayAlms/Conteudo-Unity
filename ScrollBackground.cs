using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public Renderer aux;
    public float speed = 0.1f;
    private GameObject player;
    private float playerPosX, playerPosY;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Make sure the Player has the correct name.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;
            transform.position = new Vector2(playerPosX, playerPosY);
        }

        float h = Input.GetAxis("Horizontal") * speed;

        if (aux != null && aux.material != null)
        {
            Vector2 offset = aux.material.mainTextureOffset;
            offset.x += h * Time.deltaTime; // Smooth scrolling based on time
            aux.material.mainTextureOffset = offset;
        }
        else
        {
            Debug.LogError("Renderer or Material is missing! Assign the Renderer in the Inspector.");
        }
    }
}
