using UnityEngine;
using UnityEngine.UI;

public class LaunchBrick : MonoBehaviour
{
    public float impulseForce;
    private float impulseForceBasic = 10f;
    public Vector2 impulseDirection;
    private float keyDownTime = 0f;
    private bool isKeyHeld = false;
    private float jaugeTime = 1f;

    public float maxForce;
    
    public Vector3 startPos;
    public Vector3 endPos;
    
    public GameObject RestartUI;
    public GameObject UpgradeUI;
    
    public GameDirector _gameDirector;

    public Slider Jauge;
    public GameObject JaugetoDisappear;
    
    

    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);
    }
    
    void Update()
    {
        endPos = transform.position;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpgradeUI.SetActive(false);
            keyDownTime = Time.time;
            isKeyHeld = true;
             JaugetoDisappear.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jauge.value += jaugeTime * Time.deltaTime;  
        }
        

        if (Input.GetKeyUp(KeyCode.Space) && isKeyHeld)
        {
            JaugetoDisappear.SetActive(false);
            float heldDuration = (Time.time - keyDownTime)* 10f;
            isKeyHeld = false;
            
            
            impulseForce *= heldDuration;
            Debug.Log(heldDuration);
            if (impulseForce > maxForce)
            {
                impulseForce = maxForce;
                Debug.Log("MaxReach");
            }
            
            GetComponent<Rigidbody>().AddForce(impulseDirection * impulseForce,ForceMode.Impulse);
            GetComponent<Rigidbody>().useGravity = true;
            heldDuration = 0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        endPos = collision.contacts[0].point;
        RestartUI.SetActive(true);
        Jauge.value = 0f;
        impulseForce = impulseForceBasic;
    }


    public void UpgradeImpulse()
    {
        impulseForceBasic += 10f;
        impulseForce = impulseForceBasic;
        jaugeTime *= 0.8f;
        Debug.Log(impulseForce);
        Debug.Log(_gameDirector.Money);
        _gameDirector.Money -= _gameDirector.requirement1;
        _gameDirector.MoneyText.text = _gameDirector.Money.ToString();
    }

    public void UpgradeMaxReach()
    {
        maxForce += 5;
        Debug.Log(maxForce);
        _gameDirector.Money -= _gameDirector.requirement2;
        _gameDirector.MoneyText.text = _gameDirector.Money.ToString();
    }

    public void UpgradeAngle()
    {
        _gameDirector.Money -= _gameDirector.requirement3;
        _gameDirector.MoneyText.text = _gameDirector.Money.ToString();
    }
    
    
}