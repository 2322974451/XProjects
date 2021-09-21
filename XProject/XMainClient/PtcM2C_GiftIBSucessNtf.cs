using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014FA RID: 5370
	internal class PtcM2C_GiftIBSucessNtf : Protocol
	{
		// Token: 0x0600E8FD RID: 59645 RVA: 0x003420E4 File Offset: 0x003402E4
		public override uint GetProtoType()
		{
			return 29707U;
		}

		// Token: 0x0600E8FE RID: 59646 RVA: 0x003420FB File Offset: 0x003402FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiftIBBackInfo>(stream, this.Data);
		}

		// Token: 0x0600E8FF RID: 59647 RVA: 0x0034210B File Offset: 0x0034030B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GiftIBBackInfo>(stream);
		}

		// Token: 0x0600E900 RID: 59648 RVA: 0x0034211A File Offset: 0x0034031A
		public override void Process()
		{
			Process_PtcM2C_GiftIBSucessNtf.Process(this);
		}

		// Token: 0x040064FB RID: 25851
		public GiftIBBackInfo Data = new GiftIBBackInfo();
	}
}
