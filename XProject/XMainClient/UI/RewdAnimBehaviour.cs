using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class RewdAnimBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/ItemTpl");
			this.m_btnok = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_tweenbg = (base.transform.Find("CriticalConfirm/P").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tweentitle = (base.transform.Find("CriticalConfirm/P/titleLabel").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_TitleLabel = (base.transform.Find("CriticalConfirm/P/titleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_objTmp = base.transform.Find("items/tmp").gameObject;
		}

		public GameObject m_objTmp;

		public IXUIButton m_btnok;

		public IXUITweenTool m_tweenbg;

		public IXUITweenTool m_tweentitle;

		public IXUILabel m_TitleLabel;
	}
}
