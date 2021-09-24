using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getintegralbattleInfores")]
	[Serializable]
	public class getintegralbattleInfores : IExtensible
	{

		[ProtoMember(1, Name = "battleinfo", DataFormat = DataFormat.Default)]
		public List<IntegralBattle> battleinfo
		{
			get
			{
				return this._battleinfo;
			}
		}

		[ProtoMember(2, Name = "battleTime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> battleTime
		{
			get
			{
				return this._battleTime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<IntegralBattle> _battleinfo = new List<IntegralBattle>();

		private readonly List<uint> _battleTime = new List<uint>();

		private IExtension extensionObject;
	}
}
