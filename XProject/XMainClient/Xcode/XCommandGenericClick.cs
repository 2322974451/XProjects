using System;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandGenericClick : XBaseCommand
	{

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

		public override void OnFinish()
		{
			this.Stop();
		}

		public override void Stop()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnGeneric = false;
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
		}

		private GameObject _finger;
	}
}
