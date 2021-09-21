using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001881 RID: 6273
	internal class XWheelOfFortuneHandler : DlgHandlerBase
	{
		// Token: 0x0601051E RID: 66846 RVA: 0x003F3E4C File Offset: 0x003F204C
		protected override void Init()
		{
			base.Init();
			this.DIRECTION = XSingleton<XGlobalConfig>.singleton.GetInt("WheelOfFortuneDirection");
			this.CIRCLE_DEGREE = 360 * this.DIRECTION;
			this.FIRST_STAGE_DEGREE = (int)(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WheelOfFortuneFirstStageDegree")) * (float)this.CIRCLE_DEGREE);
			this.SECOND_STAGE_DEGREE = (int)(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WheelOfFortuneSecondStageDegree")) * (float)this.CIRCLE_DEGREE);
			this.RESULT_STAY_TIME = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WheelOfFortuneResultStayTime"));
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XCharacterItemDocument.uuID) as XCharacterItemDocument);
			GameObject gameObject = base.PanelObject.transform.FindChild("Bg/ItemTpl").gameObject;
			GameObject gameObject2 = gameObject.transform.FindChild("Effect").gameObject;
			this.m_ItemSelector.LoadFromUI(gameObject2, base.PanelObject.transform);
			XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			xuipool.SetupPool(gameObject.transform.parent.gameObject, gameObject, (uint)XLotteryBoxItem.POOL_SIZE, false);
			for (int i = 0; i < XLotteryBoxItem.POOL_SIZE; i++)
			{
				GameObject gameObject3 = xuipool.FetchGameObject(false);
				Transform transform = base.PanelObject.transform.FindChild("Bg/Pos/Pos" + i);
				gameObject3.transform.parent = transform;
				gameObject3.transform.localPosition = Vector3.zero;
				this.m_ItemList[i] = gameObject3;
				IXUISprite ixuisprite = gameObject3.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				int num = (int)(Mathf.Atan2(transform.localPosition.y, transform.localPosition.x) * 57.29578f);
				bool flag = this.DIRECTION * num < 0;
				if (flag)
				{
					num += this.CIRCLE_DEGREE;
				}
				this.m_DegreeList[i] = num;
				this.m_IndexMap[i] = i;
				this.m_DataList[i] = new XNormalItem();
			}
			this.m_Arrow = base.PanelObject.transform.FindChild("Bg/Arrow").gameObject;
			this.m_SpeedCurve = (this.m_Arrow.GetComponent("XCurve") as IXCurve);
			this.m_StartSpeed = this.m_SpeedCurve.Evaluate(0f) * (float)this.DIRECTION;
			this.m_BtnStart = (base.PanelObject.transform.FindChild("Bg/BtnStart").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnClose = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ShowTween = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_WheelOfFortune_fx", base.PanelObject.transform.Find("Bg/Bg/Bg"), false);
		}

		// Token: 0x0601051F RID: 66847 RVA: 0x003F4188 File Offset: 0x003F2388
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnStart.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnStartClicked));
			this.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
		}

		// Token: 0x06010520 RID: 66848 RVA: 0x003F41C2 File Offset: 0x003F23C2
		protected override void OnShow()
		{
			base.OnShow();
			this.m_State = XWheelState.WS_IDLE;
			this.ToggleOperation(false, false);
			this.m_ShowTween.PlayTween(true, -1f);
			this.m_ItemSelector.Hide();
			this.m_ResultStayTimerToken = 0U;
		}

		// Token: 0x06010521 RID: 66849 RVA: 0x003F4201 File Offset: 0x003F2401
		protected override void OnHide()
		{
			this._doc.ToggleBlock(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ResultStayTimerToken);
			base.OnHide();
		}

		// Token: 0x06010522 RID: 66850 RVA: 0x003F422C File Offset: 0x003F242C
		public override void OnUnload()
		{
			this._doc.ToggleBlock(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ResultStayTimerToken);
			this.m_ItemSelector.Unload();
			bool flag = this.m_Fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fx, true);
			}
			this.m_Fx = null;
			base.OnUnload();
		}

		// Token: 0x06010523 RID: 66851 RVA: 0x003F4294 File Offset: 0x003F2494
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_State == XWheelState.WS_IDLE || this.m_State == XWheelState.WS_DONE;
			if (!flag)
			{
				bool flag2 = this.m_State == XWheelState.WS_DOING_FIRST_STAGE;
				if (flag2)
				{
					this.m_CurrentSpeed = this.m_StartSpeed;
				}
				else
				{
					this.m_CurrentSpeed = this.m_SpeedCurve.Evaluate((this.m_CurrentDegree - this.m_StartDecSpeedDegree) / this.m_DecSpeedDegreeLength) * (float)this.DIRECTION;
				}
				this.m_CurrentDegree += this.m_CurrentSpeed * Time.deltaTime;
				bool flag3 = this.m_State == XWheelState.WS_DOING_FIRST_STAGE && this.m_CurrentDegree * (float)this.DIRECTION > this.m_StartDecSpeedDegree * (float)this.DIRECTION;
				if (flag3)
				{
					this.m_State = XWheelState.WS_DOING_SECOND_STAGE;
				}
				bool flag4 = this.m_CurrentDegree * (float)this.DIRECTION >= (float)(this.m_TargetDegree * this.DIRECTION);
				if (flag4)
				{
					this.m_CurrentDegree = (float)this.m_TargetDegree;
					this.m_State = XWheelState.WS_DONE;
					this._FinishDoing();
				}
				this.m_Arrow.transform.localRotation = Quaternion.AngleAxis(this.m_CurrentDegree, Vector3.forward);
			}
		}

		// Token: 0x06010524 RID: 66852 RVA: 0x003F43C8 File Offset: 0x003F25C8
		private void _FinishDoing()
		{
			this._doc.ToggleBlock(false);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.m_DataList[this.m_TargetIndex].itemID);
			GameObject gameObject = this.m_ItemList[this.m_TargetIndex].transform.FindChild("Icon").gameObject;
			bool flag = itemConf != null;
			if (flag)
			{
				IXUISprite ixuisprite = this.m_ItemSelector.Effects.transform.FindChild("Anim").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor((int)itemConf.ItemQuality));
				this.m_ItemSelector.Select(gameObject);
			}
			this.m_ResultStayTimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(this.RESULT_STAY_TIME, new XTimerMgr.ElapsedEventHandler(this._FinishStay), null);
		}

		// Token: 0x06010525 RID: 66853 RVA: 0x003F4498 File Offset: 0x003F2698
		private void _FinishStay(object o)
		{
			this.m_ResultStayTimerToken = 0U;
			base.SetVisible(false);
		}

		// Token: 0x06010526 RID: 66854 RVA: 0x003F44AC File Offset: 0x003F26AC
		private void _RandomPosition()
		{
			for (int i = 0; i < XLotteryBoxItem.POOL_SIZE; i++)
			{
				int num = XSingleton<XCommon>.singleton.RandomInt(i, XLotteryBoxItem.POOL_SIZE);
				int num2 = this.m_IndexMap[num];
				this.m_IndexMap[num] = this.m_IndexMap[i];
				this.m_IndexMap[i] = num2;
			}
		}

		// Token: 0x06010527 RID: 66855 RVA: 0x003F4504 File Offset: 0x003F2704
		public void OpenWheel(XLotteryBoxItem item)
		{
			base.SetVisible(true);
			this._RandomPosition();
			for (int i = 0; i < XLotteryBoxItem.POOL_SIZE; i++)
			{
				int num = this.m_IndexMap[i];
				this.m_DataList[num].itemID = item.itemList[i].itemID;
				this.m_DataList[num].itemCount = item.itemList[i].itemCount;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_ItemList[num], this.m_DataList[num].itemID, this.m_DataList[num].itemCount, false);
			}
			this.m_ItemUID = item.uid;
		}

		// Token: 0x06010528 RID: 66856 RVA: 0x003F45B8 File Offset: 0x003F27B8
		public void ShowResult(int targetIndex)
		{
			this.ToggleOperation(true, true);
			this.m_TargetIndex = this.m_IndexMap[targetIndex];
			this.m_TargetDegree = XWheelOfFortuneHandler.START_DEGREE + this.FIRST_STAGE_DEGREE + this.SECOND_STAGE_DEGREE;
			this.m_StartDecSpeedDegree = (float)(XWheelOfFortuneHandler.START_DEGREE + this.FIRST_STAGE_DEGREE);
			this.m_DecSpeedDegreeLength = (float)this.SECOND_STAGE_DEGREE;
			int num = this.m_TargetDegree % this.CIRCLE_DEGREE;
			int num2 = this.m_DegreeList[this.m_TargetIndex];
			bool flag = (num2 - num) * this.DIRECTION < 0;
			if (flag)
			{
				num2 += this.CIRCLE_DEGREE;
			}
			int num3 = num2 - num;
			this.m_DecSpeedDegreeLength += (float)num3;
			this.m_TargetDegree += num3;
			this.m_State = XWheelState.WS_DOING_FIRST_STAGE;
			this.m_CurrentDegree = (float)XWheelOfFortuneHandler.START_DEGREE;
		}

		// Token: 0x06010529 RID: 66857 RVA: 0x003F4682 File Offset: 0x003F2882
		public void ToggleOperation(bool bBlockClose, bool bBlockStart)
		{
			this.m_BtnClose.SetVisible(!bBlockClose);
			this.m_BtnStart.SetVisible(!bBlockStart);
		}

		// Token: 0x0601052A RID: 66858 RVA: 0x003F46A8 File Offset: 0x003F28A8
		private void _OnItemClicked(IXUISprite icon)
		{
			int num = (int)icon.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(this.m_DataList[num].itemID, icon, 0U);
		}

		// Token: 0x0601052B RID: 66859 RVA: 0x003F46D8 File Offset: 0x003F28D8
		private bool _OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0601052C RID: 66860 RVA: 0x003F46F4 File Offset: 0x003F28F4
		private bool _OnStartClicked(IXUIButton btn)
		{
			this._doc.UseItem(this.m_ItemUID);
			return true;
		}

		// Token: 0x04007575 RID: 30069
		private static int START_DEGREE = 90;

		// Token: 0x04007576 RID: 30070
		private int DIRECTION = -1;

		// Token: 0x04007577 RID: 30071
		private int CIRCLE_DEGREE = 360;

		// Token: 0x04007578 RID: 30072
		private int FIRST_STAGE_DEGREE = 10;

		// Token: 0x04007579 RID: 30073
		private int SECOND_STAGE_DEGREE = 3;

		// Token: 0x0400757A RID: 30074
		private float RESULT_STAY_TIME = 1.5f;

		// Token: 0x0400757B RID: 30075
		private XCharacterItemDocument _doc;

		// Token: 0x0400757C RID: 30076
		private GameObject m_Arrow;

		// Token: 0x0400757D RID: 30077
		private IXCurve m_SpeedCurve;

		// Token: 0x0400757E RID: 30078
		private IXUIButton m_BtnStart;

		// Token: 0x0400757F RID: 30079
		private IXUIButton m_BtnClose;

		// Token: 0x04007580 RID: 30080
		private IXUITweenTool m_ShowTween;

		// Token: 0x04007581 RID: 30081
		private float m_StartSpeed;

		// Token: 0x04007582 RID: 30082
		private int[] m_IndexMap = new int[XLotteryBoxItem.POOL_SIZE];

		// Token: 0x04007583 RID: 30083
		private GameObject[] m_ItemList = new GameObject[XLotteryBoxItem.POOL_SIZE];

		// Token: 0x04007584 RID: 30084
		private int[] m_DegreeList = new int[XLotteryBoxItem.POOL_SIZE];

		// Token: 0x04007585 RID: 30085
		private XItem[] m_DataList = new XItem[XLotteryBoxItem.POOL_SIZE];

		// Token: 0x04007586 RID: 30086
		private int m_TargetIndex;

		// Token: 0x04007587 RID: 30087
		private int m_TargetDegree;

		// Token: 0x04007588 RID: 30088
		private XWheelState m_State;

		// Token: 0x04007589 RID: 30089
		private float m_CurrentDegree;

		// Token: 0x0400758A RID: 30090
		private float m_CurrentSpeed;

		// Token: 0x0400758B RID: 30091
		private float m_StartDecSpeedDegree;

		// Token: 0x0400758C RID: 30092
		private float m_DecSpeedDegreeLength;

		// Token: 0x0400758D RID: 30093
		private uint m_ResultStayTimerToken = 0U;

		// Token: 0x0400758E RID: 30094
		private ulong m_ItemUID;

		// Token: 0x0400758F RID: 30095
		private XItemSelector m_ItemSelector = new XItemSelector(0U);

		// Token: 0x04007590 RID: 30096
		private XFx m_Fx = null;
	}
}
