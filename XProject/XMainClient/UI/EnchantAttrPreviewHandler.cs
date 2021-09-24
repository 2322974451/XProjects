using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnchantAttrPreviewHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_AttrName = (base.PanelObject.transform.Find("Detail/AttrName").GetComponent("XUILabel") as IXUILabel);
			this.m_AttrValue = (base.PanelObject.transform.Find("Detail/AttrValue").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

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

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

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

		private XEnchantDocument _doc = null;

		private IXUISprite m_Close;

		private IXUILabel m_AttrName;

		private IXUILabel m_AttrValue;

		private EnchantEquip.RowData m_Data;
	}
}
