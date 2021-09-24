using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpriteSelectHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSelectHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			Transform transform = base.PanelObject.transform.Find("ScrollView/WrapContent/Tpl");
			this.m_ScrollView = (base.PanelObject.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.m_ScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.IsVisible();
			if (flag)
			{
				this.SetSpriteList(this._doc.SpriteList, true);
			}
			bool flag2 = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.IsVisible();
			if (flag2)
			{
				this._doc.DealWithResolveList();
				this.SetSpriteList(this._doc.ResolveList, true);
			}
			bool flag3 = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame.IsVisible();
			if (flag3)
			{
				this.SetSpriteList(this._doc.SpriteList, true);
			}
		}

		public void SetSpriteList(List<SpriteInfo> list, bool resetScrollPos = true)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this._list = list;
				this.m_WrapContent.SetContentCount(list.Count, false);
				if (resetScrollPos)
				{
					this.m_ScrollView.SetPosition(0f);
				}
			}
		}

		private void DesWrapListUpdated(Transform t, int i)
		{
			bool flag = i < 0 || i >= this._list.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("leftScrollView_index is out of range of sprite list. index = ", i.ToString(), " cout = ", this._list.Count.ToString(), null, null);
			}
			else
			{
				SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._list[i].SpriteID);
				GameObject gameObject = t.Find("Fight").gameObject;
				gameObject.SetActive(this._doc.CurrentTag == SpriteHandlerTag.Main && this._doc.isSpriteFight(this._list[i].uid));
				GameObject gameObject2 = t.Find("Fight2").gameObject;
				gameObject2.SetActive(this._doc.CurrentTag != SpriteHandlerTag.Main && this._doc.isSpriteFight(this._list[i].uid));
				IXUISprite ixuisprite = t.Find("Frame").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = string.Format("kuang_dj_{0}", bySpriteID.SpriteQuality);
				IXUISprite ixuisprite2 = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.spriteName = bySpriteID.SpriteIcon;
				Transform ts = t.Find("Star");
				this.SetStar(ts, this._list[i].EvolutionLevel);
				GameObject gameObject3 = t.Find("Up").gameObject;
				bool active = (this._doc.CurrentTag == SpriteHandlerTag.Fight && this.isUpIconShow(i)) || (this._doc.CurrentTag == SpriteHandlerTag.Main && this._doc.isSpriteFight(this._list[i].uid) && !this._doc.isSpriteFoodEmpty() && this._doc.isSpriteNeed2Feed(this._list[i].uid, false));
				gameObject3.SetActive(active);
				IXUISprite ixuisprite3 = t.GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.ID = (ulong)((long)i);
				switch (this._doc.CurrentTag)
				{
				case SpriteHandlerTag.Main:
				{
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.OnSpriteListClick));
					bool flag2 = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick == 10000 && i == 0;
					if (flag2)
					{
						DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.OnSpriteListClick(ixuisprite3);
					}
					t.transform.Find("Select").gameObject.SetActive(i == DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick);
					break;
				}
				case SpriteHandlerTag.Fight:
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame.OnLeftListClick));
					t.transform.Find("Select").gameObject.SetActive(false);
					break;
				case SpriteHandlerTag.Resolve:
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.OnSpriteListClick));
					t.Find("Select").gameObject.SetActive(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.ScrollViewHasSprite(this._list[i].uid));
					break;
				}
			}
		}

		private bool isUpIconShow(int i)
		{
			return this._doc.isSpriteNeed2Fight(i);
		}

		private void SetStar(Transform ts, uint num)
		{
			uint num2 = num / XSpriteSystemDocument.MOONWORTH;
			uint num3 = num % XSpriteSystemDocument.MOONWORTH;
			for (int i = 0; i < 7; i++)
			{
				IXUISprite ixuisprite = ts.Find(string.Format("star{0}", i)).GetComponent("XUISprite") as IXUISprite;
				bool flag = (long)i < (long)((ulong)(num2 + num3));
				if (flag)
				{
					ixuisprite.SetVisible(true);
					ixuisprite.spriteName = (((long)i < (long)((ulong)num2)) ? "l_stars_02" : "l_stars_01");
				}
				else
				{
					ixuisprite.SetVisible(false);
				}
			}
		}

		private XSpriteSystemDocument _doc;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		private List<SpriteInfo> _list;
	}
}
