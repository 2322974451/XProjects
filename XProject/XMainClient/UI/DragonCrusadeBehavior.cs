using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class DragonCrusadeBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_closed = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_myRankSpr = (base.transform.FindChild("Bg/MyRank").GetComponent("XUISprite") as IXUISprite);
			this.m_leftBtn = (base.transform.FindChild("Bg/Left").GetComponent("XUIButton") as IXUIButton);
			this.m_rightBtn = (base.transform.FindChild("Bg/Right").GetComponent("XUIButton") as IXUIButton);
			this.slideSprite = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.mMyRank = base.transform.Find("Bg/MyRank/My").gameObject;
			this.goLoading = base.transform.Find("Loading").gameObject;
			this.goLoadingTxt = (base.transform.FindChild("Loading/Bg/Slogan").GetComponent("XUILabel") as IXUILabel);
			this.goLoading.SetActive(false);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Help;

		public IXUISprite slideSprite = null;

		public GameObject goLoading = null;

		public IXUILabel goLoadingTxt = null;

		public GameObject mMyRank = null;

		public IXUIButton m_closed = null;

		public IXUIButton m_leftBtn = null;

		public IXUIButton m_rightBtn = null;

		public IXUISprite m_myRankSpr = null;
	}
}
