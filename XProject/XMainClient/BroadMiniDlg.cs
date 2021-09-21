using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BCE RID: 3022
	internal class BroadMiniDlg : DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>
	{
		// Token: 0x17003078 RID: 12408
		// (get) Token: 0x0600AC41 RID: 44097 RVA: 0x001FAB30 File Offset: 0x001F8D30
		public override string fileName
		{
			get
			{
				return "GameSystem/BroadcastMiniDlg";
			}
		}

		// Token: 0x17003079 RID: 12409
		// (get) Token: 0x0600AC42 RID: 44098 RVA: 0x001FAB48 File Offset: 0x001F8D48
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700307A RID: 12410
		// (get) Token: 0x0600AC43 RID: 44099 RVA: 0x001FAB5C File Offset: 0x001F8D5C
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700307B RID: 12411
		// (get) Token: 0x0600AC44 RID: 44100 RVA: 0x001FAB70 File Offset: 0x001F8D70
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600AC45 RID: 44101 RVA: 0x001FAB84 File Offset: 0x001F8D84
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_btn.gameObject.transform.localPosition = this.target;
			this.uiCamera = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").GetComponent<Camera>();
		}

		// Token: 0x0600AC46 RID: 44102 RVA: 0x001FABDC File Offset: 0x001F8DDC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btn.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnButtonDrag));
			base.uiBehaviour.m_btn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnPressHandler));
			base.uiBehaviour.m_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIconClick));
		}

		// Token: 0x0600AC47 RID: 44103 RVA: 0x001FAC48 File Offset: 0x001F8E48
		protected override void OnShow()
		{
			base.OnShow();
			this.isPressing = false;
		}

		// Token: 0x0600AC48 RID: 44104 RVA: 0x001FAC59 File Offset: 0x001F8E59
		protected override void OnHide()
		{
			base.OnHide();
			this.isPressing = false;
		}

		// Token: 0x0600AC49 RID: 44105 RVA: 0x001FAC6C File Offset: 0x001F8E6C
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

		// Token: 0x0600AC4A RID: 44106 RVA: 0x001FAD23 File Offset: 0x001F8F23
		public void Show(bool show)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600AC4B RID: 44107 RVA: 0x001FAD34 File Offset: 0x001F8F34
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

		// Token: 0x0600AC4C RID: 44108 RVA: 0x001FAEA8 File Offset: 0x001F90A8
		private void OnPressHandler(IXUIButton btn, bool press)
		{
			bool flag = !press;
			if (flag)
			{
				this.AttachBounds();
			}
			this.isPressing = press;
		}

		// Token: 0x0600AC4D RID: 44109 RVA: 0x001FAED0 File Offset: 0x001F90D0
		private bool OnIconClick(IXUIButton btn)
		{
			DlgBase<BroadcastDlg, BroadcastBehaviour>.singleton.SetVisible(true, true);
			DlgBase<BroadcastDlg, BroadcastBehaviour>.singleton.ShowList();
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AC4E RID: 44110 RVA: 0x001FAF04 File Offset: 0x001F9104
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

		// Token: 0x0600AC4F RID: 44111 RVA: 0x001FB034 File Offset: 0x001F9234
		public Vector3 GetIconPos()
		{
			return base.uiBehaviour.m_btn.gameObject.transform.localPosition;
		}

		// Token: 0x0600AC50 RID: 44112 RVA: 0x001FB060 File Offset: 0x001F9260
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

		// Token: 0x040040D9 RID: 16601
		private const int width = 1136;

		// Token: 0x040040DA RID: 16602
		private const int height = 640;

		// Token: 0x040040DB RID: 16603
		private bool isPressing = false;

		// Token: 0x040040DC RID: 16604
		private bool checkPos = false;

		// Token: 0x040040DD RID: 16605
		private Vector3 from = Vector3.zero;

		// Token: 0x040040DE RID: 16606
		private Vector3 target = new Vector3(-533f, -180f, 0f);

		// Token: 0x040040DF RID: 16607
		private float tagTime = 0f;

		// Token: 0x040040E0 RID: 16608
		public bool isBroadcast = false;

		// Token: 0x040040E1 RID: 16609
		public Camera uiCamera;
	}
}
