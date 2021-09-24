using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XShowSameQualityItemsBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.OkBtn = (base.transform.Find("task/OK").GetComponent("XUIButton") as IXUIButton);
			this.TaskStr = (base.transform.Find("task/OK/TaskStr").GetComponent("XUILabel") as IXUILabel);
			this.TipStr = (base.transform.Find("task/Tip").GetComponent("XUILabel") as IXUILabel);
			this.progressLabel = (base.transform.Find("task/Tnum").GetComponent("XUILabel") as IXUILabel);
			this.ScrollView = (base.transform.Find("ItemsFrame").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("ItemsFrame/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton OkBtn = null;

		public IXUILabel TaskStr;

		public IXUILabel TipStr;

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public IXUILabel progressLabel;

		public IXUIButton CloseBtn;
	}
}
