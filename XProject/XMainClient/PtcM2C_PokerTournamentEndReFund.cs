using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_PokerTournamentEndReFund : Protocol
	{

		public override uint GetProtoType()
		{
			return 50590U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PokerTournamentEndReFundMsg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PokerTournamentEndReFundMsg>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_PokerTournamentEndReFund.Process(this);
		}

		public PokerTournamentEndReFundMsg Data = new PokerTournamentEndReFundMsg();
	}
}
