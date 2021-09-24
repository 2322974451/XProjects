using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XSpriteShowBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_AvatarRoot = base.transform.Find("Bg/AvatarRoot");
			this.m_FxPoint = base.transform.Find("Bg/Fx");
			this.m_Quality = (base.transform.Find("Bg/Quality").GetComponent("XUISprite") as IXUISprite);
			this.m_QualityTween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		public IXUISprite m_Close;

		public Transform m_AvatarRoot;

		public Transform m_FxPoint;

		public IXUISprite m_Quality;

		public IXUITweenTool m_QualityTween;
	}
}
