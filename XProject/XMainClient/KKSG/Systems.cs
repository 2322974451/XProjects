using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Systems")]
	[Serializable]
	public class Systems : IExtensible
	{

		[ProtoMember(1, Name = "sysIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sysIDs
		{
			get
			{
				return this._sysIDs;
			}
		}

		[ProtoMember(2, Name = "closeSysIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> closeSysIDs
		{
			get
			{
				return this._closeSysIDs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _sysIDs = new List<uint>();

		private readonly List<uint> _closeSysIDs = new List<uint>();

		private IExtension extensionObject;
	}
}
