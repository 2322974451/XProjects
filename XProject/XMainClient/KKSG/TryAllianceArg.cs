using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TryAllianceArg")]
	[Serializable]
	public class TryAllianceArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guild", DataFormat = DataFormat.TwosComplement)]
		public ulong guild
		{
			get
			{
				return this._guild ?? 0UL;
			}
			set
			{
				this._guild = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildSpecified
		{
			get
			{
				return this._guild != null;
			}
			set
			{
				bool flag = value == (this._guild == null);
				if (flag)
				{
					this._guild = (value ? new ulong?(this.guild) : null);
				}
			}
		}

		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guild;

		private IExtension extensionObject;
	}
}
