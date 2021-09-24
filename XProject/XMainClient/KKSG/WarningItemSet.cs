using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WarningItemSet")]
	[Serializable]
	public class WarningItemSet : IExtensible
	{

		[ProtoMember(1, Name = "WarningItem", DataFormat = DataFormat.Default)]
		public List<WarningPackage> WarningItem
		{
			get
			{
				return this._WarningItem;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<WarningPackage> _WarningItem = new List<WarningPackage>();

		private IExtension extensionObject;
	}
}
