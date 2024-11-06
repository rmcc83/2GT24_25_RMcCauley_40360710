using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public Animator animator;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flash fuel indicator if fuel animation bool in player controller script is true
        if (playerController.fuelAnim == true)
        {
            animator.SetBool("FuelAnim", true);

        }

        else animator.SetBool("FuelAnim", false);
    }
}
