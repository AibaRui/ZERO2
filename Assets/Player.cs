using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    bool _isGround;


    //ˆÚ“®
    [SerializeField] float _runSpeed;
    [SerializeField] float _runSpeednoGround=10;

    [SerializeField] float _maxSpeed;
    [SerializeField] float _runSpeedM;


    //ƒWƒƒƒ“ƒv
    bool _isjump;
    [SerializeField] float _upJump=10;
    [SerializeField] float _downJump = 10;
    int _jumpCount=0;

    SpriteRenderer _sp;

    [SerializeField] GameObject _1;
    [SerializeField] GameObject _2;
     SpriteRenderer _sp1;
     SpriteRenderer _sp2;
    [SerializeField] Color _11;
    [SerializeField] Color _12;
    [SerializeField] Color _21;
    [SerializeField] Color _22;

    float _h;
    float _v;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();

        _sp2 = _2.GetComponent<SpriteRenderer>();
        _sp1 = _1.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        

        if(Input.GetKeyDown("r"))
        {
            Debug.Log("2");
            _sp1.color = _12;
            _sp2.color = _22;

            _rb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
            gameObject.layer = 7;
        }

        if (Input.GetKeyDown("e"))
        {
            Debug.Log("1");
            _sp1.color = _11;
            _sp2.color = _21;
            gameObject.layer = 6;
            _rb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
        }
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
        DoJump();
    }

    void DoJump()
    { 
        if(_isGround&&_isjump&&_jumpCount==0)
        {
            _jumpCount++;
            _isGround = false;
            _isjump = false;
            Debug.Log("Jump2");
            _rb.AddForce(transform.up * _upJump, ForceMode2D.Impulse);
        }

       else if(_isjump&&_jumpCount==1)
        {
            _jumpCount++;
            Debug.Log("Jump3");
            _isjump = false;
            _rb.AddForce(transform.up * _upJump*0.8f, ForceMode2D.Impulse);
        }

    }


    void Jump()
    {
        if(_rb.velocity.y>10)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 10);
        }

      
        if(Input.GetKeyDown("w"))
        {
           

            if (_jumpCount<=1)
            {
              _isjump = true;
            } 
            
        }
       
    }

    void Move()
    {
         float _h = Input.GetAxisRaw("Horizontal");

        

        if(_h>0&&_isGround)
        {
            if(_rb.velocity.x>2)
           {
            Debug.Log("ok");
            _rb.velocity = new Vector2(_maxSpeed, _rb.velocity.y);
           }
            else
            {
                _rb.AddForce(transform.right * _runSpeed * _h);
            }
        }
        else if(_h<0&&_isGround)
        {
            if (_rb.velocity.x < -2)
            {
                Debug.Log("ok");
                _rb.velocity = new Vector2(-_maxSpeed, _rb.velocity.y);
            }
            else
            {
                _rb.AddForce(transform.right * _runSpeed * _h);
            }

        }
        else if(_h > 0)
        {
            Vector2 velo = new Vector2(_h * _runSpeednoGround, _rb.velocity.y);
            _rb.velocity = velo;
        }
        else if(_h < 0)
        {
            Vector2 velo = new Vector2(_h * _runSpeednoGround, _rb.velocity.y);
            _rb.velocity = velo;
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            _isGround = true;
          
            _jumpCount = 0;
        }
    }





  public void SpeedUp()
    {
        _runSpeed = 10;
    }

    public void ColorChange(int red, int green , int blue )
    {
        var colors = new Color(red, green, blue);
        _sp.color = colors;
    }



}