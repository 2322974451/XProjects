using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleStatisticsNtf")]
	[Serializable]
	public class BattleStatisticsNtf : IExtensible
	{

		[ProtoMember(1, Name = "skillID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillID
		{
			get
			{
				return this._skillID;
			}
		}

		[ProtoMember(2, Name = "skillCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> skillCount
		{
			get
			{
				return this._skillCount;
			}
		}

		[ProtoMember(3, Name = "skillValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> skillValue
		{
			get
			{
				return this._skillValue;
			}
		}

		[ProtoMember(4, Name = "mobID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> mobID
		{
			get
			{
				return this._mobID;
			}
		}

		[ProtoMember(5, Name = "mobCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> mobCount
		{
			get
			{
				return this._mobCount;
			}
		}

		[ProtoMember(6, Name = "mobValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> mobValue
		{
			get
			{
				return this._mobValue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _skillID = new List<uint>();

		private readonly List<int> _skillCount = new List<int>();

		private readonly List<double> _skillValue = new List<double>();

		private readonly List<uint> _mobID = new List<uint>();

		private readonly List<int> _mobCount = new List<int>();

		private readonly List<double> _mobValue = new List<double>();

		private IExtension extensionObject;
	}
}
