using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ScenePrepareInfoNtf")]
	[Serializable]
	public class ScenePrepareInfoNtf : IExtensible
	{

		[ProtoMember(1, Name = "unreadyroles", DataFormat = DataFormat.Default)]
		public List<string> unreadyroles
		{
			get
			{
				return this._unreadyroles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<string> _unreadyroles = new List<string>();

		private IExtension extensionObject;
	}
}
