using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CDD RID: 3293
	internal class EquipTransformBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B88C RID: 47244 RVA: 0x00252D8C File Offset: 0x00250F8C
		private void Awake()
		{
			this.btnClose = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("SmeltingReplaceFrame");
			this.tweenTool = (transform.Find("Result").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.sprPerfect = (this.tweenTool.gameObject.transform.Find("wm").GetComponent("XUISprite") as IXUISprite);
			this.sprImperfect = (this.tweenTool.gameObject.transform.Find("fwm").GetComponent("XUISprite") as IXUISprite);
			this.sprPerfect.SetAlpha(0f);
			this.sprImperfect.SetAlpha(0f);
			this.SrcView = new EquipTransformItemView();
			this.SrcView.FindFrom(transform.Find("1"));
			this.DestView = new EquipTransformItemView();
			this.DestView.FindFrom(transform.Find("2"));
			this.btnTransform = (transform.Find("BtnReplace").GetComponent("XUIButton") as IXUIButton);
			this.lbDragonCoin = (this.btnTransform.gameObject.transform.Find("MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this.TipScrollView = (transform.Find("Tip/TipPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.TipLabel = (this.TipScrollView.gameObject.transform.Find("tips").GetComponent("XUILabel") as IXUILabel);
			this.EquipScrollView = (transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.EquipWrapContent = (this.EquipScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.goPanelHint = transform.Find("PanelHint").gameObject;
			this.btnPanelHintOk = (this.goPanelHint.transform.Find("BtnOK").GetComponent("XUIButton") as IXUIButton);
			this.lbPanelHintItem = (this.goPanelHint.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			this.goPanelHintItem = this.goPanelHint.transform.Find("ItemTpl").gameObject;
			this.goPanelHint.SetActive(false);
			transform = transform.Find("ItemNeeds");
			this.NeedItems = new NeedItemView[transform.childCount];
			for (int i = 0; i < this.NeedItems.Length; i++)
			{
				this.NeedItems[i] = new NeedItemView(false);
				this.NeedItems[i].FindFrom(transform.GetChild(i));
			}
		}

		// Token: 0x0400491A RID: 18714
		public IXUISprite sprPerfect;

		// Token: 0x0400491B RID: 18715
		public IXUISprite sprImperfect;

		// Token: 0x0400491C RID: 18716
		public IXUITweenTool tweenTool;

		// Token: 0x0400491D RID: 18717
		public IXUIButton btnClose;

		// Token: 0x0400491E RID: 18718
		public IXUIButton btnTransform;

		// Token: 0x0400491F RID: 18719
		public IXUIScrollView TipScrollView;

		// Token: 0x04004920 RID: 18720
		public IXUIScrollView EquipScrollView;

		// Token: 0x04004921 RID: 18721
		public IXUIWrapContent EquipWrapContent;

		// Token: 0x04004922 RID: 18722
		public IXUILabel TipLabel;

		// Token: 0x04004923 RID: 18723
		public IXUILabel lbDragonCoin;

		// Token: 0x04004924 RID: 18724
		public EquipTransformItemView SrcView;

		// Token: 0x04004925 RID: 18725
		public EquipTransformItemView DestView;

		// Token: 0x04004926 RID: 18726
		public NeedItemView[] NeedItems;

		// Token: 0x04004927 RID: 18727
		public GameObject goPanelHint;

		// Token: 0x04004928 RID: 18728
		public IXUIButton btnPanelHintOk;

		// Token: 0x04004929 RID: 18729
		public IXUILabel lbPanelHintItem;

		// Token: 0x0400492A RID: 18730
		public GameObject goPanelHintItem;

		// Token: 0x0400492B RID: 18731
		public XUIPool FriendTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
