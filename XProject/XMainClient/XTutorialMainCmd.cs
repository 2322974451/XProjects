using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XTutorialMainCmd
	{

		public int savebit;

		public string tag;

		public bool isMust;

		public List<XTutorialCmdExecuteCondition> conditions;

		public List<string> condParams;

		public string subTutorial;
	}
}
