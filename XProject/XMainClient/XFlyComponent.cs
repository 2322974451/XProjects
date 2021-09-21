using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F28 RID: 3880
	internal sealed class XFlyComponent : XComponent
	{
		// Token: 0x170035CF RID: 13775
		// (get) Token: 0x0600CDA3 RID: 52643 RVA: 0x002F83F4 File Offset: 0x002F65F4
		public override uint ID
		{
			get
			{
				return XFlyComponent.uuID;
			}
		}

		// Token: 0x170035D0 RID: 13776
		// (get) Token: 0x0600CDA4 RID: 52644 RVA: 0x002F840C File Offset: 0x002F660C
		public float CurrentHeight
		{
			get
			{
				return this._current;
			}
		}

		// Token: 0x170035D1 RID: 13777
		// (get) Token: 0x0600CDA5 RID: 52645 RVA: 0x002F8424 File Offset: 0x002F6624
		public float MinHeight
		{
			get
			{
				return this._min;
			}
		}

		// Token: 0x170035D2 RID: 13778
		// (get) Token: 0x0600CDA6 RID: 52646 RVA: 0x002F843C File Offset: 0x002F663C
		public float MaxHeight
		{
			get
			{
				return this._max;
			}
		}

		// Token: 0x0600CDA7 RID: 52647 RVA: 0x002F8454 File Offset: 0x002F6654
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			XOthersAttributes xothersAttributes = this._entity.Attributes as XOthersAttributes;
			this._max = xothersAttributes.FloatingMax;
			this._min = xothersAttributes.FloatingMin;
			this._target = (this._max - this._min) * XSingleton<XCommon>.singleton.RandomPercentage() + this._min;
		}

		// Token: 0x0600CDA8 RID: 52648 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600CDA9 RID: 52649 RVA: 0x002F84B8 File Offset: 0x002F66B8
		public override void Attached()
		{
			this._target += XSingleton<XScene>.singleton.TerrainY(this._entity.EngineObject.Position);
			this._current = this._target;
			this._entity.ApplyMove(0f, this._current - this._entity.EngineObject.Position.y, 0f);
		}

		// Token: 0x0600CDAA RID: 52650 RVA: 0x002F852C File Offset: 0x002F672C
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

		// Token: 0x04005BA6 RID: 23462
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Fly");

		// Token: 0x04005BA7 RID: 23463
		private float _max = 0f;

		// Token: 0x04005BA8 RID: 23464
		private float _min = 0f;

		// Token: 0x04005BA9 RID: 23465
		private float _current = 0f;

		// Token: 0x04005BAA RID: 23466
		private float _target = 0f;
	}
}
