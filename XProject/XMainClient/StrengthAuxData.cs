using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	public class StrengthAuxData
	{

		public StrengthAuxData(FpStrengthNew.RowData data)
		{
			this.m_StrengthenData = data;
		}

		public int Id
		{
			get
			{
				return this.m_StrengthenData.BQID;
			}
		}

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

		public FpStrengthNew.RowData StrengthenData
		{
			get
			{
				return this.m_StrengthenData;
			}
		}

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

		public bool IsShow
		{
			get
			{
				bool flag = this.StrengthenData == null;
				return !flag && XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)this.StrengthenData.BQSystem) && (long)this.StrengthenData.ShowLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

		private uint m_iFightNum = 0U;

		private double _fightPercent = 0.0;

		private FpStrengthNew.RowData m_StrengthenData = null;
	}
}
