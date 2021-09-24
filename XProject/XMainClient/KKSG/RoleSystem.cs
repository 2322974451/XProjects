using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleSystem")]
	[Serializable]
	public class RoleSystem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "system", DataFormat = DataFormat.Default)]
		public byte[] system
		{
			get
			{
				return this._system ?? null;
			}
			set
			{
				this._system = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool systemSpecified
		{
			get
			{
				return this._system != null;
			}
			set
			{
				bool flag = value == (this._system == null);
				if (flag)
				{
					this._system = (value ? this.system : null);
				}
			}
		}

		private bool ShouldSerializesystem()
		{
			return this.systemSpecified;
		}

		private void Resetsystem()
		{
			this.systemSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "firsttime", DataFormat = DataFormat.Default)]
		public byte[] firsttime
		{
			get
			{
				return this._firsttime ?? null;
			}
			set
			{
				this._firsttime = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firsttimeSpecified
		{
			get
			{
				return this._firsttime != null;
			}
			set
			{
				bool flag = value == (this._firsttime == null);
				if (flag)
				{
					this._firsttime = (value ? this.firsttime : null);
				}
			}
		}

		private bool ShouldSerializefirsttime()
		{
			return this.firsttimeSpecified;
		}

		private void Resetfirsttime()
		{
			this.firsttimeSpecified = false;
		}

		[ProtoMember(3, Name = "opentime", DataFormat = DataFormat.Default)]
		public List<SysOpenTime> opentime
		{
			get
			{
				return this._opentime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private byte[] _system;

		private byte[] _firsttime;

		private readonly List<SysOpenTime> _opentime = new List<SysOpenTime>();

		private IExtension extensionObject;
	}
}
