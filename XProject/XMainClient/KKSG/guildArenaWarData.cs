using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "guildArenaWarData")]
	[Serializable]
	public class guildArenaWarData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "warType", DataFormat = DataFormat.TwosComplement)]
		public uint warType
		{
			get
			{
				return this._warType ?? 0U;
			}
			set
			{
				this._warType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool warTypeSpecified
		{
			get
			{
				return this._warType != null;
			}
			set
			{
				bool flag = value == (this._warType == null);
				if (flag)
				{
					this._warType = (value ? new uint?(this.warType) : null);
				}
			}
		}

		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		[ProtoMember(2, Name = "guildArenaGroupData", DataFormat = DataFormat.Default)]
		public List<GuildArenaGroupData> guildArenaGroupData
		{
			get
			{
				return this._guildArenaGroupData;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _warType;

		private readonly List<GuildArenaGroupData> _guildArenaGroupData = new List<GuildArenaGroupData>();

		private IExtension extensionObject;
	}
}
