using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    [SerializeField]
    private Photographer _photographer;

    [SerializeField]
    private Transform _followingTarget;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();

        _photographer.InitCamera(_followingTarget);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementInput();
    }
    private void UpdateMovementInput()
    {
        Quaternion rot = Quaternion.Euler(x: 0, _photographer.Yaw, z: 0);



        _characterMovement.SetMovementInput(rot * Vector3.forward * Input.GetAxis("Vertical") +
                                            rot * Vector3.right * Input.GetAxis("Horizontal"));
    }
}
