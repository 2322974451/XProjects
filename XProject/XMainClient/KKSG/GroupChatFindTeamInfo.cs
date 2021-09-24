using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatFindTeamInfo")]
	[Serializable]
	public class GroupChatFindTeamInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
		public string groupchatName
		{
			get
			{
				return this._groupchatName ?? "";
			}
			set
			{
				this._groupchatName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatNameSpecified
		{
			get
			{
				return this._groupchatName != null;
			}
			set
			{
				bool flag = value == (this._groupchatName == null);
				if (flag)
				{
					this._groupchatName = (value ? this.groupchatName : null);
				}
			}
		}

		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "issueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong issueIndex
		{
			get
			{
				return this._issueIndex ?? 0UL;
			}
			set
			{
				this._issueIndex = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool issueIndexSpecified
		{
			get
			{
				return this._issueIndex != null;
			}
			set
			{
				bool flag = value == (this._issueIndex == null);
				if (flag)
				{
					this._issueIndex = (value ? new ulong?(this.issueIndex) : null);
				}
			}
		}

		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
		public uint stageID
		{
			get
			{
				return this._stageID ?? 0U;
			}
			set
			{
				this._stageID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageIDSpecified
		{
			get
			{
				return this._stageID != null;
			}
			set
			{
				bool flag = value == (this._stageID == null);
				if (flag)
				{
					this._stageID = (value ? new uint?(this.stageID) : null);
				}
			}
		}

		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "fighting", DataFormat = DataFormat.TwosComplement)]
		public uint fighting
		{
			get
			{
				return this._fighting ?? 0U;
			}
			set
			{
				this._fighting = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fightingSpecified
		{
			get
			{
				return this._fighting != null;
			}
			set
			{
				bool flag = value == (this._fighting == null);
				if (flag)
				{
					this._fighting = (value ? new uint?(this.fighting) : null);
				}
			}
		}

		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
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
					this._type = (value ? new uint?(this.type) : null);
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

		[ProtoMember(7, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "issuetime", DataFormat = DataFormat.TwosComplement)]
		public uint issuetime
		{
			get
			{
				return this._issuetime ?? 0U;
			}
			set
			{
				this._issuetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool issuetimeSpecified
		{
			get
			{
				return this._issuetime != null;
			}
			set
			{
				bool flag = value == (this._issuetime == null);
				if (flag)
				{
					this._issuetime = (value ? new uint?(this.issuetime) : null);
				}
			}
		}

		private bool ShouldSerializeissuetime()
		{
			return this.issuetimeSpecified;
		}

		private void Resetissuetime()
		{
			this.issuetimeSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "leaderroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderroleid
		{
			get
			{
				return this._leaderroleid ?? 0UL;
			}
			set
			{
				this._leaderroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderroleidSpecified
		{
			get
			{
				return this._leaderroleid != null;
			}
			set
			{
				bool flag = value == (this._leaderroleid == null);
				if (flag)
				{
					this._leaderroleid = (value ? new ulong?(this.leaderroleid) : null);
				}
			}
		}

		private bool ShouldSerializeleaderroleid()
		{
			return this.leaderroleidSpecified;
		}

		private void Resetleaderroleid()
		{
			this.leaderroleidSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "isselfingroup", DataFormat = DataFormat.Default)]
		public bool isselfingroup
		{
			get
			{
				return this._isselfingroup ?? false;
			}
			set
			{
				this._isselfingroup = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isselfingroupSpecified
		{
			get
			{
				return this._isselfingroup != null;
			}
			set
			{
				bool flag = value == (this._isselfingroup == null);
				if (flag)
				{
					this._isselfingroup = (value ? new bool?(this.isselfingroup) : null);
				}
			}
		}

		private bool ShouldSerializeisselfingroup()
		{
			return this.isselfingroupSpecified;
		}

		private void Resetisselfingroup()
		{
			this.isselfingroupSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private string _groupchatName;

		private ulong? _issueIndex;

		private uint? _stageID;

		private uint? _fighting;

		private uint? _type;

		private uint? _time;

		private uint? _state;

		private uint? _issuetime;

		private ulong? _leaderroleid;

		private bool? _isselfingroup;

		private IExtension extensionObject;
	}
}
