using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleGuildBonusData")]
	[Serializable]
	public class RoleGuildBonusData : IExtensible
	{

		[ProtoMember(1, Name = "sentGuildBonus", DataFormat = DataFormat.Default)]
		public List<OnlyOnceGuildBonusData> sentGuildBonus
		{
			get
			{
				return this._sentGuildBonus;
			}
		}

		[ProtoMember(2, Name = "gotGuildBonusDayNum", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> gotGuildBonusDayNum
		{
			get
			{
				return this._gotGuildBonusDayNum;
			}
		}

		[ProtoMember(3, Name = "gotGuildBonusTotalNum", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> gotGuildBonusTotalNum
		{
			get
			{
				return this._gotGuildBonusTotalNum;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<OnlyOnceGuildBonusData> _sentGuildBonus = new List<OnlyOnceGuildBonusData>();

		private readonly List<MapKeyValue> _gotGuildBonusDayNum = new List<MapKeyValue>();

		private readonly List<MapKeyValue> _gotGuildBonusTotalNum = new List<MapKeyValue>();

		private IExtension extensionObject;
	}
}
