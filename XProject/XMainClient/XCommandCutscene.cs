using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandCutscene : XBaseCommand
	{

		public override bool Execute()
		{
			base.publicModule();
			XSingleton<XCutScene>.singleton.Start(this._cmd.param1, !string.IsNullOrEmpty(this._cmd.param2) && this._cmd.param2.ToLower() == "true", true);
			return true;
		}

		public override void Update()
		{
			bool flag = !XSingleton<XCutScene>.singleton.IsPlaying;
			if (flag)
			{
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
		}

		public override void OnFinish()
		{
			base.OnFinish();
		}

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
