using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020018A3 RID: 6307
	internal class XGuildApproveSettingView : DlgHandlerBase
	{
		// Token: 0x060106CD RID: 67277 RVA: 0x00402CCC File Offset: 0x00400ECC
		protected override void Init()
		{
			this.m_PPTInput = (base.PanelObject.transform.FindChild("SettingMenu/PPTInput").GetComponent("XUIInput") as IXUIInput);
			this.m_AutoApprove = (base.PanelObject.transform.FindChild("SettingMenu/AutoApprove").GetComponent("XUICheckBox") as IXUICheckBox);
			this._doc = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
		}

		// Token: 0x060106CE RID: 67278 RVA: 0x00402D40 File Offset: 0x00400F40
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("SettingMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
		}

		// Token: 0x060106CF RID: 67279 RVA: 0x00402DC8 File Offset: 0x00400FC8
		protected override void OnShow()
		{
			base.OnShow();
			GuildApproveSetting approveSetting = this._doc.ApproveSetting;
			this.m_PPTInput.SetText(approveSetting.GetStrPPT());
			this.m_AutoApprove.bChecked = approveSetting.autoApprove;
		}

		// Token: 0x060106D0 RID: 67280 RVA: 0x00402E10 File Offset: 0x00401010
		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			GuildApproveSetting guildApproveSetting = new GuildApproveSetting();
			string text = this.m_PPTInput.GetText();
			bool flag = text.Length == 0;
			if (flag)
			{
				guildApproveSetting.PPT = 0;
			}
			else
			{
				guildApproveSetting.PPT = int.Parse(text);
			}
			guildApproveSetting.autoApprove = this.m_AutoApprove.bChecked;
			this._doc.ReqSetApprove(guildApproveSetting);
			base.SetVisible(false);
			return true;
		}

		// Token: 0x060106D1 RID: 67281 RVA: 0x00402E80 File Offset: 0x00401080
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007694 RID: 30356
		private IXUIInput m_PPTInput;

		// Token: 0x04007695 RID: 30357
		private IXUICheckBox m_AutoApprove;

		// Token: 0x04007696 RID: 30358
		private XGuildApproveDocument _doc;
	}
}
