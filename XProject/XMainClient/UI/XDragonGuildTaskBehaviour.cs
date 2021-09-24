using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class XDragonGuildTaskBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Trooplevel = base.transform.Find("Bg/TroopLevel");
			this.m_progress = (this.m_Trooplevel.Find("ProgressBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_GuildLevel = (this.m_Trooplevel.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildExpCur = (this.m_Trooplevel.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildExpMax = (this.m_Trooplevel.Find("ValueMax").GetComponent("XUILabel") as IXUILabel);
			this.m_cdrewards = (base.transform.Find("Bg/CDRewards").GetComponent("XUILabel") as IXUILabel);
			this.m_task = (base.transform.Find("Bg/buttons/SelectTask").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_taskrep = base.transform.Find("Bg/buttons/SelectTask/redpoint");
			this.m_achieve = (base.transform.Find("Bg/buttons/SelectAchieve").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_acieverep = base.transform.Find("Bg/buttons/SelectAchieve/redpoint");
			this.m_Toptask = base.transform.Find("Bg/Task/Top/Brunch/Task");
			this.m_Topachieve = base.transform.Find("Bg/Task/Top/Brunch/Achieve");
			this.m_wrapcontent = (base.transform.Find("Bg/Task/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUIButton m_close;

		public Transform m_Trooplevel;

		public IXUILabel m_GuildLevel;

		public IXUIProgress m_progress;

		public IXUILabel m_GuildExpMax;

		public IXUILabel m_GuildExpCur;

		public IXUILabel m_cdrewards;

		public IXUICheckBox m_task;

		public IXUICheckBox m_achieve;

		public Transform m_Toptask;

		public Transform m_Topachieve;

		public IXUIWrapContent m_wrapcontent;

		public Transform m_taskrep;

		public Transform m_acieverep;
	}
}
