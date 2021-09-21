using System;

namespace XMainClient
{
	// Token: 0x02000DF6 RID: 3574
	internal class XCommandExec : XBaseCommand
	{
		// Token: 0x0600C14B RID: 49483 RVA: 0x002919A0 File Offset: 0x0028FBA0
		public override bool Execute()
		{
			base.publicModule();
			XCommandExec._execute(this._cmd.param1);
			return true;
		}

		// Token: 0x0600C14C RID: 49484 RVA: 0x002919CC File Offset: 0x0028FBCC
		public static void _execute(string param1)
		{
			string text = "Table/Tutorial/" + param1;
		}
	}
}
