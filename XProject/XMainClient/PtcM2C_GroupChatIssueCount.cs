using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015BB RID: 5563
	internal class PtcM2C_GroupChatIssueCount : Protocol
	{
		// Token: 0x0600EC11 RID: 60433 RVA: 0x003468F8 File Offset: 0x00344AF8
		public override uint GetProtoType()
		{
			return 61968U;
		}

		// Token: 0x0600EC12 RID: 60434 RVA: 0x0034690F File Offset: 0x00344B0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatIssueCountNtf>(stream, this.Data);
		}

		// Token: 0x0600EC13 RID: 60435 RVA: 0x0034691F File Offset: 0x00344B1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatIssueCountNtf>(stream);
		}

		// Token: 0x0600EC14 RID: 60436 RVA: 0x0034692E File Offset: 0x00344B2E
		public override void Process()
		{
			Process_PtcM2C_GroupChatIssueCount.Process(this);
		}

		// Token: 0x04006598 RID: 26008
		public GroupChatIssueCountNtf Data = new GroupChatIssueCountNtf();
	}
}
