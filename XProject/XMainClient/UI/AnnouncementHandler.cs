using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D9 RID: 6105
	internal class AnnouncementHandler : DlgHandlerBase
	{
		// Token: 0x170038AD RID: 14509
		// (get) Token: 0x0600FD00 RID: 64768 RVA: 0x003B24C0 File Offset: 0x003B06C0
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/ActivityAnnouncement";
			}
		}

		// Token: 0x0600FD01 RID: 64769 RVA: 0x003B24D8 File Offset: 0x003B06D8
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
			base.Init();
			this.m_Table = (base.PanelObject.transform.Find("ScrollView/Table").GetComponent("XUITable") as IXUITable);
			Transform transform = base.PanelObject.transform.Find("ScrollView/Table/NoticeTpl");
			this.m_NoticePool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.PanelObject.transform.Find("ScrollView/Table/ActivityTpl");
			this.m_ActivityPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.PanelObject.transform.Find("Tabs/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
		}

		// Token: 0x0600FD02 RID: 64770 RVA: 0x003B25C6 File Offset: 0x003B07C6
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.CurrentTab = 0;
			this._doc.SendFetchNotice();
			this.RefreshData();
		}

		// Token: 0x0600FD03 RID: 64771 RVA: 0x003B25EF File Offset: 0x003B07EF
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(this.m_NoticePool, "ChildList/LevelTwoTpl/Texture");
		}

		// Token: 0x0600FD04 RID: 64772 RVA: 0x003B2610 File Offset: 0x003B0810
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshTab();
			int currentTab = this._doc.CurrentTab;
			if (currentTab != 0)
			{
				if (currentTab == 1)
				{
					this.RefreshNoticeList();
				}
			}
			else
			{
				this.RefreshActivityList();
			}
			this._last_notice = null;
		}

		// Token: 0x0600FD05 RID: 64773 RVA: 0x003B265C File Offset: 0x003B085C
		public void RefreshTab()
		{
			this.m_TabPool.ReturnAll(false);
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = this.m_TabPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				Transform transform = gameObject.transform.Find("Bg/RedPoint");
				IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuilabel.SetText(XStringDefineProxy.GetString(string.Format("AnnouncementTab{0}", i)));
				ixuilabel2.SetText(XStringDefineProxy.GetString(string.Format("AnnouncementTab{0}", i)));
				transform.gameObject.SetActive(this._doc.GetTabRedPoint(i));
				ixuicheckBox.ForceSetFlag(i == this._doc.CurrentTab);
				ixuicheckBox.ID = (ulong)((long)i);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClicked));
				gameObject.transform.localPosition = this.m_TabPool.TplPos + new Vector3((float)(i * this.m_TabPool.TplWidth), 0f);
			}
		}

		// Token: 0x0600FD06 RID: 64774 RVA: 0x003B27CC File Offset: 0x003B09CC
		private bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool bChecked = checkbox.bChecked;
			if (bChecked)
			{
				this._doc.CurrentTab = (int)checkbox.ID;
				this.RefreshData();
			}
			return true;
		}

		// Token: 0x0600FD07 RID: 64775 RVA: 0x003B2804 File Offset: 0x003B0A04
		public void RefreshActivityList()
		{
			this.m_ActivityPool.ReturnAll(false);
			this.m_NoticePool.ReturnAll(false);
			for (int i = 0; i < this._doc.NoticeList.Count; i++)
			{
				bool flag = this._doc.NoticeList[i].type != 6U;
				if (!flag)
				{
					GameObject gameObject = this.m_ActivityPool.FetchGameObject(false);
					gameObject.name = "activity" + i.ToString("d4");
					IXUITexture ixuitexture = gameObject.GetComponent("XUITexture") as IXUITexture;
					IXUITexture ixuitexture2 = gameObject.transform.Find("ActivityTex").GetComponent("XUITexture") as IXUITexture;
					IXUILabel ixuilabel = gameObject.transform.Find("ChildList/LevelTwoTpl/Label").GetComponent("XUILabel") as IXUILabel;
					Transform transform = gameObject.transform.Find("new");
					transform.gameObject.SetActive(this._doc.NoticeList[i].isnew);
					ixuitexture2.SetVisible(true);
					XSingleton<XUICacheImage>.singleton.Load(this._doc.NoticeList[i].title, ixuitexture2, DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.uiBehaviour);
					ixuilabel.SetText(this._doc.NoticeList[i].content);
					ixuitexture.ID = (ulong)((long)i);
					ixuitexture.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnActivityClicked));
					Transform transform2 = gameObject.transform.Find("ChildList");
					transform2.localScale = new Vector3(1f, 0f, 1f);
				}
			}
			this.m_Table.RePositionNow();
		}

		// Token: 0x0600FD08 RID: 64776 RVA: 0x003B29D8 File Offset: 0x003B0BD8
		public void RefreshNoticeList()
		{
			this.m_ActivityPool.ReturnAll(false);
			this.m_NoticePool.ReturnAll(false);
			for (int i = 0; i < this._doc.NoticeList.Count; i++)
			{
				bool flag = this._doc.NoticeList[i].type != 3U && this._doc.NoticeList[i].type != 4U;
				if (!flag)
				{
					GameObject gameObject = this.m_NoticePool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					gameObject.name = "notice" + i.ToString("d4");
					Transform transform = gameObject.transform.Find("new");
					IXUILabel ixuilabel = gameObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = gameObject.transform.Find("Selected/Title").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel4 = gameObject.transform.Find("Selected/Time").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel5 = gameObject.transform.Find("ChildList/LevelTwoTpl/Label").GetComponent("XUILabel") as IXUILabel;
					IXUITexture ixuitexture = gameObject.transform.Find("ChildList/LevelTwoTpl/Texture").GetComponent("XUITexture") as IXUITexture;
					transform.gameObject.SetActive(this._doc.NoticeList[i].isnew);
					ixuilabel.SetText(this._doc.NoticeList[i].title);
					ixuilabel3.SetText(this._doc.NoticeList[i].title);
					DateTime dateTime = XSingleton<UiUtility>.singleton.TimeNow(this._doc.NoticeList[i].updatetime, true);
					ixuilabel2.SetText(dateTime.ToString("yyyy-MM-dd"));
					ixuilabel4.SetText(dateTime.ToString("yyyy-MM-dd"));
					uint type = this._doc.NoticeList[i].type;
					if (type != 3U)
					{
						if (type == 4U)
						{
							ixuilabel5.SetVisible(false);
							ixuitexture.SetVisible(true);
							XSingleton<XUICacheImage>.singleton.Load(this._doc.NoticeList[i].content, ixuitexture, DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.uiBehaviour);
						}
					}
					else
					{
						ixuilabel5.SetVisible(true);
						ixuitexture.SetVisible(false);
						ixuilabel5.SetText(this._doc.NoticeList[i].content);
					}
					ixuisprite.ID = (ulong)((long)i);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNoticeClicked));
					Transform transform2 = gameObject.transform.Find("Selected");
					Transform transform3 = gameObject.transform.Find("ChildList");
					transform2.gameObject.SetActive(false);
					transform3.localScale = new Vector3(1f, 0f, 1f);
				}
			}
			this.m_Table.RePositionNow();
		}

		// Token: 0x0600FD09 RID: 64777 RVA: 0x003B2D40 File Offset: 0x003B0F40
		private void OnNoticeClicked(IXUISprite sp)
		{
			bool flag = sp.gameObject == this._last_notice;
			if (flag)
			{
				IXUITweenTool ixuitweenTool = this._last_notice.GetComponent("XUIPlayTween") as IXUITweenTool;
				Transform transform = this._last_notice.transform.Find("Selected");
				transform.gameObject.SetActive(false);
				ixuitweenTool.PlayTween(false, -1f);
				this._last_notice = null;
			}
			else
			{
				IXUITweenTool ixuitweenTool2 = sp.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
				Transform transform2 = sp.transform.Find("Selected");
				transform2.gameObject.SetActive(true);
				ixuitweenTool2.PlayTween(true, -1f);
				bool flag2 = this._last_notice != null;
				if (flag2)
				{
					IXUITweenTool ixuitweenTool3 = this._last_notice.GetComponent("XUIPlayTween") as IXUITweenTool;
					Transform transform3 = this._last_notice.transform.Find("Selected");
					transform3.gameObject.SetActive(false);
					ixuitweenTool3.PlayTween(false, -1f);
				}
				this._last_notice = sp.gameObject;
			}
			bool isnew = this._doc.NoticeList[(int)sp.ID].isnew;
			if (isnew)
			{
				this._doc.SendClickNotice(this._doc.NoticeList[(int)sp.ID]);
				Transform transform4 = sp.transform.Find("new");
				transform4.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600FD0A RID: 64778 RVA: 0x003B2ED0 File Offset: 0x003B10D0
		private void OnActivityClicked(IXUITexture tex)
		{
			bool flag = tex.gameObject == this._last_notice;
			if (flag)
			{
				IXUITweenTool ixuitweenTool = this._last_notice.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.PlayTween(false, -1f);
				this._last_notice = null;
			}
			else
			{
				IXUITweenTool ixuitweenTool2 = tex.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool2.PlayTween(true, -1f);
				bool flag2 = this._last_notice != null;
				if (flag2)
				{
					IXUITweenTool ixuitweenTool3 = this._last_notice.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool3.PlayTween(false, -1f);
				}
				this._last_notice = tex.gameObject;
			}
			bool isnew = this._doc.NoticeList[(int)tex.ID].isnew;
			if (isnew)
			{
				this._doc.SendClickNotice(this._doc.NoticeList[(int)tex.ID]);
				Transform transform = tex.gameObject.transform.Find("new");
				transform.gameObject.SetActive(false);
			}
		}

		// Token: 0x04006F53 RID: 28499
		private XAnnouncementDocument _doc;

		// Token: 0x04006F54 RID: 28500
		private IXUITable m_Table;

		// Token: 0x04006F55 RID: 28501
		private XUIPool m_NoticePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F56 RID: 28502
		private XUIPool m_ActivityPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F57 RID: 28503
		private XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F58 RID: 28504
		private GameObject _last_notice = null;
	}
}
