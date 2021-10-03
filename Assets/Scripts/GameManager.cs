using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuGame;
    public GameObject menuGameOver;
    public float fast = 2;
    public GameObject col;
    public GameObject stone1;
    public GameObject stone2;
    public Renderer background;
    public bool gameOver = false;
    public bool gameStart = false;
    public List<GameObject> cols;
    public List<GameObject> stones;
    // Start is called before the first frame update
    void Start()
    {
        // Create a map
        for (int i = 0; i < 21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // Create a stones
        stones.Add(Instantiate(stone1, new Vector2(14, -2), Quaternion.identity));
        stones.Add(Instantiate(stone2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                gameStart = true;
            }
        }

        if (gameStart == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (gameStart == true && gameOver == false)
        {
            menuGame.SetActive(false);
            background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            // Move map
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }

                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * fast;
            }

            // Move stones
            for (int i = 0; i < stones.Count; i++)
            {
                if (stones[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    stones[i].transform.position = new Vector3(randomObs, -2, 0);
                }

                stones[i].transform.position = stones[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * fast;
            }
        }
    }
}
