using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleAncientPowerData")]
	[Serializable]
	public class HeroBattleAncientPowerData : IExtensible
	{

		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
			}
		}

		[ProtoMember(2, Name = "ancientpower", DataFormat = DataFormat.TwosComplement)]
		public List<double> ancientpower
		{
			get
			{
				return this._ancientpower;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleids = new List<ulong>();

		private readonly List<double> _ancientpower = new List<double>();

		private IExtension extensionObject;
	}
}
