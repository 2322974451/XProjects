using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200111D RID: 4381
	internal class PtcG2C_TssSdkAntiDataNtf : Protocol
	{
		// Token: 0x0600D939 RID: 55609 RVA: 0x0032AB74 File Offset: 0x00328D74
		public override uint GetProtoType()
		{
			return 33482U;
		}

		// Token: 0x0600D93A RID: 55610 RVA: 0x0032AB8B File Offset: 0x00328D8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TssSdkAntiData>(stream, this.Data);
		}

		// Token: 0x0600D93B RID: 55611 RVA: 0x0032AB9B File Offset: 0x00328D9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TssSdkAntiData>(stream);
		}

		// Token: 0x0600D93C RID: 55612 RVA: 0x0032ABAA File Offset: 0x00328DAA
		public override void Process()
		{
			Process_PtcG2C_TssSdkAntiDataNtf.Process(this);
		}

		// Token: 0x040061FB RID: 25083
		public TssSdkAntiData Data = new TssSdkAntiData();
	}
}
