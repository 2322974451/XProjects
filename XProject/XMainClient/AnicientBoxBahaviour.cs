using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AnicientBoxBahaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.itemTpl = base.transform.Find("bg/ItemList/ItemTpl").gameObject;
			this.itemTpl.SetActive(false);
			this.m_title = (base.transform.Find("bg/title").GetComponent("XUILabel") as IXUILabel);
			this.m_point = (base.transform.Find("bg/tips").GetComponent("XUILabel") as IXUILabel);
			this.m_btnClaim = (base.transform.Find("bg/Bt").GetComponent("XUIButton") as IXUIButton);
			this.m_rwdpool.SetupPool(this.itemTpl.transform.parent.gameObject, this.itemTpl, 2U, false);
			this.m_black = (base.transform.Find("backclick").GetComponent("XUISprite") as IXUISprite);
			this.m_sprRed = (base.transform.Find("bg/Bt/redpoint").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUILabel m_title;

		public IXUILabel m_point;

		public GameObject itemTpl;

		public IXUIButton m_btnClaim;

		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_black;

		public IXUISprite m_sprRed;
	}
}
