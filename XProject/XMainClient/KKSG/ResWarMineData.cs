using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarMineData")]
	[Serializable]
	public class ResWarMineData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "mine", DataFormat = DataFormat.TwosComplement)]
		public uint mine
		{
			get
			{
				return this._mine ?? 0U;
			}
			set
			{
				this._mine = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mineSpecified
		{
			get
			{
				return this._mine != null;
			}
			set
			{
				bool flag = value == (this._mine == null);
				if (flag)
				{
					this._mine = (value ? new uint?(this.mine) : null);
				}
			}
		}

		private bool ShouldSerializemine()
		{
			return this.mineSpecified;
		}

		private void Resetmine()
		{
			this.mineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildid;

		private uint? _mine;

		private IExtension extensionObject;
	}
}
