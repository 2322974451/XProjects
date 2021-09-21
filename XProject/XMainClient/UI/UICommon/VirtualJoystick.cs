using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI.UICommon
{
	// Token: 0x0200192D RID: 6445
	internal class VirtualJoystick : DlgBase<VirtualJoystick, VirtualJoystickBehaviour>
	{
		// Token: 0x17003B20 RID: 15136
		// (get) Token: 0x06010EF5 RID: 69365 RVA: 0x0044BBC0 File Offset: 0x00449DC0
		public override string fileName
		{
			get
			{
				return "Common/VirtualJoyStick";
			}
		}

		// Token: 0x17003B21 RID: 15137
		// (get) Token: 0x06010EF6 RID: 69366 RVA: 0x0044BBD8 File Offset: 0x00449DD8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06010EF7 RID: 69367 RVA: 0x0044BBEB File Offset: 0x00449DEB
		protected override void Init()
		{
			this.Hide();
		}

		// Token: 0x17003B22 RID: 15138
		// (get) Token: 0x06010EF8 RID: 69368 RVA: 0x0044BBF8 File Offset: 0x00449DF8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010EF9 RID: 69369 RVA: 0x0044BC0C File Offset: 0x00449E0C
		protected void Hide()
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				base.uiBehaviour.m_Panel.gameObject.transform.localPosition = new Vector3((float)XGameUI._far_far_away, (float)XGameUI._far_far_away, 0f);
				this._bLogicalVisible = false;
			}
		}

		// Token: 0x06010EFA RID: 69370 RVA: 0x0044BC64 File Offset: 0x00449E64
		public void ShowPanel(bool bShow, Vector2 screenPos = default(Vector2))
		{
			if (bShow)
			{
				bool flag = !base.IsVisible();
				if (flag)
				{
					this.SetVisible(true, true);
				}
				Vector3 vector = XSingleton<XGameUI>.singleton.UICamera.ScreenToWorldPoint(screenPos);
				Vector3 vec = this.m_uiBehaviour.transform.InverseTransformPoint(vector);
				base.uiBehaviour.m_Panel.gameObject.transform.localPosition = this.LimitPosition(vec);
				bool flag2 = !this._bLogicalVisible;
				if (flag2)
				{
					IXUITweenTool ixuitweenTool = base.uiBehaviour.m_Direction.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool.PlayTween(true, -1f);
				}
				this._bLogicalVisible = true;
			}
			else
			{
				this.Hide();
			}
		}

		// Token: 0x06010EFB RID: 69371 RVA: 0x0044BD2C File Offset: 0x00449F2C
		public void SetJoystickPos(float radius, float angle)
		{
			float num = this.GetPanelRadius() + this.GetJoystickRadius();
			float num2 = (radius > num) ? num : radius;
			float num3 = angle / 180f * 3.1415927f;
			float num4 = Mathf.Cos(num3) * num2;
			float num5 = -Mathf.Sin(num3) * num2;
			base.uiBehaviour.m_Direction.gameObject.transform.localPosition = new Vector3(num4, num5, 0f);
		}

		// Token: 0x06010EFC RID: 69372 RVA: 0x0044BD9C File Offset: 0x00449F9C
		public float GetPanelRadius()
		{
			bool flag = !this.m_bLoaded && this.autoload;
			if (flag)
			{
				base.Load();
			}
			return (float)(base.uiBehaviour.m_Panel.spriteWidth / 2);
		}

		// Token: 0x06010EFD RID: 69373 RVA: 0x0044BDE0 File Offset: 0x00449FE0
		public float GetJoystickRadius()
		{
			bool flag = !this.m_bLoaded && this.autoload;
			if (flag)
			{
				base.Load();
			}
			return (float)(base.uiBehaviour.m_Joystick.spriteWidth / 2 - 15);
		}

		// Token: 0x06010EFE RID: 69374 RVA: 0x0044BE28 File Offset: 0x0044A028
		protected Vector3 LimitPosition(Vector3 vec)
		{
			Vector3 result = vec;
			int base_UI_Width = XSingleton<XGameUI>.singleton.Base_UI_Width;
			int base_UI_Height = XSingleton<XGameUI>.singleton.Base_UI_Height;
			float num = this.GetPanelRadius() + this.GetJoystickRadius() * 2f;
			bool flag = vec.x - num < (float)(-(float)base_UI_Width / 2);
			if (flag)
			{
				result.x = (float)(-(float)base_UI_Width / 2) + num;
			}
			bool flag2 = vec.x + num > (float)(base_UI_Width / 2);
			if (flag2)
			{
				result.x = (float)(base_UI_Width / 2) - num;
			}
			bool flag3 = vec.y + num > (float)(base_UI_Height / 2);
			if (flag3)
			{
				result.y = (float)(base_UI_Height / 2) - num;
			}
			bool flag4 = vec.y - num < (float)(-(float)base_UI_Height / 2);
			if (flag4)
			{
				result.y = (float)(-(float)base_UI_Height / 2) + num;
			}
			return result;
		}

		// Token: 0x04007C83 RID: 31875
		private bool _bLogicalVisible;
	}
}
