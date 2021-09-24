using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CompeteNestBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_rankTra = base.transform.FindChild("Rank");
			this.m_closedBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Main/Tittles");
			this.m_tittleLab = (transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (base.transform.FindChild("Main/Right/Times").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Main");
			this.m_bgTexture = (transform.FindChild("P").GetComponent("XUITexture") as IXUITexture);
			this.m_rankBtn = (transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_claimBtn = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_claimredpoint = transform.FindChild("Right/BtnStartSingle/RedPoint");
			transform = base.transform.FindChild("Main/ListPanel");
			this.m_itemsGo = transform.gameObject;
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Grid/ItemTpl").gameObject, 2U, false);
			this.m_tipsLab = (base.transform.FindChild("Main/t").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUITexture m_bgTexture;

		public IXUILabel m_tittleLab;

		public IXUILabel m_timesLab;

		public IXUILabel m_tipsLab;

		public IXUIButton m_rankBtn;

		public IXUIButton m_goBattleBtn;

		public IXUIButton m_closedBtn;

		public IXUIButton m_claimBtn;

		public Transform m_claimredpoint;

		public GameObject m_itemsGo;

		public Transform m_rankTra;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
