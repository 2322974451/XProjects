using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018EA RID: 6378
	public class XWelfareNiceGirlHandler : DlgHandlerBase
	{
		// Token: 0x17003A81 RID: 14977
		// (get) Token: 0x060109C7 RID: 68039 RVA: 0x00419F58 File Offset: 0x00418158
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/XWelfareNiceGirlHandler";
			}
		}

		// Token: 0x060109C8 RID: 68040 RVA: 0x00419F6F File Offset: 0x0041816F
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x060109C9 RID: 68041 RVA: 0x00419F80 File Offset: 0x00418180
		protected override void OnShow()
		{
			base.OnShow();
			XWelfareDocument.Doc.ArgentaMainInterfaceState = false;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Welfare_NiceGirl, true);
			XWelfareDocument.Doc.SendArgentaActivityInfo(1U, 0U);
		}

		// Token: 0x060109CA RID: 68042 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x060109CB RID: 68043 RVA: 0x00419FB4 File Offset: 0x004181B4
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshRedPoint();
			bool flag = this._curBlessType == XWelfareNiceGirlHandler.BlessType.DialyGift;
			if (flag)
			{
				bool bChecked = this._dailyCheck.bChecked;
				if (bChecked)
				{
					this.RefreshScorllViewContent();
				}
				else
				{
					this._dailyCheck.bChecked = true;
				}
			}
			bool flag2 = this._curBlessType == XWelfareNiceGirlHandler.BlessType.SpecialGift;
			if (flag2)
			{
				bool bChecked2 = this._specialCheck.bChecked;
				if (bChecked2)
				{
					this.RefreshScorllViewContent();
				}
				else
				{
					this._specialCheck.bChecked = true;
				}
			}
		}

		// Token: 0x060109CC RID: 68044 RVA: 0x0041A040 File Offset: 0x00418240
		private void RefreshScorllViewContent()
		{
			this._dailyGiftRoot.gameObject.SetActive(this._curBlessType == XWelfareNiceGirlHandler.BlessType.DialyGift);
			this._specialGiftRoot.gameObject.SetActive(this._curBlessType == XWelfareNiceGirlHandler.BlessType.SpecialGift);
			bool flag = this._curBlessType == XWelfareNiceGirlHandler.BlessType.DialyGift;
			if (flag)
			{
				int argentDailyDataCount = XWelfareDocument.Doc.GetArgentDailyDataCount();
				this._dailyWrapContent.SetContentCount(argentDailyDataCount, false);
				this._dailyScrollView.ResetPosition();
			}
			else
			{
				XTempActivityDocument.Doc.SortActivityTaskByType(7U);
				int activityTaskCountByType = XTempActivityDocument.Doc.GetActivityTaskCountByType(7U);
				this._specailWrapContent.SetContentCount(activityTaskCountByType, false);
				this._specialScrollView.ResetPosition();
			}
		}

		// Token: 0x060109CD RID: 68045 RVA: 0x0041A0EC File Offset: 0x004182EC
		private void InitProperties()
		{
			this._CDRewards = (base.transform.Find("CDRewards").GetComponent("XUILabel") as IXUILabel);
			this._dailyGiftRoot = base.transform.Find("DailyGift");
			this._specialGiftRoot = base.transform.Find("SpecialGift");
			this._dailyCheck = (base.transform.Find("buttons/SelectNormal").GetComponent("XUICheckBox") as IXUICheckBox);
			this._dailyCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabChecked));
			this._dailyCheck.ID = 0UL;
			this._specialCheck = (base.transform.Find("buttons/SelectPerfect").GetComponent("XUICheckBox") as IXUICheckBox);
			this._specialCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabChecked));
			this._specialCheck.ID = 1UL;
			this._dailyWrapContent = (this._dailyGiftRoot.Find("RightView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._dailyScrollView = (this._dailyGiftRoot.Find("RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._specailWrapContent = (this._specialGiftRoot.Find("RightView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._specialScrollView = (this._dailyGiftRoot.Find("RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._dailyWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.DailyGiftContentInit));
			this._dailyWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DailyGiftContentUpdate));
			this._specailWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.SpecialGiftContentUpdate));
			this._specailWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.SpecialGiftContentInit));
		}

		// Token: 0x060109CE RID: 68046 RVA: 0x0041A2D8 File Offset: 0x004184D8
		private void RefreshRedPoint()
		{
			Transform transform = base.transform.Find("buttons/SelectNormal/redpoint");
			Transform transform2 = base.transform.Find("buttons/SelectPerfect/redpoint");
			transform.gameObject.SetActive(XWelfareDocument.Doc.GetDailyGiftRedPoint());
			transform2.gameObject.SetActive(XWelfareDocument.Doc.GetSpecialGiftRedPoint());
		}

		// Token: 0x060109CF RID: 68047 RVA: 0x0041A334 File Offset: 0x00418534
		private void WrapContentUpdate(Transform itemTransform, int index)
		{
			bool flag = this._curBlessType == XWelfareNiceGirlHandler.BlessType.DialyGift;
			if (flag)
			{
				this.DailyGiftContentUpdate(itemTransform, index);
			}
			else
			{
				this.SpecialGiftContentUpdate(itemTransform, index);
			}
		}

		// Token: 0x060109D0 RID: 68048 RVA: 0x0041A364 File Offset: 0x00418564
		private void SpecialGiftContentUpdate(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("OperateBtn").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = itemTransform.Find("TaskName").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = itemTransform.Find("Progress").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = itemTransform.Find("OperateBtn/Text").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = itemTransform.Find("TaskIcon").GetComponent("XUISprite") as IXUISprite;
			Transform transform = itemTransform.Find("Items");
			Transform transform2 = itemTransform.Find("HadGet");
			SpActivityTask activityTaskInfoByIndex = XTempActivityDocument.Doc.GetActivityTaskInfoByIndex(7U, index);
			bool flag = activityTaskInfoByIndex != null;
			if (flag)
			{
				ixuibutton.gameObject.SetActive(true);
				ixuibutton.ID = (ulong)activityTaskInfoByIndex.taskid;
				transform2.gameObject.SetActive(false);
				bool flag2 = activityTaskInfoByIndex.state == 0U;
				if (flag2)
				{
					ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("PVPActivity_Go"));
				}
				else
				{
					bool flag3 = activityTaskInfoByIndex.state == 1U;
					if (flag3)
					{
						ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("SRS_FETCH"));
					}
					else
					{
						ixuibutton.gameObject.SetActive(false);
						transform2.gameObject.SetActive(true);
					}
				}
				int num = 1;
				SuperActivityTask.RowData dataByActivityByTypeID = XTempActivityDocument.Doc.GetDataByActivityByTypeID(7U, activityTaskInfoByIndex.taskid);
				bool flag4 = dataByActivityByTypeID != null;
				if (flag4)
				{
					num = dataByActivityByTypeID.cnt;
					ixuisprite.SetSprite(dataByActivityByTypeID.icon);
					ixuilabel.SetText(dataByActivityByTypeID.title);
				}
				ixuilabel2.SetText(string.Format("{0}/{1}", activityTaskInfoByIndex.progress, num));
				SeqListRef<uint>? argentTaskRewards = XWelfareDocument.Doc.GetArgentTaskRewards(activityTaskInfoByIndex.taskid);
				int i = 0;
				bool flag5 = argentTaskRewards != null;
				if (flag5)
				{
					int num2 = Mathf.Min((int)argentTaskRewards.Value.count, transform.childCount);
					while (i < num2)
					{
						Transform child = transform.GetChild(i);
						child.gameObject.SetActive(true);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(child.gameObject, (int)argentTaskRewards.Value[i, 0], (int)argentTaskRewards.Value[i, 1], true);
						IXUISprite ixuisprite2 = child.gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)argentTaskRewards.Value[i, 0];
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						i++;
					}
				}
				while (i < transform.childCount)
				{
					transform.GetChild(i++).gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x060109D1 RID: 68049 RVA: 0x0041A67C File Offset: 0x0041887C
		private void DailyGiftContentUpdate(Transform itemTransform, int index)
		{
			Transform transform = itemTransform.Find("HadGet");
			Transform transform2 = itemTransform.Find("Items");
			IXUIButton ixuibutton = itemTransform.Find("GetBtn").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = itemTransform.Find("Title").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = itemTransform.Find("desc").GetComponent("XUILabel") as IXUILabel;
			ArgentaDaily.RowData argentDailyDataByIndex = XWelfareDocument.Doc.GetArgentDailyDataByIndex(index);
			bool flag = argentDailyDataByIndex != null;
			if (flag)
			{
				ixuilabel.SetText(argentDailyDataByIndex.Title);
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(argentDailyDataByIndex.Description));
				ixuibutton.ID = (ulong)argentDailyDataByIndex.ID;
				bool flag2 = XWelfareDocument.Doc.CurArgentaDailyIDList.Contains(argentDailyDataByIndex.ID);
				ixuibutton.gameObject.SetActive(!flag2);
				transform.gameObject.SetActive(flag2);
				SeqListRef<uint> reward = argentDailyDataByIndex.Reward;
				int num = Mathf.Min((int)reward.count, transform2.childCount);
				int i;
				for (i = 0; i < num; i++)
				{
					Transform child = transform2.GetChild(i);
					child.gameObject.SetActive(true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(child.gameObject, (int)reward[i, 0], (int)reward[i, 1], true);
					IXUISprite ixuisprite = child.gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)reward[i, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				while (i < transform2.childCount)
				{
					transform2.GetChild(i++).gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x060109D2 RID: 68050 RVA: 0x0041A880 File Offset: 0x00418A80
		private void WrapContentInit(Transform itemTransform, int index)
		{
			bool flag = this._curBlessType == XWelfareNiceGirlHandler.BlessType.DialyGift;
			if (flag)
			{
				this.DailyGiftContentInit(itemTransform, index);
			}
			else
			{
				this.SpecialGiftContentInit(itemTransform, index);
			}
		}

		// Token: 0x060109D3 RID: 68051 RVA: 0x0041A8B0 File Offset: 0x00418AB0
		private void DailyGiftContentInit(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("GetBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDailyBtn));
		}

		// Token: 0x060109D4 RID: 68052 RVA: 0x0041A8EC File Offset: 0x00418AEC
		private bool OnClickDailyBtn(IXUIButton button)
		{
			uint num = (uint)button.ID;
			bool flag = num > 0U;
			if (flag)
			{
				XWelfareDocument.Doc.SendArgentaActivityInfo(2U, num);
			}
			return true;
		}

		// Token: 0x060109D5 RID: 68053 RVA: 0x0041A91C File Offset: 0x00418B1C
		private void SpecialGiftContentInit(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("OperateBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickOperateBtn));
		}

		// Token: 0x060109D6 RID: 68054 RVA: 0x0041A958 File Offset: 0x00418B58
		private bool OnClickOperateBtn(IXUIButton button)
		{
			uint num = (uint)button.ID;
			uint activityState = XTempActivityDocument.Doc.GetActivityState(7U, num);
			bool flag = activityState == 0U;
			if (flag)
			{
				SuperActivityTask.RowData[] table = XTempActivityDocument.SuperActivityTaskTable.Table;
				for (int i = 0; i < table.Length; i++)
				{
					bool flag2 = table[i].taskid == num;
					if (flag2)
					{
						SuperActivityTask.RowData rowData = table[i];
						bool flag3 = rowData.arg != null && rowData.arg.Length != 0;
						if (flag3)
						{
							bool flag4 = rowData.arg[0] == 1;
							if (flag4)
							{
								DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SelectChapter(rowData.arg[1], (uint)rowData.arg[2]);
							}
							else
							{
								bool flag5 = rowData.arg[0] == 2;
								if (flag5)
								{
									DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(rowData.arg[1]);
								}
							}
						}
						else
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem((int)rowData.jump);
						}
						return true;
					}
				}
			}
			else
			{
				XTempActivityDocument.Doc.GetActivityAwards(7U, num);
			}
			return true;
		}

		// Token: 0x060109D7 RID: 68055 RVA: 0x0041AA7C File Offset: 0x00418C7C
		private bool OnTabChecked(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._curBlessType = (XWelfareNiceGirlHandler.BlessType)iXUICheckBox.ID;
				this.RefreshScorllViewContent();
				result = true;
			}
			return result;
		}

		// Token: 0x060109D8 RID: 68056 RVA: 0x0041AAB4 File Offset: 0x00418CB4
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.SetRewardLeftTime();
		}

		// Token: 0x060109D9 RID: 68057 RVA: 0x0041AAC8 File Offset: 0x00418CC8
		private void SetRewardLeftTime()
		{
			int num = (int)(XWelfareDocument.Doc.ActivityLeftTime - (uint)((int)Time.realtimeSinceStartup));
			bool flag = num >= 1;
			if (flag)
			{
				this._CDRewards.gameObject.SetActive(true);
				string str = string.Format(XSingleton<XStringTable>.singleton.GetString("MulActivity_Tips2"), ":");
				bool flag2 = num >= 43200;
				if (flag2)
				{
					this._CDRewards.SetText(str + XSingleton<UiUtility>.singleton.TimeDuarationFormatString(num, 4));
				}
				else
				{
					this._CDRewards.SetText(str + XSingleton<UiUtility>.singleton.TimeDuarationFormatString(num, 5));
				}
			}
			else
			{
				this._CDRewards.gameObject.SetActive(false);
			}
		}

		// Token: 0x040078CE RID: 30926
		private IXUIWrapContent _dailyWrapContent = null;

		// Token: 0x040078CF RID: 30927
		private IXUIWrapContent _specailWrapContent = null;

		// Token: 0x040078D0 RID: 30928
		private XWelfareNiceGirlHandler.BlessType _curBlessType = XWelfareNiceGirlHandler.BlessType.DialyGift;

		// Token: 0x040078D1 RID: 30929
		private Transform _dailyGiftRoot;

		// Token: 0x040078D2 RID: 30930
		private Transform _specialGiftRoot;

		// Token: 0x040078D3 RID: 30931
		private IXUIScrollView _dailyScrollView;

		// Token: 0x040078D4 RID: 30932
		private IXUIScrollView _specialScrollView;

		// Token: 0x040078D5 RID: 30933
		private IXUILabel _CDRewards;

		// Token: 0x040078D6 RID: 30934
		private IXUICheckBox _dailyCheck;

		// Token: 0x040078D7 RID: 30935
		private IXUICheckBox _specialCheck;

		// Token: 0x02001A1C RID: 6684
		private enum BlessType
		{
			// Token: 0x04008266 RID: 33382
			DialyGift,
			// Token: 0x04008267 RID: 33383
			SpecialGift
		}
	}
}
