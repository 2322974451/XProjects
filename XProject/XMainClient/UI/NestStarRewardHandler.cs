using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class NestStarRewardHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/NestStarReward";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			this.m_ItemPool1.ReturnAll(false);
			this.m_ItemPool2.ReturnAll(false);
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			this.m_ItemPool1.ReturnAll(false);
			this.m_ItemPool2.ReturnAll(false);
			base.OnUnload();
		}

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

		public bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIButton m_Close;

		private GameObject m_itemParentGo;

		private XUIPool m_ItemPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XNestDocument m_doc;
	}
}
