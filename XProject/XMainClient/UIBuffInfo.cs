using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC1 RID: 4033
	internal class UIBuffInfo
	{
		// Token: 0x0600D18A RID: 53642 RVA: 0x0030A9FC File Offset: 0x00308BFC
		public static UIBuffInfo Create(XBuff buff)
		{
			UIBuffInfo uibuffInfo = new UIBuffInfo();
			uibuffInfo.Set(buff);
			return uibuffInfo;
		}

		// Token: 0x0600D18B RID: 53643 RVA: 0x0030AA20 File Offset: 0x00308C20
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

		// Token: 0x0600D18C RID: 53644 RVA: 0x0030AAA0 File Offset: 0x00308CA0
		public static UIBuffInfo Create(ServerBuffInfo buff)
		{
			UIBuffInfo uibuffInfo = new UIBuffInfo();
			uibuffInfo.Set(buff);
			return uibuffInfo;
		}

		// Token: 0x0600D18D RID: 53645 RVA: 0x0030AAC4 File Offset: 0x00308CC4
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

		// Token: 0x04005F13 RID: 24339
		public uint buffID;

		// Token: 0x04005F14 RID: 24340
		public uint buffLevel;

		// Token: 0x04005F15 RID: 24341
		public float leftTime;

		// Token: 0x04005F16 RID: 24342
		public float startTime;

		// Token: 0x04005F17 RID: 24343
		public double HP;

		// Token: 0x04005F18 RID: 24344
		public double maxHP;

		// Token: 0x04005F19 RID: 24345
		public ulong mobUID;

		// Token: 0x04005F1A RID: 24346
		public bool bReduceCD;

		// Token: 0x04005F1B RID: 24347
		public int transformID;

		// Token: 0x04005F1C RID: 24348
		public uint stackCount;

		// Token: 0x04005F1D RID: 24349
		public BuffTable.RowData buffInfo;
	}
}
