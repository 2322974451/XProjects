using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000E65 RID: 3685
	internal class XTeamCreateTeamWindow
	{
		// Token: 0x0600C584 RID: 50564 RVA: 0x002B9E2C File Offset: 0x002B802C
		public XTeamCreateTeamWindow(GameObject panelGo)
		{
			this.PanelObject = panelGo;
			this.m_Input = (this.PanelObject.transform.FindChild("CreateMenu/PwdInput").GetComponent("XUIInput") as IXUIInput);
			this.m_Title = (this.PanelObject.transform.FindChild("CreateMenu/Dungeon").GetComponent("XUILabel") as IXUILabel);
			this._doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.RegisterEvent();
		}

		// Token: 0x0600C585 RID: 50565 RVA: 0x002B9EB4 File Offset: 0x002B80B4
		public void RegisterEvent()
		{
			IXUIButton ixuibutton = this.PanelObject.transform.FindChild("CreateMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			IXUIButton ixuibutton2 = this.PanelObject.transform.FindChild("CreateMenu/Cancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClicked));
		}

		// Token: 0x0600C586 RID: 50566 RVA: 0x002B9F32 File Offset: 0x002B8132
		public void Show()
		{
			this.PanelObject.SetActive(true);
			this.m_Input.SetText("");
			this.m_Title.SetText(this._doc.currentDungeonName);
		}

		// Token: 0x0600C587 RID: 50567 RVA: 0x002B9F6A File Offset: 0x002B816A
		public void Hide()
		{
			this.PanelObject.SetActive(false);
		}

		// Token: 0x0600C588 RID: 50568 RVA: 0x002B9F7C File Offset: 0x002B817C
		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = this.m_Input.GetText();
			this._doc.password = text;
			this._doc.ReqTeamOp(TeamOperate.TEAM_CREATE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			this.Hide();
			return true;
		}

		// Token: 0x0600C589 RID: 50569 RVA: 0x002B9FC0 File Offset: 0x002B81C0
		private bool _OnCancelBtnClicked(IXUIButton btn)
		{
			this.Hide();
			return true;
		}

		// Token: 0x0400567A RID: 22138
		private GameObject PanelObject;

		// Token: 0x0400567B RID: 22139
		private XTeamDocument _doc;

		// Token: 0x0400567C RID: 22140
		private IXUIInput m_Input;

		// Token: 0x0400567D RID: 22141
		private IXUILabel m_Title;
	}
}
