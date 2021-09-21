using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012CC RID: 4812
	internal class PtcM2C_SkyCityFinalRes : Protocol
	{
		// Token: 0x0600E014 RID: 57364 RVA: 0x00335880 File Offset: 0x00333A80
		public override uint GetProtoType()
		{
			return 30112U;
		}

		// Token: 0x0600E015 RID: 57365 RVA: 0x00335897 File Offset: 0x00333A97
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityFinalBaseInfo>(stream, this.Data);
		}

		// Token: 0x0600E016 RID: 57366 RVA: 0x003358A7 File Offset: 0x00333AA7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityFinalBaseInfo>(stream);
		}

		// Token: 0x0600E017 RID: 57367 RVA: 0x003358B6 File Offset: 0x00333AB6
		public override void Process()
		{
			Process_PtcM2C_SkyCityFinalRes.Process(this);
		}

		// Token: 0x04006348 RID: 25416
		public SkyCityFinalBaseInfo Data = new SkyCityFinalBaseInfo();
	}
}
