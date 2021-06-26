using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oru : MonoBehaviour
{
    [SerializeField] private float spriteWidth = 512;
    private Texture2D sprite;
    private new Renderer renderer;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite.texture;
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 colPoint = new Vector3(collision.GetContact(0).point.x, collision.GetContact(0).point.y - 0.1f, 0);
        float diff = renderer.bounds.size.x - Mathf.Abs(colPoint.x - renderer.bounds.max.x);
        float percentage = diff / renderer.bounds.size.x;

        // right
        GameObject go = new GameObject();
        go.transform.position = colPoint;
        float width = spriteWidth * (1 - percentage);
        Sprite sp = Sprite.Create(sprite, new Rect(spriteWidth - width, 0, width, sprite.height), new Vector2(0.0f, 0.5f), 100.0f);

        SpriteRenderer rend = go.AddComponent<SpriteRenderer>();
        rend.sprite = sp;

        go.AddComponent<Rigidbody2D>();
        go.AddComponent<BoxCollider2D>();

        // left
        go = new GameObject();
        go.transform.position = colPoint;
        width = spriteWidth * percentage;
        sp = Sprite.Create(sprite, new Rect(0,0, width, sprite.height), new Vector2(1.0f, 0.5f), 100.0f);

        rend = go.AddComponent<SpriteRenderer>();
        rend.sprite = sp;

        go.AddComponent<Rigidbody2D>();
        go.AddComponent<BoxCollider2D>();

        // destroy
        Destroy(gameObject);
    }
}
