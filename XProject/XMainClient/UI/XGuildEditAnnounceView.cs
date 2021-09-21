using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020018A4 RID: 6308
	internal class XGuildEditAnnounceView : DlgHandlerBase
	{
		// Token: 0x060106D3 RID: 67283 RVA: 0x00402E9C File Offset: 0x0040109C
		protected override void Init()
		{
			this.m_Input = (base.PanelObject.transform.FindChild("EditAnnounceMenu/Input").GetComponent("XUIInput") as IXUIInput);
			this._HallDoc = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		// Token: 0x060106D4 RID: 67284 RVA: 0x00402EF4 File Offset: 0x004010F4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("EditAnnounceMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			this.m_Input.RegisterChangeEventHandler(new InputChangeEventHandler(this._OnInputChangeHandler));
		}

		// Token: 0x060106D5 RID: 67285 RVA: 0x00402F91 File Offset: 0x00401191
		protected override void OnShow()
		{
			base.OnShow();
			this.m_Input.SetText(this._GuildDoc.BasicData.actualAnnoucement);
		}

		// Token: 0x060106D6 RID: 67286 RVA: 0x00402FB8 File Offset: 0x004011B8
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

		// Token: 0x060106D7 RID: 67287 RVA: 0x00403020 File Offset: 0x00401220
		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = this.m_Input.GetText();
			this._HallDoc.ReqEditAnnounce(text);
			return true;
		}

		// Token: 0x060106D8 RID: 67288 RVA: 0x0040304C File Offset: 0x0040124C
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007697 RID: 30359
		private IXUIInput m_Input;

		// Token: 0x04007698 RID: 30360
		private XGuildHallDocument _HallDoc;

		// Token: 0x04007699 RID: 30361
		private XGuildDocument _GuildDoc;

		// Token: 0x0400769A RID: 30362
		private string m_inputValue;
	}
}
