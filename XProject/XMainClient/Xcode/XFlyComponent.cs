using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XFlyComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XFlyComponent.uuID;
			}
		}

		public float CurrentHeight
		{
			get
			{
				return this._current;
			}
		}

		public float MinHeight
		{
			get
			{
				return this._min;
			}
		}

		public float MaxHeight
		{
			get
			{
				return this._max;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			XOthersAttributes xothersAttributes = this._entity.Attributes as XOthersAttributes;
			this._max = xothersAttributes.FloatingMax;
			this._min = xothersAttributes.FloatingMin;
			this._target = (this._max - this._min) * XSingleton<XCommon>.singleton.RandomPercentage() + this._min;
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		public override void Attached()
		{
			this._target += XSingleton<XScene>.singleton.TerrainY(this._entity.EngineObject.Position);
			this._current = this._target;
			this._entity.ApplyMove(0f, this._current - this._entity.EngineObject.Position.y, 0f);
		}

		public override void Update(float fDeltaT)
		{
			bool isDead = this._entity.IsDead;
			if (!isDead)
			{
				this._entity.DisableGravity();
				bool flag = this._entity.Skill.IsCasting();
				if (!flag)
				{
					float num = (this._target - this._current) * Mathf.Min(1f, 3f * fDeltaT);
					this._current += num;
					this._entity.ApplyMove(0f, num, 0f);
					float num2 = XSingleton<XScene>.singleton.TerrainY(this._entity.EngineObject.Position);
					bool flag2 = this._entity.EngineObject.Position.y - num2 > this._max || this._entity.EngineObject.Position.y - num2 < this._min;
					if (flag2)
					{
						this._target = (this._max - this._min) * XSingleton<XCommon>.singleton.RandomPercentage() + this._min + num2;
					}
					this._target += ((XSingleton<XCommon>.singleton.RandomPercentage() > 0.5f) ? 0.03f : -0.03f);
					this._current = this._entity.EngineObject.Position.y;
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Fly");

		private float _max = 0f;

		private float _min = 0f;

		private float _current = 0f;

		private float _target = 0f;
	}
}
