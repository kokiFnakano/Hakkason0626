using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oru : MonoBehaviour
{
    [SerializeField] private float spriteWidth = 512;
    [SerializeField] private GameObject score20, score50, score100;
    [SerializeField] private bool title = false;
    [SerializeField] private AudioClip[] clip;
    private Texture2D sprite;
    private new Renderer renderer;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite.texture;
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
            return;

        Vector3 colPoint = new Vector3(collision.GetContact(0).point.x, collision.GetContact(0).point.y - 0.1f, 0);
        float diff = renderer.bounds.size.x - Mathf.Abs(colPoint.x - renderer.bounds.max.x);
        float percentage = diff / renderer.bounds.size.x;

        // right
        GameObject go = new GameObject();
        go.transform.position = colPoint;
        go.transform.localScale = transform.localScale;
        float width = spriteWidth * (1 - percentage);
        Sprite sp = Sprite.Create(sprite, new Rect(spriteWidth - width, 0, width, sprite.height), new Vector2(0.0f, 0.5f), 100.0f);

        SpriteRenderer rend = go.AddComponent<SpriteRenderer>();
        rend.sprite = sp;

        Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
        go.AddComponent<BoxCollider2D>();
        if(title) rb.AddForce(Vector3.right * 15);

        // left
        go = new GameObject();
        go.transform.position = colPoint;
        go.transform.localScale = transform.localScale;
        width = spriteWidth * percentage;
        sp = Sprite.Create(sprite, new Rect(0,0, width, sprite.height), new Vector2(1.0f, 0.5f), 100.0f);

        rend = go.AddComponent<SpriteRenderer>();
        rend.sprite = sp;

        rb = go.AddComponent<Rigidbody2D>();
        go.AddComponent<BoxCollider2D>();
        if(title) rb.AddForce(Vector3.left * 15);

        // score
        if (score20 != null)
        {
            if (percentage > 0.4f && percentage < 0.6f)
                Instantiate(score100, transform.position, Quaternion.identity);
            else if (percentage > 0.2f && percentage < 0.8f)
                Instantiate(score50, transform.position, Quaternion.identity);
            else
                Instantiate(score20, transform.position, Quaternion.identity);
        }
        else if(title)
        {
            WaremonoCreater.startGame = true;
        }

        // destroy
        if(!title) AudioManager.Instance.PlaySE(clip[Random.Range(0, clip.Length)]);
        Destroy(gameObject);
    }
}
