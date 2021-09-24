using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactItemsHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactItemsHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillTabs();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_bagWindow.OnHide();
			this.m_doc.NewItems.TryClear();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillBagList();
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.m_bagWindow = null;
			this.m_doc.ItemsHandler = null;
		}

		public void RefreshUi()
		{
			this.FillBagList();
		}

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

		private void FillBagList()
		{
			this.m_doc.NewItems.bCanClear = true;
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifactByTabLevel));
			this.m_bagWindow.OnShow();
		}

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

		private ArtifactDeityStoveDocument m_doc;

		private XBagWindow m_bagWindow;

		private IXUICheckBox m_curSelectToggle;

		private IXUIScrollView m_scrollView;

		private XUIPool m_tabsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
