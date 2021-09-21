using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E4 RID: 6116
	internal class HolidayHandler : DlgHandlerBase
	{
		// Token: 0x170038B8 RID: 14520
		// (get) Token: 0x0600FD88 RID: 64904 RVA: 0x003B7398 File Offset: 0x003B5598
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/HolidayFrame";
			}
		}

		// Token: 0x0600FD89 RID: 64905 RVA: 0x003B73B0 File Offset: 0x003B55B0
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
			this.m_Tip1 = (base.PanelObject.transform.Find("Main/Tip1").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime = new XLeftTimeCounter(this.m_Tip1, true);
			this.m_LeftTime.SetTimeFormat(0, 3, 4, false);
			this.m_Tip2 = (base.PanelObject.transform.Find("Main/Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_Enter = (base.PanelObject.transform.Find("Main/Btns/EnterBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Bg = (base.PanelObject.transform.Find("Main/Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_AwardRoot = base.PanelObject.transform.Find("Main/Items");
			GameObject gameObject = base.PanelObject.transform.Find("Main/Items/Item").gameObject;
			this.m_ItemPool.SetupPool(this.m_AwardRoot.gameObject, gameObject, 7U, false);
		}

		// Token: 0x0600FD8A RID: 64906 RVA: 0x003B74EF File Offset: 0x003B56EF
		protected override void OnShow()
		{
			base.OnShow();
			this.doc.SendQueryHolidayData();
			this.Refresh();
		}

		// Token: 0x0600FD8B RID: 64907 RVA: 0x003B750C File Offset: 0x003B570C
		protected override void OnHide()
		{
			base.OnHide();
			this.m_Bg.SetTexturePath("");
		}

		// Token: 0x0600FD8C RID: 64908 RVA: 0x003B7527 File Offset: 0x003B5727
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Enter.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

		// Token: 0x0600FD8D RID: 64909 RVA: 0x003B754C File Offset: 0x003B574C
		public void Refresh()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.doc.GetFestivalLeftTime() == 0U;
				if (flag2)
				{
					this.m_LeftTime.SetLeftTime(10000000f, -1);
					this.m_LeftTime.SetFormatString(XSingleton<XStringTable>.singleton.GetString("HOLIDAY_TIP3"));
				}
				else
				{
					this.m_LeftTime.SetLeftTime(this.doc.GetFestivalLeftTime(), -1);
					this.m_LeftTime.SetFormatString(XSingleton<XStringTable>.singleton.GetString("HOLIDAY_TIP1"));
				}
				this.m_Tip2.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("HOLIDAY_TIP2"), this.doc.GetFestivalLeftCount()));
				this.SetAwardsInfo();
				this.SetBG();
			}
		}

		// Token: 0x0600FD8E RID: 64910 RVA: 0x003B7624 File Offset: 0x003B5824
		private bool OnEnterClicked(IXUIButton btn)
		{
			this.doc.EnterHolidayLevel();
			return true;
		}

		// Token: 0x0600FD8F RID: 64911 RVA: 0x003B7644 File Offset: 0x003B5844
		private void SetBG()
		{
			string festivalPicPath = this.doc.GetFestivalPicPath();
			bool flag = string.IsNullOrEmpty(festivalPicPath);
			if (!flag)
			{
				this.m_Bg.SetTexturePath(festivalPicPath);
			}
		}

		// Token: 0x0600FD90 RID: 64912 RVA: 0x003B7678 File Offset: 0x003B5878
		private void SetAwardsInfo()
		{
			this.m_ItemPool.ReturnAll(false);
			uint[] festivalRewardList = this.doc.GetFestivalRewardList();
			bool flag = festivalRewardList == null;
			if (!flag)
			{
				for (int i = 0; i < festivalRewardList.Length; i++)
				{
					GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_AwardRoot;
					gameObject.name = i.ToString();
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * i), 0f, 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)festivalRewardList[i];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)festivalRewardList[i], 0, false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x0600FD91 RID: 64913 RVA: 0x003B778E File Offset: 0x003B598E
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_LeftTime.Update();
		}

		// Token: 0x04006FD3 RID: 28627
		private XOperatingActivityDocument doc;

		// Token: 0x04006FD4 RID: 28628
		private IXUILabel m_Tip1;

		// Token: 0x04006FD5 RID: 28629
		private IXUILabel m_Tip2;

		// Token: 0x04006FD6 RID: 28630
		private IXUIButton m_Enter;

		// Token: 0x04006FD7 RID: 28631
		private IXUITexture m_Bg;

		// Token: 0x04006FD8 RID: 28632
		private Transform m_AwardRoot;

		// Token: 0x04006FD9 RID: 28633
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006FDA RID: 28634
		private XLeftTimeCounter m_LeftTime;
	}
}
