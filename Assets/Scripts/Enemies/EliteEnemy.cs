using UnityEngine;

public class EliteEnemy : Enemy
{
    private Vector2 startPos; // Starting Position
    private int direction = -1; // Direction my enemy is facing

    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        base.Awake();

        startPos = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

   
}
