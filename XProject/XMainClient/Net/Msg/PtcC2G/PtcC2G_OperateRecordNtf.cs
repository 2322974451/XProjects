using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_OperateRecordNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 56173U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OperateRecord>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OperateRecord>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public OperateRecord Data = new OperateRecord();
	}
}
