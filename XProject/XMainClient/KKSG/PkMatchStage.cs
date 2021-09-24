using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkMatchStage")]
	[Serializable]
	public class PkMatchStage : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ctime", DataFormat = DataFormat.TwosComplement)]
		public uint ctime
		{
			get
			{
				return this._ctime ?? 0U;
			}
			set
			{
				this._ctime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ctimeSpecified
		{
			get
			{
				return this._ctime != null;
			}
			set
			{
				bool flag = value == (this._ctime == null);
				if (flag)
				{
					this._ctime = (value ? new uint?(this.ctime) : null);
				}
			}
		}

		private bool ShouldSerializectime()
		{
			return this.ctimeSpecified;
		}

		private void Resetctime()
		{
			this.ctimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "span", DataFormat = DataFormat.TwosComplement)]
		public uint span
		{
			get
			{
				return this._span ?? 0U;
			}
			set
			{
				this._span = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool spanSpecified
		{
			get
			{
				return this._span != null;
			}
			set
			{
				bool flag = value == (this._span == null);
				if (flag)
				{
					this._span = (value ? new uint?(this.span) : null);
				}
			}
		}

		private bool ShouldSerializespan()
		{
			return this.spanSpecified;
		}

		private void Resetspan()
		{
			this.spanSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "robotpercent", DataFormat = DataFormat.TwosComplement)]
		public uint robotpercent
		{
			get
			{
				return this._robotpercent ?? 0U;
			}
			set
			{
				this._robotpercent = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool robotpercentSpecified
		{
			get
			{
				return this._robotpercent != null;
			}
			set
			{
				bool flag = value == (this._robotpercent == null);
				if (flag)
				{
					this._robotpercent = (value ? new uint?(this.robotpercent) : null);
				}
			}
		}

		private bool ShouldSerializerobotpercent()
		{
			return this.robotpercentSpecified;
		}

		private void Resetrobotpercent()
		{
			this.robotpercentSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lookupid", DataFormat = DataFormat.TwosComplement)]
		public int lookupid
		{
			get
			{
				return this._lookupid ?? 0;
			}
			set
			{
				this._lookupid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lookupidSpecified
		{
			get
			{
				return this._lookupid != null;
			}
			set
			{
				bool flag = value == (this._lookupid == null);
				if (flag)
				{
					this._lookupid = (value ? new int?(this.lookupid) : null);
				}
			}
		}

		private bool ShouldSerializelookupid()
		{
			return this.lookupidSpecified;
		}

		private void Resetlookupid()
		{
			this.lookupidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _ctime;

		private uint? _span;

		private uint? _robotpercent;

		private int? _lookupid;

		private IExtension extensionObject;
	}
}
