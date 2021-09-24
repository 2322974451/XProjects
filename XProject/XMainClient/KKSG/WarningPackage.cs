using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WarningPackage")]
	[Serializable]
	public class WarningPackage : IExtensible
	{

		[ProtoMember(1, Name = "WarningPos", DataFormat = DataFormat.TwosComplement)]
		public List<uint> WarningPos
		{
			get
			{
				return this._WarningPos;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public ulong ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _WarningPos = new List<uint>();

		private ulong _ID;

		private IExtension extensionObject;
	}
}
