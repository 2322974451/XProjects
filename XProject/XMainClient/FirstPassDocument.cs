using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CFE RID: 3326
	internal class FirstPassDocument : XDocComponent
	{
		// Token: 0x170032B7 RID: 12983
		// (get) Token: 0x0600BA0E RID: 47630 RVA: 0x0025E4F4 File Offset: 0x0025C6F4
		public override uint ID
		{
			get
			{
				return FirstPassDocument.uuID;
			}
		}

		// Token: 0x170032B8 RID: 12984
		// (get) Token: 0x0600BA0F RID: 47631 RVA: 0x0025E50C File Offset: 0x0025C70C
		public int NeedPassTeamCount
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("PassTeamCount");
			}
		}

		// Token: 0x170032B9 RID: 12985
		// (get) Token: 0x0600BA10 RID: 47632 RVA: 0x0025E530 File Offset: 0x0025C730
		public static FirstPassDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(FirstPassDocument.uuID) as FirstPassDocument;
			}
		}

		// Token: 0x170032BA RID: 12986
		// (get) Token: 0x0600BA11 RID: 47633 RVA: 0x0025E55B File Offset: 0x0025C75B
		// (set) Token: 0x0600BA12 RID: 47634 RVA: 0x0025E563 File Offset: 0x0025C763
		public FirstPassMainHandler View { get; set; }

		// Token: 0x0600BA13 RID: 47635 RVA: 0x0025E56C File Offset: 0x0025C76C
		public static void Execute(OnLoadedCallback callback = null)
		{
			FirstPassDocument.AsyncLoader.AddTask("Table/FirstPass", FirstPassDocument.sFirstPassTable, false);
			FirstPassDocument.AsyncLoader.AddTask("Table/FirstPassReward", FirstPassDocument.sFirstPassReward, false);
			FirstPassDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600BA14 RID: 47636 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600BA15 RID: 47637 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600BA16 RID: 47638 RVA: 0x0025E5A8 File Offset: 0x0025C7A8
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			bool flag = this.m_FirstPassData != null;
			if (flag)
			{
				for (int i = 0; i < this.m_FirstPassData.Count; i++)
				{
					this.m_FirstPassData[i] = null;
				}
				this.m_FirstPassData.Clear();
			}
		}

		// Token: 0x0600BA17 RID: 47639 RVA: 0x0025E604 File Offset: 0x0025C804
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqRankList(this.CurData.Id);
			}
			else
			{
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					bool flag3 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag3)
					{
						this.ReqFirstPassTopRoleInfo(this.CurData.Id);
					}
					else
					{
						this.ReqFirstPassInfo();
					}
				}
			}
		}

		// Token: 0x0600BA18 RID: 47640 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x170032BB RID: 12987
		// (get) Token: 0x0600BA19 RID: 47641 RVA: 0x0025E694 File Offset: 0x0025C894
		public List<FirstPassAuxData> FirstPassData
		{
			get
			{
				bool flag = this.m_FirstPassData == null;
				if (flag)
				{
					this.m_FirstPassData = new List<FirstPassAuxData>();
					for (int i = 0; i < FirstPassDocument.sFirstPassTable.Table.Length; i++)
					{
						FirstPassAuxData item = new FirstPassAuxData(FirstPassDocument.sFirstPassTable.Table[i]);
						this.m_FirstPassData.Add(item);
					}
				}
				return this.m_FirstPassData;
			}
		}

		// Token: 0x170032BC RID: 12988
		// (get) Token: 0x0600BA1A RID: 47642 RVA: 0x0025E704 File Offset: 0x0025C904
		// (set) Token: 0x0600BA1B RID: 47643 RVA: 0x0025E71C File Offset: 0x0025C91C
		public bool IsHadOutRedDot
		{
			get
			{
				return this.m_isHadOutRedDot;
			}
			set
			{
				bool flag = this.m_isHadOutRedDot != value;
				if (flag)
				{
					this.m_isHadOutRedDot = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_OperatingActivity, true);
					bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshRedpoint();
					}
				}
			}
		}

		// Token: 0x170032BD RID: 12989
		// (get) Token: 0x0600BA1C RID: 47644 RVA: 0x0025E76D File Offset: 0x0025C96D
		// (set) Token: 0x0600BA1D RID: 47645 RVA: 0x0025E775 File Offset: 0x0025C975
		public FirstPassAuxData CurData { get; set; }

		// Token: 0x170032BE RID: 12990
		// (get) Token: 0x0600BA1E RID: 47646 RVA: 0x0025E780 File Offset: 0x0025C980
		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		// Token: 0x170032BF RID: 12991
		// (get) Token: 0x0600BA1F RID: 47647 RVA: 0x0025E798 File Offset: 0x0025C998
		public bool IsHadNextData
		{
			get
			{
				int index = this.GetIndex();
				bool flag = index == this.FirstPassData.Count - 1;
				return !flag && this.FirstPassData[index + 1].IsOpen();
			}
		}

		// Token: 0x170032C0 RID: 12992
		// (get) Token: 0x0600BA20 RID: 47648 RVA: 0x0025E7DC File Offset: 0x0025C9DC
		public bool IsHadLastData
		{
			get
			{
				int index = this.GetIndex();
				bool flag = index == 0;
				return !flag && this.FirstPassData[index - 1].IsOpen();
			}
		}

		// Token: 0x170032C1 RID: 12993
		// (get) Token: 0x0600BA21 RID: 47649 RVA: 0x0025E814 File Offset: 0x0025CA14
		public FirstPassAuxData AutoSelectFirstPassData
		{
			get
			{
				bool flag = this.FirstPassData.Count == 0;
				FirstPassAuxData result;
				if (flag)
				{
					result = null;
				}
				else
				{
					bool flag2 = this.FirstPassData.Count == 1;
					if (flag2)
					{
						result = this.FirstPassData[0];
					}
					else
					{
						for (int i = 0; i < this.FirstPassData.Count; i++)
						{
							bool flag3 = i == 0;
							if (flag3)
							{
								bool flag4 = !this.FirstPassData[i].IsOpen();
								if (flag4)
								{
									return this.FirstPassData[i];
								}
							}
							bool flag5 = i == this.FirstPassData.Count - 1;
							if (flag5)
							{
								return this.FirstPassData[i];
							}
							bool flag6 = this.FirstPassData[i].PassTeamCount < this.NeedPassTeamCount;
							if (flag6)
							{
								return this.FirstPassData[i];
							}
							bool flag7 = !this.FirstPassData[i + 1].IsOpen();
							if (flag7)
							{
								return this.FirstPassData[i];
							}
						}
						result = this.FirstPassData[0];
					}
				}
				return result;
			}
		}

		// Token: 0x0600BA22 RID: 47650 RVA: 0x0025E950 File Offset: 0x0025CB50
		public void SetCurDataByNestType(int nestType)
		{
			bool flag = this.FirstPassData.Count <= 0;
			if (!flag)
			{
				for (int i = 0; i < this.FirstPassData.Count; i++)
				{
					bool flag2 = this.FirstPassData[i] != null;
					if (flag2)
					{
						bool flag3 = (ulong)this.FirstPassData[i].FirstPassRow.NestType == (ulong)((long)nestType);
						if (flag3)
						{
							this.CurData = this.FirstPassData[i];
							return;
						}
					}
				}
				this.CurData = this.FirstPassData[0];
			}
		}

		// Token: 0x0600BA23 RID: 47651 RVA: 0x0025E9F0 File Offset: 0x0025CBF0
		public FirstPassAuxData GetNextFirstPassData()
		{
			int index = this.GetIndex();
			bool flag = index == this.FirstPassData.Count - 1;
			FirstPassAuxData result;
			if (flag)
			{
				result = this.CurData;
			}
			else
			{
				bool flag2 = !this.FirstPassData[index + 1].IsOpen();
				if (flag2)
				{
					result = this.CurData;
				}
				else
				{
					result = this.FirstPassData[index + 1];
				}
			}
			return result;
		}

		// Token: 0x0600BA24 RID: 47652 RVA: 0x0025EA58 File Offset: 0x0025CC58
		public FirstPassAuxData GetLastFirstPassData()
		{
			int index = this.GetIndex();
			bool flag = index == 0;
			FirstPassAuxData result;
			if (flag)
			{
				result = this.CurData;
			}
			else
			{
				bool flag2 = !this.FirstPassData[index - 1].IsOpen();
				if (flag2)
				{
					result = this.CurData;
				}
				else
				{
					result = this.FirstPassData[index - 1];
				}
			}
			return result;
		}

		// Token: 0x0600BA25 RID: 47653 RVA: 0x0025EAB4 File Offset: 0x0025CCB4
		private int GetIndex()
		{
			for (int i = 0; i < this.FirstPassData.Count; i++)
			{
				bool flag = this.FirstPassData[i].Id == this.CurData.Id;
				if (flag)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600BA26 RID: 47654 RVA: 0x0025EB0C File Offset: 0x0025CD0C
		public bool MainArrowRedDot(ArrowDirection direction)
		{
			bool flag = this.CurData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int index = this.GetIndex();
				if (direction != ArrowDirection.Left)
				{
					if (direction == ArrowDirection.Right)
					{
						for (int i = index + 1; i < this.FirstPassData.Count; i++)
						{
							bool flag2 = this.FirstPassData[i].IsCanPrise | this.FirstPassData[i].IsHadReward;
							if (flag2)
							{
								return true;
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < index; j++)
					{
						bool flag3 = this.FirstPassData[j].IsCanPrise | this.FirstPassData[j].IsHadReward;
						if (flag3)
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600BA27 RID: 47655 RVA: 0x0025EBE8 File Offset: 0x0025CDE8
		public bool InfoArrowRedDot(ArrowDirection direction)
		{
			bool flag = this.CurData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int index = this.GetIndex();
				if (direction != ArrowDirection.Left)
				{
					if (direction == ArrowDirection.Right)
					{
						for (int i = index + 1; i < this.FirstPassData.Count; i++)
						{
							bool isCanPrise = this.FirstPassData[i].IsCanPrise;
							if (isCanPrise)
							{
								return true;
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < index; j++)
					{
						bool isCanPrise2 = this.FirstPassData[j].IsCanPrise;
						if (isCanPrise2)
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600BA28 RID: 47656 RVA: 0x0025EC9C File Offset: 0x0025CE9C
		public void ReqFirstPassInfo()
		{
			RpcC2G_FirstPassInfoReq rpc = new RpcC2G_FirstPassInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600BA29 RID: 47657 RVA: 0x0025ECBC File Offset: 0x0025CEBC
		public void ReqFirstPassReward(int firstPassId)
		{
			RpcC2G_GetFirstPassReward rpcC2G_GetFirstPassReward = new RpcC2G_GetFirstPassReward();
			rpcC2G_GetFirstPassReward.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetFirstPassReward);
		}

		// Token: 0x0600BA2A RID: 47658 RVA: 0x0025ECEC File Offset: 0x0025CEEC
		public void ReqCommendFirstPass(int firstPassId)
		{
			RpcC2G_CommendFirstPass rpcC2G_CommendFirstPass = new RpcC2G_CommendFirstPass();
			rpcC2G_CommendFirstPass.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_CommendFirstPass);
		}

		// Token: 0x0600BA2B RID: 47659 RVA: 0x0025ED1C File Offset: 0x0025CF1C
		public void ReqFirstPassTopRoleInfo(int firstPassId)
		{
			RpcC2G_FirstPassGetTopRoleInfo rpcC2G_FirstPassGetTopRoleInfo = new RpcC2G_FirstPassGetTopRoleInfo();
			rpcC2G_FirstPassGetTopRoleInfo.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_FirstPassGetTopRoleInfo);
		}

		// Token: 0x0600BA2C RID: 47660 RVA: 0x0025ED4C File Offset: 0x0025CF4C
		public void ReqRankList(int firstPassId)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.FirstPassRank);
			rpcC2M_ClientQueryRankListNtf.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x0600BA2D RID: 47661 RVA: 0x0025ED8C File Offset: 0x0025CF8C
		public void RefreshOutRedDot(bool priseReward, bool passReward)
		{
			this.IsHadOutRedDot = true;
		}

		// Token: 0x0600BA2E RID: 47662 RVA: 0x0025ED98 File Offset: 0x0025CF98
		public void OnGetFirstPassInfo(FirstPassInfoReqRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				for (int i = 0; i < oRes.stageInfos.Count; i++)
				{
					this.RefreshFirstPassData(oRes.stageInfos[i]);
				}
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshUI();
				}
			}
		}

		// Token: 0x0600BA2F RID: 47663 RVA: 0x0025EE24 File Offset: 0x0025D024
		public void OnGetFirstPassTopRoleInfo(FirstPassGetTopRoleInfoRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.SetTeamInfoListData(oRes.infos);
					this.CurData.PriseTotalNum = (uint)oRes.commendNum;
					this.CurData.SetPassTime((uint)oRes.time);
					bool flag3 = this.CurData.FirstPassRow.NestType > 0U;
					if (flag3)
					{
						this.CurData.SetStar(oRes.starLevel);
					}
				}
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					bool flag5 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag5)
					{
						this.View.TeamInfoHandler.FillAvata();
					}
				}
			}
		}

		// Token: 0x0600BA30 RID: 47664 RVA: 0x0025EF20 File Offset: 0x0025D120
		public void OnGetFirstPassReward(GetFirstPassRewardRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.IsGetedReward = true;
				}
				this.SetOutRedDotStatue();
				bool flag3 = this.View != null && this.View.IsVisible();
				if (flag3)
				{
					this.View.RefreshUI();
				}
			}
		}

		// Token: 0x0600BA31 RID: 47665 RVA: 0x0025EF9C File Offset: 0x0025D19C
		public void OnGetCommendFirstPass(CommendFirstPassRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.IsGivedPrise = true;
				}
				bool flag3 = this.CurData != null;
				if (flag3)
				{
					this.CurData.PriseTotalNum = (uint)oRes.commendNum;
				}
				this.SetOutRedDotStatue();
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					bool flag5 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag5)
					{
						this.View.TeamInfoHandler.RefreshUI();
					}
				}
			}
		}

		// Token: 0x0600BA32 RID: 47666 RVA: 0x0025F068 File Offset: 0x0025D268
		public void OnGetRankList(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this.m_rankList = new FirstPassRankList(oRes, true);
				bool flag2 = DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.FillContent();
				}
			}
		}

		// Token: 0x0600BA33 RID: 47667 RVA: 0x0025F0C4 File Offset: 0x0025D2C4
		private void SetOutRedDotStatue()
		{
			bool flag = false;
			for (int i = 0; i < this.FirstPassData.Count; i++)
			{
				flag |= this.FirstPassData[i].IsCanPrise;
				flag |= this.FirstPassData[i].IsHadReward;
			}
			this.IsHadOutRedDot = flag;
		}

		// Token: 0x0600BA34 RID: 47668 RVA: 0x0025F120 File Offset: 0x0025D320
		private void RefreshFirstPassData(FirstPassStageInfo2Client info)
		{
			bool flag = info == null;
			if (!flag)
			{
				for (int i = 0; i < this.FirstPassData.Count; i++)
				{
					bool flag2 = this.FirstPassData[i].Id == info.firstPassID;
					if (flag2)
					{
						this.FirstPassData[i].CurRank = info.myRank;
						this.FirstPassData[i].IsGivedPrise = info.hasCommended;
						this.FirstPassData[i].IsGetedReward = info.isGetReward;
						this.FirstPassData[i].PassTeamCount = info.totalRank;
						break;
					}
				}
			}
		}

		// Token: 0x04004A6E RID: 19054
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FirstPassDocument");

		// Token: 0x04004A6F RID: 19055
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004A70 RID: 19056
		public static FirstPassTable sFirstPassTable = new FirstPassTable();

		// Token: 0x04004A71 RID: 19057
		public static FirstPassReward sFirstPassReward = new FirstPassReward();

		// Token: 0x04004A72 RID: 19058
		public static readonly int MaxAvata = 6;

		// Token: 0x04004A74 RID: 19060
		private List<FirstPassAuxData> m_FirstPassData = null;

		// Token: 0x04004A75 RID: 19061
		private bool m_isHadOutRedDot = false;

		// Token: 0x04004A77 RID: 19063
		private FirstPassRankList m_rankList = null;
	}
}
