using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "guildarenadisplace")]
	[Serializable]
	public class guildarenadisplace : IExtensible
	{

		[ProtoMember(1, Name = "units", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> units
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

		private readonly List<GuildDarenaUnit> _units = new List<GuildDarenaUnit>();

		private IExtension extensionObject;
	}
}
