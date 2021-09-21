using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A8 RID: 6056
	internal class XTitanItem : XDataBase
	{
		// Token: 0x1700386C RID: 14444
		// (get) Token: 0x0600FA5F RID: 64095 RVA: 0x0039DDCC File Offset: 0x0039BFCC
		public int ItemID
		{
			get
			{
				return this.m_ItemID;
			}
		}

		// Token: 0x0600FA60 RID: 64096 RVA: 0x0039DDE4 File Offset: 0x0039BFE4
		public override void Init()
		{
			base.Init();
			this.m_ItemID = 0;
			this.m_Upperbound = 0UL;
			this.m_bHasUpperbound = false;
			this.m_go = null;
		}

		// Token: 0x0600FA61 RID: 64097 RVA: 0x0039DE0B File Offset: 0x0039C00B
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XTitanItem>.Recycle(this);
		}

		// Token: 0x0600FA62 RID: 64098 RVA: 0x0039DE1C File Offset: 0x0039C01C
		public void Set(int itemid, GameObject go)
		{
			this.m_go = go;
			this.m_ItemID = itemid;
			bool flag = itemid == 6;
			if (flag)
			{
				this.m_Upperbound = this.GetFatigueUpperbound();
				this.m_bHasUpperbound = true;
			}
			this._SetUI();
			this.RefreshValue(false);
		}

		// Token: 0x0600FA63 RID: 64099 RVA: 0x0039DE68 File Offset: 0x0039C068
		private void _SetUI()
		{
			this.m_uiIcon = (this.m_go.transform.Find("icon").GetComponent("XUISprite") as IXUISprite);
			Transform transform = this.m_go.transform.Find("Add");
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(this.IsShowAddBtn(this.m_ItemID));
			}
			Transform transform2 = this.m_go.transform.Find("Tip");
			bool flag2 = transform2 != null;
			if (flag2)
			{
				this.m_Tip = (this.m_go.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
				this.m_Tip.SetText(XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(this.m_ItemID).ItemName, 0U));
				this.m_Tip.SetVisible(false);
			}
			Transform transform3 = this.m_go.transform.Find("Bg");
			bool flag3 = transform3 != null;
			if (flag3)
			{
				this.m_btnAdd = (transform3.GetComponent("XUIButton") as IXUIButton);
				bool flag4 = this.m_btnAdd != null;
				if (flag4)
				{
					this.m_btnAdd.RegisterPressEventHandler(null);
					this.m_btnAdd.RegisterClickEventHandler(null);
					bool flag5 = this.IsShowAddBtn(this.m_ItemID);
					if (flag5)
					{
						this.m_btnAdd.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAddClicked));
					}
					else
					{
						this.m_btnAdd.RegisterPressEventHandler(new ButtonPressEventHandler(this._OnAddPress));
					}
				}
			}
			this.m_uiTween = XNumberTween.Create(this.m_go.transform);
			string strSprite;
			string strAtlas;
			XBagDocument.GetItemBigIconAndAtlas(this.m_ItemID, out strSprite, out strAtlas, 0U);
			this.m_uiIcon.SetSprite(strSprite, strAtlas, false);
		}

		// Token: 0x0600FA64 RID: 64100 RVA: 0x0039E048 File Offset: 0x0039C248
		private bool IsShowAddBtn(int itemID)
		{
			bool flag = itemID == int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteAwakeItemID")) || itemID == int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteStarUpItemID"));
			return !flag;
		}

		// Token: 0x0600FA65 RID: 64101 RVA: 0x0039E094 File Offset: 0x0039C294
		public void RefreshValue(bool bAnim)
		{
			this.m_Value = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(this.m_ItemID);
			string postfix = string.Empty;
			bool bHasUpperbound = this.m_bHasUpperbound;
			if (bHasUpperbound)
			{
				bool flag = this.m_ItemID == 6;
				if (flag)
				{
					this.m_Upperbound = this.GetFatigueUpperbound();
				}
				postfix = string.Format("/{0}", this.m_Upperbound);
			}
			XSingleton<UiUtility>.singleton.SetVirtualItem(this.m_uiTween, this.m_Value, bAnim, postfix);
		}

		// Token: 0x0600FA66 RID: 64102 RVA: 0x0039E120 File Offset: 0x0039C320
		private ulong GetFatigueUpperbound()
		{
			ulong num = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxRecoverFatigue"));
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
			if (flag)
			{
				PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court);
				num += (ulong)((memberPrivilegeConfig != null) ? ((long)memberPrivilegeConfig.FatigueLimit) : 0L);
			}
			return num;
		}

		// Token: 0x0600FA67 RID: 64103 RVA: 0x0039E17C File Offset: 0x0039C37C
		private bool _OnAddClicked(IXUIButton btn)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(this.m_ItemID);
			return true;
		}

		// Token: 0x0600FA68 RID: 64104 RVA: 0x0039E1A0 File Offset: 0x0039C3A0
		private void _OnAddPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_Tip == null;
			if (!flag)
			{
				this.m_Tip.SetVisible(state);
			}
		}

		// Token: 0x04006DBB RID: 28091
		private int m_ItemID;

		// Token: 0x04006DBC RID: 28092
		private ulong m_Upperbound;

		// Token: 0x04006DBD RID: 28093
		private bool m_bHasUpperbound;

		// Token: 0x04006DBE RID: 28094
		private ulong m_Value;

		// Token: 0x04006DBF RID: 28095
		private GameObject m_go;

		// Token: 0x04006DC0 RID: 28096
		private IXUISprite m_uiIcon;

		// Token: 0x04006DC1 RID: 28097
		private IXUIButton m_btnAdd;

		// Token: 0x04006DC2 RID: 28098
		private XNumberTween m_uiTween;

		// Token: 0x04006DC3 RID: 28099
		private IXUILabel m_Tip;
	}
}
