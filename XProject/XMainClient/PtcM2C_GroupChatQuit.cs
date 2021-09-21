using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001588 RID: 5512
	internal class PtcM2C_GroupChatQuit : Protocol
	{
		// Token: 0x0600EB43 RID: 60227 RVA: 0x003457F4 File Offset: 0x003439F4
		public override uint GetProtoType()
		{
			return 56654U;
		}

		// Token: 0x0600EB44 RID: 60228 RVA: 0x0034580B File Offset: 0x00343A0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatQuitPtc>(stream, this.Data);
		}

		// Token: 0x0600EB45 RID: 60229 RVA: 0x0034581B File Offset: 0x00343A1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatQuitPtc>(stream);
		}

		// Token: 0x0600EB46 RID: 60230 RVA: 0x0034582A File Offset: 0x00343A2A
		public override void Process()
		{
			Process_PtcM2C_GroupChatQuit.Process(this);
		}

		// Token: 0x04006573 RID: 25971
		public GroupChatQuitPtc Data = new GroupChatQuitPtc();
	}
}
