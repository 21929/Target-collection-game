using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject target;

    float timer;

    int collected;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int count = 0; count < 5; count++)
        {
            int x = Random.Range(-8, 8);
            int y = Random.Range(-4, 4);

            Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collected < 5)
        {
            timer += Time.deltaTime;
            timerText.GetComponent<TextMeshProUGUI>().text = timer.ToString("F1");
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.05f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.05f, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.05f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            collected++;
            Destroy(other.gameObject);
        }
    }
}
