using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8C RID: 3212
	internal class AbyssPartyEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B570 RID: 46448 RVA: 0x0023CA94 File Offset: 0x0023AC94
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

		// Token: 0x040046ED RID: 18157
		public IXUIButton m_Close;

		// Token: 0x040046EE RID: 18158
		public IXUIButton m_Help;

		// Token: 0x040046EF RID: 18159
		public IXUIButton m_Join;

		// Token: 0x040046F0 RID: 18160
		public IXUIButton m_Fall;

		// Token: 0x040046F1 RID: 18161
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040046F2 RID: 18162
		public IXUILabel m_Name;

		// Token: 0x040046F3 RID: 18163
		public IXUILabel m_CurPPT;

		// Token: 0x040046F4 RID: 18164
		public IXUILabel m_SugPPT;

		// Token: 0x040046F5 RID: 18165
		public IXUILabel m_SugLevel;

		// Token: 0x040046F6 RID: 18166
		public Transform m_CostItem;

		// Token: 0x040046F7 RID: 18167
		public XUIPool m_AbyssPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
