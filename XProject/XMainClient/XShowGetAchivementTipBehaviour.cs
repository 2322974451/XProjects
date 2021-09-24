using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XShowGetAchivementTipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_AchivementName = (base.transform.FindChild("Bg/Label1").GetComponent("XUILabel") as IXUILabel);
			this.m_AchivementText = (base.transform.FindChild("Bg/Label2").GetComponent("XUILabel") as IXUILabel);
			this.m_Bg = base.transform.FindChild("Bg").gameObject;
			this.m_AchivementName2 = (base.transform.FindChild("Bg1/Label1").GetComponent("XUILabel") as IXUILabel);
			this.m_AchivementText2 = (base.transform.FindChild("Bg1/Label2").GetComponent("XUILabel") as IXUILabel);
			this.m_Bg2 = base.transform.FindChild("Bg1").gameObject;
			this.m_Bg2.SetActive(false);
		}

		public GameObject m_Bg;

		public IXUILabel m_AchivementName;

		public IXUILabel m_AchivementText;

		public GameObject m_Bg2;

		public IXUILabel m_AchivementName2;

		public IXUILabel m_AchivementText2;
	}
}
