using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandPureText : XBaseCommand
	{

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

		public override void Update()
		{
		}
	}
}
