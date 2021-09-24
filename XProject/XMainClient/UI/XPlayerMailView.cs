using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XPlayerMailView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
		}

		private XMailDocument _doc = null;
	}
}
