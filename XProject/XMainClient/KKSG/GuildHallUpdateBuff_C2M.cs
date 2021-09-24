using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHallUpdateBuff_C2M")]
	[Serializable]
	public class GuildHallUpdateBuff_C2M : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _buffid;

		private IExtension extensionObject;
	}
}
