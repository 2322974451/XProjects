using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200172E RID: 5934
	internal class XBuffIcon
	{
		// Token: 0x0600F508 RID: 62728 RVA: 0x003738DC File Offset: 0x00371ADC
		public void Init(GameObject go, bool bShowTime)
		{
			this.m_Go = go;
			this.m_OriginPos = go.transform.localPosition;
			this.m_uiIcon = (go.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_uiLeftTime = (go.transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_uiCount = (go.transform.Find("Count").GetComponent("XUILabel") as IXUILabel);
			this.m_Tween = (go.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_bShowTime = bShowTime;
			this.m_uiLeftTime.SetVisible(this.m_bShowTime);
			this.Hide();
		}

		// Token: 0x0600F509 RID: 62729 RVA: 0x003739A8 File Offset: 0x00371BA8
		public void Set(UIBuffInfo buffInfo)
		{
			this.m_Go.transform.localPosition = this.m_OriginPos;
			this.m_uiIcon.SetSprite(buffInfo.buffInfo.BuffIcon);
			bool flag = buffInfo.stackCount <= 1U;
			if (flag)
			{
				this.m_uiCount.SetText(string.Empty);
			}
			else
			{
				this.m_uiCount.SetText(XSingleton<XCommon>.singleton.StringCombine("[b]", buffInfo.stackCount.ToString()));
			}
			this.m_bPermernent = (buffInfo.buffInfo.BuffDuration < 0f);
			XBuffIcon.AnimState animState = XBuffIcon.AnimState.AS_NORMAL;
			bool flag2 = !this.m_bPermernent && buffInfo.leftTime <= XBuffIcon.DISAPPEAR_START_LEFT_TIME;
			if (flag2)
			{
				animState = XBuffIcon.AnimState.AS_DISAPPEARING;
			}
			bool flag3 = animState != this.m_AnimState;
			if (flag3)
			{
				this._ResetAnimState();
				XBuffIcon.AnimState animState2 = animState;
				if (animState2 == XBuffIcon.AnimState.AS_DISAPPEARING)
				{
					this._PlayStartDisappearAnim();
				}
			}
			this.m_nLeftTime = 0;
			this.m_fStartTime = buffInfo.startTime;
			this.m_fStartLeftTime = buffInfo.leftTime;
			this.m_fLeftTime = buffInfo.leftTime - (this._GetCurTime() - buffInfo.startTime);
			this.m_bActive = true;
			this._UpdateTime();
		}

		// Token: 0x0600F50A RID: 62730 RVA: 0x00373ADD File Offset: 0x00371CDD
		public void Hide()
		{
			this.m_Go.transform.localPosition = XGameUI.Far_Far_Away;
			this._ResetAnimState();
			this.m_bActive = false;
		}

		// Token: 0x0600F50B RID: 62731 RVA: 0x00373B04 File Offset: 0x00371D04
		private float _GetCurTime()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			float result;
			if (syncMode)
			{
				result = Time.realtimeSinceStartup;
			}
			else
			{
				result = Time.time;
			}
			return result;
		}

		// Token: 0x0600F50C RID: 62732 RVA: 0x00373B34 File Offset: 0x00371D34
		private void _PlayStartDisappearAnim()
		{
			bool flag = this.m_Tween != null;
			if (flag)
			{
				this.m_Tween.PlayTween(true, -1f);
				this.m_AnimState = XBuffIcon.AnimState.AS_DISAPPEARING;
			}
		}

		// Token: 0x0600F50D RID: 62733 RVA: 0x00373B6C File Offset: 0x00371D6C
		private void _ResetAnimState()
		{
			bool flag = this.m_AnimState == XBuffIcon.AnimState.AS_DISAPPEARING;
			if (flag)
			{
				bool flag2 = this.m_Tween != null;
				if (flag2)
				{
					this.m_Tween.ResetTween(true);
				}
			}
			this.m_AnimState = XBuffIcon.AnimState.AS_NORMAL;
		}

		// Token: 0x0600F50E RID: 62734 RVA: 0x00373BAC File Offset: 0x00371DAC
		public void OnUpdate()
		{
			bool flag = !this.m_bActive;
			if (!flag)
			{
				bool flag2 = !this.m_bPermernent && this.m_bShowTime;
				if (flag2)
				{
					this.m_fLeftTime = this.m_fStartLeftTime - (this._GetCurTime() - this.m_fStartTime);
					this._UpdateTime();
				}
			}
		}

		// Token: 0x0600F50F RID: 62735 RVA: 0x00373C04 File Offset: 0x00371E04
		private void _UpdateTime()
		{
			bool bPermernent = this.m_bPermernent;
			if (bPermernent)
			{
				this.m_uiLeftTime.SetText("");
				this.m_uiLeftTime.Alpha = 1f;
			}
			else
			{
				int num = Mathf.CeilToInt(this.m_fLeftTime);
				bool flag = num != this.m_nLeftTime;
				if (flag)
				{
					this.m_nLeftTime = num;
					bool flag2 = num <= 0 || (float)num > XSingleton<XGlobalConfig>.singleton.BuffMaxDisplayTime;
					if (flag2)
					{
						this.m_uiLeftTime.Alpha = 0f;
					}
					else
					{
						this.m_uiLeftTime.SetText(XSingleton<XCommon>.singleton.StringCombine("[b]", num.ToString()));
						this.m_uiLeftTime.Alpha = 1f;
					}
				}
			}
		}

		// Token: 0x040069F7 RID: 27127
		private static float DISAPPEAR_START_LEFT_TIME = 3f;

		// Token: 0x040069F8 RID: 27128
		private GameObject m_Go;

		// Token: 0x040069F9 RID: 27129
		private IXUISprite m_uiIcon;

		// Token: 0x040069FA RID: 27130
		private IXUILabel m_uiLeftTime;

		// Token: 0x040069FB RID: 27131
		private IXUILabel m_uiCount;

		// Token: 0x040069FC RID: 27132
		private IXUITweenTool m_Tween;

		// Token: 0x040069FD RID: 27133
		private Vector3 m_OriginPos;

		// Token: 0x040069FE RID: 27134
		private float m_fLeftTime;

		// Token: 0x040069FF RID: 27135
		private int m_nLeftTime;

		// Token: 0x04006A00 RID: 27136
		private float m_fStartTime;

		// Token: 0x04006A01 RID: 27137
		private float m_fStartLeftTime;

		// Token: 0x04006A02 RID: 27138
		private bool m_bActive = false;

		// Token: 0x04006A03 RID: 27139
		private bool m_bPermernent = false;

		// Token: 0x04006A04 RID: 27140
		private bool m_bShowTime = true;

		// Token: 0x04006A05 RID: 27141
		private XBuffIcon.AnimState m_AnimState = XBuffIcon.AnimState.AS_NORMAL;

		// Token: 0x02001A08 RID: 6664
		private enum AnimState
		{
			// Token: 0x0400820C RID: 33292
			AS_NORMAL,
			// Token: 0x0400820D RID: 33293
			AS_DISAPPEARING
		}
	}
}
