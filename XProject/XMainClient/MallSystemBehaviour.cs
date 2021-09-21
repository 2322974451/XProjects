using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E4B RID: 3659
	internal class MallSystemBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C457 RID: 50263 RVA: 0x002AD888 File Offset: 0x002ABA88
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopName = (base.transform.FindChild("Bg/ShopName").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < MallSystemBehaviour.MAX_MONEY_NUM; i++)
			{
				this.m_MoneyType.Add(0);
				IXUISprite item = base.transform.FindChild("Bg/NormalShopFrame/MoneyBoard/Money" + (i + 1).ToString() + "/board").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = base.transform.FindChild("Bg/NormalShopFrame/MoneyBoard/Money" + (i + 1).ToString()).GetComponent("XUILabel") as IXUILabel;
				IXUISprite item2 = base.transform.FindChild("Bg/NormalShopFrame/MoneyBoard/Money" + (i + 1).ToString() + "/icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel item3 = base.transform.FindChild("Bg/NormalShopFrame/MoneyBoard/Money" + (i + 1).ToString() + "/value").GetComponent("XUILabel") as IXUILabel;
				XNumberTween item4 = XNumberTween.Create(ixuilabel.gameObject.transform);
				this.m_MoneyNum.Add(item3);
				this.m_MoneyIcon.Add(item2);
				this.m_MoneyBoard.Add(ixuilabel);
				this.m_MoneyBack.Add(item);
				this.m_MoneyTween.Add(item4);
			}
		}

		// Token: 0x04005563 RID: 21859
		public static readonly int MAX_MONEY_NUM = 3;

		// Token: 0x04005564 RID: 21860
		public IXUIButton m_Close;

		// Token: 0x04005565 RID: 21861
		public IXUIButton m_Help;

		// Token: 0x04005566 RID: 21862
		public IXUILabel m_ShopName;

		// Token: 0x04005567 RID: 21863
		public List<IXUILabel> m_MoneyBoard = new List<IXUILabel>();

		// Token: 0x04005568 RID: 21864
		public List<XNumberTween> m_MoneyTween = new List<XNumberTween>();

		// Token: 0x04005569 RID: 21865
		public List<IXUILabel> m_MoneyNum = new List<IXUILabel>();

		// Token: 0x0400556A RID: 21866
		public List<IXUISprite> m_MoneyIcon = new List<IXUISprite>();

		// Token: 0x0400556B RID: 21867
		public List<IXUISprite> m_MoneyBack = new List<IXUISprite>();

		// Token: 0x0400556C RID: 21868
		public List<int> m_MoneyType = new List<int>();
	}
}
