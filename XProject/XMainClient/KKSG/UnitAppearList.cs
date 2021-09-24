using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UnitAppearList")]
	[Serializable]
	public class UnitAppearList : IExtensible
	{

		[ProtoMember(1, Name = "units", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> units
		{
			get
			{
				return this._units;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<UnitAppearance> _units = new List<UnitAppearance>();

		private IExtension extensionObject;
	}
}
