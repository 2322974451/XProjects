using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A0 RID: 4512
	internal class PtcC2M_LoadOfflineChatNtf : Protocol
	{
		// Token: 0x0600DB43 RID: 56131 RVA: 0x0032ECAC File Offset: 0x0032CEAC
		public override uint GetProtoType()
		{
			return 26622U;
		}

		// Token: 0x0600DB44 RID: 56132 RVA: 0x0032ECC3 File Offset: 0x0032CEC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoadOffLineChatNtf>(stream, this.Data);
		}

		// Token: 0x0600DB45 RID: 56133 RVA: 0x0032ECD3 File Offset: 0x0032CED3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoadOffLineChatNtf>(stream);
		}

		// Token: 0x0600DB46 RID: 56134 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400625A RID: 25178
		public LoadOffLineChatNtf Data = new LoadOffLineChatNtf();
	}
}
