using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBuffSimpleAllInfo")]
	[Serializable]
	public class GuildBuffSimpleAllInfo : IExtensible
	{

		[ProtoMember(1, Name = "buff", DataFormat = DataFormat.Default)]
		public List<GuildBuffSimpleInfo> buff
		{
			get
			{
				return this._buff;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildBuffSimpleInfo> _buff = new List<GuildBuffSimpleInfo>();

		private IExtension extensionObject;
	}
}
