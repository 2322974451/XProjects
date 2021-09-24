using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildTaskRefreshResultDlgBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.beforeSprite = (base.transform.Find("P2/TaskLevelBefore").GetComponent("XUISprite") as IXUISprite);
			this.afterSprite = (base.transform.Find("P2/TaskLevelAfter").GetComponent("XUISprite") as IXUISprite);
			this.blockBtn = (base.transform.Find("Block").GetComponent("XUIButton") as IXUIButton);
			this.resultLabel = (base.transform.Find("P2/ResultText").GetComponent("XUILabel") as IXUILabel);
			this.m_FxDepth = base.transform.Find("Fx/FxDepth");
			this.m_FxDepth2 = base.transform.Find("Fx/FxDepth2");
			this.TweenGroup = (base.transform.Find("P2").GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup);
		}

		public IXUISprite beforeSprite;

		public IXUISprite afterSprite;

		public IXUIButton blockBtn;

		public Transform m_FxDepth;

		public Transform m_FxDepth2;

		public IXUILabel resultLabel;

		public IXUIPlayTweenGroup TweenGroup;
	}
}
