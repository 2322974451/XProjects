using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012D0 RID: 4816
	internal class PtcG2C_SkyCityTimeRes : Protocol
	{
		// Token: 0x0600E022 RID: 57378 RVA: 0x00335950 File Offset: 0x00333B50
		public override uint GetProtoType()
		{
			return 30724U;
		}

		// Token: 0x0600E023 RID: 57379 RVA: 0x00335967 File Offset: 0x00333B67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityTimeInfo>(stream, this.Data);
		}

		// Token: 0x0600E024 RID: 57380 RVA: 0x00335977 File Offset: 0x00333B77
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityTimeInfo>(stream);
		}

		// Token: 0x0600E025 RID: 57381 RVA: 0x00335986 File Offset: 0x00333B86
		public override void Process()
		{
			Process_PtcG2C_SkyCityTimeRes.Process(this);
		}

		// Token: 0x0400634A RID: 25418
		public SkyCityTimeInfo Data = new SkyCityTimeInfo();
	}
}
