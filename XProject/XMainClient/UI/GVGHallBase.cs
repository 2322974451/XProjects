using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGHallBase : DlgHandlerBase
	{

		protected override void Init()
		{
			Transform transform = base.PanelObject.transform.FindChild("Reward/item");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_ItemReward = base.PanelObject.transform.FindChild("Reward");
			this._rankScrollView = (base.PanelObject.transform.FindChild("RankList/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._rankWrapContent = (base.PanelObject.transform.FindChild("RankList/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._selfTransform = base.PanelObject.transform.FindChild("MyRank/Detail");
			this._rankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemWrapUpdate));
			this.m_HelpText = (base.PanelObject.transform.FindChild("help/Intro/Text").GetComponent("XUILabel") as IXUILabel);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.SetupRankList();
		}

		private void SetupRankList()
		{
			this.selfIndex = -1;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.selfGuildID = specificDocument.BasicData.uid;
			this._rankWrapContent.SetContentCount(this.GetContentSize(), false);
			this._rankScrollView.ResetPosition();
			this.SetSelfGuildInfo(this.selfIndex);
		}

		protected virtual int GetContentSize()
		{
			return 0;
		}

		protected void SetSelfGuildInfo(int index)
		{
			this.OnItemWrapUpdate(this._selfTransform, index);
		}

		protected virtual void OnItemWrapUpdate(Transform t, int index)
		{
		}

		protected virtual void SetupRewardList(string[] values)
		{
			int num = values.Length;
			this.m_ItemPool.ReturnAll(false);
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_ItemReward;
				gameObject.transform.localPosition = new Vector3((float)(i * 80), 0f);
				int num2 = int.Parse(values[i]);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num2, 0, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)num2);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		private IXUIWrapContent _rankWrapContent;

		private IXUIScrollView _rankScrollView;

		private Transform _selfTransform;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_ItemReward;

		protected IXUILabel m_HelpText;

		protected ulong selfGuildID = 0UL;

		protected int selfIndex = -1;
	}
}
