using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBattleOptionsHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_CameraSpeed = (base.PanelObject.transform.FindChild("TailCameraSpeed/Bar").GetComponent("XUISlider") as IXUISlider);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("TailCameraSpeedRange").Split(XGlobalConfig.SequenceSeparator);
			this.m_MinCameraSpeed = int.Parse(array[0]);
			this.m_MaxCameraSpeed = int.Parse(array[1]);
			this.doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_CameraSpeed.Value = Mathf.Clamp01(Mathf.InverseLerp((float)this.m_MinCameraSpeed, (float)this.m_MaxCameraSpeed, (float)this.doc.GetValue(XOptionsDefine.OD_TAILCAMERA_SPEED)));
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.doc.SetValue(XOptionsDefine.OD_TAILCAMERA_SPEED, (int)Mathf.Lerp((float)this.m_MinCameraSpeed, (float)this.m_MaxCameraSpeed, this.m_CameraSpeed.Value), false);
		}

		private XOptionsDocument doc;

		private IXUISlider m_CameraSpeed;

		private int m_MinCameraSpeed;

		private int m_MaxCameraSpeed;
	}
}
