
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Player : MonoBehaviour
{
    public GameObject cube;
    public Rigidbody Rb;
    public int life = 3;
    public bool canJump = false;
    public bool jump = false;
    public float MovementSpeed = 0.5f;
    public bool ApplyGravity = true;
    public bool IsMoving = false;
    public bool shouldFall = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print(life);
        if (life == 0)
        {
            Thread.Sleep(3);
            StartCoroutine(RespawnWait());
        }
        if (life < 0)
        {
            Thread.Sleep(3);
            StartCoroutine(RespawnWait());
        }
        if (life > 0)
        {
            if (shouldFall == true)
            {
                Rb.velocity += -transform.up * 10;
            }
            if (gameObject)
            {
                Vector3 gravityUp = (gameObject.transform.position - new Vector3(651, 46, 476));
                Vector3 localUp = transform.up;
                Quaternion targetRotation = Quaternion.FromToRotation(gravityUp, localUp) * transform.rotation;
                transform.up = Vector3.Lerp(transform.up, gravityUp, 20 * Time.deltaTime);
                if (ApplyGravity == true)
                {
                    Rb.velocity += ((-gravityUp * 30) * Rb.mass);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ApplyGravity = false;
                jump = true;
                if (jump == true)
                {
                    if (canJump == true)
                    {
                        Rb.velocity += transform.up * 20;
                        MovementSpeed = 5.0f;
                        StartCoroutine(DelayGravityPull());
                    }
                }
            }
            var mvfrwrd = false;
            if (gameObject)
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    mvfrwrd = true;
                    if (mvfrwrd == true)
                    {
                        Rb.velocity += transform.forward * MovementSpeed;
                    }
                }
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    Thread.Sleep(1);
                    mvfrwrd = false;
                }
            }
            var mvbkwrd = false;
            if (gameObject)
            {

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    mvbkwrd = true;
                    if (mvbkwrd == true)
                    {
                        Rb.velocity += -transform.forward * MovementSpeed;
                    }
                }
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    Thread.Sleep(1);
                    mvbkwrd = false;
                }
            }
            var mvlft = false;
            if (gameObject)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    mvlft = true;
                    if (mvlft == true)
                    {
                        Rb.velocity += -transform.right * MovementSpeed;
                    }
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    Thread.Sleep(1);
                    mvbkwrd = false;
                }
            }
            var mvrght = false;
            if (gameObject)
            {

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    mvrght = true;
                    if (mvrght == true)
                    {
                        Rb.velocity += transform.right * MovementSpeed;
                    }
                }
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    Thread.Sleep(1);
                    mvbkwrd = false;
                }
            }
        }
    }
    public IEnumerator DelayGravityPull()
    {
        yield return new WaitForSeconds(2f);
        shouldFall = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        shouldFall = false;
        ApplyGravity = true;
        canJump = true;
        MovementSpeed = 1000.0f;
    }
    IEnumerator RespawnWait()
    {
        yield return new WaitForSeconds(3f);
        life = 3;
        ApplyGravity = false;
        transform.position = new Vector3(646, 69, 472);
        yield return new WaitForSeconds(1f);
        ApplyGravity = true;
    }
}