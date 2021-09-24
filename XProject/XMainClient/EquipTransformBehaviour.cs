using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipTransformBehaviour : DlgBehaviourBase
	{

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

		public IXUISprite sprPerfect;

		public IXUISprite sprImperfect;

		public IXUITweenTool tweenTool;

		public IXUIButton btnClose;

		public IXUIButton btnTransform;

		public IXUIScrollView TipScrollView;

		public IXUIScrollView EquipScrollView;

		public IXUIWrapContent EquipWrapContent;

		public IXUILabel TipLabel;

		public IXUILabel lbDragonCoin;

		public EquipTransformItemView SrcView;

		public EquipTransformItemView DestView;

		public NeedItemView[] NeedItems;

		public GameObject goPanelHint;

		public IXUIButton btnPanelHintOk;

		public IXUILabel lbPanelHintItem;

		public GameObject goPanelHintItem;

		public XUIPool FriendTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
