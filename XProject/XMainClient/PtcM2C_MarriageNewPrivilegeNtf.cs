using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200169A RID: 5786
	internal class PtcM2C_MarriageNewPrivilegeNtf : Protocol
	{
		// Token: 0x0600EFC0 RID: 61376 RVA: 0x0034BDA8 File Offset: 0x00349FA8
		public override uint GetProtoType()
		{
			return 50551U;
		}

		// Token: 0x0600EFC1 RID: 61377 RVA: 0x0034BDBF File Offset: 0x00349FBF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageNewPrivilegeNtfData>(stream, this.Data);
		}

		// Token: 0x0600EFC2 RID: 61378 RVA: 0x0034BDCF File Offset: 0x00349FCF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MarriageNewPrivilegeNtfData>(stream);
		}

		// Token: 0x0600EFC3 RID: 61379 RVA: 0x0034BDDE File Offset: 0x00349FDE
		public override void Process()
		{
			Process_PtcM2C_MarriageNewPrivilegeNtf.Process(this);
		}

		// Token: 0x0400665E RID: 26206
		public MarriageNewPrivilegeNtfData Data = new MarriageNewPrivilegeNtfData();
	}
}
