using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A7 RID: 2471
	internal class XGuildRelaxGameDocument : XDocComponent
	{
		// Token: 0x17002D2D RID: 11565
		// (get) Token: 0x0600956A RID: 38250 RVA: 0x001656D8 File Offset: 0x001638D8
		public override uint ID
		{
			get
			{
				return XGuildRelaxGameDocument.uuID;
			}
		}

		// Token: 0x17002D2E RID: 11566
		// (get) Token: 0x0600956B RID: 38251 RVA: 0x001656F0 File Offset: 0x001638F0
		public uint GuildVoiceQAState
		{
			get
			{
				return this._guildVoiceQAState;
			}
		}

		// Token: 0x17002D2F RID: 11567
		// (get) Token: 0x0600956C RID: 38252 RVA: 0x00165708 File Offset: 0x00163908
		public float GuildVoiceQAWaitTime
		{
			get
			{
				return this._guildVoiceQAWaitTime;
			}
		}

		// Token: 0x17002D30 RID: 11568
		// (get) Token: 0x0600956D RID: 38253 RVA: 0x00165720 File Offset: 0x00163920
		// (set) Token: 0x0600956E RID: 38254 RVA: 0x00165728 File Offset: 0x00163928
		public bool RedPoint { get; set; }

		// Token: 0x0600956F RID: 38255 RVA: 0x00165731 File Offset: 0x00163931
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRelaxGameDocument.AsyncLoader.AddTask("Table/GuildRelaxGameList", XGuildRelaxGameDocument.GameList, false);
			XGuildRelaxGameDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009570 RID: 38256 RVA: 0x00165756 File Offset: 0x00163956
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.GuildStatusChanged));
		}

		// Token: 0x06009571 RID: 38257 RVA: 0x00165778 File Offset: 0x00163978
		public bool GuildStatusChanged(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		// Token: 0x06009572 RID: 38258 RVA: 0x00165794 File Offset: 0x00163994
		public void OpenGuildVoiceQuery()
		{
			RpcC2G_OpenGuildQAReq rpc = new RpcC2G_OpenGuildQAReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009573 RID: 38259 RVA: 0x001657B4 File Offset: 0x001639B4
		public void GetGuildVoiceInfo()
		{
			RpcC2G_GetGuildQADataReq rpc = new RpcC2G_GetGuildQADataReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009574 RID: 38260 RVA: 0x001657D4 File Offset: 0x001639D4
		public void JoinGuildVoiceInfo()
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			bool isVoiceQAIng = specificDocument.IsVoiceQAIng;
			if (isVoiceQAIng)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(true, true);
			}
			else
			{
				specificDocument.VoiceQAJoinChoose(true, 3U);
			}
		}

		// Token: 0x06009575 RID: 38261 RVA: 0x00165810 File Offset: 0x00163A10
		public void SetGuildVoiceInfo(uint state, float time)
		{
			this._guildVoiceQAState = state;
			XSingleton<XDebug>.singleton.AddLog(string.Format("Get guild voice open state = {0} by server", state), null, null, null, null, null, XDebugColor.XDebug_None);
			this._guildVoiceQAWaitTime = time;
			bool flag = DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.Refresh(XSysDefine.XSys_GuildRelax_VoiceQA);
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.RefreshRedPoint(XSysDefine.XSys_GuildRelax_VoiceQA);
			}
		}

		// Token: 0x06009576 RID: 38262 RVA: 0x00165880 File Offset: 0x00163A80
		public void RefreshRedPoint()
		{
			XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.RedPoint = false;
			bool flag = !specificDocument2.bInGuild;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildRelax_Joker, true);
			}
			else
			{
				this.RedPoint = (specificDocument.GameCount > 0);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildRelax_Joker, true);
				bool flag2 = !DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.IsVisible();
				if (!flag2)
				{
					DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.RefreshRedPoint(XSysDefine.XSys_GuildRelax_VoiceQA);
				}
			}
		}

		// Token: 0x06009577 RID: 38263 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400329F RID: 12959
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildRelaxGameDocument");

		// Token: 0x040032A0 RID: 12960
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040032A1 RID: 12961
		public static GuildRelaxGameList GameList = new GuildRelaxGameList();

		// Token: 0x040032A2 RID: 12962
		private uint _guildVoiceQAState = 0U;

		// Token: 0x040032A3 RID: 12963
		private float _guildVoiceQAWaitTime = 0f;
	}
}
