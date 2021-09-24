using System;

namespace XMainClient
{

	internal class XCommandExec : XBaseCommand
	{

		public override bool Execute()
		{
			base.publicModule();
			XCommandExec._execute(this._cmd.param1);
			return true;
		}

		public static void _execute(string param1)
		{
			string text = "Table/Tutorial/" + param1;
		}
	}
}
