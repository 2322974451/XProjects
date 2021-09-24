using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI.UICommon
{

	internal class VirtualJoystick : DlgBase<VirtualJoystick, VirtualJoystickBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/VirtualJoyStick";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		protected override void Init()
		{
			this.Hide();
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected void Hide()
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				base.uiBehaviour.m_Panel.gameObject.transform.localPosition = new Vector3((float)XGameUI._far_far_away, (float)XGameUI._far_far_away, 0f);
				this._bLogicalVisible = false;
			}
		}

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

		public void SetJoystickPos(float radius, float angle)
		{
			float num = this.GetPanelRadius() + this.GetJoystickRadius();
			float num2 = (radius > num) ? num : radius;
			float num3 = angle / 180f * 3.1415927f;
			float num4 = Mathf.Cos(num3) * num2;
			float num5 = -Mathf.Sin(num3) * num2;
			base.uiBehaviour.m_Direction.gameObject.transform.localPosition = new Vector3(num4, num5, 0f);
		}

		public float GetPanelRadius()
		{
			bool flag = !this.m_bLoaded && this.autoload;
			if (flag)
			{
				base.Load();
			}
			return (float)(base.uiBehaviour.m_Panel.spriteWidth / 2);
		}

		public float GetJoystickRadius()
		{
			bool flag = !this.m_bLoaded && this.autoload;
			if (flag)
			{
				base.Load();
			}
			return (float)(base.uiBehaviour.m_Joystick.spriteWidth / 2 - 15);
		}

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

		private bool _bLogicalVisible;
	}
}
