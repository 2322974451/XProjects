using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class LoadingDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Dynamics/LoadingProgress");
			this.m_LoadingProgress = (transform.GetComponent("XUIProgress") as IXUIProgress);
			this.m_Dog = (transform.FindChild("Dog/").GetComponent("XUISprite") as IXUISprite);
			this.m_Canvas = base.transform.FindChild("fade_canvas");
			this.m_LoadingTips = (base.transform.FindChild("Bg/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_LoadingBg = base.transform.FindChild("Bg");
			this.m_LoadingPic = (base.transform.FindChild("Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_WaitForOthersTip = (base.transform.Find("Bg/WaitOthers").GetComponent("XUILabel") as IXUILabel);
			this.m_Canvas.gameObject.SetActive(false);
		}

		public IXUIProgress m_LoadingProgress = null;

		public Transform m_LoadingBg = null;

		public Transform m_Canvas = null;

		public IXUILabel m_LoadingTips = null;

		public IXUITexture m_LoadingPic = null;

		public IXUILabel m_WaitForOthersTip = null;

		public IXUISprite m_Dog = null;
	}
}
