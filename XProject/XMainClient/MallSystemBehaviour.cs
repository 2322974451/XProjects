using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class MallSystemBehaviour : DlgBehaviourBase
	{

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

		public static readonly int MAX_MONEY_NUM = 3;

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUILabel m_ShopName;

		public List<IXUILabel> m_MoneyBoard = new List<IXUILabel>();

		public List<XNumberTween> m_MoneyTween = new List<XNumberTween>();

		public List<IXUILabel> m_MoneyNum = new List<IXUILabel>();

		public List<IXUISprite> m_MoneyIcon = new List<IXUISprite>();

		public List<IXUISprite> m_MoneyBack = new List<IXUISprite>();

		public List<int> m_MoneyType = new List<int>();
	}
}
