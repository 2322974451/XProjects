using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JoinLargeRoomArg")]
	[Serializable]
	public class JoinLargeRoomArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "plat", DataFormat = DataFormat.TwosComplement)]
		public uint plat
		{
			get
			{
				return this._plat ?? 0U;
			}
			set
			{
				this._plat = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool platSpecified
		{
			get
			{
				return this._plat != null;
			}
			set
			{
				bool flag = value == (this._plat == null);
				if (flag)
				{
					this._plat = (value ? new uint?(this.plat) : null);
				}
			}
		}

		private bool ShouldSerializeplat()
		{
			return this.platSpecified;
		}

		private void Resetplat()
		{
			this.platSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		private void Resetip()
		{
			this.ipSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "acc", DataFormat = DataFormat.Default)]
		public string acc
		{
			get
			{
				return this._acc ?? "";
			}
			set
			{
				this._acc = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accSpecified
		{
			get
			{
				return this._acc != null;
			}
			set
			{
				bool flag = value == (this._acc == null);
				if (flag)
				{
					this._acc = (value ? this.acc : null);
				}
			}
		}

		private bool ShouldSerializeacc()
		{
			return this.accSpecified;
		}

		private void Resetacc()
		{
			this.accSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _param;

		private ulong? _roleid;

		private uint? _plat;

		private string _ip;

		private string _acc;

		private IExtension extensionObject;
	}
}
