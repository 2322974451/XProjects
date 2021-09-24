using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WeeknestBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_rankTra = base.transform.FindChild("Rank");
			this.m_closedBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Main/Tittles");
			this.m_tittleLab = (transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (transform.FindChild("Times").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Main/Btns");
			this.m_rankBtn = (transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_bgTexture = (base.transform.FindChild("Main/P").GetComponent("XUITexture") as IXUITexture);
			transform = base.transform.FindChild("Main/Items");
			this.m_itemsGo = transform.gameObject;
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, false);
			this.m_tipsLab = (transform.FindChild("t").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel m_tittleLab;

		public IXUILabel m_timesLab;

		public IXUILabel m_tipsLab;

		public IXUIButton m_rankBtn;

		public IXUIButton m_goBattleBtn;

		public IXUIButton m_closedBtn;

		public IXUITexture m_bgTexture;

		public GameObject m_itemsGo;

		public Transform m_rankTra;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
