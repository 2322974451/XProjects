using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleConfig")]
	[Serializable]
	public class RoleConfig : IExtensible
	{

		[ProtoMember(1, Name = "type", DataFormat = DataFormat.Default)]
		public List<string> type
		{
			get
			{
				return this._type;
			}
		}

		[ProtoMember(2, Name = "value", DataFormat = DataFormat.Default)]
		public List<string> value
		{
			get
			{
				return this._value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<string> _type = new List<string>();

		private readonly List<string> _value = new List<string>();

		private IExtension extensionObject;
	}
}
