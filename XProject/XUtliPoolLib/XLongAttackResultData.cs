using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XLongAttackResultData
	{

		public XLongAttackResultData()
		{
			this.WithCollision = true;
			this.TriggerOnce = true;
			this.EndFx_Ground = true;
			this.FlyWithTerrain = true;
			this.AimTargetCenter = true;
			this.StaticCollider = true;
		}

		[SerializeField]
		public XResultBulletType Type = XResultBulletType.Sphere;

		[SerializeField]
		[DefaultValue(true)]
		public bool WithCollision;

		[SerializeField]
		[DefaultValue(false)]
		public bool Follow;

		[SerializeField]
		[DefaultValue(0f)]
		public float Runningtime;

		[SerializeField]
		[DefaultValue(0f)]
		public float Stickytime;

		[SerializeField]
		[DefaultValue(0f)]
		public float Velocity;

		[SerializeField]
		[DefaultValue(0f)]
		public float Radius;

		[SerializeField]
		[DefaultValue(0f)]
		public float Palstance;

		[SerializeField]
		[DefaultValue(0f)]
		public float RingVelocity;

		[SerializeField]
		[DefaultValue(0f)]
		public float RingRadius;

		[SerializeField]
		[DefaultValue(false)]
		public bool RingFull;

		[SerializeField]
		public string Prefab = null;

		[SerializeField]
		[DefaultValue(true)]
		public bool TriggerOnce;

		[SerializeField]
		[DefaultValue(false)]
		public bool TriggerAtEnd;

		[SerializeField]
		[DefaultValue(0f)]
		public float TriggerAtEnd_Cycle;

		[SerializeField]
		[DefaultValue(0)]
		public int TriggerAtEnd_Count;

		[SerializeField]
		[DefaultValue(0)]
		public int FireAngle;

		[SerializeField]
		public string HitGround_Fx = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float HitGroundFx_LifeTime;

		[SerializeField]
		public string End_Fx = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float EndFx_LifeTime;

		[SerializeField]
		[DefaultValue(true)]
		public bool EndFx_Ground;

		[SerializeField]
		public string Audio = null;

		[SerializeField]
		public AudioChannel Audio_Channel = AudioChannel.Skill;

		[SerializeField]
		public string End_Audio = null;

		[SerializeField]
		public AudioChannel End_Audio_Channel = AudioChannel.Skill;

		[SerializeField]
		[DefaultValue(true)]
		public bool FlyWithTerrain;

		[SerializeField]
		[DefaultValue(false)]
		public bool IsPingPong;

		[SerializeField]
		[DefaultValue(true)]
		public bool AimTargetCenter;

		[SerializeField]
		[DefaultValue(0f)]
		public float At_X;

		[SerializeField]
		[DefaultValue(0f)]
		public float At_Y;

		[SerializeField]
		[DefaultValue(0f)]
		public float At_Z;

		[SerializeField]
		[DefaultValue(0f)]
		public float Refine_Cycle;

		[SerializeField]
		[DefaultValue(0)]
		public int Refine_Count;

		[SerializeField]
		[DefaultValue(false)]
		public bool AutoRefine_at_Half;

		[SerializeField]
		[DefaultValue(true)]
		public bool StaticCollider;

		[SerializeField]
		[DefaultValue(false)]
		public bool DynamicCollider;

		[SerializeField]
		[DefaultValue(false)]
		public bool Manipulation;

		[SerializeField]
		[DefaultValue(false)]
		public bool Reinforce;

		[SerializeField]
		[DefaultValue(0f)]
		public float ManipulationRadius;

		[SerializeField]
		[DefaultValue(0f)]
		public float ManipulationForce;
	}
}
