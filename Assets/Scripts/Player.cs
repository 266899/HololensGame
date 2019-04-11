using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public GameObject cursor;
    private float shootingDistance = 100f;
    public Image healthBar;
    public static bool alive = true;
    public static float health = 100f;
    public Text killCount;
    public GameObject pauseMenu;
   

    void Update ()
    {   
        RaycastHit hit;
        Ray forwardRay = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(forwardRay, out hit, shootingDistance))
        {
            if (hit.collider.tag == "Enemy")
            {
                cursor.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                cursor.GetComponent<Renderer>().material.color = Color.green;
            }
        }

        killCount.text = Enemy.killCount.ToString();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

}
