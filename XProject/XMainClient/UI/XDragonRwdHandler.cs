using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XDragonRwdHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_chbx.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectCnbx));
		}

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

		protected override void OnHide()
		{
			this.cbInit = false;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.doc = null;
			base.OnUnload();
		}

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

		public void Refresh()
		{
			this.cbInit = true;
			this.m_chbx.bChecked = this.doc.isAgreeHelp;
			this.m_lblTimes.SetText(this.doc.helpCnt.ToString());
			this.m_WrapContent.SetContentCount(this.doc.rewds.Count, false);
			this.m_PanelScrollView.ResetPosition();
		}

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

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_PanelScrollView;

		private IXUILabel m_lblWeek;

		private IXUILabel m_lblIntro;

		private IXUILabel m_lblTimes;

		private IXUICheckBox m_chbx;

		private bool cbInit;

		private XDragonRewardDocument doc;
	}
}
