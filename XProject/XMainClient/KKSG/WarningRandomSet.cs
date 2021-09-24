using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WarningRandomSet")]
	[Serializable]
	public class WarningRandomSet : IExtensible
	{

		[ProtoMember(1, Name = "WarningItems", DataFormat = DataFormat.Default)]
		public List<WarningItemSet> WarningItems
		{
			get
			{
				return this._WarningItems;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Firer", DataFormat = DataFormat.TwosComplement)]
		public ulong Firer
		{
			get
			{
				return this._Firer;
			}
			set
			{
				this._Firer = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "skill", DataFormat = DataFormat.TwosComplement)]
		public uint skill
		{
			get
			{
				return this._skill;
			}
			set
			{
				this._skill = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<WarningItemSet> _WarningItems = new List<WarningItemSet>();

		private ulong _Firer;

		private uint _skill;

		private IExtension extensionObject;
	}
}
