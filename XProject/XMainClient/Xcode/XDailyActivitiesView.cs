using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDailyActivitiesView : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/DailyActivity/LivenessActivityFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
			this._doc.View = this;
			Transform transform = base.PanelObject.transform.Find("RightView/ActivityTpl");
			this.m_ActivityItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this._scrollView = (base.PanelObject.transform.FindChild("RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Progress = new XChestProgress(base.PanelObject.transform.FindChild("UpView/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_Progress.IncreaseSpeed = XDailyActivitiesView.ExpIncreaseSpeed;
			transform = base.PanelObject.transform.FindChild("UpView/Progress/Chests/Chest");
			this.m_ChestPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.PanelObject.transform.FindChild("LeftView/Item");
			this.totalExp = (base.PanelObject.transform.FindChild("UpView/CurrentExp").GetComponent("XUILabel") as IXUILabel);
			this.m_TotalExpTween = XNumberTween.Create(this.totalExp);
			this.m_TotalExpTween.SetNumberWithTween(0UL, "", false, true);
			this.m_WeekExp = (base.PanelObject.transform.FindChild("LeftView/Exp").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekExpTween = XNumberTween.Create(this.m_WeekExp);
			this.m_WeekExpTween.SetNumberWithTween(0UL, "", false, true);
			this.m_WeekAward1 = (base.PanelObject.transform.FindChild("LeftView/Exp500").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekAward2 = (base.PanelObject.transform.FindChild("LeftView/Exp1000").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekAwardBox1 = (base.PanelObject.transform.FindChild("LeftView/Exp500/box").GetComponent("XUISprite") as IXUISprite);
			this.m_WeekAwardBox2 = (base.PanelObject.transform.FindChild("LeftView/Exp1000/box").GetComponent("XUISprite") as IXUISprite);
			this.m_WeekAwardBox1Redpoint = (base.PanelObject.transform.FindChild("LeftView/Exp500/box/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_WeekAwardBox2Redpoint = (base.PanelObject.transform.FindChild("LeftView/Exp1000/box/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_WeekAward1Get = base.PanelObject.transform.FindChild("LeftView/Exp500/ylq").gameObject;
			this.m_WeekAward2Get = base.PanelObject.transform.FindChild("LeftView/Exp1000/ylq").gameObject;
			this.m_WeekAwardFx1 = base.PanelObject.transform.FindChild("LeftView/Exp500/Fx").gameObject;
			this.m_WeekAwardFx2 = base.PanelObject.transform.FindChild("LeftView/Exp1000/Fx").gameObject;
			this.m_ChestPool.ReturnAll(false);
			for (int i = 0; i < this._doc.ChestCount; i++)
			{
				GameObject chest = this.m_ChestPool.FetchGameObject(false);
				XChest chest2 = new XChest(chest, this._doc.SpriteName[i]);
				this.m_Progress.AddChest(chest2);
			}
			this.ChangeChestProgressState(true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < this._doc.ChestCount; i++)
			{
				this.m_Progress.ChestList[i].m_Chest.ID = (ulong)((long)i);
				this.m_Progress.ChestList[i].m_Chest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			}
			this.m_WeekAwardBox1.ID = (ulong)((long)this._doc.ChestCount);
			this.m_WeekAwardBox1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnWeekAwardBoxClicked));
			this.m_WeekAwardBox2.ID = (ulong)((long)this._doc.ChestCount + 1L);
			this.m_WeekAwardBox2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnWeekAwardBoxClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitView(true);
			this.SetWeedAwardExp();
		}

		private void SetWeedAwardExp()
		{
			bool flag = this._doc.WeekExps.Count >= 2;
			if (flag)
			{
				this.m_WeekAward1.SetText(this._doc.WeekExps[0].ToString());
				this.m_WeekAwardBox1.SetGrey(!this._doc.IsChestOpend((uint)this._doc.ChestCount));
				this.m_WeekAward1Get.SetActive(this._doc.IsChestOpend((uint)this._doc.ChestCount));
				bool flag2 = this._doc.WeekExp >= this._doc.WeekExps[0] && !this._doc.IsChestOpend((uint)this._doc.ChestCount);
				this.m_WeekAwardBox1Redpoint.SetVisible(flag2);
				this.m_WeekAwardFx1.SetActive(flag2);
				this.m_WeekAward2.SetText(this._doc.WeekExps[1].ToString());
				this.m_WeekAwardBox2.SetGrey(!this._doc.IsChestOpend((uint)(this._doc.ChestCount + 1)));
				this.m_WeekAward2Get.SetActive(this._doc.IsChestOpend((uint)(this._doc.ChestCount + 1)));
				bool flag3 = this._doc.WeekExp >= this._doc.WeekExps[1] && !this._doc.IsChestOpend((uint)(this._doc.ChestCount + 1));
				this.m_WeekAwardBox2Redpoint.SetVisible(flag3);
				this.m_WeekAwardFx2.SetActive(flag3);
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.InitView(false);
			this.SetWeedAwardExp();
		}

		public void InitView(bool RefreshNow)
		{
			if (RefreshNow)
			{
				this.m_ActivityItemPool.ReturnAll(false);
			}
			else
			{
				this._refreshNow = false;
			}
			this._doc.ActivityList.Clear();
			this._doc.QueryDailyActivityData();
		}

		public override void OnUnload()
		{
			this.m_Progress.Unload();
			this._doc.View = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_Progress.Update(Time.deltaTime);
		}

		public void SetCurrentExpAmi()
		{
			this.m_Progress.TargetExp = this._doc.CurrentExp;
			this.m_TotalExpTween.SetNumberWithTween((ulong)this._doc.CurrentExp, "", false, true);
			this.m_WeekExpTween.SetNumberWithTween((ulong)this._doc.WeekExp, "", false, true);
		}

		public void ChangeChestProgressState(bool init = false)
		{
			for (int i = 0; i < this._doc.ChestCount; i++)
			{
				XChest xchest = this.m_Progress.ChestList[i];
				if (init)
				{
					xchest.SetExp(this._doc.ChestExps[i]);
				}
				xchest.Opened = this._doc.IsChestOpend((uint)i);
			}
			if (init)
			{
				this.m_Progress.SetExp(0U, this._doc.MaxExp);
			}
		}

		public void RefreshPage()
		{
			this.SetWeedAwardExp();
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this._scrollView.SetPosition(0f);
			bool flag = !this._refreshNow;
			if (flag)
			{
				this._refreshNow = true;
				this.m_ActivityItemPool.ReturnAll(false);
			}
			for (int i = 0; i < this._doc.ActivityList.Count; i++)
			{
				GameObject gameObject = this.m_ActivityItemPool.FetchGameObject(true);
				gameObject.transform.localPosition = new Vector3(this.m_ActivityItemPool.TplPos.x, this.m_ActivityItemPool.TplPos.y - (float)(i * this.m_ActivityItemPool.TplHeight), this.m_ActivityItemPool.TplPos.z);
				this._UpdateActivityState(gameObject, i);
			}
		}

		private void _UpdateActivityState(GameObject go, int index)
		{
			XDailyActivity xdailyActivity = this._doc.ActivityList[index];
			ActivityTable.RowData activityBasicInfo = this._doc.GetActivityBasicInfo(xdailyActivity.id);
			bool flag = activityBasicInfo == null;
			if (flag)
			{
				go.SetActive(false);
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find DailyActivity ID ", xdailyActivity.id.ToString(), ", Skip it", null, null, null);
			}
			else
			{
				IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = go.transform.FindChild("Description").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = go.transform.FindChild("Exp").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = go.transform.FindChild("HuoyueBi").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = go.transform.FindChild("Progress").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = go.transform.FindChild("Finish").GetComponent("XUISprite") as IXUISprite;
				IXUIButton ixuibutton = go.transform.FindChild("Go").GetComponent("XUIButton") as IXUIButton;
				GameObject gameObject = go.transform.FindChild("Bg").gameObject;
				GameObject gameObject2 = go.transform.FindChild("BgHighight").gameObject;
				gameObject.SetActive(activityBasicInfo.random == 0U);
				gameObject2.SetActive(activityBasicInfo.random > 0U);
				ixuilabel.SetText(activityBasicInfo.title);
				ixuilabel2.SetText(activityBasicInfo.name);
				bool active = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow);
				ixuilabel4.gameObject.SetActive(active);
				ixuilabel3.SetText(string.Format("+{0}", activityBasicInfo.value));
				ixuilabel4.SetText("+" + activityBasicInfo.item[0, 1]);
				ixuisprite.SetSprite(activityBasicInfo.icon);
				ixuilabel5.SetVisible(!xdailyActivity.finish);
				ixuisprite2.SetVisible(xdailyActivity.finish);
				ixuibutton.SetVisible(!xdailyActivity.finish);
				bool flag2 = !xdailyActivity.finish;
				if (flag2)
				{
					ixuilabel5.SetText(string.Format("{0}/{1}", xdailyActivity.currentCount, xdailyActivity.requiredCount));
					IXUIButton ixuibutton2 = go.transform.FindChild("Go").GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.ID = (ulong)((long)index);
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBtnClicked));
				}
			}
		}

		private void OnChestClicked(IXUISprite iSp)
		{
			uint num = (uint)iSp.ID;
			bool flag = this.m_Progress.IsExpEnough((int)num) && !this._doc.IsChestOpend(num);
			if (flag)
			{
				this._doc.ReqFetchChest(num);
			}
			else
			{
				this.ShowReward(num, iSp);
			}
		}

		private void OnWeekAwardBoxClicked(IXUISprite iSp)
		{
			uint num = (uint)iSp.ID;
			uint num2 = num - (uint)this._doc.ChestExps.Count;
			bool flag = (ulong)num2 < (ulong)((long)this._doc.WeekExps.Count) && num2 >= 0U;
			if (flag)
			{
				bool flag2 = !this._doc.IsChestOpend(num) && this._doc.WeekExp >= this._doc.WeekExps[(int)num2];
				if (flag2)
				{
					this._doc.ReqFetchChest(num);
				}
				else
				{
					this.ShowReward(num, iSp);
				}
			}
		}

		public void ShowReward(uint index, IXUISprite iSp)
		{
			this._doc.GetChestReward(index);
			List<uint> list = new List<uint>();
			List<uint> list2 = new List<uint>();
			for (int i = 0; i < this._doc.Reward.Count; i++)
			{
				list.Add(this._doc.Reward[i, 0]);
				list2.Add(this._doc.Reward[i, 1]);
			}
			DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.Show(list, list2, false);
			DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.SetGlobalPosition(iSp.gameObject.transform.position);
		}

		public void OnChestFetched(uint index)
		{
			bool flag = (ulong)index < (ulong)((long)this.m_Progress.ChestList.Count);
			if (flag)
			{
				this.m_Progress.ChestList[(int)index].Open();
			}
			else
			{
				bool flag2 = (ulong)index - (ulong)((long)this.m_Progress.ChestList.Count) < (ulong)((long)this._doc.WeekExps.Count);
				if (flag2)
				{
					this.SetWeedAwardExp();
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("activity chest index is out of range!", null, null, null, null, null);
				}
			}
		}

		private bool OnGoBtnClicked(IXUIButton btn)
		{
			bool flag = (int)btn.ID >= this._doc.ActivityList.Count;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<RewardSystemDlg, TabDlgBehaviour>.singleton.Close(false);
				uint num = this._doc.ActivityList[(int)btn.ID].sysID;
				bool flag2 = (ulong)num > (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Num));
				if (flag2)
				{
					num %= 10000U;
				}
				XSysDefine xsysDefine = (XSysDefine)num;
				XSysDefine xsysDefine2 = xsysDefine;
				if (xsysDefine2 != XSysDefine.XSys_GuildRelax_VoiceQA)
				{
					if (xsysDefine2 != XSysDefine.XSys_GuildDailyTask)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
					}
					else
					{
						XSingleton<UIManager>.singleton.CloseAllUI();
						XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
					}
				}
				else
				{
					DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Activity);
				}
				result = true;
			}
			return result;
		}

		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public static string TEXTUREPATH = "atlas/UI/Battle/minimap/";

		private XDailyActivitiesDocument _doc = null;

		private IXUIScrollView _scrollView;

		private XChestProgress m_Progress;

		private IXUILabel totalExp;

		private XNumberTween m_TotalExpTween;

		private IXUILabel m_WeekExp;

		private XNumberTween m_WeekExpTween;

		private IXUILabel m_WeekAward1;

		private IXUILabel m_WeekAward2;

		private IXUISprite m_WeekAwardBox1;

		private IXUISprite m_WeekAwardBox2;

		private IXUISprite m_WeekAwardBox1Redpoint;

		private IXUISprite m_WeekAwardBox2Redpoint;

		private GameObject m_WeekAward1Get;

		private GameObject m_WeekAward2Get;

		private GameObject m_WeekAwardFx1;

		private GameObject m_WeekAwardFx2;

		private bool _refreshNow = true;

		private static readonly uint ExpIncreaseSpeed = 80U;
	}
}
