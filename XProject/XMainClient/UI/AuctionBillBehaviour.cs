using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class AuctionBillBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_billTitleTxt = (base.transform.FindChild("Detail/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ItemTpl = base.transform.FindChild("Detail/ItemTpl").gameObject;
			this.m_iconSprite = (base.transform.FindChild("Detail/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_RecentPrice = (base.transform.FindChild("Detail/SellSuccess/RecentPrice").GetComponent("XUILabel") as IXUILabel);
			this.m_TotalPrice = (base.transform.FindChild("Detail/SellSuccess/Grid/Total/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ProcedurePrice = (base.transform.FindChild("Detail/SellSuccess/Grid/Procedure/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_SinglePriceOperate = new AuctionNumberOperate(base.transform.FindChild("Detail/SellSuccess/Grid/Price").gameObject, new Vector3(-98f, 96f, 0f));
			this.m_CountOperate = new AuctionNumberOperate(base.transform.FindChild("Detail/SellSuccess/Grid/Free").gameObject, new Vector3(-98f, 36f, 0f));
			this.m_LeftButton = (base.transform.FindChild("Detail/LeftButton").GetComponent("XUIButton") as IXUIButton);
			this.m_RightButton = (base.transform.FindChild("Detail/RightButton").GetComponent("XUIButton") as IXUIButton);
			this.m_maskSprite = (base.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_RecommondTxt = (base.transform.FindChild("Detail/SellSuccess/Recommond").GetComponent("XUILabel") as IXUILabel);
			this.m_rightButtonLabel = (base.transform.FindChild("Detail/RightButton/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_leftButtonLabel = (base.transform.FindChild("Detail/LeftButton/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CloseButton = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_sellOper = (base.transform.FindChild("Detail/SellSuccess/Grid").GetComponent("XUITable") as IXUITable);
			this.m_leftPosition = this.m_LeftButton.gameObject.transform.localPosition;
			this.m_rightPosition = this.m_RightButton.gameObject.transform.localPosition;
			this.m_middlePosition = new Vector3(0f, this.m_leftPosition.y, 0f);
		}

		public void SetButtonPosition(string[] seq)
		{
			int num = 0;
			bool flag = !string.IsNullOrEmpty(seq[0]);
			if (flag)
			{
				this.m_RightButton.SetVisible(true);
				this.m_rightButtonLabel.SetText(seq[0]);
				num++;
			}
			else
			{
				this.m_RightButton.SetVisible(false);
			}
			bool flag2 = !string.IsNullOrEmpty(seq[1]);
			if (flag2)
			{
				this.m_LeftButton.SetVisible(true);
				this.m_leftButtonLabel.SetText(seq[1]);
				num++;
			}
			else
			{
				this.m_LeftButton.SetVisible(false);
			}
			bool flag3 = num == 1;
			if (flag3)
			{
				this.m_RightButton.gameObject.transform.localPosition = this.m_middlePosition;
			}
			else
			{
				bool flag4 = num == 2;
				if (flag4)
				{
					this.m_LeftButton.gameObject.transform.localPosition = this.m_leftPosition;
					this.m_RightButton.gameObject.transform.localPosition = this.m_rightPosition;
				}
			}
		}

		public IXUISprite m_maskSprite;

		public IXUILabel m_billTitleTxt;

		public GameObject m_ItemTpl;

		public IXUISprite m_iconSprite;

		public IXUILabel m_RecentPrice;

		public IXUILabel m_TotalPrice;

		public IXUILabel m_ProcedurePrice;

		public IXUILabel m_RecommondTxt;

		public IXUITable m_sellOper;

		public AuctionNumberOperate m_SinglePriceOperate;

		public AuctionNumberOperate m_CountOperate;

		public IXUIButton m_LeftButton;

		public IXUIButton m_RightButton;

		public IXUIButton m_CloseButton;

		private IXUILabel m_rightButtonLabel;

		private IXUILabel m_leftButtonLabel;

		private Vector3 m_leftPosition = new Vector3(-137f, -162f, 0f);

		private Vector3 m_rightPosition = new Vector3(137f, -162f, 0f);

		private Vector3 m_middlePosition = new Vector3(0f, -162f, 0f);
	}
}
