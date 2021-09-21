using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BD RID: 6077
	internal class EnchantAttrPreviewHandler : DlgHandlerBase
	{
		// Token: 0x0600FBA1 RID: 64417 RVA: 0x003A75A8 File Offset: 0x003A57A8
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_AttrName = (base.PanelObject.transform.Find("Detail/AttrName").GetComponent("XUILabel") as IXUILabel);
			this.m_AttrValue = (base.PanelObject.transform.Find("Detail/AttrValue").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600FBA2 RID: 64418 RVA: 0x003A764B File Offset: 0x003A584B
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
		}

		// Token: 0x0600FBA3 RID: 64419 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FBA4 RID: 64420 RVA: 0x003A7670 File Offset: 0x003A5870
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = this.m_Data == null;
			if (!flag)
			{
				XPrefixAttributes enchantAttrs = this._doc.GetEnchantAttrs(this.m_Data.EnchantID);
				bool flag2 = enchantAttrs == null;
				if (!flag2)
				{
					XSingleton<XCommon>.singleton.shareSB.Length = 0;
					for (int i = 0; i < enchantAttrs.AttributeList.Count; i++)
					{
						XSingleton<XCommon>.singleton.shareSB.Append(XAttributeCommon.GetAttrStr((int)enchantAttrs.AttributeList[i].attrid));
						XSingleton<XCommon>.singleton.shareSB.Append('\n');
					}
					this.m_AttrName.SetText(XSingleton<XCommon>.singleton.shareSB.ToString());
					XSingleton<XCommon>.singleton.shareSB.Length = 0;
					for (int j = 0; j < enchantAttrs.AttributeList.Count; j++)
					{
						XSingleton<XCommon>.singleton.shareSB.Append(XAttributeCommon.GetAttrValueStr(enchantAttrs.AttributeList[j].attrid, (uint)enchantAttrs.AttributeList[j].minValue, true));
						XSingleton<XCommon>.singleton.shareSB.Append('~');
						XSingleton<XCommon>.singleton.shareSB.Append(XAttributeCommon.GetAttrValueStr(enchantAttrs.AttributeList[j].attrid, (uint)enchantAttrs.AttributeList[j].maxValue, false));
						XSingleton<XCommon>.singleton.shareSB.Append('\n');
					}
					this.m_AttrValue.SetText(XSingleton<XCommon>.singleton.shareSB.ToString());
				}
			}
		}

		// Token: 0x0600FBA5 RID: 64421 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600FBA6 RID: 64422 RVA: 0x003A782C File Offset: 0x003A5A2C
		public void Show(int itemid)
		{
			this.m_Data = this._doc.GetEnchantEquipData(itemid);
			bool flag = this.m_Data == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find enchant item config: " + itemid, null, null, null, null, null);
			}
			else
			{
				base.SetVisible(true);
			}
		}

		// Token: 0x04006E74 RID: 28276
		private XEnchantDocument _doc = null;

		// Token: 0x04006E75 RID: 28277
		private IXUISprite m_Close;

		// Token: 0x04006E76 RID: 28278
		private IXUILabel m_AttrName;

		// Token: 0x04006E77 RID: 28279
		private IXUILabel m_AttrValue;

		// Token: 0x04006E78 RID: 28280
		private EnchantEquip.RowData m_Data;
	}
}
