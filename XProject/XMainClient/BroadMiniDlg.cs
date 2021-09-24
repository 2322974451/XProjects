using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BroadMiniDlg : DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/BroadcastMiniDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_btn.gameObject.transform.localPosition = this.target;
			this.uiCamera = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").GetComponent<Camera>();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btn.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnButtonDrag));
			base.uiBehaviour.m_btn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnPressHandler));
			base.uiBehaviour.m_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIconClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.isPressing = false;
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.isPressing = false;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !this.isPressing && this.checkPos;
			if (flag)
			{
				bool flag2 = Vector3.Distance(this.from, this.target) < 1f;
				if (flag2)
				{
					base.uiBehaviour.m_btn.gameObject.transform.localPosition = this.target;
					this.checkPos = false;
				}
				else
				{
					base.uiBehaviour.m_btn.gameObject.transform.localPosition = Vector3.Lerp(this.from, this.target, (Time.time - this.tagTime) / 0.2f);
				}
			}
		}

		public void Show(bool show)
		{
			this.SetVisible(false, true);
		}

		private void OnButtonDrag(IXUIButton btn, Vector2 delta)
		{
			bool flag = this.isPressing;
			if (flag)
			{
				Vector3 mousePosition = Input.mousePosition;
				bool flag2 = this.uiCamera != null;
				if (flag2)
				{
					mousePosition.x = Mathf.Clamp01(mousePosition.x / (float)Screen.width);
					mousePosition.y = Mathf.Clamp01(mousePosition.y / (float)Screen.height);
					base.uiBehaviour.m_btn.gameObject.transform.position = this.uiCamera.ViewportToWorldPoint(mousePosition);
					bool orthographic = this.uiCamera.orthographic;
					if (orthographic)
					{
						Vector3 localPosition = base.uiBehaviour.m_btn.gameObject.transform.localPosition;
						localPosition.x = Mathf.Round(localPosition.x);
						localPosition.y = Mathf.Round(localPosition.y);
						base.uiBehaviour.m_btn.gameObject.transform.localPosition = localPosition;
					}
				}
				else
				{
					mousePosition.x -= (float)Screen.width * 0.5f;
					mousePosition.y -= (float)Screen.height * 0.5f;
					mousePosition.x = Mathf.Round(mousePosition.x);
					mousePosition.y = Mathf.Round(mousePosition.y);
					base.uiBehaviour.m_btn.gameObject.transform.localPosition = mousePosition;
				}
			}
		}

		private void OnPressHandler(IXUIButton btn, bool press)
		{
			bool flag = !press;
			if (flag)
			{
				this.AttachBounds();
			}
			this.isPressing = press;
		}

		private bool OnIconClick(IXUIButton btn)
		{
			DlgBase<BroadcastDlg, BroadcastBehaviour>.singleton.SetVisible(true, true);
			DlgBase<BroadcastDlg, BroadcastBehaviour>.singleton.ShowList();
			this.SetVisible(false, true);
			return true;
		}

		private void AttachBounds()
		{
			Vector3 localPosition = base.uiBehaviour.m_btn.gameObject.transform.localPosition;
			float x = localPosition.x;
			float y = localPosition.y;
			float num = x + 568f;
			float num2 = 568f - x;
			float num3 = 320f - y;
			float num4 = y + 320f;
			float num5 = Mathf.Min(new float[]
			{
				num,
				num2,
				num3,
				num4
			});
			bool flag = num == num5;
			if (flag)
			{
				this.target = new Vector3(-533f, y, 0f);
			}
			else
			{
				bool flag2 = num2 == num5;
				if (flag2)
				{
					this.target = new Vector3(533f, y, 0f);
				}
				else
				{
					bool flag3 = num3 == num5;
					if (flag3)
					{
						this.target = new Vector3(x, 288f, 0f);
					}
					else
					{
						this.target = new Vector3(x, -288f, 0f);
					}
				}
			}
			this.tagTime = Time.time;
			this.from = base.uiBehaviour.m_btn.gameObject.transform.localPosition;
			this.checkPos = true;
		}

		public Vector3 GetIconPos()
		{
			return base.uiBehaviour.m_btn.gameObject.transform.localPosition;
		}

		public void StopBroad()
		{
			bool flag = this.isBroadcast;
			if (flag)
			{
				try
				{
					XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.StopBroadcast();
				}
				catch
				{
				}
			}
		}

		private const int width = 1136;

		private const int height = 640;

		private bool isPressing = false;

		private bool checkPos = false;

		private Vector3 from = Vector3.zero;

		private Vector3 target = new Vector3(-533f, -180f, 0f);

		private float tagTime = 0f;

		public bool isBroadcast = false;

		public Camera uiCamera;
	}
}
