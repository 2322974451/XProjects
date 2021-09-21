using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AFA RID: 2810
	internal class SelectPlayerFromList : AIRunTimeNodeAction
	{
		// Token: 0x0600A5EF RID: 42479 RVA: 0x001CB338 File Offset: 0x001C9538
		public SelectPlayerFromList(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5F0 RID: 42480 RVA: 0x001CF2C8 File Offset: 0x001CD4C8
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.ResetHartedList(entity);
		}
	}
}
