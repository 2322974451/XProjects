using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF9 RID: 2809
	internal class AIRunTimeResetHartedList : AIRunTimeNodeAction
	{
		// Token: 0x0600A5ED RID: 42477 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeResetHartedList(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5EE RID: 42478 RVA: 0x001CF2A8 File Offset: 0x001CD4A8
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.ResetHartedList(entity);
		}
	}
}
