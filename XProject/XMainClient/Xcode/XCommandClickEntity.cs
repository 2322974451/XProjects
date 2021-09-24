using System;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandClickEntity : XBaseCommand
	{

		public override bool Execute()
		{
			Vector3 zero = Vector3.zero;
			Transform parent = XSingleton<XGameUI>.singleton.UIRoot.FindChild("TutorialPanel");
			bool flag = this._finger == null;
			if (flag)
			{
				this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Quan", true, false) as GameObject);
			}
			this._finger.SetActive(false);
			this._finger.SetActive(true);
			XSingleton<UiUtility>.singleton.AddChild(parent, this._finger.transform);
			this.UpdateFinger();
			XSingleton<XTutorialMgr>.singleton.Exculsive = true;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnEntity = true;
			return true;
		}

		public override void Update()
		{
			base.Update();
			this.UpdateFinger();
		}

		protected void UpdateFinger()
		{
			bool flag = this._target == null || this._finger == null;
			if (!flag)
			{
				Vector3 vector = Vector3.zero;
				vector = this._target.EngineObject.Position;
				vector += new Vector3(0f, 0.8f, 0f);
				Vector3 vector2 = XSingleton<XScene>.singleton.GameCamera.UnityCamera.WorldToViewportPoint(vector);
				Vector3 position = XSingleton<XGameUI>.singleton.UICamera.ViewportToWorldPoint(vector2);
				this._finger.transform.position = position;
				Vector3 localPosition = this._finger.transform.localPosition;
				localPosition.x = (float)Mathf.FloorToInt(localPosition.x);
				localPosition.y = (float)Mathf.FloorToInt(localPosition.y);
				localPosition.z = 0f;
				this._finger.transform.localPosition = localPosition;
			}
		}

		public override void OnFinish()
		{
			this.Stop();
		}

		public override void Stop()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnEntity = false;
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
		}

		private GameObject _finger;

		private XEntity _target = null;
	}
}
