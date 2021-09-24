using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWeekNestDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XWeekNestDocument.uuID;
			}
		}

		public static XWeekNestDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XWeekNestDocument.uuID) as XWeekNestDocument;
			}
		}

		public int CurDNid
		{
			get
			{
				return this.m_curDNid;
			}
			set
			{
				this.m_curDNid = value;
			}
		}

		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		public FirstPassRankList LastWeekRankList
		{
			get
			{
				return this.m_LastWeek_rankList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XWeekNestDocument.AsyncLoader.Execute(callback);
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
				bool flag2 = this.View.m_weekNestRankHandler != null && this.View.m_weekNestRankHandler.IsVisible();
				if (flag2)
				{
					this.ReqRankList();
				}
				else
				{
					this.ReqTeamCount();
				}
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void ReqTeamCount()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
		}

		public void ReqRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.NestWeekRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReqLastSeasonRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.LastWeek_NestWeekRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
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
							bool flag5 = this.View.m_weekNestRankHandler != null && this.View.m_weekNestRankHandler.IsVisible();
							if (flag5)
							{
								this.View.m_weekNestRankHandler.FillContent();
							}
						}
					}
				}
				else
				{
					this.m_LastWeek_rankList.Init(oRes, false);
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
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_WeekNest);
				return !flag && this.m_hadRedDot;
			}
			set
			{
				this.m_hadRedDot = value;
			}
		}

		public string GetTittleNameByRank(int rank)
		{
			bool flag = this.m_titleRowList == null;
			if (flag)
			{
				XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
				this.m_titleRowList = new List<DesignationTable.RowData>();
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WeekNestTitleType");
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
						return this.m_titleRowList[j].Designation;
					}
				}
			}
			return "";
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
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeekNestPics");
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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XWeekNestDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private Dictionary<uint, string> m_picDic;

		private int m_curDNid = 0;

		public WeekNestDlg View = null;

		private FirstPassRankList m_rankList = null;

		private FirstPassRankList m_LastWeek_rankList = new FirstPassRankList();

		private List<DesignationTable.RowData> m_titleRowList;

		private bool m_hadRedDot = false;
	}
}
