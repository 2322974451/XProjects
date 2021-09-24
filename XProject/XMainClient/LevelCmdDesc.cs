using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class LevelCmdDesc
	{

		public void Reset()
		{
			this.state = XCmdState.Cmd_In_Queue;
		}

		public LevelCmd cmd = LevelCmd.Level_Cmd_Invalid;

		public List<string> Param = new List<string>();

		public XCmdState state = XCmdState.Cmd_In_Queue;
	}
}
