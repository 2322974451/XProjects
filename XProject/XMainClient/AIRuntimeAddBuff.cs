using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AA0 RID: 2720
	internal class AIRuntimeAddBuff : AIRunTimeNodeAction
	{
		// Token: 0x0600A506 RID: 42246 RVA: 0x001CB344 File Offset: 0x001C9544
		public AIRuntimeAddBuff(XmlElement node) : base(node)
		{
			this.BuffId = int.Parse(node.GetAttribute("Shared_BuffIdmValue"));
			this.BuffId2 = int.Parse(node.GetAttribute("Shared_BuffId2mValue"));
			this.BuffIdName = node.GetAttribute("Shared_BuffIdName");
			this.BuffId2Name = node.GetAttribute("Shared_BuffId2Name");
			this.MonsterId = int.Parse(node.GetAttribute("Shared_MonsterIdmValue"));
			this.MonsterIdName = node.GetAttribute("Shared_MonsterIdName");
		}

		// Token: 0x0600A507 RID: 42247 RVA: 0x001CB3D0 File Offset: 0x001C95D0
		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this.MonsterIdName, this.MonsterId);
			int intByName2 = entity.AI.AIData.GetIntByName(this.BuffIdName, this.BuffId);
			int intByName3 = entity.AI.AIData.GetIntByName(this.BuffId2Name, this.BuffId2);
			return XSingleton<XAIOtherActions>.singleton.AddBuff(intByName, intByName2, intByName3);
		}

		// Token: 0x04003C4C RID: 15436
		private int BuffId;

		// Token: 0x04003C4D RID: 15437
		private int BuffId2;

		// Token: 0x04003C4E RID: 15438
		private string BuffIdName;

		// Token: 0x04003C4F RID: 15439
		private string BuffId2Name;

		// Token: 0x04003C50 RID: 15440
		private int MonsterId;

		// Token: 0x04003C51 RID: 15441
		private string MonsterIdName;
	}
}
