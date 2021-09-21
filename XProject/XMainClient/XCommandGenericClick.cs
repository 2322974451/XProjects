using System;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DA2 RID: 3490
	internal class XCommandGenericClick : XBaseCommand
	{
		// Token: 0x0600BDA2 RID: 48546 RVA: 0x00276C68 File Offset: 0x00274E68
		public override bool Execute()
		{
			bool flag = this._finger == null;
			if (flag)
			{
				this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Quan", true, false) as GameObject);
			}
			base.SetOverlay();
			XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.UIRoot, XBaseCommand._Overlay.transform);
			int num = int.Parse(this._cmd.param1);
			int num2 = int.Parse(this._cmd.param2);
			Vector3 vector = XSingleton<XGameUI>.singleton.UICamera.ScreenToWorldPoint(XTutorialHelper.BaseScreenPos2Real(new Vector2((float)num, (float)num2)));
			Vector3 localPosition = XBaseCommand._Overlay.transform.InverseTransformPoint(vector);
			XSingleton<UiUtility>.singleton.AddChild(XBaseCommand._Overlay.transform, this._finger.transform);
			localPosition.z = 0f;
			this._finger.transform.localPosition = localPosition;
			XSingleton<XTutorialMgr>.singleton.Exculsive = true;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnGeneric = true;
			base.SetTutorialText(this._cmd.textPos, this._finger.transform);
			base.publicModule();
			return true;
		}

		// Token: 0x0600BDA3 RID: 48547 RVA: 0x001E3B34 File Offset: 0x001E1D34
		public override void OnFinish()
		{
			this.Stop();
		}

		// Token: 0x0600BDA4 RID: 48548 RVA: 0x00276DA3 File Offset: 0x00274FA3
		public override void Stop()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnGeneric = false;
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
		}

		// Token: 0x04004D43 RID: 19779
		private GameObject _finger;
	}
}
