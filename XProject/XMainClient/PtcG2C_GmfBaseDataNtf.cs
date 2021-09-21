using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001178 RID: 4472
	internal class PtcG2C_GmfBaseDataNtf : Protocol
	{
		// Token: 0x0600DAB3 RID: 55987 RVA: 0x0032E030 File Offset: 0x0032C230
		public override uint GetProtoType()
		{
			return 4338U;
		}

		// Token: 0x0600DAB4 RID: 55988 RVA: 0x0032E047 File Offset: 0x0032C247
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfRoleDatas>(stream, this.Data);
		}

		// Token: 0x0600DAB5 RID: 55989 RVA: 0x0032E057 File Offset: 0x0032C257
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfRoleDatas>(stream);
		}

		// Token: 0x0600DAB6 RID: 55990 RVA: 0x0032E066 File Offset: 0x0032C266
		public override void Process()
		{
			Process_PtcG2C_GmfBaseDataNtf.Process(this);
		}

		// Token: 0x04006245 RID: 25157
		public GmfRoleDatas Data = new GmfRoleDatas();
	}
}
