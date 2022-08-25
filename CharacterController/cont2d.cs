using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cont2d : MonoBehaviour
{
    [Header("Controller")]
    public float movementspeed;
    
    Rigidbody2D rg;
    public float jumpForce;
    //float movement;
    //float extrajump;
    bool faceright = true;

    [Header("LifeAndDead")]
    public bool Death;
     int restOfHearth;
    public Image[] hearth = new Image[3];


    //[Header("ForGround")]
    //public Transform GroundCheck;
    //public LayerMask GroundLayer;
    //public bool isGrounded;
    //public Vector2 GroundCheckSize;


    //public bool isJumping;


    [Header("For WallSliding")]
     float wallSlideSpeed;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckpoint;
    [SerializeField] Vector2 wallCheckSize;
    bool isTouchingWall;
    bool isWallSliding;


    //[Header("For WallJumping")]
    //[SerializeField] float wallJumpForcex = 18;
    //[SerializeField] float wallJumpForcey;


    //[SerializeField] bool walljumping;
    //[SerializeField] float jumptime;

    [Header("Animations")]
    Animator Anim;
    public GameObject particle;
    SpriteRenderer _sprite;
    Color temp;
    public GameObject blood;


    AudioSource Auido;
    bool sað;
    bool Sol;

    
    Renderer rend;
    Color c;
    GameObject[] saw;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        Auido = GetComponent<AudioSource>();
    }
    IEnumerator  wallsildePlus()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            wallSlideSpeed += .25f;
            if(wallSlideSpeed >= 6)
            {
                wallSlideSpeed = 6.5f;
                break;
            }
        }
    }
    void Start()
    {
       
        Time.timeScale = 1;
        restOfHearth = 2;
        wallSlideSpeed = 3;
        isTouchingWall = false;
        isWallSliding = false;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        //cameramovement.isdead = false;
        //rg = GetComponent<Rigidbody2D>();
        StartCoroutine(wallsildePlus());

        //Anim = GetComponent<Animator>();
        //_sprite = GetComponent<SpriteRenderer>();
        temp = _sprite.color;
        //Auido = GetComponent<AudioSource>();
    }

    //public void doublejump()
    //{
    //    if (/*Input.GetButtonDown("Jump") && */extrajump > 0 && !isGrounded)
    //    {
    //        rg.velocity = Vector2.up * jumpForce;
    //        extrajump--;
    //    }
    //    else if (isGrounded || isTouchingWall)
    //    {
    //        extrajump = 1;
    //    }
    //}
    void Flip()
    {
        if (!isWallSliding)
        {

            faceright = !faceright;
            transform.Rotate(0, 180, 0);


        }
    }
    void CheckWorld()
    {
        //isGrounded = Physics2D.OverlapBox(GroundCheck.position, GroundCheckSize, 0, GroundLayer);
        isTouchingWall = Physics2D.OverlapBox(wallCheckpoint.position, wallCheckSize, 0, wallLayer);
    }
    private void FixedUpdate()
    {

        //movement = _joystick.Horizontal;
        //movement = Input.GetAxis("Horizontal");
        Vector3 goright = new Vector3(4.60f, transform.position.y, transform.position.z);
        Vector3 goleft = new Vector3(-4.66f, transform.position.y, transform.position.z);
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.deltaPosition.x > 10f)
            {
                Auido.Play();
                sað = true;
                Sol = false;
            }
            if (parmak.deltaPosition.x < -10f)
            {
                Auido.Play();
                Sol = true;
                sað = false;
            }
            if (sað == true)
            {
                transform.position = Vector3.Lerp(transform.position, goright, 5* Time.deltaTime);

            }
            if (Sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, goleft, 5* Time.deltaTime);

            }
        }
        //transform.position += new Vector3(movement, 0) * Time.deltaTime / movementspeed;

        if (Sol && faceright)
        {
            Flip();

        }
        else if (sað && !faceright)
        {
            Flip();
        }

        if (isWallSliding)
        {
           
            Anim.SetBool("isidle", true);
        }

        //if (movement == 0)
        //{
        //    anim.SetBool("isRunning",false);
        //}
        //else
        //{
        //    anim.Play("Running");
        //}

    }
    void Update()
    {
       
        //if (Input.GetButtonDown("Jump") && (isGrounded || isTouchingWall || isWallSliding))
        //{


        //    rg.velocity = new Vector2(rg.velocity.x, jumpForce);

        //    isJumping = true;

        //}
        CheckWorld();
        WallSlide();
        //WallJumping();
        //doublejump();

        

    }
    //public void buttonjump()
    //{

    //    if (/*Input.GetButtonDown("Jump") && */(isGrounded || isTouchingWall || isWallSliding))
    //    {


    //        rg.velocity = new Vector2(rg.velocity.x, jumpForce);

    //        isJumping = true;

    //    }
    //}

    void WallSlide()
    {
        if (isTouchingWall)
        {
            isWallSliding = true;


        }
        else
        {
            isWallSliding = false;

        }
        if (isWallSliding)
        {
            rg.velocity = new Vector2(rg.velocity.x, Mathf.Clamp(rg.velocity.y, wallSlideSpeed, float.MaxValue));

        }
    }

    //public void WallJumping()
    //{
    //    if (/*Input.GetButtonDown("Jump") && */isWallSliding)
    //    {
    //        walljumping = true;
    //        Invoke("SetWallJumpingToFalse", jumptime);
    //        //rg.velocity = new Vector2(wallJumpForcex * -movement, wallJumpForcey);

    //    }
    //    if (walljumping)
    //    {
    //        rg.velocity = new Vector2(wallJumpForcex * -movement, wallJumpForcey);
    //    }
    //}
    //void SetWallJumpingToFalse()
    //{
    //    walljumping = false;
    //}
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawCube(wallCheckpoint.position, wallCheckSize);

    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawCube(GroundCheck.position, GroundCheckSize);
    //}

    //public void death()
    //{
    //    particle.SetActive(true);
    //    _sprite.color = Color.HSVToRGB(0, 39, 95);
    //    Anim.Play("Dead");
        
    //    //cameramovement.isdead = true;

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallFlame"))
        {
            _sprite.color = Color.red;
            hearth[restOfHearth].gameObject.SetActive(false);
            


            if (restOfHearth == 0)
            {
                cameramovement.isdead = true;
                
                
            }
            else
                restOfHearth--;


            Invoke("ChangeColor", .1f);

        }
        if (collision.gameObject.CompareTag("falling"))
        {
            cameramovement.isdead = true;
        }
        if (collision.gameObject.CompareTag("hearth"))
        {
            if (restOfHearth < 2)
            {
                restOfHearth++;
                hearth[restOfHearth].gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }
            //if (collision.gameObject.CompareTag("saw"))
            //{
            //    _sprite.color = Color.HSVToRGB(0,16,100);


            //    if(restOfHearth == 0)
            //    {
            //        Anim.Play("killedbysaw");
            //        blood.SetActive(true);
            //        Death = true;
            //    }
            //    _sprite.color = temp;
            //    restOfHearth--;
            //}
        }
        
    }
    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);

        c.a = 0.5f;

        rend.material.color = c;
        //saw[0].GetComponent<CircleCollider2D>().isTrigger = true;
        //saw[1].GetComponent<CircleCollider2D>().isTrigger = true;
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
        Physics2D.IgnoreLayerCollision(7,8,  true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(7,8 ,false);
        //this.GetComponent<BoxCollider2D>().isTrigger = false;
        //saw[0].GetComponent<CircleCollider2D>().isTrigger = false;
        //saw[1].GetComponent<CircleCollider2D>().isTrigger = false;
        c.a = 1f;
        rend.material.color = c;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("saw"))
        {

            _sprite.color = Color.red;

            hearth[restOfHearth].gameObject.SetActive(false);
           
            StartCoroutine(GetInvulnerable());
           

            if (restOfHearth == 0)
            {
                blood.SetActive(true);
                cameramovement.isdead = true;
               

            }
            else
                restOfHearth--;

            Invoke("ChangeColor", .1f);

           



        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(wallCheckpoint.transform.position,wallCheckSize);
    }


    void ChangeColor()
    {
        _sprite.color = temp;
    }
}


