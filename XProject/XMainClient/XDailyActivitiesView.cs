using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F0F RID: 3855
	internal class XDailyActivitiesView : DlgHandlerBase
	{
		// Token: 0x17003597 RID: 13719
		// (get) Token: 0x0600CC8C RID: 52364 RVA: 0x002F17B8 File Offset: 0x002EF9B8
		protected override string FileName
		{
			get
			{
				return "GameSystem/DailyActivity/LivenessActivityFrame";
			}
		}

		// Token: 0x0600CC8D RID: 52365 RVA: 0x002F17D0 File Offset: 0x002EF9D0
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

		// Token: 0x0600CC8E RID: 52366 RVA: 0x002F1B70 File Offset: 0x002EFD70
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

		// Token: 0x0600CC8F RID: 52367 RVA: 0x002F1C4A File Offset: 0x002EFE4A
		protected override void OnShow()
		{
			base.OnShow();
			this.InitView(true);
			this.SetWeedAwardExp();
		}

		// Token: 0x0600CC90 RID: 52368 RVA: 0x002F1C64 File Offset: 0x002EFE64
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

		// Token: 0x0600CC91 RID: 52369 RVA: 0x002F1E19 File Offset: 0x002F0019
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.InitView(false);
			this.SetWeedAwardExp();
		}

		// Token: 0x0600CC92 RID: 52370 RVA: 0x002F1E34 File Offset: 0x002F0034
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

		// Token: 0x0600CC93 RID: 52371 RVA: 0x002F1E7A File Offset: 0x002F007A
		public override void OnUnload()
		{
			this.m_Progress.Unload();
			this._doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600CC94 RID: 52372 RVA: 0x002F1E9D File Offset: 0x002F009D
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_Progress.Update(Time.deltaTime);
		}

		// Token: 0x0600CC95 RID: 52373 RVA: 0x002F1EB8 File Offset: 0x002F00B8
		public void SetCurrentExpAmi()
		{
			this.m_Progress.TargetExp = this._doc.CurrentExp;
			this.m_TotalExpTween.SetNumberWithTween((ulong)this._doc.CurrentExp, "", false, true);
			this.m_WeekExpTween.SetNumberWithTween((ulong)this._doc.WeekExp, "", false, true);
		}

		// Token: 0x0600CC96 RID: 52374 RVA: 0x002F1F1C File Offset: 0x002F011C
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

		// Token: 0x0600CC97 RID: 52375 RVA: 0x002F1FA8 File Offset: 0x002F01A8
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

		// Token: 0x0600CC98 RID: 52376 RVA: 0x002F208C File Offset: 0x002F028C
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

		// Token: 0x0600CC99 RID: 52377 RVA: 0x002F2380 File Offset: 0x002F0580
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

		// Token: 0x0600CC9A RID: 52378 RVA: 0x002F23D4 File Offset: 0x002F05D4
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

		// Token: 0x0600CC9B RID: 52379 RVA: 0x002F2470 File Offset: 0x002F0670
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

		// Token: 0x0600CC9C RID: 52380 RVA: 0x002F2514 File Offset: 0x002F0714
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

		// Token: 0x0600CC9D RID: 52381 RVA: 0x002F25A4 File Offset: 0x002F07A4
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

		// Token: 0x04005AF0 RID: 23280
		public XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005AF1 RID: 23281
		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005AF2 RID: 23282
		public static string TEXTUREPATH = "atlas/UI/Battle/minimap/";

		// Token: 0x04005AF3 RID: 23283
		private XDailyActivitiesDocument _doc = null;

		// Token: 0x04005AF4 RID: 23284
		private IXUIScrollView _scrollView;

		// Token: 0x04005AF5 RID: 23285
		private XChestProgress m_Progress;

		// Token: 0x04005AF6 RID: 23286
		private IXUILabel totalExp;

		// Token: 0x04005AF7 RID: 23287
		private XNumberTween m_TotalExpTween;

		// Token: 0x04005AF8 RID: 23288
		private IXUILabel m_WeekExp;

		// Token: 0x04005AF9 RID: 23289
		private XNumberTween m_WeekExpTween;

		// Token: 0x04005AFA RID: 23290
		private IXUILabel m_WeekAward1;

		// Token: 0x04005AFB RID: 23291
		private IXUILabel m_WeekAward2;

		// Token: 0x04005AFC RID: 23292
		private IXUISprite m_WeekAwardBox1;

		// Token: 0x04005AFD RID: 23293
		private IXUISprite m_WeekAwardBox2;

		// Token: 0x04005AFE RID: 23294
		private IXUISprite m_WeekAwardBox1Redpoint;

		// Token: 0x04005AFF RID: 23295
		private IXUISprite m_WeekAwardBox2Redpoint;

		// Token: 0x04005B00 RID: 23296
		private GameObject m_WeekAward1Get;

		// Token: 0x04005B01 RID: 23297
		private GameObject m_WeekAward2Get;

		// Token: 0x04005B02 RID: 23298
		private GameObject m_WeekAwardFx1;

		// Token: 0x04005B03 RID: 23299
		private GameObject m_WeekAwardFx2;

		// Token: 0x04005B04 RID: 23300
		private bool _refreshNow = true;

		// Token: 0x04005B05 RID: 23301
		private static readonly uint ExpIncreaseSpeed = 80U;
	}
}
