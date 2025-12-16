using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 1f;
    private float _timer;
    public float damage = 10f;
    public bool inflictsStatusEffect = false;
    public StatusEffectClass effectToApply;
    public GameObject PlayerTarget { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter2d Called");
        if(collision.gameObject == PlayerTarget)
        {
            
            PlayerTarget.GetComponent<PlayerCharacter>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
