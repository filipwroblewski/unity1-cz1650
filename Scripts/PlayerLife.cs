using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }

    void die()
    {
        anim.SetTrigger("death");
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    void restartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
