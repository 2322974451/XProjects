using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class WeekEndNestBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_tex = (transform.FindChild("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_reddotGo = transform.FindChild("Right/BtnStartSingle/RedPoint").gameObject;
			this.m_getBtn = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_gotoTeamBtn = (transform.FindChild("Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_getSpr = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUISprite") as IXUISprite);
			this.m_tittleLab = (transform.FindChild("Left/CurrName").GetComponent("XUILabel") as IXUILabel);
			this.m_rulesLab = (transform.FindChild("Left/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (transform.FindChild("Right/Times").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = transform.FindChild("WeekReward/ItemTpl");
			this.m_parentTra = transform.FindChild("WeekReward/ListPanel");
			this.m_itemPool.SetupPool(transform.FindChild("WeekReward").gameObject, transform2.gameObject, 3U, true);
		}

		public IXUILabel m_timesLab;

		public IXUILabel m_tittleLab;

		public IXUILabel m_rulesLab;

		public IXUISprite m_getSpr;

		public IXUIButton m_closedBtn;

		public IXUIButton m_helpBtn;

		public IXUIButton m_getBtn;

		public IXUIButton m_gotoTeamBtn;

		public GameObject m_reddotGo;

		public Transform m_parentTra;

		public IXUITexture m_tex;

		public XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
