using System;
using UILib;

namespace XMainClient.UI
{

	internal class XGuildEditAnnounceView : DlgHandlerBase
	{

		protected override void Init()
		{
			this.m_Input = (base.PanelObject.transform.FindChild("EditAnnounceMenu/Input").GetComponent("XUIInput") as IXUIInput);
			this._HallDoc = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("EditAnnounceMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			this.m_Input.RegisterChangeEventHandler(new InputChangeEventHandler(this._OnInputChangeHandler));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_Input.SetText(this._GuildDoc.BasicData.actualAnnoucement);
		}

		private void _OnInputChangeHandler(IXUIInput input)
		{
			string text = input.GetText();
			bool flag = string.IsNullOrEmpty(text) || text.Equals(this.m_inputValue);
			if (!flag)
			{
				this.m_inputValue = input.GetText();
				this.m_inputValue = this.m_inputValue.Replace("\n", string.Empty);
				input.SetText(this.m_inputValue);
			}
		}

		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = this.m_Input.GetText();
			this._HallDoc.ReqEditAnnounce(text);
			return true;
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIInput m_Input;

		private XGuildHallDocument _HallDoc;

		private XGuildDocument _GuildDoc;

		private string m_inputValue;
	}
}
