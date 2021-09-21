using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A75 RID: 2677
	internal class XGuildHallDocument : XDocComponent, ILogSource
	{
		// Token: 0x17002F79 RID: 12153
		// (get) Token: 0x0600A2CA RID: 41674 RVA: 0x001BC63C File Offset: 0x001BA83C
		public override uint ID
		{
			get
			{
				return XGuildHallDocument.uuID;
			}
		}

		// Token: 0x17002F7A RID: 12154
		// (get) Token: 0x0600A2CB RID: 41675 RVA: 0x001BC653 File Offset: 0x001BA853
		// (set) Token: 0x0600A2CC RID: 41676 RVA: 0x001BC65B File Offset: 0x001BA85B
		public XGuildHallView GuildHallView { get; set; }

		// Token: 0x0600A2CD RID: 41677 RVA: 0x001BC664 File Offset: 0x001BA864
		public List<ILogData> GetLogList()
		{
			return this.m_LogList;
		}

		// Token: 0x17002F7B RID: 12155
		// (get) Token: 0x0600A2CE RID: 41678 RVA: 0x001BC67C File Offset: 0x001BA87C
		private XGuildDocument GuildDoc
		{
			get
			{
				bool flag = this._GuildDoc == null;
				if (flag)
				{
					this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				}
				return this._GuildDoc;
			}
		}

		// Token: 0x0600A2D0 RID: 41680 RVA: 0x001BC6C8 File Offset: 0x001BA8C8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnPositionChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

		// Token: 0x0600A2D1 RID: 41681 RVA: 0x001BC71C File Offset: 0x001BA91C
		protected bool OnPositionChanged(XEventArgs args)
		{
			XGuildPositionChangedEventArgs xguildPositionChangedEventArgs = args as XGuildPositionChangedEventArgs;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.RefreshButtonsState();
			}
			return true;
		}

		// Token: 0x0600A2D2 RID: 41682 RVA: 0x001BC760 File Offset: 0x001BA960
		protected bool OnLevelChanged(XEventArgs args)
		{
			XGuildLevelChangedEventArgs xguildLevelChangedEventArgs = args as XGuildLevelChangedEventArgs;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.ReqGuildBrief();
			}
			return true;
		}

		// Token: 0x0600A2D3 RID: 41683 RVA: 0x001BC7A0 File Offset: 0x001BA9A0
		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
			if (flag)
			{
				bool flag2 = this.GuildHallView != null && this.GuildHallView.IsVisible();
				if (flag2)
				{
					this.GuildHallView.SetVisibleWithAnimation(false, null);
				}
			}
			return true;
		}

		// Token: 0x0600A2D4 RID: 41684 RVA: 0x001BC7F4 File Offset: 0x001BA9F4
		public void ReqExitGuild()
		{
			RpcC2M_LeaveFromGuild rpcC2M_LeaveFromGuild = new RpcC2M_LeaveFromGuild();
			rpcC2M_LeaveFromGuild.oArg.roleID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromGuild);
		}

		// Token: 0x0600A2D5 RID: 41685 RVA: 0x001BC834 File Offset: 0x001BAA34
		public void OnExitGuild(LeaveGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x0600A2D6 RID: 41686 RVA: 0x001BC868 File Offset: 0x001BAA68
		public void ReqGuildBrief()
		{
			RpcC2M_AskGuildBriefInfo rpc = new RpcC2M_AskGuildBriefInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A2D7 RID: 41687 RVA: 0x001BC888 File Offset: 0x001BAA88
		public void OnGuildBrief(GuildBriefRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				XGuildBasicData basicData = this.GuildDoc.BasicData;
				basicData.Init(oRes);
				bool flag2 = this.GuildHallView != null && this.GuildHallView.IsVisible();
				if (flag2)
				{
					this.GuildHallView.Refresh();
				}
				XGuildGrowthDocument specificDocument = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
				specificDocument.SetPoint(this.GuildDoc.BasicData.resource, this.GuildDoc.BasicData.technology);
			}
		}

		// Token: 0x0600A2D8 RID: 41688 RVA: 0x001BC928 File Offset: 0x001BAB28
		public void ReqLogList()
		{
			RpcC2M_FetchGuildHistoryNew rpc = new RpcC2M_FetchGuildHistoryNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A2D9 RID: 41689 RVA: 0x001BC948 File Offset: 0x001BAB48
		public void OnGetLogList(GuildHistoryRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				for (int i = 0; i < this.m_LogList.Count; i++)
				{
					(this.m_LogList[i] as XDataBase).Recycle();
				}
				this.m_LogList.Clear();
				for (int j = 0; j < oRes.records.Count; j++)
				{
					GHisRecord ghisRecord = oRes.records[j];
					XGuildLogBase xguildLogBase = XGuildLogBase.CreateLog(ghisRecord.type);
					xguildLogBase.SetData(ghisRecord);
					this.m_LogList.Add(xguildLogBase);
				}
				bool flag2 = this.GuildHallView != null && this.GuildHallView.IsVisible();
				if (flag2)
				{
					bool flag3 = this.GuildHallView.LogView != null && this.GuildHallView.LogView.active;
					if (flag3)
					{
						this.GuildHallView.LogView.Refresh();
					}
				}
			}
		}

		// Token: 0x0600A2DA RID: 41690 RVA: 0x001BCA68 File Offset: 0x001BAC68
		public void ReqEditAnnounce(string s)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.annoucement = s;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		// Token: 0x0600A2DB RID: 41691 RVA: 0x001BCA98 File Offset: 0x001BAC98
		public void OnEditAnnounceSuccess(string s)
		{
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.EditAnnounceView.SetVisible(false);
			}
		}

		// Token: 0x0600A2DC RID: 41692 RVA: 0x001BCAD4 File Offset: 0x001BACD4
		public void OnAnnounceChanged(string s)
		{
			this.GuildDoc.BasicData.announcement = s;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.RefreshAnnouncement();
			}
		}

		// Token: 0x0600A2DD RID: 41693 RVA: 0x001BCB1C File Offset: 0x001BAD1C
		public void ReqEditPortrait(int index)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.Icon = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		// Token: 0x0600A2DE RID: 41694 RVA: 0x001BCB4C File Offset: 0x001BAD4C
		public void OnPortraitChanged(int index)
		{
			this.GuildDoc.BasicData.portraitIndex = index;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.RefreshPortrait();
			}
		}

		// Token: 0x0600A2DF RID: 41695 RVA: 0x001BCB94 File Offset: 0x001BAD94
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.ReqGuildBrief();
			}
		}

		// Token: 0x04003AD4 RID: 15060
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildHallDocument");

		// Token: 0x04003AD6 RID: 15062
		private List<ILogData> m_LogList = new List<ILogData>();

		// Token: 0x04003AD7 RID: 15063
		private XGuildDocument _GuildDoc;
	}
}
