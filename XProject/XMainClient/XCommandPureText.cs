using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DD4 RID: 3540
	internal class XCommandPureText : XBaseCommand
	{
		// Token: 0x0600C0C0 RID: 49344 RVA: 0x0028D2E8 File Offset: 0x0028B4E8
		public override bool Execute()
		{
			this._startTime = Time.time;
			int num = int.Parse(this._cmd.param1);
			int num2 = int.Parse(this._cmd.param2);
			Vector3 vector = XSingleton<XGameUI>.singleton.UICamera.ScreenToWorldPoint(XTutorialHelper.BaseScreenPos2Real(new Vector2((float)num, (float)num2)));
			Vector3 vector2 = XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(vector);
			base.SetTutorialText(this._cmd.textPos, XSingleton<XGameUI>.singleton.UIRoot);
			base.publicModule();
			return true;
		}

		// Token: 0x0600C0C1 RID: 49345 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Update()
		{
		}
	}
}
