using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class HeroBattleMVPBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Name = (base.transform.Find("Bg/Board/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill = (base.transform.Find("Bg/Board/Kill").GetComponent("XUILabel") as IXUILabel);
			this.m_Death = (base.transform.Find("Bg/Board/Death").GetComponent("XUILabel") as IXUILabel);
			this.m_Assit = (base.transform.Find("Bg/Board/Help").GetComponent("XUILabel") as IXUILabel);
			this.m_ShareBtn = (base.transform.Find("Bg/ShareBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.LogoWC = base.transform.Find("Bg/LogoWC").gameObject;
			this.LogoQQ = base.transform.Find("Bg/LogoQQ").gameObject;
			this.LogoDN = base.transform.Find("Bg/p").gameObject;
			this.LogoTX = base.transform.Find("Bg/gg").gameObject;
			this.m_HeroName = (base.transform.Find("Bg/Board/HeroName").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroDesc = (base.transform.Find("Bg/Board/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroSay = (base.transform.Find("Bg/Board/Say").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel m_Name;

		public IXUILabel m_Kill;

		public IXUILabel m_Death;

		public IXUILabel m_Assit;

		public IXUIButton m_ShareBtn;

		public IXUISprite m_Close;

		public GameObject LogoWC;

		public GameObject LogoQQ;

		public GameObject LogoDN;

		public GameObject LogoTX;

		public IXUILabel m_HeroName;

		public IXUILabel m_HeroDesc;

		public IXUILabel m_HeroSay;
	}
}
