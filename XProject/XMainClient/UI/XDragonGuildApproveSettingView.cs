using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020016D6 RID: 5846
	internal class XDragonGuildApproveSettingView : DlgHandlerBase
	{
		// Token: 0x0600F124 RID: 61732 RVA: 0x00352E50 File Offset: 0x00351050
		protected override void Init()
		{
			this.m_PPTInput = (base.PanelObject.transform.FindChild("SettingMenu/PPTInput").GetComponent("XUIInput") as IXUIInput);
			this.m_AutoApprove = (base.PanelObject.transform.FindChild("SettingMenu/AutoApprove").GetComponent("XUICheckBox") as IXUICheckBox);
			this._doc = XDocuments.GetSpecificDocument<XDragonGuildApproveDocument>(XDragonGuildApproveDocument.uuID);
		}

		// Token: 0x0600F125 RID: 61733 RVA: 0x00352EC4 File Offset: 0x003510C4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("SettingMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
		}

		// Token: 0x0600F126 RID: 61734 RVA: 0x00352F4C File Offset: 0x0035114C
		protected override void OnShow()
		{
			base.OnShow();
			DragonGuildApproveSetting approveSetting = this._doc.ApproveSetting;
			this.m_PPTInput.SetText(approveSetting.GetStrPPT());
			this.m_AutoApprove.bChecked = approveSetting.autoApprove;
		}

		// Token: 0x0600F127 RID: 61735 RVA: 0x00352F94 File Offset: 0x00351194
		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			DragonGuildApproveSetting dragonGuildApproveSetting = new DragonGuildApproveSetting();
			string text = this.m_PPTInput.GetText();
			bool flag = text.Length == 0;
			if (flag)
			{
				dragonGuildApproveSetting.PPT = 0U;
			}
			else
			{
				dragonGuildApproveSetting.PPT = uint.Parse(text);
			}
			dragonGuildApproveSetting.autoApprove = this.m_AutoApprove.bChecked;
			this._doc.ReqSetApprove(dragonGuildApproveSetting);
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F128 RID: 61736 RVA: 0x00353004 File Offset: 0x00351204
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x040066FA RID: 26362
		private IXUIInput m_PPTInput;

		// Token: 0x040066FB RID: 26363
		private IXUICheckBox m_AutoApprove;

		// Token: 0x040066FC RID: 26364
		private XDragonGuildApproveDocument _doc;
	}
}
