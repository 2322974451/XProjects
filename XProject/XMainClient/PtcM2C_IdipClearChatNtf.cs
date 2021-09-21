using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012A5 RID: 4773
	internal class PtcM2C_IdipClearChatNtf : Protocol
	{
		// Token: 0x0600DF72 RID: 57202 RVA: 0x00334988 File Offset: 0x00332B88
		public override uint GetProtoType()
		{
			return 47934U;
		}

		// Token: 0x0600DF73 RID: 57203 RVA: 0x0033499F File Offset: 0x00332B9F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipClearChatInfo>(stream, this.Data);
		}

		// Token: 0x0600DF74 RID: 57204 RVA: 0x003349AF File Offset: 0x00332BAF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipClearChatInfo>(stream);
		}

		// Token: 0x0600DF75 RID: 57205 RVA: 0x003349BE File Offset: 0x00332BBE
		public override void Process()
		{
			Process_PtcM2C_IdipClearChatNtf.Process(this);
		}

		// Token: 0x04006328 RID: 25384
		public IdipClearChatInfo Data = new IdipClearChatInfo();
	}
}
