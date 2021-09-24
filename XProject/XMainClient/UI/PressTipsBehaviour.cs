using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class PressTipsBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this._ContentTransform = base.transform.Find("Info");
			this._ContentValue = (this._ContentTransform.GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel _ContentValue;

		public Transform _ContentTransform;
	}
}
