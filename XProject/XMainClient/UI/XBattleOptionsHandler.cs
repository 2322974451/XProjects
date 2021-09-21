using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001726 RID: 5926
	internal class XBattleOptionsHandler : DlgHandlerBase
	{
		// Token: 0x0600F4B6 RID: 62646 RVA: 0x003702A8 File Offset: 0x0036E4A8
		protected override void Init()
		{
			base.Init();
			this.m_CameraSpeed = (base.PanelObject.transform.FindChild("TailCameraSpeed/Bar").GetComponent("XUISlider") as IXUISlider);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("TailCameraSpeedRange").Split(XGlobalConfig.SequenceSeparator);
			this.m_MinCameraSpeed = int.Parse(array[0]);
			this.m_MaxCameraSpeed = int.Parse(array[1]);
			this.doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		// Token: 0x0600F4B7 RID: 62647 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F4B8 RID: 62648 RVA: 0x0037032D File Offset: 0x0036E52D
		protected override void OnShow()
		{
			base.OnShow();
			this.m_CameraSpeed.Value = Mathf.Clamp01(Mathf.InverseLerp((float)this.m_MinCameraSpeed, (float)this.m_MaxCameraSpeed, (float)this.doc.GetValue(XOptionsDefine.OD_TAILCAMERA_SPEED)));
		}

		// Token: 0x0600F4B9 RID: 62649 RVA: 0x00370369 File Offset: 0x0036E569
		protected override void OnHide()
		{
			base.OnHide();
			this.doc.SetValue(XOptionsDefine.OD_TAILCAMERA_SPEED, (int)Mathf.Lerp((float)this.m_MinCameraSpeed, (float)this.m_MaxCameraSpeed, this.m_CameraSpeed.Value), false);
		}

		// Token: 0x04006993 RID: 27027
		private XOptionsDocument doc;

		// Token: 0x04006994 RID: 27028
		private IXUISlider m_CameraSpeed;

		// Token: 0x04006995 RID: 27029
		private int m_MinCameraSpeed;

		// Token: 0x04006996 RID: 27030
		private int m_MaxCameraSpeed;
	}
}
