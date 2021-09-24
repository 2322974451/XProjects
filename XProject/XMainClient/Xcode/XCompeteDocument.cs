using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCompeteDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCompeteDocument.uuID;
			}
		}

		public static XCompeteDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XCompeteDocument.uuID) as XCompeteDocument;
			}
		}

		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCompeteDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				bool flag2 = this.View.m_rankHandler != null && this.View.m_rankHandler.IsVisible();
				if (flag2)
				{
					this.ReqRankList();
				}
				else
				{
					this.ReqCompeteDragonInfo();
				}
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void ReqCompeteDragonInfo()
		{
			RpcC2G_GetCompeteDragonInfo rpcC2G_GetCompeteDragonInfo = new RpcC2G_GetCompeteDragonInfo();
			rpcC2G_GetCompeteDragonInfo.oArg.opArg = CompeteDragonOpArg.CompeteDragon_GetInfo;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetCompeteDragonInfo);
		}

		public void ReqRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.CompeteDragonRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReqLastSeasonRankList()
		{
		}

		public void ReqFetchReward()
		{
			RpcC2G_GetCompeteDragonInfo rpcC2G_GetCompeteDragonInfo = new RpcC2G_GetCompeteDragonInfo();
			rpcC2G_GetCompeteDragonInfo.oArg.opArg = CompeteDragonOpArg.CompeteDragon_GetReward;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetCompeteDragonInfo);
		}

		public void OnGetCompeteDragonInfo(GetCompeteDragonInfoRes oRes)
		{
			this.CurDNid = (int)oRes.curDNExpID;
			this.CanGetCount = oRes.canCanGetRewardCount;
			this.LeftRewardCount = oRes.leftRewardCount;
			this.GetRewardMax = oRes.totalRewardCount;
			this.RefreshUi();
		}

		public void OnFetchReward(GetCompeteDragonInfoRes oRes)
		{
			this.CanGetCount--;
			this.LeftRewardCount--;
			this.RefreshUi();
		}

		public void OnGetRankList(ClientQueryRankListRes oRes, bool LastWeek = false)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				bool flag2 = !LastWeek;
				if (flag2)
				{
					this.m_rankList = new FirstPassRankList(oRes, false);
					bool flag3 = this.View != null && this.View.IsVisible();
					if (flag3)
					{
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							bool flag5 = this.View.m_rankHandler != null && this.View.m_rankHandler.IsVisible();
							if (flag5)
							{
								this.View.m_rankHandler.FillContent();
							}
						}
					}
				}
			}
		}

		public void RefreshUi()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.Resfresh();
			}
		}

		public bool HadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Activity_WeekDragonNest);
				return !flag && this.m_hadRedDot;
			}
			set
			{
				this.m_hadRedDot = value;
			}
		}

		public DesignationTable.RowData GetTittleNameByRank(int rank)
		{
			bool flag = this.m_titleRowList == null;
			if (flag)
			{
				XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
				this.m_titleRowList = new List<DesignationTable.RowData>();
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WeekDragonTitleType");
				for (int i = 0; i < xdesignationDocument._DesignationTable.Table.Length; i++)
				{
					DesignationTable.RowData rowData = xdesignationDocument._DesignationTable.Table[i];
					bool flag2 = rowData != null && rowData.CompleteType == @int;
					if (flag2)
					{
						bool flag3 = !this.m_titleRowList.Contains(rowData);
						if (flag3)
						{
							this.m_titleRowList.Add(rowData);
						}
					}
				}
			}
			for (int j = 0; j < this.m_titleRowList.Count; j++)
			{
				bool flag4 = this.m_titleRowList[j].CompleteValue != null && this.m_titleRowList[j].CompleteValue.Length == 2;
				if (flag4)
				{
					bool flag5 = rank >= this.m_titleRowList[j].CompleteValue[0] && rank <= this.m_titleRowList[j].CompleteValue[1];
					if (flag5)
					{
						return this.m_titleRowList[j];
					}
				}
			}
			return null;
		}

		public string GetPicNameByDNid(uint DNid)
		{
			bool flag = this.m_picDic == null;
			if (flag)
			{
				this.InitPicData();
			}
			string result = "";
			this.m_picDic.TryGetValue(DNid, out result);
			return result;
		}

		private void InitPicData()
		{
			this.m_picDic = new Dictionary<uint, string>();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeekDragonPics");
			bool flag = string.IsNullOrEmpty(value);
			if (!flag)
			{
				string[] array = value.Split(XGlobalConfig.ListSeparator);
				bool flag2 = array == null;
				if (!flag2)
				{
					for (int i = 0; i < array.Length; i++)
					{
						string[] array2 = array[i].Split(XGlobalConfig.SequenceSeparator);
						bool flag3 = array2 == null;
						if (!flag3)
						{
							bool flag4 = array2.Length != 2;
							if (!flag4)
							{
								uint key;
								bool flag5 = uint.TryParse(array2[0], out key);
								if (flag5)
								{
									bool flag6 = !this.m_picDic.ContainsKey(key);
									if (flag6)
									{
										this.m_picDic.Add(key, array2[1]);
									}
								}
							}
						}
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCompeteDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public CompeteNestDlg View = null;

		public int CurDNid = 0;

		public int CanGetCount = 0;

		public int GetRewardMax = 0;

		public int LeftRewardCount = 0;

		private FirstPassRankList m_rankList = null;

		private List<DesignationTable.RowData> m_titleRowList;

		private Dictionary<uint, string> m_picDic;

		private bool m_hadRedDot = false;
	}
}
