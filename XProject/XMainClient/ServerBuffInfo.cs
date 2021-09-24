using System;
using KKSG;
using UnityEngine;

namespace XMainClient
{

	internal class ServerBuffInfo
	{

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

		public UIBuffInfo UIBuff
		{
			get
			{
				return this.m_UIBuffInfo;
			}
		}

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

		public void UpdateFromRemoveBuff(BuffInfo info)
		{
			this.transformID = info.TransformID;
		}

		public uint buffID;

		public uint buffLevel;

		public double HP;

		public double maxHP;

		public ulong mobUID;

		public bool bReduceCD = false;

		public int transformID;

		public uint stackCount = 1U;

		private float startTime;

		private float startLeftTime;

		private UIBuffInfo m_UIBuffInfo = new UIBuffInfo();
	}
}
