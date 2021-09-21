using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001319 RID: 4889
	internal class PtcG2C_SpActivityChangeNtf : Protocol
	{
		// Token: 0x0600E153 RID: 57683 RVA: 0x003375C8 File Offset: 0x003357C8
		public override uint GetProtoType()
		{
			return 24832U;
		}

		// Token: 0x0600E154 RID: 57684 RVA: 0x003375DF File Offset: 0x003357DF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpActivityChange>(stream, this.Data);
		}

		// Token: 0x0600E155 RID: 57685 RVA: 0x003375EF File Offset: 0x003357EF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpActivityChange>(stream);
		}

		// Token: 0x0600E156 RID: 57686 RVA: 0x003375FE File Offset: 0x003357FE
		public override void Process()
		{
			Process_PtcG2C_SpActivityChangeNtf.Process(this);
		}

		// Token: 0x04006386 RID: 25478
		public SpActivityChange Data = new SpActivityChange();
	}
}
