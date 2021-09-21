using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A20 RID: 2592
	internal class XBackFlowWelfareHandler : DlgHandlerBase
	{
		// Token: 0x17002EBF RID: 11967
		// (get) Token: 0x06009E7C RID: 40572 RVA: 0x001A0B20 File Offset: 0x0019ED20
		protected override string FileName
		{
			get
			{
				return "Hall/BfBannerHandler";
			}
		}

		// Token: 0x06009E7D RID: 40573 RVA: 0x001A0B38 File Offset: 0x0019ED38
		protected override void Init()
		{
			base.Init();
			this._bgTexture = (base.transform.Find("banner").GetComponent("XUITexture") as IXUITexture);
			this._bgTexture.SetTexturePath("atlas/UI/GameSystem/Activity/Tex_HuiliuBanner_h2Split");
			Transform transform = base.transform.Find("Day/Daytpl");
			this._dayPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this._dayProgress = (base.transform.Find("Progress").GetComponent("XUIProgress") as IXUIProgress);
			this._dayProgressSprite = (base.transform.Find("Progress").GetComponent("XUISprite") as IXUISprite);
			this._ChestObj = base.transform.Find("Chest").gameObject;
			IXUISprite ixuisprite = this._ChestObj.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetDog));
			this._gettedObj = base.transform.Find("Getted").gameObject;
			this._labelColor = (base.transform.Find("Day/Daytpl/num").GetComponent("XUILabel") as IXUILabel).GetColor();
			this._effect = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BfBannerHandler_fx", this._ChestObj.transform, false);
			this._effect.SetActive(false);
		}

		// Token: 0x06009E7E RID: 40574 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E7F RID: 40575 RVA: 0x001A0CB4 File Offset: 0x0019EEB4
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		// Token: 0x06009E80 RID: 40576 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E81 RID: 40577 RVA: 0x001A0CC8 File Offset: 0x0019EEC8
		public override void OnUnload()
		{
			bool flag = this._effect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._effect, true);
			}
			this._effect = null;
			base.OnUnload();
		}

		// Token: 0x06009E82 RID: 40578 RVA: 0x001A0D03 File Offset: 0x0019EF03
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		// Token: 0x06009E83 RID: 40579 RVA: 0x001A0D14 File Offset: 0x0019EF14
		public void PlayDogEffect()
		{
			bool flag = this._effect != null;
			if (flag)
			{
				this._effect.SetActive(true);
				this._effect.Play();
			}
		}

		// Token: 0x06009E84 RID: 40580 RVA: 0x001A0D4C File Offset: 0x0019EF4C
		private void RefreshUI()
		{
			bool flag = this._effect != null;
			if (flag)
			{
				this._effect.SetActive(false);
			}
			this._dayPool.ReturnAll(false);
			this._taskID = XBackFlowDocument.Doc.GetBannerTaskID();
			this._totalDays = 5U;
			uint num = 0U;
			this._gettedObj.SetActive(false);
			this._ChestObj.SetActive(false);
			bool flag2 = this._taskID > 0U;
			if (flag2)
			{
				SuperActivityTask.RowData dataByActivityByTypeID = XTempActivityDocument.Doc.GetDataByActivityByTypeID(5U, this._taskID);
				bool flag3 = dataByActivityByTypeID != null;
				if (flag3)
				{
					this._totalDays = dataByActivityByTypeID.num[0];
				}
				SpActivityTask activityTaskInfo = XTempActivityDocument.Doc.GetActivityTaskInfo(5U, this._taskID);
				bool flag4 = activityTaskInfo != null;
				if (flag4)
				{
					num = activityTaskInfo.progress;
					this._gettedObj.SetActive(activityTaskInfo.state == 2U);
					IXUISprite ixuisprite = this._ChestObj.GetComponent("XUISprite") as IXUISprite;
					Transform transform = this._ChestObj.transform.Find("RedPoint");
					this._ChestObj.SetActive(activityTaskInfo.state != 2U);
					ixuisprite.SetEnabled(activityTaskInfo.state == 1U);
					transform.gameObject.SetActive(activityTaskInfo.state == 1U);
					bool flag5 = activityTaskInfo.state == 1U;
					if (flag5)
					{
						this.PlayDogEffect();
					}
					else
					{
						bool flag6 = this._effect != null;
						if (flag6)
						{
							this._effect.SetActive(false);
						}
					}
				}
			}
			float num2 = (float)this._dayProgressSprite.spriteWidth / this._totalDays;
			int num3 = 0;
			while ((long)num3 < (long)((ulong)this._totalDays))
			{
				GameObject gameObject = this._dayPool.FetchGameObject(false);
				gameObject.transform.localPosition = this._dayPool.TplPos + Vector3.right * (float)(num3 + 1) * num2;
				IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetEnabled((ulong)num >= (ulong)((long)(num3 + 1)));
				IXUILabel ixuilabel = gameObject.transform.Find("num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText((num3 + 1).ToString());
				IXUILabel ixuilabel2 = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
				bool flag7 = (ulong)num > (ulong)((long)num3);
				if (flag7)
				{
					ixuilabel2.SetColor(this._labelColor);
					ixuilabel2.Alpha = 1f;
					ixuilabel.SetColor(this._labelColor);
					ixuilabel.Alpha = 1f;
					ixuisprite2.SetColor(Color.white);
				}
				else
				{
					ixuilabel2.SetColor(Color.gray);
					ixuilabel2.Alpha = 0.5f;
					ixuilabel.SetColor(Color.gray);
					ixuilabel.Alpha = 0.5f;
					ixuisprite2.SetColor(Color.black);
				}
				num3++;
			}
			this._dayProgress.value = num / this._totalDays;
		}

		// Token: 0x06009E85 RID: 40581 RVA: 0x001A108C File Offset: 0x0019F28C
		private void OnGetDog(IXUISprite uiSprite)
		{
			bool flag = this._taskID > 0U;
			if (flag)
			{
				XTempActivityDocument.Doc.GetActivityAwards(5U, this._taskID);
			}
		}

		// Token: 0x04003840 RID: 14400
		private IXUITexture _bgTexture;

		// Token: 0x04003841 RID: 14401
		protected XUIPool _dayPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003842 RID: 14402
		private uint _totalDays;

		// Token: 0x04003843 RID: 14403
		private uint _taskID;

		// Token: 0x04003844 RID: 14404
		private IXUIProgress _dayProgress;

		// Token: 0x04003845 RID: 14405
		private IXUISprite _dayProgressSprite;

		// Token: 0x04003846 RID: 14406
		private GameObject _ChestObj;

		// Token: 0x04003847 RID: 14407
		private GameObject _gettedObj;

		// Token: 0x04003848 RID: 14408
		private Color _labelColor;

		// Token: 0x04003849 RID: 14409
		private XFx _effect;
	}
}
