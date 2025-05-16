using System;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private float amtToMove = 10f;
    [SerializeField] private float moveSpeed = 0.5f;

    private Vector3 Pos;
    private float startingY = 0f;

    private GameObject GameObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObj = this.gameObject;
        Pos = GameObj.transform.position;
        startingY = Pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Don't forget to get our starting position first to add the negative to positive ranges to.
        // Absolute value causes bouncing for now but it allows us to only go up instead of down as well, for now.
        //Pos.y = startingY + Mathf.Abs(Mathf.Sin(Time.time * moveSpeed) *  amtToMove);
        Pos.y = Mathf.Lerp(Pos.y, startingY + (Mathf.Abs(Mathf.Sin(Time.time * moveSpeed)) * amtToMove), 1 );
        //Pos.y *= -1;
        GameObj.transform.position = Pos;
    }
}
