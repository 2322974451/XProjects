using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PPTCheckMgr : XSingleton<PPTCheckMgr>
	{

		public bool CheckMyPPT(int needPPT)
		{
			XMainInterfaceDocument xmainInterfaceDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XMainInterfaceDocument.uuID) as XMainInterfaceDocument;
			int playerPPT = xmainInterfaceDocument.GetPlayerPPT();
			return playerPPT >= needPPT;
		}

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

		private ButtonClickEventHandler mGoStillHandler;
	}
}
