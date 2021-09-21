using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009D0 RID: 2512
	internal class XFPStrengthenDocument : XDocComponent
	{
		// Token: 0x17002DAF RID: 11695
		// (get) Token: 0x06009883 RID: 39043 RVA: 0x00179750 File Offset: 0x00177950
		public override uint ID
		{
			get
			{
				return XFPStrengthenDocument.uuID;
			}
		}

		// Token: 0x17002DB0 RID: 11696
		// (get) Token: 0x06009884 RID: 39044 RVA: 0x00179768 File Offset: 0x00177968
		// (set) Token: 0x06009885 RID: 39045 RVA: 0x00179780 File Offset: 0x00177980
		public XFpStrengthenView StrengthenView
		{
			get
			{
				return this._XFpStrengthenView;
			}
			set
			{
				this._XFpStrengthenView = value;
			}
		}

		// Token: 0x06009886 RID: 39046 RVA: 0x0017978A File Offset: 0x0017798A
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

		// Token: 0x06009887 RID: 39047 RVA: 0x001797AC File Offset: 0x001779AC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = !this.m_sendMesIsBack;
			if (flag)
			{
				this.m_sendMesIsBack = true;
				this.RequsetFightNum();
			}
		}

		// Token: 0x06009888 RID: 39048 RVA: 0x0014E32B File Offset: 0x0014C52B
		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		// Token: 0x06009889 RID: 39049 RVA: 0x001797D8 File Offset: 0x001779D8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/FpStrengthNew", XFPStrengthenDocument.StrengthenReader, false);
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/BQ", XFPStrengthenDocument.StrengthenReader1, false);
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/RecommendFightNum", XFPStrengthenDocument._RecommendFightReader, false);
			XFPStrengthenDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600988A RID: 39050 RVA: 0x00179834 File Offset: 0x00177A34
		public FpStrengthenTable.RowData GetStrengthData(int id)
		{
			return XFPStrengthenDocument.StrengthenReader1.GetByBQID(id);
		}

		// Token: 0x0600988B RID: 39051 RVA: 0x00179854 File Offset: 0x00177A54
		public RecommendFightNum.RowData GetRecommendFightData(XSysDefine type, int level = -1)
		{
			bool flag = level == -1;
			if (flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("XAttributeMgr.singleton.XPlayerData is null", null, null, null, null, null);
				}
			}
			bool flag3 = type == XSysDefine.XSys_None;
			if (flag3)
			{
				for (int i = 0; i < XFPStrengthenDocument._RecommendFightReader.Table.Length; i++)
				{
					bool flag4 = (ulong)XFPStrengthenDocument._RecommendFightReader.Table[i].Level == (ulong)((long)level);
					if (flag4)
					{
						return XFPStrengthenDocument._RecommendFightReader.Table[i];
					}
				}
			}
			else
			{
				for (int j = 0; j < XFPStrengthenDocument._RecommendFightReader.Table.Length; j++)
				{
					bool flag5 = (ulong)XFPStrengthenDocument._RecommendFightReader.Table[j].Level == (ulong)((long)level) && XFPStrengthenDocument._RecommendFightReader.Table[j].SystemID == (uint)type;
					if (flag5)
					{
						return XFPStrengthenDocument._RecommendFightReader.Table[j];
					}
				}
			}
			return null;
		}

		// Token: 0x17002DB1 RID: 11697
		// (get) Token: 0x0600988C RID: 39052 RVA: 0x00179974 File Offset: 0x00177B74
		public List<StrengthAuxData> StrengthAuxDataList
		{
			get
			{
				bool flag = this._StrengthAuxDataList == null;
				if (flag)
				{
					this._StrengthAuxDataList = new List<StrengthAuxData>();
					for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
					{
						FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
						bool flag2 = rowData == null;
						if (!flag2)
						{
							bool flag3 = rowData.Bqtype == 0;
							if (flag3)
							{
								StrengthAuxData item = new StrengthAuxData(rowData);
								this._StrengthAuxDataList.Add(item);
							}
						}
					}
				}
				return this._StrengthAuxDataList;
			}
		}

		// Token: 0x17002DB2 RID: 11698
		// (get) Token: 0x0600988D RID: 39053 RVA: 0x00179A08 File Offset: 0x00177C08
		public int ShowUpSprNum
		{
			get
			{
				bool flag = this.m_showUpSprNum == -1;
				if (flag)
				{
					this.m_showUpSprNum = XSingleton<XGlobalConfig>.singleton.GetInt("ShowUpSprNum");
				}
				return this.m_showUpSprNum;
			}
		}

		// Token: 0x0600988E RID: 39054 RVA: 0x00179A44 File Offset: 0x00177C44
		public void RequsetFightNum()
		{
			RpcC2G_QueryPowerPoint rpc = new RpcC2G_QueryPowerPoint();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			this.m_sendMesIsBack = false;
		}

		// Token: 0x0600988F RID: 39055 RVA: 0x00179A6C File Offset: 0x00177C6C
		public void RefreshUi(QueryPowerPointRes oRes)
		{
			this.m_sendMesIsBack = true;
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				bool flag2 = oRes.bqID == null || oRes.ppt == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("the sever gived data is null!", null, null, null, null, null);
				}
				else
				{
					for (int i = 0; i < oRes.bqID.Count; i++)
					{
						StrengthAuxData strengthAuxDataById = this.GetStrengthAuxDataById(oRes.bqID[i]);
						bool flag3 = strengthAuxDataById != null;
						if (flag3)
						{
							strengthAuxDataById.FightNum = (uint)oRes.ppt[i];
							strengthAuxDataById.FightPercent = strengthAuxDataById.GetFightPercent(this.GetFightNumBySysType((XSysDefine)strengthAuxDataById.StrengthenData.BQSystem));
						}
					}
					this.AuxSortCompare();
					this.SetNeedUp();
					this.SetHadRedot();
					bool flag4 = DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.RefreshUi(true);
					}
				}
			}
		}

		// Token: 0x06009890 RID: 39056 RVA: 0x00179B80 File Offset: 0x00177D80
		private void AuxSortCompare()
		{
			for (int i = 0; i < this.StrengthAuxDataList.Count - 1; i++)
			{
				for (int j = i + 1; j < this.StrengthAuxDataList.Count; j++)
				{
					bool flag = this.StrengthAuxDataList[i].FightPercent > this.StrengthAuxDataList[j].FightPercent;
					if (flag)
					{
						StrengthAuxData value = this.StrengthAuxDataList[j];
						this.StrengthAuxDataList[j] = this.StrengthAuxDataList[i];
						this.StrengthAuxDataList[i] = value;
					}
				}
			}
		}

		// Token: 0x06009891 RID: 39057 RVA: 0x00179C34 File Offset: 0x00177E34
		private StrengthAuxData GetStrengthAuxDataById(uint BQId)
		{
			bool flag = this.StrengthAuxDataList == null || this.StrengthAuxDataList.Count == 0;
			StrengthAuxData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.StrengthAuxDataList.Count; i++)
				{
					bool flag2 = (long)this.StrengthAuxDataList[i].Id == (long)((ulong)BQId);
					if (flag2)
					{
						return this.StrengthAuxDataList[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06009892 RID: 39058 RVA: 0x00179CB0 File Offset: 0x00177EB0
		public int GetFightNumBySysType(XSysDefine type)
		{
			RecommendFightNum.RowData recommendFightData = this.GetRecommendFightData(type, -1);
			bool flag = recommendFightData == null;
			int result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("the data is not find ==", type.ToString(), null, null, null, null);
				result = 1;
			}
			else
			{
				result = (int)recommendFightData.Point;
			}
			return result;
		}

		// Token: 0x06009893 RID: 39059 RVA: 0x00179D00 File Offset: 0x00177F00
		public List<FpStrengthNew.RowData> GetStrengthByType(int type)
		{
			List<FpStrengthNew.RowData> list = new List<FpStrengthNew.RowData>();
			for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
			{
				FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
				bool flag = rowData.Bqtype == type;
				if (flag)
				{
					bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)rowData.BQSystem) && (long)rowData.ShowLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					bool flag3 = flag2;
					if (flag3)
					{
						list.Add(rowData);
					}
				}
			}
			bool flag4 = type != 0;
			if (flag4)
			{
				list.Sort(new Comparison<FpStrengthNew.RowData>(this.DataCompare));
			}
			return list;
		}

		// Token: 0x06009894 RID: 39060 RVA: 0x00179DBC File Offset: 0x00177FBC
		private int DataCompare(FpStrengthNew.RowData left, FpStrengthNew.RowData right)
		{
			bool flag = left.StarNum > right.StarNum;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06009895 RID: 39061 RVA: 0x00179DE8 File Offset: 0x00177FE8
		public int GetFuncNumByType(int type)
		{
			int num = 0;
			for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
			{
				FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
				bool flag = rowData.Bqtype == type && XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)rowData.BQSystem) && (long)rowData.ShowLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06009896 RID: 39062 RVA: 0x00179E70 File Offset: 0x00178070
		public FpStrengthenTable.RowData SearchBySysID(XSysDefine sys)
		{
			for (int i = 0; i < XFPStrengthenDocument.StrengthenReader1.Table.Length; i++)
			{
				FpStrengthenTable.RowData rowData = XFPStrengthenDocument.StrengthenReader1.Table[i];
				bool flag = rowData.BQSystem == (int)sys;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x06009897 RID: 39063 RVA: 0x00179EC0 File Offset: 0x001780C0
		public List<FpStrengthenTable.RowData> GetBQByType(int type)
		{
			List<FpStrengthenTable.RowData> list = new List<FpStrengthenTable.RowData>();
			for (int i = 0; i < XFPStrengthenDocument.StrengthenReader1.Table.Length; i++)
			{
				FpStrengthenTable.RowData rowData = XFPStrengthenDocument.StrengthenReader1.Table[i];
				bool flag = rowData.Bqtype == type;
				if (flag)
				{
					bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)rowData.BQSystem) && (long)rowData.ShowLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					bool flag3 = flag2;
					if (flag3)
					{
						list.Add(rowData);
					}
				}
			}
			return list;
		}

		// Token: 0x06009898 RID: 39064 RVA: 0x00179F5C File Offset: 0x0017815C
		public void TryShowBrief()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = !specificDocument.bInTeam;
			if (flag)
			{
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Strong_Brief, EXStage.Hall);
			}
		}

		// Token: 0x06009899 RID: 39065 RVA: 0x00179F94 File Offset: 0x00178194
		public string GetTotalFightRateDes(int fightPercent)
		{
			this.InitStringData();
			string text = "";
			bool flag = this._totalFightRateDes == null || this._totalFightRateNums == null;
			string result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("error,plase check Strength_TotalFight_Rate(gb or stringTab)", null, null, null, null, null);
				result = text;
			}
			else
			{
				int index = this.GetIndex((double)fightPercent, this._totalFightRateNums);
				bool flag2 = this._totalFightRateDes.Length >= index;
				if (flag2)
				{
					text = this._totalFightRateDes[index];
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("err  err err!", null, null, null, null, null);
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600989A RID: 39066 RVA: 0x0017A02C File Offset: 0x0017822C
		public string GetPartFightRateDes(double fightPercent)
		{
			this.InitStringData();
			string text = "";
			bool flag = this._partFightRateDes == null || this._partFightRateNums == null;
			string result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("error,plase check Strength_TotalFight_Rate(gb or stringTab)", null, null, null, null, null);
				result = text;
			}
			else
			{
				int index = this.GetIndex(fightPercent, this._partFightRateNums);
				bool flag2 = this._partFightRateDes.Length >= index;
				if (flag2)
				{
					bool flag3 = index == 0;
					if (flag3)
					{
						text = XSingleton<XCommon>.singleton.StringCombine("[ff4343]", this._partFightRateDes[index], "[-]");
					}
					else
					{
						bool flag4 = index == 1;
						if (flag4)
						{
							text = XSingleton<XCommon>.singleton.StringCombine("[6df5ff]", this._partFightRateDes[index], "[-]");
						}
						else
						{
							bool flag5 = index == 2;
							if (flag5)
							{
								text = XSingleton<XCommon>.singleton.StringCombine("[4ef23d]", this._partFightRateDes[index], "[-]");
							}
							else
							{
								bool flag6 = index == 3;
								if (flag6)
								{
									text = XSingleton<XCommon>.singleton.StringCombine("[fff640]", this._partFightRateDes[index], "[-]");
								}
								else
								{
									text = this._partFightRateDes[index];
								}
							}
						}
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("err   err  err", null, null, null, null, null);
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600989B RID: 39067 RVA: 0x0017A170 File Offset: 0x00178370
		private int GetIndex(double fightPercent, int[] array)
		{
			bool flag = array == null || array.Length == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					bool flag2 = fightPercent < (double)array[i];
					if (flag2)
					{
						return i;
					}
				}
				result = array.Length;
			}
			return result;
		}

		// Token: 0x0600989C RID: 39068 RVA: 0x0017A1C0 File Offset: 0x001783C0
		private void InitStringData()
		{
			bool dataIsInit = this._dataIsInit;
			if (!dataIsInit)
			{
				this._totalFightRateDes = XStringDefineProxy.GetString("Strength_TotalFight_Rate").Split(new char[]
				{
					'|'
				});
				this._partFightRateDes = XStringDefineProxy.GetString("Strength_ParticalFight_Rate").Split(new char[]
				{
					'|'
				});
				this._totalFightRateNums = XSingleton<XGlobalConfig>.singleton.GetIntList("Strength_TotalFight_Rate").ToArray();
				this._partFightRateNums = XSingleton<XGlobalConfig>.singleton.GetIntList("Strength_ParticalFight_Rate").ToArray();
				this._dataIsInit = true;
			}
		}

		// Token: 0x0600989D RID: 39069 RVA: 0x0017A258 File Offset: 0x00178458
		private bool OnAttributeChange(XEventArgs e)
		{
			XAttrChangeEventArgs xattrChangeEventArgs = e as XAttrChangeEventArgs;
			XAttributeDefine attrKey = xattrChangeEventArgs.AttrKey;
			if (attrKey == XAttributeDefine.XAttr_POWER_POINT_Basic)
			{
				this.RequsetFightNum();
			}
			return true;
		}

		// Token: 0x17002DB3 RID: 11699
		// (get) Token: 0x0600989E RID: 39070 RVA: 0x0017A28C File Offset: 0x0017848C
		public Dictionary<int, XTuple<int, bool>> NewDic
		{
			get
			{
				bool flag = this.m_newDic == null;
				if (flag)
				{
					this.m_newDic = new Dictionary<int, XTuple<int, bool>>();
					bool flag2 = XFPStrengthenDocument.StrengthenReader != null;
					if (flag2)
					{
						for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
						{
							FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
							bool flag3 = rowData != null;
							if (flag3)
							{
								bool flag4 = !this.m_newDic.ContainsKey(rowData.BQID);
								if (flag4)
								{
									this.m_newDic.Add(rowData.BQID, new XTuple<int, bool>(rowData.Bqtype, false));
								}
							}
						}
					}
				}
				return this.m_newDic;
			}
		}

		// Token: 0x0600989F RID: 39071 RVA: 0x0017A344 File Offset: 0x00178544
		public bool GetNewStatus(int BqId)
		{
			bool flag = this.NewDic.ContainsKey(BqId);
			return flag && this.NewDic[BqId].Item2;
		}

		// Token: 0x060098A0 RID: 39072 RVA: 0x0017A37C File Offset: 0x0017857C
		public bool GetTabNew(int BqType)
		{
			bool flag = this.TabNewDic.ContainsKey(BqType);
			return flag && this.TabNewDic[BqType];
		}

		// Token: 0x060098A1 RID: 39073 RVA: 0x0017A3B0 File Offset: 0x001785B0
		public void SetNew(List<uint> sysIds)
		{
			bool flag = sysIds == null;
			if (!flag)
			{
				for (int i = 0; i < sysIds.Count; i++)
				{
					this.SetNew(sysIds[i]);
				}
			}
		}

		// Token: 0x060098A2 RID: 39074 RVA: 0x0017A3F0 File Offset: 0x001785F0
		public void CancleNew(int bqType)
		{
			bool flag = this.TabNewDic.ContainsKey(bqType);
			if (flag)
			{
				this.TabNewDic.Remove(bqType);
				foreach (KeyValuePair<int, XTuple<int, bool>> keyValuePair in this.NewDic)
				{
					bool flag2 = keyValuePair.Value.Item1 == bqType;
					if (flag2)
					{
						keyValuePair.Value.Item2 = false;
					}
				}
			}
		}

		// Token: 0x17002DB4 RID: 11700
		// (get) Token: 0x060098A4 RID: 39076 RVA: 0x0017A4B8 File Offset: 0x001786B8
		// (set) Token: 0x060098A3 RID: 39075 RVA: 0x0017A484 File Offset: 0x00178684
		public bool IsHadRedot
		{
			get
			{
				return this.m_isHadRedot;
			}
			set
			{
				bool flag = this.m_isHadRedot != value;
				if (flag)
				{
					this.m_isHadRedot = value;
					XSingleton<XGameSysMgr>.singleton.UpdateRedPointOnHallUI(XSysDefine.XSys_Strong);
				}
			}
		}

		// Token: 0x17002DB5 RID: 11701
		// (get) Token: 0x060098A5 RID: 39077 RVA: 0x0017A4D0 File Offset: 0x001786D0
		// (set) Token: 0x060098A6 RID: 39078 RVA: 0x0017A4D8 File Offset: 0x001786D8
		public bool NeedUp { get; set; }

		// Token: 0x060098A7 RID: 39079 RVA: 0x0017A4E4 File Offset: 0x001786E4
		private void SetNew(uint sysId)
		{
			bool flag = XFPStrengthenDocument.StrengthenReader == null;
			if (!flag)
			{
				for (int i = 0; i < XFPStrengthenDocument.StrengthenReader.Table.Length; i++)
				{
					FpStrengthNew.RowData rowData = XFPStrengthenDocument.StrengthenReader.Table[i];
					bool flag2 = rowData == null;
					if (!flag2)
					{
						bool flag3 = (long)rowData.BQSystem == (long)((ulong)sysId);
						if (flag3)
						{
							bool flag4 = this.NewDic.ContainsKey(rowData.BQID);
							if (flag4)
							{
								this.NewDic[rowData.BQID].Item2 = true;
							}
							bool flag5 = !this.TabNewDic.ContainsKey(rowData.Bqtype);
							if (flag5)
							{
								this.TabNewDic.Add(rowData.Bqtype, true);
							}
						}
					}
				}
			}
		}

		// Token: 0x060098A8 RID: 39080 RVA: 0x0017A5B0 File Offset: 0x001787B0
		private void SetNeedUp()
		{
			this.NeedUp = false;
			for (int i = 0; i < this.StrengthAuxDataList.Count; i++)
			{
				bool flag = this.StrengthAuxDataList[i].FightPercent < (double)this.ShowUpSprNum;
				if (flag)
				{
					this.NeedUp = true;
					break;
				}
			}
		}

		// Token: 0x060098A9 RID: 39081 RVA: 0x0017A60C File Offset: 0x0017880C
		private void SetHadRedot()
		{
			bool flag = this.NeedUp;
			bool flag2 = !flag;
			if (flag2)
			{
				foreach (KeyValuePair<int, XTuple<int, bool>> keyValuePair in this.NewDic)
				{
					bool item = keyValuePair.Value.Item2;
					if (item)
					{
						flag = true;
						break;
					}
				}
			}
			this.IsHadRedot = flag;
		}

		// Token: 0x04003442 RID: 13378
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XFPStrengthenDocument");

		// Token: 0x04003443 RID: 13379
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003444 RID: 13380
		public static FpStrengthNew StrengthenReader = new FpStrengthNew();

		// Token: 0x04003445 RID: 13381
		public static FpStrengthenTable StrengthenReader1 = new FpStrengthenTable();

		// Token: 0x04003446 RID: 13382
		private static RecommendFightNum _RecommendFightReader = new RecommendFightNum();

		// Token: 0x04003447 RID: 13383
		private XFpStrengthenView _XFpStrengthenView = null;

		// Token: 0x04003448 RID: 13384
		private int[] _totalFightRateNums;

		// Token: 0x04003449 RID: 13385
		private string[] _totalFightRateDes;

		// Token: 0x0400344A RID: 13386
		private int[] _partFightRateNums;

		// Token: 0x0400344B RID: 13387
		private string[] _partFightRateDes;

		// Token: 0x0400344C RID: 13388
		private List<StrengthAuxData> _StrengthAuxDataList = null;

		// Token: 0x0400344D RID: 13389
		private int m_showUpSprNum = -1;

		// Token: 0x0400344E RID: 13390
		private bool m_sendMesIsBack = true;

		// Token: 0x0400344F RID: 13391
		private bool _dataIsInit = false;

		// Token: 0x04003450 RID: 13392
		private Dictionary<int, XTuple<int, bool>> m_newDic;

		// Token: 0x04003451 RID: 13393
		public Dictionary<int, bool> TabNewDic = new Dictionary<int, bool>();

		// Token: 0x04003453 RID: 13395
		private bool m_isHadRedot = false;
	}
}
