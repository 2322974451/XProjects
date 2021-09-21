using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B3 RID: 6067
	internal class ArtifactItemsHandler : DlgHandlerBase
	{
		// Token: 0x1700387D RID: 14461
		// (get) Token: 0x0600FB05 RID: 64261 RVA: 0x003A2C50 File Offset: 0x003A0E50
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactItemsHandler";
			}
		}

		// Token: 0x0600FB06 RID: 64262 RVA: 0x003A2C68 File Offset: 0x003A0E68
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("Tabs");
			this.m_tabsPool.SetupPool(transform.gameObject, transform.FindChild("TabTpl0").gameObject, 5U, true);
			this.m_scrollView = (transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_doc = ArtifactDeityStoveDocument.Doc;
			this.m_bagWindow = new XBagWindow(base.PanelObject, new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifactByTabLevel));
			this.m_bagWindow.Init();
			this.m_doc.ItemsHandler = this;
		}

		// Token: 0x0600FB07 RID: 64263 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FB08 RID: 64264 RVA: 0x003A2D28 File Offset: 0x003A0F28
		protected override void OnShow()
		{
			base.OnShow();
			this.FillTabs();
		}

		// Token: 0x0600FB09 RID: 64265 RVA: 0x003A2D39 File Offset: 0x003A0F39
		protected override void OnHide()
		{
			base.OnHide();
			this.m_bagWindow.OnHide();
			this.m_doc.NewItems.TryClear();
		}

		// Token: 0x0600FB0A RID: 64266 RVA: 0x003A2D60 File Offset: 0x003A0F60
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillBagList();
		}

		// Token: 0x0600FB0B RID: 64267 RVA: 0x003A2D71 File Offset: 0x003A0F71
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_bagWindow = null;
			this.m_doc.ItemsHandler = null;
		}

		// Token: 0x0600FB0C RID: 64268 RVA: 0x003A2D8E File Offset: 0x003A0F8E
		public void RefreshUi()
		{
			this.FillBagList();
		}

		// Token: 0x0600FB0D RID: 64269 RVA: 0x003A2D98 File Offset: 0x003A0F98
		private void FillTabs()
		{
			this.m_tabsPool.ReturnAll(true);
			List<int> tabLevels = this.m_doc.GetTabLevels();
			int num = 0;
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.m_doc.LevelDic.TryGetValue((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, out num);
			}
			int num2 = num;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < tabLevels.Count; i++)
			{
				bool flag2 = tabLevels[i] > num2;
				if (flag2)
				{
					break;
				}
				num4 = i + 1;
				GameObject gameObject = this.m_tabsPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_scrollView.gameObject.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(0f, this.m_tabsPool.TplPos.y - (float)(i * this.m_tabsPool.TplHeight), 0f);
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactLevel"), tabLevels[i]));
				ixuilabel2.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactLevel"), tabLevels[i]));
				IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)tabLevels[i]);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
				bool flag3 = tabLevels[i] == num;
				if (flag3)
				{
					num3 = i + 1;
					this.m_curSelectToggle = ixuicheckBox;
					ixuicheckBox.ForceSetFlag(true);
					this.OnClickTab(ixuicheckBox);
				}
				else
				{
					ixuicheckBox.ForceSetFlag(false);
				}
			}
			bool flag4 = num3 > 8;
			if (flag4)
			{
				this.m_scrollView.SetPosition((float)(num3 / num4));
			}
		}

		// Token: 0x0600FB0E RID: 64270 RVA: 0x003A2FEC File Offset: 0x003A11EC
		private void FillBagList()
		{
			this.m_doc.NewItems.bCanClear = true;
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifactByTabLevel));
			this.m_bagWindow.OnShow();
		}

		// Token: 0x0600FB0F RID: 64271 RVA: 0x003A3044 File Offset: 0x003A1244
		private void WrapContentItemUpdated(Transform t, int index)
		{
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILongPress ixuilongPress = t.FindChild("Icon").GetComponent("XUILongPress") as IXUILongPress;
			bool flag = this.m_bagWindow.m_XItemList == null || index >= this.m_bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
				ixuisprite.RegisterSpriteClickEventHandler(null);
				ixuilongPress.RegisterSpriteLongPressEventHandler(null);
			}
			else
			{
				ixuisprite.ID = this.m_bagWindow.m_XItemList[index].uid;
				bool flag2 = this.m_doc.IsSelected(ixuisprite.ID);
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
					ixuisprite.RegisterSpriteClickEventHandler(null);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.m_bagWindow.m_XItemList[index]);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				}
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("artifact", this.m_bagWindow.m_XItemList[index].itemID.ToString());
				Transform transform = t.FindChild("Icon/RedPoint");
				bool flag3 = transform != null;
				if (flag3)
				{
					transform.gameObject.SetActive(false);
				}
				transform = t.Find("Icon/TimeBg");
				bool flag4 = transform != null;
				if (flag4)
				{
					transform.gameObject.SetActive(false);
				}
				transform = t.FindChild("Icon/New");
				bool flag5 = transform != null;
				if (flag5)
				{
					transform.gameObject.SetActive(this.m_doc.NewItems.IsNew(ixuisprite.ID));
				}
				transform = t.FindChild("Icon/State");
				bool flag6 = transform != null;
				if (flag6)
				{
					transform.gameObject.SetActive(XBagDocument.BagDoc.ArtifactBag.HasItem(this.m_bagWindow.m_XItemList[index].uid));
				}
			}
		}

		// Token: 0x0600FB10 RID: 64272 RVA: 0x003A3290 File Offset: 0x003A1490
		private bool OnClickTab(IXUICheckBox cb)
		{
			bool flag = !cb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_doc.ResetSelection(false);
				this.m_curSelectToggle = cb;
				this.m_doc.CurSelectTabLevel = (int)cb.ID;
				this.m_doc.RefreshAllHandlerUi();
				result = true;
			}
			return result;
		}

		// Token: 0x0600FB11 RID: 64273 RVA: 0x003A32E8 File Offset: 0x003A14E8
		private void OnItemClicked(IXUISprite iSp)
		{
			bool flag = iSp.ID == 0UL;
			if (!flag)
			{
				bool flag2 = this.m_doc.NewItems.RemoveItem(iSp.ID, ItemType.ARTIFACT, false);
				if (flag2)
				{
					this.FillBagList();
				}
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(iSp.ID);
				bool flag3 = itemByUID == null;
				if (!flag3)
				{
					XSingleton<TooltipParam>.singleton.bShowPutInBtn = true;
					XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemByUID, null, iSp, true, 0U);
				}
			}
		}

		// Token: 0x04006E26 RID: 28198
		private ArtifactDeityStoveDocument m_doc;

		// Token: 0x04006E27 RID: 28199
		private XBagWindow m_bagWindow;

		// Token: 0x04006E28 RID: 28200
		private IXUICheckBox m_curSelectToggle;

		// Token: 0x04006E29 RID: 28201
		private IXUIScrollView m_scrollView;

		// Token: 0x04006E2A RID: 28202
		private XUIPool m_tabsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
