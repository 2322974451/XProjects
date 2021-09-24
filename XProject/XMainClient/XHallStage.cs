using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHallStage : XConcreteStage
	{

		public XHallStage() : base(EXStage.Hall)
		{
		}

		protected override void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraCloseUpComponent.uuID);
			base.InstallCamera();
		}

		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			XSingleton<XGameUI>.singleton.LoadHallUI(this._eStage);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(true, true);
			XSingleton<XLoginDocument>.singleton.EnableSDONotify();
		}

		public override void OnLeaveScene(bool transfer)
		{
			base.OnLeaveScene(transfer);
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			XSingleton<XGameSysMgr>.singleton.Update(fDeltaT);
		}
	}
}
