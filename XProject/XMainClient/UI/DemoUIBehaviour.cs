using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018FF RID: 6399
	internal class DemoUIBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010B32 RID: 68402 RVA: 0x00429C98 File Offset: 0x00427E98
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg").gameObject;
			Transform transform = base.transform.FindChild("Bg/DebugCommitBtn");
			bool flag = null != transform;
			if (flag)
			{
				this.m_Button = (transform.GetComponent("XUIButton") as IXUIButton);
			}
			this.m_PreviousButton = (base.transform.FindChild("Bg/PreviousBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_NextButton = (base.transform.FindChild("Bg/NextBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform2 = base.transform.FindChild("Bg/DebugDlgInput");
			bool flag2 = null != transform2;
			if (flag2)
			{
				this.m_Input = (transform2.GetComponent("XUIInput") as IXUIInput);
			}
			this.m_ScrollView = (base.transform.FindChild("Bg/MessageDisplay").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MessagePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MessagePool.SetupPool(base.transform.FindChild("Bg/MessageDisplay").gameObject, base.transform.FindChild("Bg/MessageDisplay/MessageTpl").gameObject, DemoUI.MAX_MESSAGE_COUNT, false);
			this.m_ActiveMessages = new List<IXUILabel>((int)DemoUI.MAX_MESSAGE_COUNT);
			Transform transform3 = base.transform.FindChild("fps");
			bool flag3 = null != transform3;
			if (flag3)
			{
				this.m_fps = (transform3.GetComponent("XUILabel") as IXUILabel);
				Transform transform4 = transform3.FindChild("Open");
				bool flag4 = transform4 != null;
				if (flag4)
				{
					this.m_Open = (transform4.GetComponent("XUIButton") as IXUIButton);
				}
			}
		}

		// Token: 0x04007A22 RID: 31266
		public IXUIButton m_Button = null;

		// Token: 0x04007A23 RID: 31267
		public IXUIButton m_PreviousButton = null;

		// Token: 0x04007A24 RID: 31268
		public IXUIButton m_NextButton = null;

		// Token: 0x04007A25 RID: 31269
		public IXUIInput m_Input = null;

		// Token: 0x04007A26 RID: 31270
		public IXUIButton m_Close = null;

		// Token: 0x04007A27 RID: 31271
		public XUIPool m_MessagePool;

		// Token: 0x04007A28 RID: 31272
		public List<IXUILabel> m_ActiveMessages;

		// Token: 0x04007A29 RID: 31273
		public IXUIScrollView m_ScrollView;

		// Token: 0x04007A2A RID: 31274
		public GameObject m_Bg;

		// Token: 0x04007A2B RID: 31275
		public IXUILabel m_fps = null;

		// Token: 0x04007A2C RID: 31276
		public IXUIButton m_Open = null;
	}
}
