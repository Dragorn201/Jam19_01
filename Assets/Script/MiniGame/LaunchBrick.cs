using UnityEngine;
using UnityEngine.UI;

public class LaunchBrick : MonoBehaviour
{
    public float impulseForce;
    private float impulseForceBasic = 5f;
    public Vector2 impulseDirection;
    private float keyDownTime = 0f;
    private bool isKeyHeld = false;
    private float jaugeTime = 0.8f;
    [SerializeField] public bool brickFlying = false;

    public float maxForce;
    
    public Vector3 startPos;
    public Vector3 endPos;
    
    public GameObject RestartUI;
    public GameObject UpgradeUI;
    
    public GameDirector _gameDirector;

    public Slider Jauge;
    public GameObject JaugetoDisappear;
    
    
    //Upgrade Images
    public GameObject Hand;
    public GameObject Thrower;
    public GameObject Catapult;
    public GameObject Bazooka;
    
    //Upgrade Buttons
    public GameObject HAND_BouttonUpgrade;
    public GameObject THROWER_BouttonUpgrade;
    public GameObject CATAPULT_BouttonUpgrade;
    public GameObject BAZOOKA_BouttonUpgrade;
    
    public TMPro.TMP_Text UpgradeCostText;
    public GameObject coinIcon;
    
    

    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);
        impulseForce = impulseForceBasic;
        
        Thrower.SetActive(false);
        Catapult.SetActive(false);
        Bazooka.SetActive(false);
        UpgradeCostText.text = "25";

    }
    
    void Update()
    {
        endPos = transform.position;
        
        if (Input.GetKeyDown(KeyCode.Space) && brickFlying == false)
        {
            UpgradeUI.SetActive(false);
            keyDownTime = Time.time;
            isKeyHeld = true;
            JaugetoDisappear.SetActive(true);
            brickFlying = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jauge.value += jaugeTime * Time.deltaTime;  
        }
        

        if (Input.GetKeyUp(KeyCode.Space) && isKeyHeld)
        {
            float heldDuration = (Time.time - keyDownTime)* 5f;
            isKeyHeld = false;
            
            JaugetoDisappear.SetActive(false);
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


    public void UpgradeImpulse1()
    {

            Thrower.SetActive(true);
            Hand.SetActive(false);
            impulseForceBasic += 10f;
            impulseForce = impulseForceBasic;
            jaugeTime *= 0.8f;
            maxForce += 5;
            _gameDirector.Money -= _gameDirector.requirement1;
            _gameDirector.MoneyText.text = _gameDirector.Money.ToString();
            THROWER_BouttonUpgrade.SetActive(true);
            HAND_BouttonUpgrade.SetActive(false);
            UpgradeCostText.text = "50";
            audioManager.Instance.PlaySfxClip(1);

    }

    public void UpgradeImpulse2()
    {
        Catapult.SetActive(true);
        Thrower.SetActive(false);
        impulseForceBasic += 20f;
        impulseForce = impulseForceBasic;
        jaugeTime *= 0.8f;
        maxForce += 10;
        _gameDirector.Money -= _gameDirector.requirement2;
        _gameDirector.MoneyText.text = _gameDirector.Money.ToString();    
        CATAPULT_BouttonUpgrade.SetActive(true);
        THROWER_BouttonUpgrade.SetActive(false);
        UpgradeCostText.text = "75";     
        audioManager.Instance.PlaySfxClip(1);
        
    }

    public void UpgradeImpulse3()
    {
        Bazooka.SetActive(true);
        Catapult.SetActive(false);
        impulseForceBasic += 70f;
        impulseForce = impulseForceBasic;
        jaugeTime *= 0.8f;
        maxForce += 30;
        _gameDirector.Money -= _gameDirector.requirement3;
        _gameDirector.MoneyText.text = _gameDirector.Money.ToString(); 
        BAZOOKA_BouttonUpgrade.SetActive(true);
        CATAPULT_BouttonUpgrade.SetActive(false);
        UpgradeCostText.text = ""; 
        coinIcon.SetActive(false);
        audioManager.Instance.PlaySfxClip(1);
        
        
    }

            

    
}