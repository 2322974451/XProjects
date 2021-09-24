using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class UIBuffInfo
	{

		public static UIBuffInfo Create(XBuff buff)
		{
			UIBuffInfo uibuffInfo = new UIBuffInfo();
			uibuffInfo.Set(buff);
			return uibuffInfo;
		}

		public void Set(XBuff buff)
		{
			this.buffID = (uint)buff.ID;
			this.buffLevel = (uint)buff.Level;
			this.leftTime = buff.GetLeftTime();
			this.startTime = Time.time;
			this.HP = buff.HP;
			this.maxHP = buff.MaxHP;
			this.mobUID = buff.EffectData.MobID;
			this.stackCount = buff.StackCount;
			this.buffInfo = buff.BuffInfo;
		}

		public static UIBuffInfo Create(ServerBuffInfo buff)
		{
			UIBuffInfo uibuffInfo = new UIBuffInfo();
			uibuffInfo.Set(buff);
			return uibuffInfo;
		}

		public bool Set(ServerBuffInfo buff)
		{
			this.buffID = buff.buffID;
			this.buffLevel = buff.buffLevel;
			this.leftTime = buff.leftTime;
			this.startTime = Time.realtimeSinceStartup;
			this.HP = buff.HP;
			this.maxHP = buff.maxHP;
			this.mobUID = buff.mobUID;
			this.bReduceCD = buff.bReduceCD;
			this.transformID = buff.transformID;
			this.stackCount = buff.stackCount;
			this.buffInfo = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)this.buffID, (int)this.buffLevel);
			bool flag = this.buffInfo == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Set Server Buff data not found: [{0} {1}]", this.buffID, this.buffLevel), null, null, null, null, null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public uint buffID;

		public uint buffLevel;

		public float leftTime;

		public float startTime;

		public double HP;

		public double maxHP;

		public ulong mobUID;

		public bool bReduceCD;

		public int transformID;

		public uint stackCount;

		public BuffTable.RowData buffInfo;
	}
}
