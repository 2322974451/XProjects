using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildMemberArg")]
	[Serializable]
	public class DragonGuildMemberArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildId
		{
			get
			{
				return this._guildId ?? 0UL;
			}
			set
			{
				this._guildId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildIdSpecified
		{
			get
			{
				return this._guildId != null;
			}
			set
			{
				bool flag = value == (this._guildId == null);
				if (flag)
				{
					this._guildId = (value ? new ulong?(this.guildId) : null);
				}
			}
		}

		private bool ShouldSerializeguildId()
		{
			return this.guildIdSpecified;
		}

		private void ResetguildId()
		{
			this.guildIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildId;

		private IExtension extensionObject;
	}
}
