using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001717 RID: 5911
	internal class AuctionBillBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F420 RID: 62496 RVA: 0x0036AC30 File Offset: 0x00368E30
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

		// Token: 0x0600F421 RID: 62497 RVA: 0x0036AEF8 File Offset: 0x003690F8
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

		// Token: 0x040068FC RID: 26876
		public IXUISprite m_maskSprite;

		// Token: 0x040068FD RID: 26877
		public IXUILabel m_billTitleTxt;

		// Token: 0x040068FE RID: 26878
		public GameObject m_ItemTpl;

		// Token: 0x040068FF RID: 26879
		public IXUISprite m_iconSprite;

		// Token: 0x04006900 RID: 26880
		public IXUILabel m_RecentPrice;

		// Token: 0x04006901 RID: 26881
		public IXUILabel m_TotalPrice;

		// Token: 0x04006902 RID: 26882
		public IXUILabel m_ProcedurePrice;

		// Token: 0x04006903 RID: 26883
		public IXUILabel m_RecommondTxt;

		// Token: 0x04006904 RID: 26884
		public IXUITable m_sellOper;

		// Token: 0x04006905 RID: 26885
		public AuctionNumberOperate m_SinglePriceOperate;

		// Token: 0x04006906 RID: 26886
		public AuctionNumberOperate m_CountOperate;

		// Token: 0x04006907 RID: 26887
		public IXUIButton m_LeftButton;

		// Token: 0x04006908 RID: 26888
		public IXUIButton m_RightButton;

		// Token: 0x04006909 RID: 26889
		public IXUIButton m_CloseButton;

		// Token: 0x0400690A RID: 26890
		private IXUILabel m_rightButtonLabel;

		// Token: 0x0400690B RID: 26891
		private IXUILabel m_leftButtonLabel;

		// Token: 0x0400690C RID: 26892
		private Vector3 m_leftPosition = new Vector3(-137f, -162f, 0f);

		// Token: 0x0400690D RID: 26893
		private Vector3 m_rightPosition = new Vector3(137f, -162f, 0f);

		// Token: 0x0400690E RID: 26894
		private Vector3 m_middlePosition = new Vector3(0f, -162f, 0f);
	}
}
