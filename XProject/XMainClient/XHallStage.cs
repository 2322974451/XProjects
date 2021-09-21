using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EE8 RID: 3816
	internal class XHallStage : XConcreteStage
	{
		// Token: 0x0600CAB8 RID: 51896 RVA: 0x002DFE77 File Offset: 0x002DE077
		public XHallStage() : base(EXStage.Hall)
		{
		}

		// Token: 0x0600CAB9 RID: 51897 RVA: 0x002DFE82 File Offset: 0x002DE082
		protected override void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraCloseUpComponent.uuID);
			base.InstallCamera();
		}

		// Token: 0x0600CABA RID: 51898 RVA: 0x002DFEA6 File Offset: 0x002DE0A6
		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			XSingleton<XGameUI>.singleton.LoadHallUI(this._eStage);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(true, true);
			XSingleton<XLoginDocument>.singleton.EnableSDONotify();
		}

		// Token: 0x0600CABB RID: 51899 RVA: 0x002DFEDB File Offset: 0x002DE0DB
		public override void OnLeaveScene(bool transfer)
		{
			base.OnLeaveScene(transfer);
		}

		// Token: 0x0600CABC RID: 51900 RVA: 0x002DFEE6 File Offset: 0x002DE0E6
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			XSingleton<XGameSysMgr>.singleton.Update(fDeltaT);
		}
	}
}
