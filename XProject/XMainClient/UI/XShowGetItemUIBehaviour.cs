using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XShowGetItemUIBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_itemTpl = base.transform.FindChild("Bg/TipTpl/ItemTpl").gameObject;
			this.m_ShowItemPool.SetupPool(this.m_itemTpl.transform.parent.gameObject, this.m_itemTpl, 4U, false);
			this.m_sprBgTip = (base.transform.FindChild("Bg/TipTpl").GetComponent("XUISprite") as IXUISprite);
			this.m_tweenBg = (base.transform.Find("Bg/TipTpl").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tweener = (base.transform.Find("Bg/TipTpl").GetComponent("XUITweener") as IXUITweener);
		}

		public XUIPool m_ShowItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_itemTpl;

		public IXUISprite m_sprBgTip;

		public IXUITweenTool m_tweenBg;

		public IXUITweener m_tweener;
	}
}
