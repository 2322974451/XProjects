using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200111C RID: 4380
	internal class PtcC2G_TssSdkSendAnti2Server : Protocol
	{
		// Token: 0x0600D934 RID: 55604 RVA: 0x0032AB28 File Offset: 0x00328D28
		public override uint GetProtoType()
		{
			return 62305U;
		}

		// Token: 0x0600D935 RID: 55605 RVA: 0x0032AB3F File Offset: 0x00328D3F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TssSdkAntiData>(stream, this.Data);
		}

		// Token: 0x0600D936 RID: 55606 RVA: 0x0032AB4F File Offset: 0x00328D4F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TssSdkAntiData>(stream);
		}

		// Token: 0x0600D937 RID: 55607 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061FA RID: 25082
		public TssSdkAntiData Data = new TssSdkAntiData();
	}
}
