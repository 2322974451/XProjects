using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFlReturn")]
	[Serializable]
	public class NpcFlReturn : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dropid", DataFormat = DataFormat.TwosComplement)]
		public uint dropid
		{
			get
			{
				return this._dropid ?? 0U;
			}
			set
			{
				this._dropid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dropidSpecified
		{
			get
			{
				return this._dropid != null;
			}
			set
			{
				bool flag = value == (this._dropid == null);
				if (flag)
				{
					this._dropid = (value ? new uint?(this.dropid) : null);
				}
			}
		}

		private bool ShouldSerializedropid()
		{
			return this.dropidSpecified;
		}

		private void Resetdropid()
		{
			this.dropidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "gtime", DataFormat = DataFormat.TwosComplement)]
		public uint gtime
		{
			get
			{
				return this._gtime ?? 0U;
			}
			set
			{
				this._gtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gtimeSpecified
		{
			get
			{
				return this._gtime != null;
			}
			set
			{
				bool flag = value == (this._gtime == null);
				if (flag)
				{
					this._gtime = (value ? new uint?(this.gtime) : null);
				}
			}
		}

		private bool ShouldSerializegtime()
		{
			return this.gtimeSpecified;
		}

		private void Resetgtime()
		{
			this.gtimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "mailconfid", DataFormat = DataFormat.TwosComplement)]
		public uint mailconfid
		{
			get
			{
				return this._mailconfid ?? 0U;
			}
			set
			{
				this._mailconfid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mailconfidSpecified
		{
			get
			{
				return this._mailconfid != null;
			}
			set
			{
				bool flag = value == (this._mailconfid == null);
				if (flag)
				{
					this._mailconfid = (value ? new uint?(this.mailconfid) : null);
				}
			}
		}

		private bool ShouldSerializemailconfid()
		{
			return this.mailconfidSpecified;
		}

		private void Resetmailconfid()
		{
			this.mailconfidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _dropid;

		private uint? _gtime;

		private uint? _mailconfid;

		private IExtension extensionObject;
	}
}
