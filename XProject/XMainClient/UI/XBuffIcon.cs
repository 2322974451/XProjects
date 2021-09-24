using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBuffIcon
	{

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

		public void Hide()
		{
			this.m_Go.transform.localPosition = XGameUI.Far_Far_Away;
			this._ResetAnimState();
			this.m_bActive = false;
		}

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

		private void _PlayStartDisappearAnim()
		{
			bool flag = this.m_Tween != null;
			if (flag)
			{
				this.m_Tween.PlayTween(true, -1f);
				this.m_AnimState = XBuffIcon.AnimState.AS_DISAPPEARING;
			}
		}

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

		private static float DISAPPEAR_START_LEFT_TIME = 3f;

		private GameObject m_Go;

		private IXUISprite m_uiIcon;

		private IXUILabel m_uiLeftTime;

		private IXUILabel m_uiCount;

		private IXUITweenTool m_Tween;

		private Vector3 m_OriginPos;

		private float m_fLeftTime;

		private int m_nLeftTime;

		private float m_fStartTime;

		private float m_fStartLeftTime;

		private bool m_bActive = false;

		private bool m_bPermernent = false;

		private bool m_bShowTime = true;

		private XBuffIcon.AnimState m_AnimState = XBuffIcon.AnimState.AS_NORMAL;

		private enum AnimState
		{

			AS_NORMAL,

			AS_DISAPPEARING
		}
	}
}
