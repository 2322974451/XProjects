using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HolidayHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/HolidayFrame";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.doc.SendQueryHolidayData();
			this.Refresh();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_Bg.SetTexturePath("");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Enter.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterClicked));
		}

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

		private bool OnEnterClicked(IXUIButton btn)
		{
			this.doc.EnterHolidayLevel();
			return true;
		}

		private void SetBG()
		{
			string festivalPicPath = this.doc.GetFestivalPicPath();
			bool flag = string.IsNullOrEmpty(festivalPicPath);
			if (!flag)
			{
				this.m_Bg.SetTexturePath(festivalPicPath);
			}
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_LeftTime.Update();
		}

		private XOperatingActivityDocument doc;

		private IXUILabel m_Tip1;

		private IXUILabel m_Tip2;

		private IXUIButton m_Enter;

		private IXUITexture m_Bg;

		private Transform m_AwardRoot;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XLeftTimeCounter m_LeftTime;
	}
}
