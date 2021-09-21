using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001715 RID: 5909
	internal class XDragonRwdHandler : DlgHandlerBase
	{
		// Token: 0x0600F406 RID: 62470 RVA: 0x00369C04 File Offset: 0x00367E04
		protected override void Init()
		{
			base.Init();
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
			}
			this.m_PanelScrollView = (base.PanelObject.transform.FindChild("detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_lblWeek = (base.PanelObject.transform.FindChild("Title/T/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_lblIntro = (base.PanelObject.transform.FindChild("Title/Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTimes = (base.PanelObject.transform.FindChild("Title/T/Times").GetComponent("XUILabel") as IXUILabel);
			this.m_chbx = (base.PanelObject.transform.FindChild("Title/Agreement/Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600F407 RID: 62471 RVA: 0x00369D4A File Offset: 0x00367F4A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_chbx.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectCnbx));
		}

		// Token: 0x0600F408 RID: 62472 RVA: 0x00369D6C File Offset: 0x00367F6C
		protected override void OnShow()
		{
			base.OnShow();
			this.doc.rwdView = this;
			this.cbInit = false;
			this.m_lblWeek.SetText(XStringDefineProxy.GetString("DragonReset"));
			this.m_lblIntro.SetText(XStringDefineProxy.GetString("DragonDesc"));
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
			}
			this.doc.FetchList();
		}

		// Token: 0x0600F409 RID: 62473 RVA: 0x00369DE9 File Offset: 0x00367FE9
		protected override void OnHide()
		{
			this.cbInit = false;
			base.OnHide();
		}

		// Token: 0x0600F40A RID: 62474 RVA: 0x00369DFA File Offset: 0x00367FFA
		public override void OnUnload()
		{
			this.doc = null;
			base.OnUnload();
		}

		// Token: 0x0600F40B RID: 62475 RVA: 0x00369E0C File Offset: 0x0036800C
		private bool OnSelectCnbx(IXUICheckBox chbx)
		{
			bool flag = this.cbInit;
			if (flag)
			{
				bool flag2 = this.doc == null;
				if (flag2)
				{
					this.doc = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
				}
				bool flag3 = chbx.bChecked != this.doc.isAgreeHelp;
				if (flag3)
				{
					this.doc.AgreeHelp(chbx.bChecked);
				}
			}
			return true;
		}

		// Token: 0x0600F40C RID: 62476 RVA: 0x00369E74 File Offset: 0x00368074
		public void Refresh()
		{
			this.cbInit = true;
			this.m_chbx.bChecked = this.doc.isAgreeHelp;
			this.m_lblTimes.SetText(this.doc.helpCnt.ToString());
			this.m_WrapContent.SetContentCount(this.doc.rewds.Count, false);
			this.m_PanelScrollView.ResetPosition();
		}

		// Token: 0x0600F40D RID: 62477 RVA: 0x00369EE8 File Offset: 0x003680E8
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.doc != null;
			if (flag)
			{
				bool flag2 = index < this.doc.rewds.Count && index >= 0;
				if (flag2)
				{
					DragonRwdItem info = this.doc.rewds[index];
					this._SetRecord(t, info);
				}
			}
		}

		// Token: 0x0600F40E RID: 62478 RVA: 0x00369F44 File Offset: 0x00368144
		private void _SetRecord(Transform t, DragonRwdItem info)
		{
			IXUILabel ixuilabel = t.Find("TLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("DLabel").GetComponent("XUILabel") as IXUILabel;
			Transform transform = t.Find("ch");
			IXUISprite ixuisprite = transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite;
			IXUIButton ixuibutton = t.Find("Get").GetComponent("XUIButton") as IXUIButton;
			IXUISprite ixuisprite2 = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite3 = t.Find("Fini").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite4 = t.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = t.Find("bj").gameObject;
			GameObject gameObject2 = t.Find("bj/bj").gameObject;
			GameObject gameObject3 = t.Find("tmp1").gameObject;
			GameObject gameObject4 = t.Find("tmp2").gameObject;
			ixuilabel.SetText(info.row.Achievement);
			ixuilabel2.SetText(info.row.Explanation);
			string empty = string.Empty;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("AchieveColor");
			bool flag = !string.IsNullOrEmpty(info.row.DesignationName);
			gameObject3.SetActive(flag);
			gameObject4.SetActive(!flag);
			Transform transform2 = flag ? gameObject3.transform : gameObject4.transform;
			int num = Mathf.Min(3, (int)info.row.Reward.count);
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject5 = transform2.GetChild(i).gameObject;
				gameObject5.transform.localScale = Vector3.one;
				IXUISprite ixuisprite5 = gameObject5.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite5.ID = (ulong)((long)info.row.Reward[i, 0]);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject5, info.row.Reward[i, 0], info.row.Reward[i, 1], false);
				ixuisprite5.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			int j = num;
			int num2 = 3;
			while (j < num2)
			{
				transform2.GetChild(j).gameObject.SetActive(false);
				j++;
			}
			gameObject2.SetActive(info.state == AchieveState.Claim);
			ixuisprite4.SetVisible(info.state == AchieveState.Claim);
			ixuisprite3.SetVisible(info.state == AchieveState.Claimed);
			ixuibutton.SetVisible(info.state != AchieveState.Claimed);
			gameObject.SetActive(info.state != AchieveState.Normal);
			ixuisprite2.SetSprite(info.row.ICON);
			bool flag2 = flag;
			if (flag2)
			{
				ixuisprite.SetSprite(info.row.DesignationName);
			}
			transform.gameObject.SetActive(!string.IsNullOrEmpty(info.row.DesignationName));
			ixuibutton.SetEnable(info.state != AchieveState.Normal, false);
			ixuibutton.ID = (ulong)((long)info.row.ID);
			bool flag3 = info.state != AchieveState.Normal;
			if (flag3)
			{
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
			}
		}

		// Token: 0x0600F40F RID: 62479 RVA: 0x0036A2F8 File Offset: 0x003684F8
		private bool OnBtnClick(IXUIButton btn)
		{
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
			}
			this.doc.Claim((int)btn.ID);
			return true;
		}

		// Token: 0x040068EC RID: 26860
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040068ED RID: 26861
		private IXUIScrollView m_PanelScrollView;

		// Token: 0x040068EE RID: 26862
		private IXUILabel m_lblWeek;

		// Token: 0x040068EF RID: 26863
		private IXUILabel m_lblIntro;

		// Token: 0x040068F0 RID: 26864
		private IXUILabel m_lblTimes;

		// Token: 0x040068F1 RID: 26865
		private IXUICheckBox m_chbx;

		// Token: 0x040068F2 RID: 26866
		private bool cbInit;

		// Token: 0x040068F3 RID: 26867
		private XDragonRewardDocument doc;
	}
}
