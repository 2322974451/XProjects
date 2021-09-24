using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AbyssPartyEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/EnterBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Fall = (base.transform.FindChild("Bg/FallBtn").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/Tab/TabTpl");
			this.m_TabPool.SetupPool(null, transform.gameObject, 3U, false);
			this.m_Name = (base.transform.FindChild("Bg/DetailFrame/NestName").GetComponent("XUILabel") as IXUILabel);
			this.m_CurPPT = (base.transform.FindChild("Bg/DetailFrame/CurPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SugPPT = (base.transform.FindChild("Bg/DetailFrame/SugPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SugLevel = (base.transform.FindChild("Bg/DetailFrame/SugLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_CostItem = base.transform.Find("Bg/Cost");
			Transform transform2 = base.transform.Find("Bg/LevelFrame");
			Transform transform3 = transform2.Find("AbyssTpl");
			this.m_AbyssPool.SetupPool(null, transform3.gameObject, AbyssPartyEntranceView.ABYSS_MAX, false);
			this.m_AbyssPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)AbyssPartyEntranceView.ABYSS_MAX))
			{
				GameObject gameObject = this.m_AbyssPool.FetchGameObject(false);
				Transform transform4 = transform2.Find(string.Format("Abyss{0}", num));
				XSingleton<UiUtility>.singleton.AddChild(transform4.gameObject, gameObject);
				gameObject.name = "item";
				num++;
			}
			this.m_AbyssPool.ActualReturnAll(true);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_Join;

		public IXUIButton m_Fall;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_Name;

		public IXUILabel m_CurPPT;

		public IXUILabel m_SugPPT;

		public IXUILabel m_SugLevel;

		public Transform m_CostItem;

		public XUIPool m_AbyssPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
