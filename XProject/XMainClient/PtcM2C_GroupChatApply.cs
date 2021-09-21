using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015BD RID: 5565
	internal class PtcM2C_GroupChatApply : Protocol
	{
		// Token: 0x0600EC18 RID: 60440 RVA: 0x00346974 File Offset: 0x00344B74
		public override uint GetProtoType()
		{
			return 34424U;
		}

		// Token: 0x0600EC19 RID: 60441 RVA: 0x0034698B File Offset: 0x00344B8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatApplyNtf>(stream, this.Data);
		}

		// Token: 0x0600EC1A RID: 60442 RVA: 0x0034699B File Offset: 0x00344B9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatApplyNtf>(stream);
		}

		// Token: 0x0600EC1B RID: 60443 RVA: 0x003469AA File Offset: 0x00344BAA
		public override void Process()
		{
			Process_PtcM2C_GroupChatApply.Process(this);
		}

		// Token: 0x04006599 RID: 26009
		public GroupChatApplyNtf Data = new GroupChatApplyNtf();
	}
}
