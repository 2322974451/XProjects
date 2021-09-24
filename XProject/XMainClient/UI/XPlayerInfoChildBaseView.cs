using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class XPlayerInfoChildBaseView
	{

		public virtual void FindFrom(Transform t)
		{
			Transform transform = t.Find("name");
			bool flag = null != transform;
			if (flag)
			{
				this.lbName = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			}
			transform = t.Find("level");
			bool flag2 = null != transform;
			if (flag2)
			{
				this.lbLevel = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = t.Find("head");
			bool flag3 = null != transform;
			if (flag3)
			{
				this.sprHead = (transform.GetComponent("XUISprite") as IXUISprite);
			}
		}

		public IXUILabelSymbol lbName;

		public IXUILabel lbLevel;

		public IXUISprite sprHead;
	}
}
