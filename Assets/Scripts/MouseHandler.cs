using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [Header("Refs")] 
    private InputHandler ip;
    private GameObject player;
    public GameObject aimingCircle;

    [Header("Stats")] [SerializeField]
    private float maxDistanceFromPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = ReferenceManager.referenceManager.GetComponent<ReferenceManager>()
            .GiveGame(ReferenceManager.RefEnumGame.player);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (GameManager.state == GameManager.GameStatus.running)
        {
            //No mouse seen keep it in the circle
            Vector2 direction = mousePos - (Vector2)player.transform.position;
            if (direction.magnitude > maxDistanceFromPlayer)
            {
                aimingCircle.transform.position = (Vector2)player.transform.position - (-1 * direction.normalized) * maxDistanceFromPlayer;
            }
            else
            {
                aimingCircle.transform.position = mousePos;
            }
        }
    }
}
