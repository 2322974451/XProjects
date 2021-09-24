using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamLeagueDetailBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("p/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamName = (base.transform.FindChild("p/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberList = (base.transform.FindChild("p/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.transform.FindChild("p/Grid/Tpl");
			this.m_MemberPool.SetupPool(this.m_MemberList.gameObject, transform.gameObject, 4U, false);
		}

		public IXUIButton m_Close;

		public IXUILabel m_TeamName;

		public IXUIList m_MemberList;

		public XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
