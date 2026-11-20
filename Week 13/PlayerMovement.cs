using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    
    //objects & components
    public Rigidbody2D rb;
    public SpriteRenderer player;
    public SpriteRenderer sword;
    public GameObject firePoint;
    //forced movement
    public Transform weaponPivot;
    public Knockback knockback;

    //sprites
    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

    
    void Start()
    {
        sword.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            speedX = -moveSpeed;
            player.sprite = bearleft;

            SwordOrientation(bearleft, 90f);
            weaponPivot.localPosition = new Vector3(-2, -3);
            sword.sortingOrder = -1;
            

            FireOrientation(firePoint, 0f);
            firePoint.transform.localPosition = new Vector4(2, -1);
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            speedX = moveSpeed;
            player.sprite = bearright;

            weaponPivot.localPosition = new Vector3(0, 0);
            SwordOrientation(bearright, 0f);
            sword.sortingOrder = -1;

            FireOrientation(firePoint, -90f);
            firePoint.transform.localPosition = new Vector4(0.5f, -0.75f);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            speedY = moveSpeed;
            player.sprite = beartop;

            SwordOrientation(beartop, 90f);//good
            weaponPivot.localPosition = new Vector3(-2.5f, -2.5f);
            sword.sortingOrder = -1;

            FireOrientation(firePoint, 270f);
            firePoint.transform.localPosition = new Vector4(2,-2.5f);
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            speedY = -moveSpeed;
            player.sprite = beardown;

            SwordOrientation(beardown, 0f);
            weaponPivot.localPosition = new Vector3(0, 0);
            sword.sortingOrder = 1;

            FireOrientation(firePoint, 180f);
            firePoint.transform.localPosition = new Vector4(0.65f,- 0.75f);
        }
        else
        {
            speedY = 0;
        }

        // don't overwrite the knockback push while it's happening
        if (knockback == null || !knockback.isKnockedBack)
        {
            rb.linearVelocity = new Vector2(speedX, speedY);
        }
    }

    //manages the orientation of the sword based on the player's sprite and the angle of the sword
    void SwordOrientation(Sprite playerSprite, float angle)
    {
        player.sprite = playerSprite;

        if (weaponPivot != null)
        {
            bool flipX = player.flipX;
            weaponPivot.localRotation = flipX ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);
        }
    }

    //manages the orientation of the fire point based on the player's sprite and the angle of the fire point
    //"up" in bullet script is the direction of the bullet, so we need to rotate the fire point to match the player's sprite and the angle of the fire point (down) which is 180 degrees from the player's sprite
    void FireOrientation(GameObject firePoint, float angle)
    {
        bool flipX = player.flipX;
        firePoint.transform.localRotation = flipX ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);

        bool flipY = player.flipY;
        firePoint.transform.localRotation = flipY ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);
    }
}