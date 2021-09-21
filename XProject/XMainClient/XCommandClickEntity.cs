using System;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B8A RID: 2954
	internal class XCommandClickEntity : XBaseCommand
	{
		// Token: 0x0600A991 RID: 43409 RVA: 0x001E3984 File Offset: 0x001E1B84
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

		// Token: 0x0600A992 RID: 43410 RVA: 0x001E3A30 File Offset: 0x001E1C30
		public override void Update()
		{
			base.Update();
			this.UpdateFinger();
		}

		// Token: 0x0600A993 RID: 43411 RVA: 0x001E3A44 File Offset: 0x001E1C44
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

		// Token: 0x0600A994 RID: 43412 RVA: 0x001E3B34 File Offset: 0x001E1D34
		public override void OnFinish()
		{
			this.Stop();
		}

		// Token: 0x0600A995 RID: 43413 RVA: 0x001E3B3E File Offset: 0x001E1D3E
		public override void Stop()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			XSingleton<XTutorialMgr>.singleton.ExculsiveOnEntity = false;
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
		}

		// Token: 0x04003EB2 RID: 16050
		private GameObject _finger;

		// Token: 0x04003EB3 RID: 16051
		private XEntity _target = null;
	}
}
