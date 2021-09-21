using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010C4 RID: 4292
	internal class PtcC2G_AddLevelScriptExtString : Protocol
	{
		// Token: 0x0600D7C7 RID: 55239 RVA: 0x00328AAC File Offset: 0x00326CAC
		public override uint GetProtoType()
		{
			return 34579U;
		}

		// Token: 0x0600D7C8 RID: 55240 RVA: 0x00328AC3 File Offset: 0x00326CC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddLevelScriptExtString>(stream, this.Data);
		}

		// Token: 0x0600D7C9 RID: 55241 RVA: 0x00328AD3 File Offset: 0x00326CD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AddLevelScriptExtString>(stream);
		}

		// Token: 0x0600D7CA RID: 55242 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061B5 RID: 25013
		public AddLevelScriptExtString Data = new AddLevelScriptExtString();
	}
}
