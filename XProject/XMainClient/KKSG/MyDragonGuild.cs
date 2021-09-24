using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MyDragonGuild")]
	[Serializable]
	public class MyDragonGuild : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		private void Resetposition()
		{
			this.positionSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "totalPPT", DataFormat = DataFormat.TwosComplement)]
		public ulong totalPPT
		{
			get
			{
				return this._totalPPT ?? 0UL;
			}
			set
			{
				this._totalPPT = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalPPTSpecified
		{
			get
			{
				return this._totalPPT != null;
			}
			set
			{
				bool flag = value == (this._totalPPT == null);
				if (flag)
				{
					this._totalPPT = (value ? new ulong?(this.totalPPT) : null);
				}
			}
		}

		private bool ShouldSerializetotalPPT()
		{
			return this.totalPPTSpecified;
		}

		private void ResettotalPPT()
		{
			this.totalPPTSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public uint capacity
		{
			get
			{
				return this._capacity ?? 0U;
			}
			set
			{
				this._capacity = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool capacitySpecified
		{
			get
			{
				return this._capacity != null;
			}
			set
			{
				bool flag = value == (this._capacity == null);
				if (flag)
				{
					this._capacity = (value ? new uint?(this.capacity) : null);
				}
			}
		}

		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "memberCount", DataFormat = DataFormat.TwosComplement)]
		public uint memberCount
		{
			get
			{
				return this._memberCount ?? 0U;
			}
			set
			{
				this._memberCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberCountSpecified
		{
			get
			{
				return this._memberCount != null;
			}
			set
			{
				bool flag = value == (this._memberCount == null);
				if (flag)
				{
					this._memberCount = (value ? new uint?(this.memberCount) : null);
				}
			}
		}

		private bool ShouldSerializememberCount()
		{
			return this.memberCountSpecified;
		}

		private void ResetmemberCount()
		{
			this.memberCountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "mapId", DataFormat = DataFormat.TwosComplement)]
		public uint mapId
		{
			get
			{
				return this._mapId ?? 0U;
			}
			set
			{
				this._mapId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapIdSpecified
		{
			get
			{
				return this._mapId != null;
			}
			set
			{
				bool flag = value == (this._mapId == null);
				if (flag)
				{
					this._mapId = (value ? new uint?(this.mapId) : null);
				}
			}
		}

		private bool ShouldSerializemapId()
		{
			return this.mapIdSpecified;
		}

		private void ResetmapId()
		{
			this.mapIdSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "mapCnt", DataFormat = DataFormat.TwosComplement)]
		public uint mapCnt
		{
			get
			{
				return this._mapCnt ?? 0U;
			}
			set
			{
				this._mapCnt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapCntSpecified
		{
			get
			{
				return this._mapCnt != null;
			}
			set
			{
				bool flag = value == (this._mapCnt == null);
				if (flag)
				{
					this._mapCnt = (value ? new uint?(this.mapCnt) : null);
				}
			}
		}

		private bool ShouldSerializemapCnt()
		{
			return this.mapCntSpecified;
		}

		private void ResetmapCnt()
		{
			this.mapCntSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "firstPassTime", DataFormat = DataFormat.TwosComplement)]
		public uint firstPassTime
		{
			get
			{
				return this._firstPassTime ?? 0U;
			}
			set
			{
				this._firstPassTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassTimeSpecified
		{
			get
			{
				return this._firstPassTime != null;
			}
			set
			{
				bool flag = value == (this._firstPassTime == null);
				if (flag)
				{
					this._firstPassTime = (value ? new uint?(this.firstPassTime) : null);
				}
			}
		}

		private bool ShouldSerializefirstPassTime()
		{
			return this.firstPassTimeSpecified;
		}

		private void ResetfirstPassTime()
		{
			this.firstPassTimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _dgid;

		private uint? _position;

		private uint? _level;

		private string _name;

		private ulong? _totalPPT;

		private uint? _capacity;

		private uint? _memberCount;

		private uint? _mapId;

		private uint? _mapCnt;

		private uint? _firstPassTime;

		private uint? _exp;

		private IExtension extensionObject;
	}
}
