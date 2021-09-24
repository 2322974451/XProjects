using System;
using UILib;

namespace XMainClient.UI
{

	internal class XGuildApproveSettingView : DlgHandlerBase
	{

		protected override void Init()
		{
			this.m_PPTInput = (base.PanelObject.transform.FindChild("SettingMenu/PPTInput").GetComponent("XUIInput") as IXUIInput);
			this.m_AutoApprove = (base.PanelObject.transform.FindChild("SettingMenu/AutoApprove").GetComponent("XUICheckBox") as IXUICheckBox);
			this._doc = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("SettingMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			GuildApproveSetting approveSetting = this._doc.ApproveSetting;
			this.m_PPTInput.SetText(approveSetting.GetStrPPT());
			this.m_AutoApprove.bChecked = approveSetting.autoApprove;
		}

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

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIInput m_PPTInput;

		private IXUICheckBox m_AutoApprove;

		private XGuildApproveDocument _doc;
	}
}
