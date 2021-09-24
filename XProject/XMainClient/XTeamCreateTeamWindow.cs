using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XTeamCreateTeamWindow
	{

		public XTeamCreateTeamWindow(GameObject panelGo)
		{
			this.PanelObject = panelGo;
			this.m_Input = (this.PanelObject.transform.FindChild("CreateMenu/PwdInput").GetComponent("XUIInput") as IXUIInput);
			this.m_Title = (this.PanelObject.transform.FindChild("CreateMenu/Dungeon").GetComponent("XUILabel") as IXUILabel);
			this._doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.RegisterEvent();
		}

		public void RegisterEvent()
		{
			IXUIButton ixuibutton = this.PanelObject.transform.FindChild("CreateMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			IXUIButton ixuibutton2 = this.PanelObject.transform.FindChild("CreateMenu/Cancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClicked));
		}

		public void Show()
		{
			this.PanelObject.SetActive(true);
			this.m_Input.SetText("");
			this.m_Title.SetText(this._doc.currentDungeonName);
		}

		public void Hide()
		{
			this.PanelObject.SetActive(false);
		}

		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = this.m_Input.GetText();
			this._doc.password = text;
			this._doc.ReqTeamOp(TeamOperate.TEAM_CREATE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			this.Hide();
			return true;
		}

		private bool _OnCancelBtnClicked(IXUIButton btn)
		{
			this.Hide();
			return true;
		}

		private GameObject PanelObject;

		private XTeamDocument _doc;

		private IXUIInput m_Input;

		private IXUILabel m_Title;
	}
}
