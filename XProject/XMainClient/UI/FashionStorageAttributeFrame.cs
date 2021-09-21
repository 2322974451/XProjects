using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017FE RID: 6142
	public class FashionStorageAttributeFrame : DlgHandlerBase
	{
		// Token: 0x0600FED0 RID: 65232 RVA: 0x003C00D4 File Offset: 0x003BE2D4
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_titleLabel = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_editPortrait = (base.transform.Find("EditPortrait").GetComponent("XUIButton") as IXUIButton);
			this.m_scrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrapContent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_redPoint = (base.transform.Find("EditPortrait/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_descLabel = (base.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_getAll = base.transform.Find("T22");
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
			this.m_editPortrait.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickEditPortrait));
			this.m_fightLabel = (base.transform.Find("T2").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600FED1 RID: 65233 RVA: 0x003C0244 File Offset: 0x003BE444
		private bool ClickEditPortrait(IXUIButton btn)
		{
			bool flag = btn.ID == 0UL || this.m_select == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool redPoint = this.m_select.RedPoint;
				if (redPoint)
				{
					this.m_doc.SendActivateFashion((uint)btn.ID);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FASHION_STORAGE_ACTIVATE_TIPS"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FED2 RID: 65234 RVA: 0x003C02B4 File Offset: 0x003BE4B4
		private void OnWrapContentUpdate(Transform t, int index)
		{
			bool flag = this.m_select == null;
			if (!flag)
			{
				bool flag2 = index < this.m_select.GetAttributeCharm().Count && index >= 0;
				if (flag2)
				{
					IXUILabel ixuilabel = t.GetComponent("XUILabel") as IXUILabel;
					AttributeCharm attributeCharm = this.m_select.GetAttributeCharm()[index];
					string @string = XStringDefineProxy.GetString((XAttributeDefine)attributeCharm.key);
					ixuilabel.SetText(XStringDefineProxy.GetString("FASHION_STORAGE_ATT", new object[]
					{
						attributeCharm.index,
						@string,
						attributeCharm.value
					}));
					ixuilabel.SetColor(attributeCharm.active ? this.m_normaColor : Color.gray);
				}
			}
		}

		// Token: 0x0600FED3 RID: 65235 RVA: 0x003C0380 File Offset: 0x003BE580
		private int GetPPT(List<AttributeCharm> charms)
		{
			double num = 0.0;
			int i = 0;
			int count = charms.Count;
			while (i < count)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(charms[i].key, charms[i].value, null, -1);
				i++;
			}
			return (int)num;
		}

		// Token: 0x0600FED4 RID: 65236 RVA: 0x003C03E0 File Offset: 0x003BE5E0
		internal void SetFashionCharm(IFashionStorageSelect select = null)
		{
			this.m_select = select;
			bool flag = select == null;
			if (flag)
			{
				this.m_wrapContent.SetContentCount(0, false);
				this.m_scrollView.ResetPosition();
				this.m_titleLabel.SetText("");
				this.m_editPortrait.SetVisible(false);
				this.m_editPortrait.ID = 0UL;
				this.m_redPoint.SetVisible(false);
				this.m_descLabel.SetText("");
				this.m_fightLabel.SetText("");
				bool flag2 = this.m_getAll != null;
				if (flag2)
				{
					this.m_getAll.gameObject.SetActive(false);
				}
			}
			else
			{
				this.m_wrapContent.SetContentCount(this.m_select.GetAttributeCharm().Count, false);
				this.m_scrollView.ResetPosition();
				this.m_editPortrait.ID = (ulong)((long)this.m_select.GetID());
				this.m_titleLabel.SetText(XStringDefineProxy.GetString("FASHIONSTORAGE_ATT_TITLE", new object[]
				{
					this.m_select.GetCount(),
					this.m_select.GetFashionList().Length
				}));
				this.m_editPortrait.SetVisible(!this.m_select.ActivateAll);
				this.m_fightLabel.SetText(XStringDefineProxy.GetString("FASHION_FIGHT_DESC", new object[]
				{
					this.m_select.GetFashionList().Length,
					this.GetPPT(this.m_select.GetAttributeCharm())
				}));
				this.m_redPoint.SetVisible(this.m_select.RedPoint);
				bool flag3 = this.m_getAll != null;
				if (flag3)
				{
					this.m_getAll.gameObject.SetActive(this.m_select.ActivateAll);
				}
				this.m_editPortrait.SetGrey(this.m_select.RedPoint);
				bool flag4 = this.m_select is FashionStorageFashionCollection;
				if (flag4)
				{
					this.m_descLabel.SetText(XStringDefineProxy.GetString("FASHION_STORAGE_FASHION_DESC"));
				}
				else
				{
					bool flag5 = this.m_select is FashionStorageEquipCollection;
					if (flag5)
					{
						this.m_descLabel.SetText(XStringDefineProxy.GetString("FASHION_STORAGE_EQUIP_DESC"));
					}
					else
					{
						this.m_descLabel.SetText("");
					}
				}
			}
		}

		// Token: 0x040070AC RID: 28844
		private IXUIScrollView m_scrollView;

		// Token: 0x040070AD RID: 28845
		private IXUIWrapContent m_wrapContent;

		// Token: 0x040070AE RID: 28846
		private IXUILabel m_titleLabel;

		// Token: 0x040070AF RID: 28847
		private IXUIButton m_editPortrait;

		// Token: 0x040070B0 RID: 28848
		private IXUISprite m_redPoint;

		// Token: 0x040070B1 RID: 28849
		private IFashionStorageSelect m_select;

		// Token: 0x040070B2 RID: 28850
		private XFashionStorageDocument m_doc;

		// Token: 0x040070B3 RID: 28851
		private Color m_normaColor = new Color(225f, 145f, 65f);

		// Token: 0x040070B4 RID: 28852
		private IXUILabel m_descLabel;

		// Token: 0x040070B5 RID: 28853
		private Transform m_getAll;

		// Token: 0x040070B6 RID: 28854
		private IXUILabel m_fightLabel;
	}
}
