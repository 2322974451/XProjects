using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DFE RID: 3582
	internal class XTutorialMainCmd
	{
		// Token: 0x040051D3 RID: 20947
		public int savebit;

		// Token: 0x040051D4 RID: 20948
		public string tag;

		// Token: 0x040051D5 RID: 20949
		public bool isMust;

		// Token: 0x040051D6 RID: 20950
		public List<XTutorialCmdExecuteCondition> conditions;

		// Token: 0x040051D7 RID: 20951
		public List<string> condParams;

		// Token: 0x040051D8 RID: 20952
		public string subTutorial;
	}
}
