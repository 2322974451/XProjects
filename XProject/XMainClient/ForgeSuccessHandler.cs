using System;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000BEB RID: 3051
	internal class ForgeSuccessHandler : DlgHandlerBase
	{
		// Token: 0x0600ADD2 RID: 44498 RVA: 0x00207134 File Offset: 0x00205334
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

		// Token: 0x0600ADD3 RID: 44499 RVA: 0x00207228 File Offset: 0x00205428
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this.m_gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoClicked));
			this.m_checkBoxSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickToggle));
		}

		// Token: 0x0600ADD4 RID: 44500 RVA: 0x00207285 File Offset: 0x00205485
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600ADD5 RID: 44501 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600ADD6 RID: 44502 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600ADD7 RID: 44503 RVA: 0x00207298 File Offset: 0x00205498
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

		// Token: 0x0600ADD8 RID: 44504 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClicked(IXUISprite spr)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600ADD9 RID: 44505 RVA: 0x002073F8 File Offset: 0x002055F8
		private bool OnGotoClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			XSmeltDocument.Doc.SelectEquip(this.m_doc.CurUid);
			return true;
		}

		// Token: 0x0600ADDA RID: 44506 RVA: 0x0020742C File Offset: 0x0020562C
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

		// Token: 0x040041B3 RID: 16819
		private XForgeDocument m_doc;

		// Token: 0x040041B4 RID: 16820
		private IXUISprite m_closeBtn;

		// Token: 0x040041B5 RID: 16821
		private IXUIButton m_gotoBtn;

		// Token: 0x040041B6 RID: 16822
		private IXUILabel m_attrNameLab;

		// Token: 0x040041B7 RID: 16823
		private IXUILabel m_attrValueLab;

		// Token: 0x040041B8 RID: 16824
		private IXUISprite m_checkBoxSpr;
	}
}
