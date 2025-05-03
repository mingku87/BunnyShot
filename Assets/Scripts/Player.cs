using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MoveableObject
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Player>();
            return instance;
        }
    }

    public float speed = 8.0f;
    public static int life;
    public static int killCount;
    public static int killGoal;
    private float skillCoolTime;
    private float skillCoolTimeLeft;
    private float shieldCoolTimeLeft;
    private float boosterCoolTimeLeft;

    public GameObject skillEffectPrefab, damagedEffectPrefab, shieldSphere;

    public Text monsterText;
    public GameObject skillImage, shieldImage, boosterImage;
    public Text skillTimeText, shieldTimeText, boosterTimeText;

    void Start()
    {
        life = 3;

        skillCoolTime = 7f;
        skillCoolTimeLeft = 0;
        shieldCoolTimeLeft = 0;
        boosterCoolTimeLeft = 0;

        killCount = 0;
        killGoal = GameConstant.killMonsterMax[GameManager.round];

        monsterText.text = killCount + "/" + killGoal;
    }

    void Update()
    {
        Move();
        Skill();
        CountCoolTime();
    }

    private void Move()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float zSpeed = Input.GetAxis("Vertical") * speed;

        vel = new Vector3(xSpeed, 0, zSpeed);
        if (vel != Vector3.zero) transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    public void Skill()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false) return;
        if (skillCoolTimeLeft > 0) return;

        FindObjectOfType<AudioEffect>().SkillSound();
        Instantiate(skillEffectPrefab, transform.position, transform.rotation);

        float radius = 7f;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in hitColliders)
            if (collider.CompareTag("Monster")) collider.GetComponent<Monster>().Die();

        skillCoolTimeLeft = skillCoolTime;
    }

    void CountCoolTime()
    {
        skillImage.SetActive(skillCoolTimeLeft > 0);
        if (skillCoolTimeLeft > 0)
        {
            skillCoolTimeLeft -= Time.deltaTime;
            skillTimeText.text = (int)Mathf.Ceil(skillCoolTimeLeft) + "";
        }
        else skillCoolTimeLeft = 0;

        shieldImage.SetActive(shieldCoolTimeLeft > 0);
        shieldSphere.SetActive(shieldCoolTimeLeft > 0);
        if (shieldCoolTimeLeft > 0)
        {
            shieldCoolTimeLeft -= Time.deltaTime;
            shieldTimeText.text = (int)Mathf.Ceil(shieldCoolTimeLeft) + "";
        }
        else shieldCoolTimeLeft = 0;

        boosterImage.SetActive(boosterCoolTimeLeft > 0);
        speed = boosterCoolTimeLeft > 0 ? 15f : 8f;
        if (boosterCoolTimeLeft > 0)
        {
            boosterCoolTimeLeft -= Time.deltaTime;
            boosterTimeText.text = (int)Mathf.Ceil(boosterCoolTimeLeft) + "";
        }
        else boosterCoolTimeLeft = 0;
    }

    void ResetSkillCoolTime()
    {
        skillCoolTimeLeft = 0;
    }

    public void KillCount()
    {
        killCount++;
        monsterText.text = killCount + "/" + killGoal;
        if (killCount == killGoal) Clear();
    }

    public void Clear()
    {
        FindObjectOfType<GameManager>().Cleargame(life);
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }

    public void GetDamaged()
    {
        if (FindObjectOfType<Rabbit>().invincibility == true) return;
        if (shieldCoolTimeLeft > 0)
        {
            shieldCoolTimeLeft = 0;
            return;
        }
        FindObjectOfType<Rabbit>().Sparkle();
        GameObject damagedEffect = Instantiate(damagedEffectPrefab, transform.position, transform.rotation);
        Destroy(damagedEffect, 2.0f);
        life--;
        FindObjectOfType<AudioEffect>().DamagedSound();
        FindObjectOfType<GameManager>().Life();

        if (life == 0) FindObjectOfType<GameManager>().Endgame();
    }

    public void GetItem(ItemType itemType)
    {
        FindObjectOfType<AudioEffect>().ItemSound();

        switch (itemType)
        {
            case ItemType.Shield:
                shieldCoolTimeLeft = 10f;
                break;
            case ItemType.Portion:
                if (life < 3) life++;
                FindObjectOfType<GameManager>().Life();
                break;
            case ItemType.Booster:
                boosterCoolTimeLeft = 10f;
                break;
            case ItemType.Clock:
                ResetSkillCoolTime();
                break;
        }
    }
}