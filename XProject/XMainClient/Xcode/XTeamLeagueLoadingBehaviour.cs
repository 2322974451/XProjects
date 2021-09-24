using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamLeagueLoadingBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Left");
			Transform transform2 = base.transform.FindChild("Bg/Right");
			this.m_TeamName[0] = (transform.FindChild("Team/Teamneme").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamName[1] = (transform2.FindChild("Team/Teamneme").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamRegion[0] = (transform.FindChild("Team/Region").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamRegion[1] = (transform2.FindChild("Team/Region").GetComponent("XUILabel") as IXUILabel);
			Transform transform3 = transform.FindChild("DetailTpl");
			this.m_MembersPool[0] = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MembersPool[0].SetupPool(transform3.parent.gameObject, transform3.gameObject, 4U, false);
			Transform transform4 = transform2.FindChild("DetailTpl");
			this.m_MembersPool[1] = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MembersPool[1].SetupPool(transform4.parent.gameObject, transform4.gameObject, 4U, false);
			for (int i = 0; i < 4; i++)
			{
				Transform item = transform.FindChild(string.Format("Detail{0}", i));
				this.m_LeftMemberNode.Add(item);
				Transform item2 = transform2.FindChild(string.Format("Detail{0}", i));
				this.m_RightMemberNode.Add(item2);
			}
		}

		public IXUILabel[] m_TeamName = new IXUILabel[2];

		public IXUILabel[] m_TeamRegion = new IXUILabel[2];

		public XUIPool[] m_MembersPool = new XUIPool[2];

		public List<Transform> m_LeftMemberNode = new List<Transform>();

		public List<Transform> m_RightMemberNode = new List<Transform>();
	}
}
