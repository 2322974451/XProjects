using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ActivityWeekendPartyBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Rule = (base.transform.FindChild("Bg/Left/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrActName = (base.transform.FindChild("Bg/Left/CurrName").GetComponent("XUILabel") as IXUILabel);
			this.m_Times = (base.transform.FindChild("Bg/Right/Times").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeTip = (base.transform.FindChild("Bg/Right/Times/time").GetComponent("XUILabel") as IXUILabel);
			this.m_SingleMatch = (base.transform.FindChild("Bg/Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamMatch = (base.transform.FindChild("Bg/Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatchLabel = (this.m_SingleMatch.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Bg = (base.transform.FindChild("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_DropAward = (base.transform.FindChild("Bg/WeekReward/ListPanel/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = this.m_DropAward.gameObject.transform.FindChild("ItemTpl");
			this.m_DropAwardPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 4U, false);
		}

		public IXUILabel m_CurrActName;

		public IXUILabel m_Rule;

		public IXUILabel m_Times;

		public IXUIButton m_SingleMatch;

		public IXUIButton m_TeamMatch;

		public IXUIButton m_Close;

		public IXUILabel m_SingleMatchLabel;

		public IXUIButton m_Help;

		public IXUITexture m_Bg;

		public IXUILabel m_TimeTip;

		public IXUIList m_DropAward;

		public XUIPool m_DropAwardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
