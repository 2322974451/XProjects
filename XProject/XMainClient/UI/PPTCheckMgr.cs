using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001850 RID: 6224
	internal class PPTCheckMgr : XSingleton<PPTCheckMgr>
	{
		// Token: 0x060102E9 RID: 66281 RVA: 0x003E2FDC File Offset: 0x003E11DC
		public bool CheckMyPPT(int needPPT)
		{
			XMainInterfaceDocument xmainInterfaceDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XMainInterfaceDocument.uuID) as XMainInterfaceDocument;
			int playerPPT = xmainInterfaceDocument.GetPlayerPPT();
			return playerPPT >= needPPT;
		}

		// Token: 0x060102EA RID: 66282 RVA: 0x003E3018 File Offset: 0x003E1218
		public void ShowPPTNotEnoughDlg(ulong btnID, ButtonClickEventHandler goBattleHandle)
		{
			this.mGoStillHandler = goBattleHandle;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("LEVEL_POWERLOWER"), XStringDefineProxy.GetString("LEVEL_POWERUP"), XStringDefineProxy.GetString("LEVEL_CONTINUE"));
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_CancelButton.ID = btnID;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.GoPowerUp), new ButtonClickEventHandler(this.GoStill));
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
		}

		// Token: 0x060102EB RID: 66283 RVA: 0x003E30D0 File Offset: 0x003E12D0
		private bool GoStill(IXUIButton go)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag = this.mGoStillHandler != null;
			if (flag)
			{
				this.mGoStillHandler(go);
			}
			this.mGoStillHandler = null;
			return true;
		}

		// Token: 0x060102EC RID: 66284 RVA: 0x003E3114 File Offset: 0x003E1314
		private bool GoPowerUp(IXUIButton go)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Strong);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("StrengthNotOpen"), "fece00");
				result = true;
			}
			else
			{
				XSingleton<UIManager>.singleton.ClearUIinStack();
				XSingleton<XGameSysMgr>.singleton.OpenSystem(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Strong));
				result = true;
			}
			return result;
		}

		// Token: 0x040073E9 RID: 29673
		private ButtonClickEventHandler mGoStillHandler;
	}
}
