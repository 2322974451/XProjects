using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.Tutorial.Command
{
	// Token: 0x020016C7 RID: 5831
	internal class XCommandNote : XBaseCommand
	{
		// Token: 0x0600F07A RID: 61562 RVA: 0x0034D49C File Offset: 0x0034B69C
		public override bool Execute()
		{
			Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild(this._cmd.param1 + "(Clone)");
			bool flag = !transform || !transform.gameObject.activeInHierarchy;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Transform transform2 = XSingleton<UiUtility>.singleton.FindChild(transform, this._cmd.param2);
				bool flag2 = transform2 == null || !transform2.gameObject.activeInHierarchy;
				if (flag2)
				{
					bool flag3 = transform2 == null && this._cmd.isOutError;
					if (flag3)
					{
						this._cmd.isOutError = false;
						XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
						{
							"TutorialId:",
							this._cmd.TutorialID,
							" Configuration File Path Error! tag:",
							this._cmd.tag,
							"\nPath:",
							this._cmd.param1,
							"(Clone)/",
							this._cmd.param2
						}), null, null, null, null, null);
					}
					result = false;
				}
				else
				{
					this._startTime = Time.time;
					this._clickGo = transform2.gameObject;
					bool flag4 = this._cmd.interalDelay > 0f;
					if (flag4)
					{
						base.SetOverlay();
					}
					this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowFinger), null);
					base.publicModule();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600F07B RID: 61563 RVA: 0x0034D644 File Offset: 0x0034B844
		protected void ShowFinger(object o)
		{
			bool flag = this._finger == null;
			if (flag)
			{
				this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialK", true, false) as GameObject);
			}
			this._finger.SetActive(false);
			string param = this._cmd.param3;
			string[] array = param.Split(XGlobalConfig.AllSeparators);
			float num = float.Parse(array[0]);
			float num2 = (array.Length > 1) ? float.Parse(array[1]) : num;
			float num3 = (array.Length > 2) ? float.Parse(array[2]) : 0f;
			float num4 = (array.Length > 3) ? float.Parse(array[3]) : 0f;
			bool flag2 = num > 0f;
			if (flag2)
			{
				IXUISprite ixuisprite = this._finger.transform.FindChild("Quan").GetComponent("XUISprite") as IXUISprite;
				this.orgWidth = ixuisprite.spriteWidth;
				this.orgHeight = ixuisprite.spriteHeight;
				ixuisprite.spriteWidth = (int)((float)ixuisprite.spriteWidth * num);
				ixuisprite.spriteHeight = (int)((float)ixuisprite.spriteHeight * num2);
				ixuisprite.gameObject.transform.localPosition = new Vector3(num3, num4, 0f);
			}
			base.SetOverlay();
			this._cloneGo = XCommon.Instantiate<GameObject>(this._clickGo);
			this.SetupCloneButton(this._clickGo, this._cloneGo);
			base.SetTutorialText(this._cmd.textPos, this._cloneGo.transform);
			this._finger.SetActive(false);
			this._finger.SetActive(true);
			base.SetAilin();
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
		}

		// Token: 0x0600F07C RID: 61564 RVA: 0x0034D814 File Offset: 0x0034BA14
		public override void Update()
		{
			base.Update();
			bool flag = this._cloneGo != null && this._clickGo != null;
			if (flag)
			{
				Vector3 position = this._clickGo.transform.position;
				Vector3 localPosition = XBaseCommand._Overlay.transform.InverseTransformPoint(position);
				localPosition.z = 0f;
				this._cloneGo.transform.localPosition = localPosition;
			}
		}

		// Token: 0x0600F07D RID: 61565 RVA: 0x0034D88C File Offset: 0x0034BA8C
		protected void SetupCloneButton(GameObject targetGo, GameObject cloneGo)
		{
			XSingleton<UiUtility>.singleton.AddChild(cloneGo.transform, this._finger.transform);
			cloneGo.name = targetGo.name;
			cloneGo.transform.parent = XBaseCommand._Overlay.transform;
			Vector3 position = targetGo.transform.position;
			Vector3 localPosition = XBaseCommand._Overlay.transform.InverseTransformPoint(position);
			localPosition.z = 0f;
			cloneGo.transform.localPosition = localPosition;
			cloneGo.transform.localScale = targetGo.transform.localScale;
		}

		// Token: 0x0600F07E RID: 61566 RVA: 0x0034D928 File Offset: 0x0034BB28
		public override void Stop()
		{
			bool flag = this._time > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time);
				this._time = 0U;
			}
			bool flag2 = this._finger != null;
			if (flag2)
			{
				IXUISprite ixuisprite = this._finger.transform.FindChild("Quan").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteWidth = this.orgWidth;
				ixuisprite.spriteHeight = this.orgHeight;
				XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			}
			base.DestroyText();
			bool flag3 = this._cloneGo != null;
			if (flag3)
			{
				this._cloneGo.transform.parent = null;
				UnityEngine.Object.Destroy(this._cloneGo);
				this._cloneGo = null;
			}
			base.DestroyAilin();
			base.DestroyOverlay();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.NoforceClick = false;
		}

		// Token: 0x0400667D RID: 26237
		private GameObject _finger;

		// Token: 0x0400667E RID: 26238
		private int orgWidth;

		// Token: 0x0400667F RID: 26239
		private int orgHeight;

		// Token: 0x04006680 RID: 26240
		private GameObject _cloneGo;

		// Token: 0x04006681 RID: 26241
		private GameObject _clickGo;

		// Token: 0x04006682 RID: 26242
		private uint _time = 0U;
	}
}
