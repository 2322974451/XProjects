using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class GuildInheritProcessBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mProcessSlider = (base.transform.FindChild("Bg/Process").GetComponent("XUISlider") as IXUISlider);
			this.mProcessLabel = (base.transform.FindChild("Bg/ProcessLabel").GetComponent("XUILabel") as IXUILabel);
			this.mContentLabel = (base.transform.FindChild("Bg/Content").GetComponent("XUILabel") as IXUILabel);
		}

		protected internal IXUISlider mProcessSlider;

		protected internal IXUILabel mProcessLabel;

		protected internal IXUILabel mContentLabel;
	}
}
