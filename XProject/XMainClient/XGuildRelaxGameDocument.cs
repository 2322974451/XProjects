using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRelaxGameDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildRelaxGameDocument.uuID;
			}
		}

		public uint GuildVoiceQAState
		{
			get
			{
				return this._guildVoiceQAState;
			}
		}

		public float GuildVoiceQAWaitTime
		{
			get
			{
				return this._guildVoiceQAWaitTime;
			}
		}

		public bool RedPoint { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRelaxGameDocument.AsyncLoader.AddTask("Table/GuildRelaxGameList", XGuildRelaxGameDocument.GameList, false);
			XGuildRelaxGameDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.GuildStatusChanged));
		}

		public bool GuildStatusChanged(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		public void OpenGuildVoiceQuery()
		{
			RpcC2G_OpenGuildQAReq rpc = new RpcC2G_OpenGuildQAReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void GetGuildVoiceInfo()
		{
			RpcC2G_GetGuildQADataReq rpc = new RpcC2G_GetGuildQADataReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildRelaxGameDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildRelaxGameList GameList = new GuildRelaxGameList();

		private uint _guildVoiceQAState = 0U;

		private float _guildVoiceQAWaitTime = 0f;
	}
}
