using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PandoraBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_DisplayFrame = base.transform.Find("Bg/DisplayFrame");
			this.m_RewardFrame = base.transform.Find("Bg/RewardFrame");
			this.m_FxPoint = base.transform.Find("Bg/FxPoint");
			this.m_OnceButton = (this.m_DisplayFrame.Find("Once").GetComponent("XUIButton") as IXUIButton);
			this.m_TenButton = (this.m_DisplayFrame.Find("Ten").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 3; i++)
			{
				this.m_DisplayLabel[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Label", i)).GetComponent("XUILabel") as IXUILabel);
				this.m_DisplayPoint[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Bg/Point", i)).GetComponent("XUISprite") as IXUISprite);
				this.m_DisplayAvatar[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Bg/avatar", i)).GetComponent("UIDummy") as IUIDummy);
			}
			this.m_BackButton = (this.m_DisplayFrame.Find("Back").GetComponent("XUISprite") as IXUISprite);
			this.m_ItemListButton = (this.m_DisplayFrame.Find("ItemList").GetComponent("XUIButton") as IXUIButton);
			this.m_OKButton = (this.m_RewardFrame.Find("OK").GetComponent("XUIButton") as IXUIButton);
			Transform transform = this.m_RewardFrame.Find("ResultTpl");
			this.m_ResultPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		public Transform m_DisplayFrame;

		public Transform m_RewardFrame;

		public Transform m_FxPoint;

		public IXUIButton m_OnceButton;

		public IXUIButton m_TenButton;

		public IXUILabel[] m_DisplayLabel = new IXUILabel[3];

		public IXUISprite[] m_DisplayPoint = new IXUISprite[3];

		public IUIDummy[] m_DisplayAvatar = new IUIDummy[3];

		public IXUISprite m_BackButton;

		public IXUIButton m_ItemListButton;

		public IXUIButton m_OKButton;

		public XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
