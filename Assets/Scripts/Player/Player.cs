using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly Inventory Inventory = new Inventory();
    
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private float _rotationSpeed = 5f;
    
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    

    private float _groundCheckRadius = 0.2f;
    private bool _isFacingRight = true;
    private bool _isCanMove = true;
    private bool _isGrounded;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _targetRotation;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
        _targetRotation = transform.eulerAngles;
    }

    private void Update()
    {
        UpdateAnimations();
        
        if(!_isCanMove)
            return;
        
        Move();
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
        
        SmoothRotate();
    }

    private void Move()
    {
        
            float moveInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector3(moveInput * _moveSpeed, _rigidbody.velocity.y, 0);
            
            if (moveInput > 0 && !_isFacingRight)
            {
                SetTargetRotation(true);  
            }
            else if (moveInput < 0 && _isFacingRight)
            {
                SetTargetRotation(false);
            }

            UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
       
    }

    private void SetTargetRotation(bool facingRight)
    {
        _targetRotation = facingRight ? new Vector3(0, 90f, 0) : new Vector3(0, -90f, 0);
        _isFacingRight = facingRight;
    }

    private void SmoothRotate()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(_targetRotation),
            _rotationSpeed * Time.deltaTime
        );
    }
    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0);
        _isGrounded = false;
        _animator.SetTrigger("Jump");
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    public void StopMove()
    {
        _isCanMove = false;
    }

    public void StartMove()
    {
        _isCanMove = true;
    }
}
