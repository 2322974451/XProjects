using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009D1 RID: 2513
	public class StrengthAuxData
	{
		// Token: 0x060098AC RID: 39084 RVA: 0x0017A70C File Offset: 0x0017890C
		public StrengthAuxData(FpStrengthNew.RowData data)
		{
			this.m_StrengthenData = data;
		}

		// Token: 0x17002DB6 RID: 11702
		// (get) Token: 0x060098AD RID: 39085 RVA: 0x0017A73C File Offset: 0x0017893C
		public int Id
		{
			get
			{
				return this.m_StrengthenData.BQID;
			}
		}

		// Token: 0x17002DB7 RID: 11703
		// (get) Token: 0x060098AE RID: 39086 RVA: 0x0017A75C File Offset: 0x0017895C
		// (set) Token: 0x060098AF RID: 39087 RVA: 0x0017A774 File Offset: 0x00178974
		public uint FightNum
		{
			get
			{
				return this.m_iFightNum;
			}
			set
			{
				this.m_iFightNum = value;
				this._fightPercent = 0.0;
			}
		}

		// Token: 0x060098B0 RID: 39088 RVA: 0x0017A790 File Offset: 0x00178990
		public double GetFightPercent(int recommendFight)
		{
			bool flag = recommendFight == 0;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				result = this.FightNum / (double)recommendFight * 100.0;
			}
			return result;
		}

		// Token: 0x17002DB8 RID: 11704
		// (get) Token: 0x060098B1 RID: 39089 RVA: 0x0017A7CC File Offset: 0x001789CC
		// (set) Token: 0x060098B2 RID: 39090 RVA: 0x0017A7E4 File Offset: 0x001789E4
		public double FightPercent
		{
			get
			{
				return this._fightPercent;
			}
			set
			{
				this._fightPercent = value;
			}
		}

		// Token: 0x17002DB9 RID: 11705
		// (get) Token: 0x060098B3 RID: 39091 RVA: 0x0017A7F0 File Offset: 0x001789F0
		public FpStrengthNew.RowData StrengthenData
		{
			get
			{
				return this.m_StrengthenData;
			}
		}

		// Token: 0x060098B4 RID: 39092 RVA: 0x0017A808 File Offset: 0x00178A08
		private FpStrengthNew.RowData GetData(int id)
		{
			List<FpStrengthNew.RowData> list = new List<FpStrengthNew.RowData>();
			for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
			{
				FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
				bool flag = rowData.BQID == id;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x17002DBA RID: 11706
		// (get) Token: 0x060098B5 RID: 39093 RVA: 0x0017A864 File Offset: 0x00178A64
		public bool IsShow
		{
			get
			{
				bool flag = this.StrengthenData == null;
				return !flag && XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)this.StrengthenData.BQSystem) && (long)this.StrengthenData.ShowLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

		// Token: 0x04003454 RID: 13396
		private uint m_iFightNum = 0U;

		// Token: 0x04003455 RID: 13397
		private double _fightPercent = 0.0;

		// Token: 0x04003456 RID: 13398
		private FpStrengthNew.RowData m_StrengthenData = null;
	}
}
