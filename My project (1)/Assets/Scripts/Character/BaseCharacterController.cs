﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
	public bool isActive = false; 

	[SerializeField]
	protected int maxHP = 1;
	[SerializeField]
	protected float defaultSpeed = 0;
	[SerializeField]
	protected int defaultPower = 0;

	protected int hp = 0;
	protected float speed = 0;
	protected int power = 0;
	protected GameObject gameManagerObj;
	protected GameManager gameManager;

	public int Hp
	{
		set
		{
			hp = Mathf.Clamp(value, 0, maxHP);

			if(hp <= 0)
			{
				Dead();
			}
		}
		get
		{
			return hp;
		}
	}

	public float Speed
	{
		set
		{
			speed = value;
		}
		get
		{
			return speed;
		}
	}

	public int Power
	{
		set
		{
			power = Mathf.Max(value, 0);
		}
		get
		{
			return power;
		}
	}


    protected virtual void Start()
    {
		gameManagerObj = GameObject.FindGameObjectWithTag("GameController");
		gameManager = gameManagerObj.GetComponent<GameManager>();

		InitCharacter();
    }

    protected virtual void Update()
    {
        
    }

	protected virtual void FixedUpdate()
	{
		FixedUpdateCharacter();
	}

	protected virtual void FixedUpdateCharacter()
	{

	}

	protected virtual void InitCharacter()
	{
		Hp = maxHP;
		Speed = defaultSpeed;

		isActive = true;
	}

	protected virtual void Move()
	{

	}

	protected virtual void Damage()
	{

	}

	protected virtual void Dead()
	{

	}

}
