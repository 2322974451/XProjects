using System;
using KKSG;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000FBF RID: 4031
	internal class ServerBuffInfo
	{
		// Token: 0x170036AB RID: 13995
		// (get) Token: 0x0600D183 RID: 53635 RVA: 0x0030A890 File Offset: 0x00308A90
		// (set) Token: 0x0600D184 RID: 53636 RVA: 0x0030A8B5 File Offset: 0x00308AB5
		public float leftTime
		{
			get
			{
				return this.startLeftTime - (Time.realtimeSinceStartup - this.startTime);
			}
			set
			{
				this.startLeftTime = value;
				this.startTime = Time.realtimeSinceStartup;
			}
		}

		// Token: 0x170036AC RID: 13996
		// (get) Token: 0x0600D185 RID: 53637 RVA: 0x0030A8CC File Offset: 0x00308ACC
		public UIBuffInfo UIBuff
		{
			get
			{
				return this.m_UIBuffInfo;
			}
		}

		// Token: 0x0600D186 RID: 53638 RVA: 0x0030A8E4 File Offset: 0x00308AE4
		public bool Set(BuffInfo data)
		{
			this.buffID = data.BuffID;
			this.buffLevel = data.BuffLevel;
			this.leftTime = data.LeftTime / 1000f;
			bool mobUIDSpecified = data.MobUIDSpecified;
			if (mobUIDSpecified)
			{
				this.mobUID = data.MobUID;
			}
			bool curHPSpecified = data.CurHPSpecified;
			if (curHPSpecified)
			{
				this.HP = data.CurHP;
			}
			bool maxHPSpecified = data.MaxHPSpecified;
			if (maxHPSpecified)
			{
				this.maxHP = data.MaxHP;
			}
			bool stackCountSpecified = data.StackCountSpecified;
			if (stackCountSpecified)
			{
				this.stackCount = data.StackCount;
			}
			bool bReduceCDSpecified = data.bReduceCDSpecified;
			if (bReduceCDSpecified)
			{
				this.bReduceCD = data.bReduceCD;
			}
			bool transformIDSpecified = data.TransformIDSpecified;
			if (transformIDSpecified)
			{
				this.transformID = data.TransformID;
			}
			return this.m_UIBuffInfo.Set(this);
		}

		// Token: 0x0600D187 RID: 53639 RVA: 0x0030A9B9 File Offset: 0x00308BB9
		public void UpdateFromRemoveBuff(BuffInfo info)
		{
			this.transformID = info.TransformID;
		}

		// Token: 0x04005F06 RID: 24326
		public uint buffID;

		// Token: 0x04005F07 RID: 24327
		public uint buffLevel;

		// Token: 0x04005F08 RID: 24328
		public double HP;

		// Token: 0x04005F09 RID: 24329
		public double maxHP;

		// Token: 0x04005F0A RID: 24330
		public ulong mobUID;

		// Token: 0x04005F0B RID: 24331
		public bool bReduceCD = false;

		// Token: 0x04005F0C RID: 24332
		public int transformID;

		// Token: 0x04005F0D RID: 24333
		public uint stackCount = 1U;

		// Token: 0x04005F0E RID: 24334
		private float startTime;

		// Token: 0x04005F0F RID: 24335
		private float startLeftTime;

		// Token: 0x04005F10 RID: 24336
		private UIBuffInfo m_UIBuffInfo = new UIBuffInfo();
	}
}
