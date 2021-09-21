using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F8 RID: 2296
	internal class XCompeteDocument : XDocComponent
	{
		// Token: 0x17002B27 RID: 11047
		// (get) Token: 0x06008ADB RID: 35547 RVA: 0x00127F90 File Offset: 0x00126190
		public override uint ID
		{
			get
			{
				return XCompeteDocument.uuID;
			}
		}

		// Token: 0x17002B28 RID: 11048
		// (get) Token: 0x06008ADC RID: 35548 RVA: 0x00127FA8 File Offset: 0x001261A8
		public static XCompeteDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XCompeteDocument.uuID) as XCompeteDocument;
			}
		}

		// Token: 0x17002B29 RID: 11049
		// (get) Token: 0x06008ADD RID: 35549 RVA: 0x00127FD4 File Offset: 0x001261D4
		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		// Token: 0x06008ADE RID: 35550 RVA: 0x00127FEC File Offset: 0x001261EC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCompeteDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008ADF RID: 35551 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008AE0 RID: 35552 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008AE1 RID: 35553 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008AE2 RID: 35554 RVA: 0x00127FFC File Offset: 0x001261FC
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

		// Token: 0x06008AE3 RID: 35555 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008AE4 RID: 35556 RVA: 0x0012805C File Offset: 0x0012625C
		public void ReqCompeteDragonInfo()
		{
			RpcC2G_GetCompeteDragonInfo rpcC2G_GetCompeteDragonInfo = new RpcC2G_GetCompeteDragonInfo();
			rpcC2G_GetCompeteDragonInfo.oArg.opArg = CompeteDragonOpArg.CompeteDragon_GetInfo;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetCompeteDragonInfo);
		}

		// Token: 0x06008AE5 RID: 35557 RVA: 0x0012808C File Offset: 0x0012628C
		public void ReqRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.CompeteDragonRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06008AE6 RID: 35558 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ReqLastSeasonRankList()
		{
		}

		// Token: 0x06008AE7 RID: 35559 RVA: 0x001280C0 File Offset: 0x001262C0
		public void ReqFetchReward()
		{
			RpcC2G_GetCompeteDragonInfo rpcC2G_GetCompeteDragonInfo = new RpcC2G_GetCompeteDragonInfo();
			rpcC2G_GetCompeteDragonInfo.oArg.opArg = CompeteDragonOpArg.CompeteDragon_GetReward;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetCompeteDragonInfo);
		}

		// Token: 0x06008AE8 RID: 35560 RVA: 0x001280ED File Offset: 0x001262ED
		public void OnGetCompeteDragonInfo(GetCompeteDragonInfoRes oRes)
		{
			this.CurDNid = (int)oRes.curDNExpID;
			this.CanGetCount = oRes.canCanGetRewardCount;
			this.LeftRewardCount = oRes.leftRewardCount;
			this.GetRewardMax = oRes.totalRewardCount;
			this.RefreshUi();
		}

		// Token: 0x06008AE9 RID: 35561 RVA: 0x00128127 File Offset: 0x00126327
		public void OnFetchReward(GetCompeteDragonInfoRes oRes)
		{
			this.CanGetCount--;
			this.LeftRewardCount--;
			this.RefreshUi();
		}

		// Token: 0x06008AEA RID: 35562 RVA: 0x00128150 File Offset: 0x00126350
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

		// Token: 0x06008AEB RID: 35563 RVA: 0x00128218 File Offset: 0x00126418
		public void RefreshUi()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.Resfresh();
			}
		}

		// Token: 0x17002B2A RID: 11050
		// (get) Token: 0x06008AED RID: 35565 RVA: 0x00128258 File Offset: 0x00126458
		// (set) Token: 0x06008AEC RID: 35564 RVA: 0x0012824C File Offset: 0x0012644C
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

		// Token: 0x06008AEE RID: 35566 RVA: 0x0012828C File Offset: 0x0012648C
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

		// Token: 0x06008AEF RID: 35567 RVA: 0x00128400 File Offset: 0x00126600
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

		// Token: 0x06008AF0 RID: 35568 RVA: 0x0012843C File Offset: 0x0012663C
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

		// Token: 0x04002C47 RID: 11335
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCompeteDocument");

		// Token: 0x04002C48 RID: 11336
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C49 RID: 11337
		public CompeteNestDlg View = null;

		// Token: 0x04002C4A RID: 11338
		public int CurDNid = 0;

		// Token: 0x04002C4B RID: 11339
		public int CanGetCount = 0;

		// Token: 0x04002C4C RID: 11340
		public int GetRewardMax = 0;

		// Token: 0x04002C4D RID: 11341
		public int LeftRewardCount = 0;

		// Token: 0x04002C4E RID: 11342
		private FirstPassRankList m_rankList = null;

		// Token: 0x04002C4F RID: 11343
		private List<DesignationTable.RowData> m_titleRowList;

		// Token: 0x04002C50 RID: 11344
		private Dictionary<uint, string> m_picDic;

		// Token: 0x04002C51 RID: 11345
		private bool m_hadRedDot = false;
	}
}
