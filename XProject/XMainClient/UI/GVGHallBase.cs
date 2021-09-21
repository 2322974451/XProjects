using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F2 RID: 5874
	internal class GVGHallBase : DlgHandlerBase
	{
		// Token: 0x0600F25F RID: 62047 RVA: 0x0035C264 File Offset: 0x0035A464
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

		// Token: 0x0600F260 RID: 62048 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F261 RID: 62049 RVA: 0x0035C374 File Offset: 0x0035A574
		public override void RefreshData()
		{
			base.RefreshData();
			this.SetupRankList();
		}

		// Token: 0x0600F262 RID: 62050 RVA: 0x0035C388 File Offset: 0x0035A588
		private void SetupRankList()
		{
			this.selfIndex = -1;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.selfGuildID = specificDocument.BasicData.uid;
			this._rankWrapContent.SetContentCount(this.GetContentSize(), false);
			this._rankScrollView.ResetPosition();
			this.SetSelfGuildInfo(this.selfIndex);
		}

		// Token: 0x0600F263 RID: 62051 RVA: 0x0035C3E8 File Offset: 0x0035A5E8
		protected virtual int GetContentSize()
		{
			return 0;
		}

		// Token: 0x0600F264 RID: 62052 RVA: 0x0035C3FB File Offset: 0x0035A5FB
		protected void SetSelfGuildInfo(int index)
		{
			this.OnItemWrapUpdate(this._selfTransform, index);
		}

		// Token: 0x0600F265 RID: 62053 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnItemWrapUpdate(Transform t, int index)
		{
		}

		// Token: 0x0600F266 RID: 62054 RVA: 0x0035C40C File Offset: 0x0035A60C
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

		// Token: 0x040067DF RID: 26591
		private IXUIWrapContent _rankWrapContent;

		// Token: 0x040067E0 RID: 26592
		private IXUIScrollView _rankScrollView;

		// Token: 0x040067E1 RID: 26593
		private Transform _selfTransform;

		// Token: 0x040067E2 RID: 26594
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040067E3 RID: 26595
		private Transform m_ItemReward;

		// Token: 0x040067E4 RID: 26596
		protected IXUILabel m_HelpText;

		// Token: 0x040067E5 RID: 26597
		protected ulong selfGuildID = 0UL;

		// Token: 0x040067E6 RID: 26598
		protected int selfIndex = -1;
	}
}
