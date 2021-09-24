using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuffList")]
	[Serializable]
	public class BuffList : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<Buff> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "casterid", DataFormat = DataFormat.TwosComplement)]
		public ulong casterid
		{
			get
			{
				return this._casterid ?? 0UL;
			}
			set
			{
				this._casterid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool casteridSpecified
		{
			get
			{
				return this._casterid != null;
			}
			set
			{
				bool flag = value == (this._casterid == null);
				if (flag)
				{
					this._casterid = (value ? new ulong?(this.casterid) : null);
				}
			}
		}

		private bool ShouldSerializecasterid()
		{
			return this.casteridSpecified;
		}

		private void Resetcasterid()
		{
			this.casteridSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private readonly List<Buff> _buffs = new List<Buff>();

		private ulong? _casterid;

		private IExtension extensionObject;
	}
}
