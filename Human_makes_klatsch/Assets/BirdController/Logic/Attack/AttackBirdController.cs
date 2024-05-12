using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Determines if the bird is currently attacking the player
/// or returning from its attack.
/// </summary>
public enum AttackStage
{
    Attack = 0,
    Return = 1
}



public class AttackBirdController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10.0f;
    [SerializeField] [Range(-45, 45)] private float _returnAngle = 0;
    [SerializeField] private bool _useDebugger = false;
    private GameObject _target;
    private AttackStage _attackStage = AttackStage.Attack;
    private Vector3 _returnPosition;
    private SpriteRenderer _spriteRenderer;

    // Start Event
    // -> In this case should be called when the bird is spawned.
    void Start()
    {
        // Try to find player game obj in world
        FindTarget();

        // Try to find & bind collision script in children
        BindToCollisionEvent();

        // Try to find the sprite renderer
        FindSpriteRenderer();
    }

    // Update Event
    // -> In here the movement of the bird is handled
    void Update()
    {
        // Look At (Based on target)
        Vector3 lookAtPosition = Vector3.zero;

        // Bird movement based on attack stage (attack / return)
        switch (_attackStage)
        {
            // Move bird to player object using Vector -> Move Towards
            case AttackStage.Attack:
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, _target.transform.position, _movementSpeed * Time.deltaTime);
                lookAtPosition = _target.transform.position;
                break;

            // Move bird to return position using Vector -> Move Towards
            case AttackStage.Return:
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, _returnPosition, _movementSpeed * Time.deltaTime);
                lookAtPosition = _returnPosition;
                break;
        }

        // Get target direction
        Vector3 direction = lookAtPosition - transform.position;
        direction.Normalize();

        // Get Z rotation from X and Y (using Mathf library)
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set rotation on Z axis
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ - 90);
    }

    
    #region Functions
    
    /// <summary>
    /// Tries to find the target in scene using the "Player" tag.
    /// If target invalid (not found) the bird will destroy itself.
    /// </summary>
    private void FindTarget()
    {
        // Try to find the egg
        _target = GameObject.FindGameObjectWithTag("Egg");

        // Destroy self if egg not found
        if(_target is null)
        {
            // Debug message
            PrintMessage(false, "Egg not found. Destroy self.");

            // Destroy self
            Destroy(this.gameObject);

            // End here
            return;
        }

        // Short message that player was found
        PrintMessage(true, "Egg found, continue.");
        //return;
    }

    /// <summary>
    /// Will search for the collision script in the owners children.
    /// If collision script not found, will destroy itself.
    /// </summary>
    private void BindToCollisionEvent()
    {
        BirdCollision collisionScript = null;

        // Loop trough children and try to find collision script
        foreach(Transform child in transform)
        {
            // Get script
            collisionScript = child.GetComponent<BirdCollision>();

            // Check if script is valid
            if(collisionScript is not null)
            {
                // Bind to on player hit
                collisionScript.OnPlayerHit += PlayerHitBinding;

                // End Function: Only care for first found script
                return;
            }
        }

        // If no script after loop, destroy self
        if(collisionScript is null)
        {
            // Debug message
            PrintMessage(false, "No collision script found. Destroy self.");
            Destroy(this.gameObject);
            return;
        }
    }

    /// <summary>
    /// Tries to find and set the sprite renderer contained in one of
    /// the owners children.
    /// </summary>
    private void FindSpriteRenderer()
    {
        // Loop trough children and try to find collision script
        foreach(Transform child in transform)
        {
            // Try to get component
            _spriteRenderer = child.GetComponent<SpriteRenderer>();

            // Check if component is valid
            if(_spriteRenderer is not null)
            {
                // Ignore other children -> End funtion
                return;
            }
        }

        // If there is no sprite component
        if(_spriteRenderer is null)
        {
            // Debug message
            PrintMessage(false, "No sprite renderer found! Destroy self.");
            Destroy(this.gameObject);
            return;
        }
    }

    /// <summary>
    /// Calculates the return position for the bird after
    /// attack on player.
    /// </summary>
    private Vector3 CalcReturnPosition()
    {
        // Get the offset (Up & Rotated)
        Vector3 offset = Quaternion.Euler(0, 0, _returnAngle * -1) * (Vector3.up * 10);

        // Adjust to target location
        return _target.transform.position + offset;
    }

    /// <summary>
    /// Call this function to stop the birds attack. Note, if bird
    /// is already returning, calling this function wont do anything.
    /// </summary>
    public void EndAttack()
    {
        // Only perform when attacking
        if(_attackStage == AttackStage.Attack)
        {
            // Calc the return position
            _returnPosition = CalcReturnPosition();

            // Switch Attack stage
            _attackStage = AttackStage.Return;

            // Start CoRoutine
            StartCoroutine(RenderCheck());
        }
    }

    /// <summary>
    /// Use this function to reset the bird into attack mode after already
    /// being set in return mode. Operation will fail if birds target invalid
    /// or if bird already in attack mode.
    /// </summary>
    /// <returns>Returns true when bird was set back to attack mode. Returns false if target invalid or bird already attacking.</returns>
    public bool AttackAgain()
    {
        // Only perform when returning
        if(_attackStage == AttackStage.Return)
        {
            // Make sure target is still valid
            if(_target is null)
            {
                // Get new target
                FindTarget();

                // Return false if no target found
                if(_target is null)
                {
                    return false;
                }
            }

            // Set Bird to attacking stage
            _attackStage = AttackStage.Attack;

            // End CoRoutine
            StopCoroutine(RenderCheck());

            // Return operation success
            return true;
        }

        // Return false if bird already attacking
        return false;
    }

    #endregion

    #region Bindings

    /// <summary>
    /// This function is bound to the OnPlayerHit() event im
    /// bird collision script and is executed when the birds collider
    /// hits a game object with player tag.
    /// </summary>
    private void PlayerHitBinding()
    {
        GameManager.Instance.ApplyDamager();

        // Tells the bird to return
        EndAttack();

        // Debug Message
        PrintMessage(true, "Attack target hit. End attack -> Start return.");
    }

    #endregion

    #region Co-Routines

    /// <summary>
    /// Check if still rendered by camera, if not destroy self.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RenderCheck()
    {
        while(_spriteRenderer.isVisible)
        {
            // Do nothing

            // Wait for end of frame
            yield return new WaitForEndOfFrame();
        }

        // Delay of 1 sec
        yield return new WaitForSeconds(1);

        // Bird Destroy
        PrintMessage(true, "Not rendered anymore. Bird destroy self.");

        // Destroy self
        Destroy(this.gameObject);
        GameManager.Instance.SetHunterStatus(false);
    }

    #endregion

    #region Debug Stuff

    /// <summary>
    /// Prints a message (positive or negative) to the debug console.
    /// </summary>
    /// <param name="positive"></param>
    /// <param name="message"></param>
    private void PrintMessage(bool positive, string message)
    {
        // Make sure debug is active
        if(_useDebugger is false)
        {
            return;
        }

        // Print positive message
        if(positive)
        {
            Debug.Log(string.Format("<color=#32a852>{0}: Debugger -> {1}</color>", name, message));
            return;
        }

        // Print negative message
        Debug.Log(string.Format("<color=#f08502>{0}: Debugger -> {1}</color>", message));
        return;
    }

    #endregion
}
