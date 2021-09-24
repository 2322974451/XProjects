using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCheckinBoxNtf")]
	[Serializable]
	public class GuildCheckinBoxNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "processbar", DataFormat = DataFormat.TwosComplement)]
		public uint processbar
		{
			get
			{
				return this._processbar ?? 0U;
			}
			set
			{
				this._processbar = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool processbarSpecified
		{
			get
			{
				return this._processbar != null;
			}
			set
			{
				bool flag = value == (this._processbar == null);
				if (flag)
				{
					this._processbar = (value ? new uint?(this.processbar) : null);
				}
			}
		}

		private bool ShouldSerializeprocessbar()
		{
			return this.processbarSpecified;
		}

		private void Resetprocessbar()
		{
			this.processbarSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
		public uint boxmask
		{
			get
			{
				return this._boxmask ?? 0U;
			}
			set
			{
				this._boxmask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool boxmaskSpecified
		{
			get
			{
				return this._boxmask != null;
			}
			set
			{
				bool flag = value == (this._boxmask == null);
				if (flag)
				{
					this._boxmask = (value ? new uint?(this.boxmask) : null);
				}
			}
		}

		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _processbar;

		private uint? _boxmask;

		private IExtension extensionObject;
	}
}
