using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatSource")]
	[Serializable]
	public class ChatSource : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "desname", DataFormat = DataFormat.Default)]
		public string desname
		{
			get
			{
				return this._desname ?? "";
			}
			set
			{
				this._desname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool desnameSpecified
		{
			get
			{
				return this._desname != null;
			}
			set
			{
				bool flag = value == (this._desname == null);
				if (flag)
				{
					this._desname = (value ? this.desname : null);
				}
			}
		}

		private bool ShouldSerializedesname()
		{
			return this.desnameSpecified;
		}

		private void Resetdesname()
		{
			this.desnameSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "isBackFlow", DataFormat = DataFormat.Default)]
		public bool isBackFlow
		{
			get
			{
				return this._isBackFlow ?? false;
			}
			set
			{
				this._isBackFlow = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isBackFlowSpecified
		{
			get
			{
				return this._isBackFlow != null;
			}
			set
			{
				bool flag = value == (this._isBackFlow == null);
				if (flag)
				{
					this._isBackFlow = (value ? new bool?(this.isBackFlow) : null);
				}
			}
		}

		private bool ShouldSerializeisBackFlow()
		{
			return this.isBackFlowSpecified;
		}

		private void ResetisBackFlow()
		{
			this.isBackFlowSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "campDuelID", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelID
		{
			get
			{
				return this._campDuelID ?? 0U;
			}
			set
			{
				this._campDuelID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelIDSpecified
		{
			get
			{
				return this._campDuelID != null;
			}
			set
			{
				bool flag = value == (this._campDuelID == null);
				if (flag)
				{
					this._campDuelID = (value ? new uint?(this.campDuelID) : null);
				}
			}
		}

		private bool ShouldSerializecampDuelID()
		{
			return this.campDuelIDSpecified;
		}

		private void ResetcampDuelID()
		{
			this.campDuelIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _profession;

		private string _name;

		private uint? _viplevel;

		private uint? _powerpoint;

		private uint? _coverDesignationID;

		private uint? _paymemberid;

		private uint? _military_rank;

		private uint? _heroid;

		private string _desname;

		private PayConsume _pre = null;

		private bool? _isBackFlow;

		private uint? _campDuelID;

		private IExtension extensionObject;
	}
}
