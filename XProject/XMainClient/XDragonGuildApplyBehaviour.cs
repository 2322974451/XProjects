using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XDragonGuildApplyBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/ApplyMenu/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnApply = (base.transform.FindChild("Bg/ApplyMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnEnterGuild = (base.transform.FindChild("Bg/ResultMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Annoucement = (base.transform.FindChild("Bg/ApplyMenu/Annoucement").GetComponent("XUILabel") as IXUILabel);
			this.m_Annoucement.SetText("");
			this.m_PPT = (base.transform.FindChild("Bg/ApplyMenu/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedApprove = (base.transform.FindChild("Bg/ApplyMenu/NeedApprove").GetComponent("XUILabel") as IXUILabel);
			this.m_ResultNote = (base.transform.FindChild("Bg/ResultMenu/Note").GetComponent("XUILabel") as IXUILabel);
			this.m_ApplyMenu = base.transform.FindChild("Bg/ApplyMenu").gameObject;
			this.m_ResultMenu = base.transform.FindChild("Bg/ResultMenu").gameObject;
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnApply = null;

		public IXUIButton m_BtnEnterGuild;

		public IXUILabel m_Annoucement;

		public IXUILabel m_PPT;

		public IXUILabel m_NeedApprove;

		public IXUILabel m_ResultNote;

		public GameObject m_ApplyMenu;

		public GameObject m_ResultMenu;
	}
}
