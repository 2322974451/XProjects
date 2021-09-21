using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000933 RID: 2355
	internal class XGuildMineEntranceDocument : XDocComponent
	{
		// Token: 0x17002BE5 RID: 11237
		// (get) Token: 0x06008E3C RID: 36412 RVA: 0x0013A6D8 File Offset: 0x001388D8
		public override uint ID
		{
			get
			{
				return XGuildMineEntranceDocument.uuID;
			}
		}

		// Token: 0x17002BE6 RID: 11238
		// (get) Token: 0x06008E3D RID: 36413 RVA: 0x0013A6F0 File Offset: 0x001388F0
		// (set) Token: 0x06008E3E RID: 36414 RVA: 0x0013A708 File Offset: 0x00138908
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

		// Token: 0x06008E3F RID: 36415 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008E40 RID: 36416 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x06008E41 RID: 36417 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008E42 RID: 36418 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x06008E43 RID: 36419 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008E44 RID: 36420 RVA: 0x0013A720 File Offset: 0x00138920
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

		// Token: 0x06008E45 RID: 36421 RVA: 0x0013A79E File Offset: 0x0013899E
		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildMineEnd, true);
		}

		// Token: 0x06008E46 RID: 36422 RVA: 0x0013A7BC File Offset: 0x001389BC
		public void ReqEnterMine()
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			RpcC2M_QueryResWar rpcC2M_QueryResWar = new RpcC2M_QueryResWar();
			XGuildResContentionBuffDocument.Doc.SendPersonalBuffOpReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, 0U, PersonalBuffOpType.PullMySelfOwned);
			XGuildResContentionBuffDocument.Doc.SendPersonalBuffOpReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, 0U, PersonalBuffOpType.PullMySelfActing);
			rpcC2M_QueryResWar.oArg.param = QueryResWarEnum.RESWAR_BATTLE;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_QueryResWar);
		}

		// Token: 0x04002E5A RID: 11866
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineEntranceDocument");

		// Token: 0x04002E5B RID: 11867
		private GuildMineEntranceView _view = null;

		// Token: 0x04002E5C RID: 11868
		public bool MainInterfaceState = false;

		// Token: 0x04002E5D RID: 11869
		public bool MainInterfaceStateEnd = false;
	}
}
