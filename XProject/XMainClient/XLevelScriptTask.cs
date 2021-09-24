using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelScriptTask : XLevelBaseTask
	{

		public XLevelScriptTask(XLevelSpawnInfo ls) : base(ls)
		{
		}

		public override bool Execute(float time)
		{
			base.Execute(time);
			XSingleton<XLevelScriptMgr>.singleton.RunScript(this._ScriptName);
			return false;
		}

		public string _ScriptName;
	}
}
