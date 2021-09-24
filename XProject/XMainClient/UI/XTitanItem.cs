using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTitanItem : XDataBase
	{

		public int ItemID
		{
			get
			{
				return this.m_ItemID;
			}
		}

		public override void Init()
		{
			base.Init();
			this.m_ItemID = 0;
			this.m_Upperbound = 0UL;
			this.m_bHasUpperbound = false;
			this.m_go = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XTitanItem>.Recycle(this);
		}

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

		private bool IsShowAddBtn(int itemID)
		{
			bool flag = itemID == int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteAwakeItemID")) || itemID == int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteStarUpItemID"));
			return !flag;
		}

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

		private bool _OnAddClicked(IXUIButton btn)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(this.m_ItemID);
			return true;
		}

		private void _OnAddPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_Tip == null;
			if (!flag)
			{
				this.m_Tip.SetVisible(state);
			}
		}

		private int m_ItemID;

		private ulong m_Upperbound;

		private bool m_bHasUpperbound;

		private ulong m_Value;

		private GameObject m_go;

		private IXUISprite m_uiIcon;

		private IXUIButton m_btnAdd;

		private XNumberTween m_uiTween;

		private IXUILabel m_Tip;
	}
}
