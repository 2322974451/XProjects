using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class FitstpassRankBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_needHideTittleGo = base.transform.FindChild("Top/T4").gameObject;
			this.m_tittleLab = (base.transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel);
			this.m_tittleLab.SetText(string.Empty);
			this.m_closeBtn = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		public IXUIButton m_closeBtn;

		public IXUIWrapContent m_wrapContent;

		public IXUILabel m_tittleLab;

		public GameObject m_needHideTittleGo;

		public GameObject m_tipsGo;
	}
}
