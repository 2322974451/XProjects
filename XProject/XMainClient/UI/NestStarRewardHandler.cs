using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200170D RID: 5901
	internal class NestStarRewardHandler : DlgHandlerBase
	{
		// Token: 0x17003795 RID: 14229
		// (get) Token: 0x0600F3A1 RID: 62369 RVA: 0x003664C8 File Offset: 0x003646C8
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/NestStarReward";
			}
		}

		// Token: 0x0600F3A2 RID: 62370 RVA: 0x003664E0 File Offset: 0x003646E0
		protected override void Init()
		{
			base.Init();
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_itemParentGo = base.transform.FindChild("Panel/List").gameObject;
			Transform transform = this.m_itemParentGo.transform.FindChild("Tpl");
			this.m_ItemPool1.SetupPool(this.m_itemParentGo, transform.gameObject, 5U, false);
			this.m_ItemPool2.SetupPool(transform.gameObject, this.m_itemParentGo.transform.FindChild("Item").gameObject, 4U, false);
			this.m_doc = XDocuments.GetSpecificDocument<XNestDocument>(XNestDocument.uuID);
		}

		// Token: 0x0600F3A3 RID: 62371 RVA: 0x003665A3 File Offset: 0x003647A3
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600F3A4 RID: 62372 RVA: 0x003665C5 File Offset: 0x003647C5
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600F3A5 RID: 62373 RVA: 0x003665D6 File Offset: 0x003647D6
		protected override void OnHide()
		{
			this.m_ItemPool1.ReturnAll(false);
			this.m_ItemPool2.ReturnAll(false);
			base.OnHide();
		}

		// Token: 0x0600F3A6 RID: 62374 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F3A7 RID: 62375 RVA: 0x003665FA File Offset: 0x003647FA
		public override void OnUnload()
		{
			this.m_ItemPool1.ReturnAll(false);
			this.m_ItemPool2.ReturnAll(false);
			base.OnUnload();
		}

		// Token: 0x0600F3A8 RID: 62376 RVA: 0x00366620 File Offset: 0x00364820
		private void FillContent()
		{
			this.m_ItemPool1.ReturnAll(false);
			this.m_ItemPool2.ReturnAll(false);
			List<NestStarReward.RowData> nestStarRewards = this.m_doc.GetNestStarRewards(this.m_doc.NestType);
			for (int i = 0; i < nestStarRewards.Count; i++)
			{
				NestStarReward.RowData rowData = nestStarRewards[i];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = this.m_ItemPool1.FetchGameObject(false);
					gameObject.transform.parent = this.m_itemParentGo.transform;
					gameObject.name = i.ToString();
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_ItemPool1.TplHeight * i), 0f);
					IXUILabel ixuilabel = gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(rowData.Tittle);
					ixuilabel = (gameObject.transform.FindChild("ch").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(XStringDefineProxy.GetString("FirstPassPlayerTittle"));
					ixuilabel.gameObject.SetActive(rowData.IsHadTittle == 1U);
					ixuilabel = (gameObject.transform.FindChild("Image/Rank").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(rowData.Stars.ToString());
					this.FillItem(rowData, gameObject);
				}
			}
		}

		// Token: 0x0600F3A9 RID: 62377 RVA: 0x003667B8 File Offset: 0x003649B8
		private void FillItem(NestStarReward.RowData data, GameObject parentGo)
		{
			for (int i = 0; i < data.Reward.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool2.FetchGameObject(false);
				gameObject.transform.parent = parentGo.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(-170 + this.m_ItemPool2.TplWidth * i), -16f, 0f);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)data.Reward[i, 0];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)data.Reward[i, 0], (int)data.Reward[i, 1], false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600F3AA RID: 62378 RVA: 0x003668C0 File Offset: 0x00364AC0
		public bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04006897 RID: 26775
		private IXUIButton m_Close;

		// Token: 0x04006898 RID: 26776
		private GameObject m_itemParentGo;

		// Token: 0x04006899 RID: 26777
		private XUIPool m_ItemPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400689A RID: 26778
		private XUIPool m_ItemPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400689B RID: 26779
		private XNestDocument m_doc;
	}
}
