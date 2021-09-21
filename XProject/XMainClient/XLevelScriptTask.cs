using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E12 RID: 3602
	internal class XLevelScriptTask : XLevelBaseTask
	{
		// Token: 0x0600C20F RID: 49679 RVA: 0x0029A187 File Offset: 0x00298387
		public XLevelScriptTask(XLevelSpawnInfo ls) : base(ls)
		{
		}

		// Token: 0x0600C210 RID: 49680 RVA: 0x0029A194 File Offset: 0x00298394
		public override bool Execute(float time)
		{
			base.Execute(time);
			XSingleton<XLevelScriptMgr>.singleton.RunScript(this._ScriptName);
			return false;
		}

		// Token: 0x0400528F RID: 21135
		public string _ScriptName;
	}
}
