using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D9F RID: 3487
	internal class XCommandCutscene : XBaseCommand
	{
		// Token: 0x0600BD90 RID: 48528 RVA: 0x00276508 File Offset: 0x00274708
		public override bool Execute()
		{
			base.publicModule();
			XSingleton<XCutScene>.singleton.Start(this._cmd.param1, !string.IsNullOrEmpty(this._cmd.param2) && this._cmd.param2.ToLower() == "true", true);
			return true;
		}

		// Token: 0x0600BD91 RID: 48529 RVA: 0x00276568 File Offset: 0x00274768
		public override void Update()
		{
			bool flag = !XSingleton<XCutScene>.singleton.IsPlaying;
			if (flag)
			{
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
		}

		// Token: 0x0600BD92 RID: 48530 RVA: 0x00276592 File Offset: 0x00274792
		public override void OnFinish()
		{
			base.OnFinish();
		}

		// Token: 0x0600BD93 RID: 48531 RVA: 0x0027659C File Offset: 0x0027479C
		public override void Stop()
		{
			base.Stop();
			bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
			if (isPlaying)
			{
				XSingleton<XCutScene>.singleton.Stop(true);
			}
		}
	}
}
