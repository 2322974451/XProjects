using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class ForgeReplaceHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_doc = XForgeDocument.Doc;
			this.m_cancleBtn = (base.PanelObject.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_sureBtn = (base.PanelObject.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Bg/AttrItem");
			this.m_beforeName = (transform.FindChild("BeforeName").GetComponent("XUILabel") as IXUILabel);
			this.m_beforeAttr = (transform.FindChild("BeforeValue").GetComponent("XUILabel") as IXUILabel);
			this.m_afterName = (transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_afterAttr = (transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_cancleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancleClicked));
			this.m_sureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSureClicked));
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
						this.m_beforeName.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, xequipItem.forgeAttrInfo.ForgeAttr[0].AttrValue);
						this.m_beforeAttr.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xequipItem.forgeAttrInfo.UnSavedAttrid));
						this.m_afterName.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, xequipItem.forgeAttrInfo.UnSavedAttrValue);
						this.m_afterAttr.SetText(text);
					}
				}
			}
		}

		private bool OnCancleClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqForgeEquip(ForgeOpType.Forge_Retain);
			return true;
		}

		private bool OnSureClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqForgeEquip(ForgeOpType.Forge_Replace);
			return true;
		}

		private XForgeDocument m_doc;

		private IXUIButton m_cancleBtn;

		private IXUIButton m_sureBtn;

		private IXUILabel m_beforeName;

		private IXUILabel m_beforeAttr;

		private IXUILabel m_afterName;

		private IXUILabel m_afterAttr;
	}
}
