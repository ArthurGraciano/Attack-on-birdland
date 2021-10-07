using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();

    }
}

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _sprite;
    protected CircleCollider2D _collider;
    protected Animator _animator;
    protected int points;
    protected int LifePoints;

    protected float Speed;

    protected Vector2 Direction;

    protected virtual void MovementPattern()
    {
        Direction = Vector2.right;
        _rigidbody2D.MovePosition
            (_rigidbody2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    private void Awake()
    {

        

        _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        _sprite = gameObject.AddComponent<SpriteRenderer>();
        _collider = gameObject.AddComponent<CircleCollider2D>();
        _animator = gameObject.AddComponent<Animator>();


        _collider.radius = 1.4f;
        _sprite.sortingOrder = 1;

        _rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rigidbody2D.gravityScale = 0;
        gameObject.tag = "Enemy";

        transform.position = RespawnRandomizer();
    }

    void FixedUpdate()
    {
        MovementPattern();
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {

    }


    public virtual void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }

    protected Vector2 RespawnRandomizer()
    {

        Vector2 Point;

        int RandomResp = Random.Range(0, RespawnPoints.RespawnPointsInstance.RespawnPointList.Count);

        Point = RespawnPoints.RespawnPointsInstance.RespawnPointList[RandomResp];

        return Point;

    }
}
