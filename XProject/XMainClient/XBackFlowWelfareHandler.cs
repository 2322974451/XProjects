using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowWelfareHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfBannerHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

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

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		public void PlayDogEffect()
		{
			bool flag = this._effect != null;
			if (flag)
			{
				this._effect.SetActive(true);
				this._effect.Play();
			}
		}

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

		private void OnGetDog(IXUISprite uiSprite)
		{
			bool flag = this._taskID > 0U;
			if (flag)
			{
				XTempActivityDocument.Doc.GetActivityAwards(5U, this._taskID);
			}
		}

		private IXUITexture _bgTexture;

		protected XUIPool _dayPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private uint _totalDays;

		private uint _taskID;

		private IXUIProgress _dayProgress;

		private IXUISprite _dayProgressSprite;

		private GameObject _ChestObj;

		private GameObject _gettedObj;

		private Color _labelColor;

		private XFx _effect;
	}
}
