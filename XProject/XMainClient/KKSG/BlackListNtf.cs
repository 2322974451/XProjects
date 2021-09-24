using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BlackListNtf")]
	[Serializable]
	public class BlackListNtf : IExtensible
	{

		[ProtoMember(1, Name = "blacklist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> blacklist
		{
			get
			{
				return this._blacklist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<Friend2Client> _blacklist = new List<Friend2Client>();

		private IExtension extensionObject;
	}
}
