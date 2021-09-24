using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildMineEntranceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildMineEntranceDocument.uuID;
			}
		}

		public GuildMineEntranceView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			bool flag = !state && state != this.MainInterfaceState && DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			}
			this.MainInterfaceState = state;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bImmUpdateUI = XGuildDocument.GuildConfig.IsSysUnlock(XSysDefine.XSys_GuildMine, specificDocument.Level);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildMine, bImmUpdateUI);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildMineMainInterface, true);
		}

		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildMineEnd, true);
		}

		public void ReqEnterMine()
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			RpcC2M_QueryResWar rpcC2M_QueryResWar = new RpcC2M_QueryResWar();
			XGuildResContentionBuffDocument.Doc.SendPersonalBuffOpReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, 0U, PersonalBuffOpType.PullMySelfOwned);
			XGuildResContentionBuffDocument.Doc.SendPersonalBuffOpReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, 0U, PersonalBuffOpType.PullMySelfActing);
			rpcC2M_QueryResWar.oArg.param = QueryResWarEnum.RESWAR_BATTLE;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_QueryResWar);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineEntranceDocument");

		private GuildMineEntranceView _view = null;

		public bool MainInterfaceState = false;

		public bool MainInterfaceStateEnd = false;
	}
}
