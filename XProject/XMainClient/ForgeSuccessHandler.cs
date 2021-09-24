using System;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class ForgeSuccessHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_doc = XForgeDocument.Doc;
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_gotoBtn = (base.PanelObject.transform.FindChild("Bg/GotoBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_checkBoxSpr = (base.PanelObject.transform.FindChild("Bg/Toggle").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.PanelObject.transform.FindChild("Bg/AttrItem");
			this.m_attrNameLab = (transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_attrValueLab = (transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this.m_gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoClicked));
			this.m_checkBoxSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickToggle));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void FillContent()
		{
			GameObject gameObject = this.m_checkBoxSpr.transform.FindChild("selected").gameObject;
			bool isShowTips = this.m_doc.IsShowTips;
			if (isShowTips)
			{
				gameObject.SetActive(false);
				this.m_checkBoxSpr.ID = 0UL;
			}
			else
			{
				gameObject.SetActive(true);
				this.m_checkBoxSpr.ID = 1UL;
			}
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				XEquipItem xequipItem = itemByUID as XEquipItem;
				bool flag2 = xequipItem.forgeAttrInfo.ForgeAttr.Count == 0;
				if (!flag2)
				{
					EquipSlotAttrDatas attrData = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)itemByUID.itemID);
					bool flag3 = attrData == null;
					if (!flag3)
					{
						string color = attrData.GetColor(1, xequipItem.forgeAttrInfo.ForgeAttr[0]);
						string text = string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xequipItem.forgeAttrInfo.ForgeAttr[0].AttrID));
						this.m_attrNameLab.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, xequipItem.forgeAttrInfo.ForgeAttr[0].AttrValue);
						this.m_attrValueLab.SetText(text);
					}
				}
			}
		}

		private void OnCloseClicked(IXUISprite spr)
		{
			base.SetVisible(false);
		}

		private bool OnGotoClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			XSmeltDocument.Doc.SelectEquip(this.m_doc.CurUid);
			return true;
		}

		private void OnClickToggle(IXUISprite spr)
		{
			GameObject gameObject = spr.transform.FindChild("selected").gameObject;
			bool flag = spr.ID == 0UL;
			if (flag)
			{
				spr.ID = 1UL;
				gameObject.SetActive(true);
				this.m_doc.IsShowTips = false;
			}
			else
			{
				spr.ID = 0UL;
				gameObject.SetActive(false);
				this.m_doc.IsShowTips = true;
			}
		}

		private XForgeDocument m_doc;

		private IXUISprite m_closeBtn;

		private IXUIButton m_gotoBtn;

		private IXUILabel m_attrNameLab;

		private IXUILabel m_attrValueLab;

		private IXUISprite m_checkBoxSpr;
	}
}
