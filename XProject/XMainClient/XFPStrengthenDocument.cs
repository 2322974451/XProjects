using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFPStrengthenDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFPStrengthenDocument.uuID;
			}
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = !this.m_sendMesIsBack;
			if (flag)
			{
				this.m_sendMesIsBack = true;
				this.RequsetFightNum();
			}
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/FpStrengthNew", XFPStrengthenDocument.StrengthenReader, false);
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/BQ", XFPStrengthenDocument.StrengthenReader1, false);
			XFPStrengthenDocument.AsyncLoader.AddTask("Table/RecommendFightNum", XFPStrengthenDocument._RecommendFightReader, false);
			XFPStrengthenDocument.AsyncLoader.Execute(callback);
		}

		public FpStrengthenTable.RowData GetStrengthData(int id)
		{
			return XFPStrengthenDocument.StrengthenReader1.GetByBQID(id);
		}

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

		public void RequsetFightNum()
		{
			RpcC2G_QueryPowerPoint rpc = new RpcC2G_QueryPowerPoint();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			this.m_sendMesIsBack = false;
		}

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

		public void TryShowBrief()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = !specificDocument.bInTeam;
			if (flag)
			{
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Strong_Brief, EXStage.Hall);
			}
		}

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

		public bool GetNewStatus(int BqId)
		{
			bool flag = this.NewDic.ContainsKey(BqId);
			return flag && this.NewDic[BqId].Item2;
		}

		public bool GetTabNew(int BqType)
		{
			bool flag = this.TabNewDic.ContainsKey(BqType);
			return flag && this.TabNewDic[BqType];
		}

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

		public bool NeedUp { get; set; }

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XFPStrengthenDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static FpStrengthNew StrengthenReader = new FpStrengthNew();

		public static FpStrengthenTable StrengthenReader1 = new FpStrengthenTable();

		private static RecommendFightNum _RecommendFightReader = new RecommendFightNum();

		private XFpStrengthenView _XFpStrengthenView = null;

		private int[] _totalFightRateNums;

		private string[] _totalFightRateDes;

		private int[] _partFightRateNums;

		private string[] _partFightRateDes;

		private List<StrengthAuxData> _StrengthAuxDataList = null;

		private int m_showUpSprNum = -1;

		private bool m_sendMesIsBack = true;

		private bool _dataIsInit = false;

		private Dictionary<int, XTuple<int, bool>> m_newDic;

		public Dictionary<int, bool> TabNewDic = new Dictionary<int, bool>();

		private bool m_isHadRedot = false;
	}
}
