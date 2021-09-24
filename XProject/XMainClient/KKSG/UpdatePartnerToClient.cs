using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdatePartnerToClient")]
	[Serializable]
	public class UpdatePartnerToClient : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PartnerUpdateType type
		{
			get
			{
				return this._type ?? PartnerUpdateType.PUType_Normal;
			}
			set
			{
				this._type = new PartnerUpdateType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new PartnerUpdateType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "partid", DataFormat = DataFormat.TwosComplement)]
		public ulong partid
		{
			get
			{
				return this._partid ?? 0UL;
			}
			set
			{
				this._partid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool partidSpecified
		{
			get
			{
				return this._partid != null;
			}
			set
			{
				bool flag = value == (this._partid == null);
				if (flag)
				{
					this._partid = (value ? new ulong?(this.partid) : null);
				}
			}
		}

		private bool ShouldSerializepartid()
		{
			return this.partidSpecified;
		}

		private void Resetpartid()
		{
			this.partidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "leave_id", DataFormat = DataFormat.TwosComplement)]
		public ulong leave_id
		{
			get
			{
				return this._leave_id ?? 0UL;
			}
			set
			{
				this._leave_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leave_idSpecified
		{
			get
			{
				return this._leave_id != null;
			}
			set
			{
				bool flag = value == (this._leave_id == null);
				if (flag)
				{
					this._leave_id = (value ? new ulong?(this.leave_id) : null);
				}
			}
		}

		private bool ShouldSerializeleave_id()
		{
			return this.leave_idSpecified;
		}

		private void Resetleave_id()
		{
			this.leave_idSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "leave_name", DataFormat = DataFormat.Default)]
		public string leave_name
		{
			get
			{
				return this._leave_name ?? "";
			}
			set
			{
				this._leave_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leave_nameSpecified
		{
			get
			{
				return this._leave_name != null;
			}
			set
			{
				bool flag = value == (this._leave_name == null);
				if (flag)
				{
					this._leave_name = (value ? this.leave_name : null);
				}
			}
		}

		private bool ShouldSerializeleave_name()
		{
			return this.leave_nameSpecified;
		}

		private void Resetleave_name()
		{
			this.leave_nameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PartnerUpdateType? _type;

		private ulong? _partid;

		private uint? _level;

		private uint? _degree;

		private ulong? _leave_id;

		private string _leave_name;

		private IExtension extensionObject;
	}
}
