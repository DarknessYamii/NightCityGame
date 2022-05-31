using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage structure
    public int [] damagePoint = { 2, 4, 6, 10, 16, 20, 27 };
    public float [] pushForce = { 3.0f, 3.5f, 4.0f, 4.5f, 5.0f, 5.5f, 6.0f};

    // Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    // Swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

   
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();    
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
       if(coll.tag == "Fighter")
        {
            if (coll.name == "player")
                return;

            // Create a new damage object, then I'll send it to the fighter I've hit
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);
            
            Debug.Log(coll.name);
            
        }
    }
    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel]; 
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

    }
}
