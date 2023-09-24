using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
class HealthSystem : MonoBehaviour
{
    private bool PlayerDead;
    [HideInInspector] public int CurrHealth;
    public int MaxHealth = 100;
    public Slider slider;
    public Image DamageFlash;
    public Color DamageFlashColor;
    public float FlashTransitionSpeed = 5f;
    public GameObject Gate;
    public GameObject GunUp;
    public GameObject Spawnner;
    public Animator Gateanim;
    public GameObject LoseUI;
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI HighScore;
    private void Start()
    {
        CurrHealth = MaxHealth;
    }

    private void Update()
    {
        slider.value = CurrHealth;
        if (DamageFlash.color != Color.clear)
        {
            DamageFlash.color = Color.Lerp(DamageFlash.color, Color.clear, FlashTransitionSpeed * Time.deltaTime);

        }
        if(PlayerDead == true)
        {
            
        }
    }
    public void DamagePlayer(int damage)
    {
        if(PlayerDead == true)
        {
            return;
        }
        DamageFlash.color = DamageFlashColor;
        CurrHealth -= damage;
        
        if(CurrHealth <= 0)
        {
            Dead();
        }
        Gateanim.SetBool("Hitted",true);
        Gateanim.SetBool("Hitted", false);
    }
    private void Dead()
    {
        if(PlayerPrefs.GetInt("High") <= FindObjectOfType<ScoreSystem>().Score)
        {
            PlayerPrefs.SetInt("High", FindObjectOfType<ScoreSystem>().Score);
        }
        
        PlayerDead = true;
        LoseUI.SetActive(true);
        slider.value = 0;
        FindObjectOfType<AudioManager>().Stop("GameplayTheme");
        FindObjectOfType<AudioManager>().Play("DeadSound");
        FinalScore.text = "Final Score: " + FindObjectOfType<ScoreSystem>().Score.ToString();
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("High").ToString();
        StartCoroutine(GateDestroyAnim());
        //Destroy(gameObject.GetComponent<Shoot>());
        //Destroy(gameObject.GetComponent<PlayerMovement>());
        //Destroy(gameObject.GetComponent<HealthSystem>());
        Destroy(gameObject);
        Destroy(GunUp);
        Destroy(Spawnner);
        Destroy(DamageFlash);
        //Destroy(FindObjectOfType<Spawner>());
    }
    IEnumerator GateDestroyAnim()
    {
        Gateanim.SetTrigger("Destroy");
        yield return new WaitForSeconds(1f);
        Destroy(Gate);
    }
}
