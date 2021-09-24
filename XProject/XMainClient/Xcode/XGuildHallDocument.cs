using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildHallDocument : XDocComponent, ILogSource
	{

		public override uint ID
		{
			get
			{
				return XGuildHallDocument.uuID;
			}
		}

		public XGuildHallView GuildHallView { get; set; }

		public List<ILogData> GetLogList()
		{
			return this.m_LogList;
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnPositionChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

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

		public void ReqExitGuild()
		{
			RpcC2M_LeaveFromGuild rpcC2M_LeaveFromGuild = new RpcC2M_LeaveFromGuild();
			rpcC2M_LeaveFromGuild.oArg.roleID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromGuild);
		}

		public void OnExitGuild(LeaveGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		public void ReqGuildBrief()
		{
			RpcC2M_AskGuildBriefInfo rpc = new RpcC2M_AskGuildBriefInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqLogList()
		{
			RpcC2M_FetchGuildHistoryNew rpc = new RpcC2M_FetchGuildHistoryNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqEditAnnounce(string s)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.annoucement = s;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		public void OnEditAnnounceSuccess(string s)
		{
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.EditAnnounceView.SetVisible(false);
			}
		}

		public void OnAnnounceChanged(string s)
		{
			this.GuildDoc.BasicData.announcement = s;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.RefreshAnnouncement();
			}
		}

		public void ReqEditPortrait(int index)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.Icon = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		public void OnPortraitChanged(int index)
		{
			this.GuildDoc.BasicData.portraitIndex = index;
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.GuildHallView.RefreshPortrait();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildHallView != null && this.GuildHallView.IsVisible();
			if (flag)
			{
				this.ReqGuildBrief();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildHallDocument");

		private List<ILogData> m_LogList = new List<ILogData>();

		private XGuildDocument _GuildDoc;
	}
}
