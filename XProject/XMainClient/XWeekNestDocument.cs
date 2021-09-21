using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C5D RID: 3165
	internal class XWeekNestDocument : XDocComponent
	{
		// Token: 0x170031AC RID: 12716
		// (get) Token: 0x0600B341 RID: 45889 RVA: 0x0022D164 File Offset: 0x0022B364
		public override uint ID
		{
			get
			{
				return XWeekNestDocument.uuID;
			}
		}

		// Token: 0x170031AD RID: 12717
		// (get) Token: 0x0600B342 RID: 45890 RVA: 0x0022D17C File Offset: 0x0022B37C
		public static XWeekNestDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XWeekNestDocument.uuID) as XWeekNestDocument;
			}
		}

		// Token: 0x170031AE RID: 12718
		// (get) Token: 0x0600B343 RID: 45891 RVA: 0x0022D1A8 File Offset: 0x0022B3A8
		// (set) Token: 0x0600B344 RID: 45892 RVA: 0x0022D1C0 File Offset: 0x0022B3C0
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

		// Token: 0x170031AF RID: 12719
		// (get) Token: 0x0600B345 RID: 45893 RVA: 0x0022D1CC File Offset: 0x0022B3CC
		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		// Token: 0x170031B0 RID: 12720
		// (get) Token: 0x0600B346 RID: 45894 RVA: 0x0022D1E4 File Offset: 0x0022B3E4
		public FirstPassRankList LastWeekRankList
		{
			get
			{
				return this.m_LastWeek_rankList;
			}
		}

		// Token: 0x0600B347 RID: 45895 RVA: 0x0022D1FC File Offset: 0x0022B3FC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XWeekNestDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B348 RID: 45896 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B349 RID: 45897 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600B34A RID: 45898 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600B34B RID: 45899 RVA: 0x0022D20C File Offset: 0x0022B40C
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

		// Token: 0x0600B34C RID: 45900 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600B34D RID: 45901 RVA: 0x0022D26C File Offset: 0x0022B46C
		public void ReqTeamCount()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
		}

		// Token: 0x0600B34E RID: 45902 RVA: 0x0022D294 File Offset: 0x0022B494
		public void ReqRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.NestWeekRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x0600B34F RID: 45903 RVA: 0x0022D2C8 File Offset: 0x0022B4C8
		public void ReqLastSeasonRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.LastWeek_NestWeekRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x0600B350 RID: 45904 RVA: 0x0022D2FC File Offset: 0x0022B4FC
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

		// Token: 0x0600B351 RID: 45905 RVA: 0x0022D3D0 File Offset: 0x0022B5D0
		public void RefreshUi()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.Resfresh();
			}
		}

		// Token: 0x170031B1 RID: 12721
		// (get) Token: 0x0600B353 RID: 45907 RVA: 0x0022D410 File Offset: 0x0022B610
		// (set) Token: 0x0600B352 RID: 45906 RVA: 0x0022D404 File Offset: 0x0022B604
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

		// Token: 0x0600B354 RID: 45908 RVA: 0x0022D444 File Offset: 0x0022B644
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

		// Token: 0x0600B355 RID: 45909 RVA: 0x0022D5C0 File Offset: 0x0022B7C0
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

		// Token: 0x0600B356 RID: 45910 RVA: 0x0022D5FC File Offset: 0x0022B7FC
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

		// Token: 0x04004552 RID: 17746
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XWeekNestDocument");

		// Token: 0x04004553 RID: 17747
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004554 RID: 17748
		private Dictionary<uint, string> m_picDic;

		// Token: 0x04004555 RID: 17749
		private int m_curDNid = 0;

		// Token: 0x04004556 RID: 17750
		public WeekNestDlg View = null;

		// Token: 0x04004557 RID: 17751
		private FirstPassRankList m_rankList = null;

		// Token: 0x04004558 RID: 17752
		private FirstPassRankList m_LastWeek_rankList = new FirstPassRankList();

		// Token: 0x04004559 RID: 17753
		private List<DesignationTable.RowData> m_titleRowList;

		// Token: 0x0400455A RID: 17754
		private bool m_hadRedDot = false;
	}
}
