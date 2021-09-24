using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatInfo")]
	[Serializable]
	public class ChatInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "channel", DataFormat = DataFormat.TwosComplement)]
		public uint channel
		{
			get
			{
				return this._channel ?? 0U;
			}
			set
			{
				this._channel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool channelSpecified
		{
			get
			{
				return this._channel != null;
			}
			set
			{
				bool flag = value == (this._channel == null);
				if (flag)
				{
					this._channel = (value ? new uint?(this.channel) : null);
				}
			}
		}

		private bool ShouldSerializechannel()
		{
			return this.channelSpecified;
		}

		private void Resetchannel()
		{
			this.channelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "source", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatSource source
		{
			get
			{
				return this._source;
			}
			set
			{
				this._source = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "dest", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatDest dest
		{
			get
			{
				return this._dest;
			}
			set
			{
				this._dest = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		public string info
		{
			get
			{
				return this._info ?? "";
			}
			set
			{
				this._info = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool infoSpecified
		{
			get
			{
				return this._info != null;
			}
			set
			{
				bool flag = value == (this._info == null);
				if (flag)
				{
					this._info = (value ? this.info : null);
				}
			}
		}

		private bool ShouldSerializeinfo()
		{
			return this.infoSpecified;
		}

		private void Resetinfo()
		{
			this.infoSpecified = false;
		}

		[ProtoMember(5, Name = "param", DataFormat = DataFormat.Default)]
		public List<ChatParam> param
		{
			get
			{
				return this._param;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "priority", DataFormat = DataFormat.TwosComplement)]
		public uint priority
		{
			get
			{
				return this._priority ?? 0U;
			}
			set
			{
				this._priority = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool prioritySpecified
		{
			get
			{
				return this._priority != null;
			}
			set
			{
				bool flag = value == (this._priority == null);
				if (flag)
				{
					this._priority = (value ? new uint?(this.priority) : null);
				}
			}
		}

		private bool ShouldSerializepriority()
		{
			return this.prioritySpecified;
		}

		private void Resetpriority()
		{
			this.prioritySpecified = false;
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

		[ProtoMember(8, IsRequired = false, Name = "issystem", DataFormat = DataFormat.Default)]
		public bool issystem
		{
			get
			{
				return this._issystem ?? false;
			}
			set
			{
				this._issystem = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool issystemSpecified
		{
			get
			{
				return this._issystem != null;
			}
			set
			{
				bool flag = value == (this._issystem == null);
				if (flag)
				{
					this._issystem = (value ? new bool?(this.issystem) : null);
				}
			}
		}

		private bool ShouldSerializeissystem()
		{
			return this.issystemSpecified;
		}

		private void Resetissystem()
		{
			this.issystemSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "storeKeyId", DataFormat = DataFormat.TwosComplement)]
		public ulong storeKeyId
		{
			get
			{
				return this._storeKeyId ?? 0UL;
			}
			set
			{
				this._storeKeyId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool storeKeyIdSpecified
		{
			get
			{
				return this._storeKeyId != null;
			}
			set
			{
				bool flag = value == (this._storeKeyId == null);
				if (flag)
				{
					this._storeKeyId = (value ? new ulong?(this.storeKeyId) : null);
				}
			}
		}

		private bool ShouldSerializestoreKeyId()
		{
			return this.storeKeyIdSpecified;
		}

		private void ResetstoreKeyId()
		{
			this.storeKeyIdSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "audioLen", DataFormat = DataFormat.TwosComplement)]
		public uint audioLen
		{
			get
			{
				return this._audioLen ?? 0U;
			}
			set
			{
				this._audioLen = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioLenSpecified
		{
			get
			{
				return this._audioLen != null;
			}
			set
			{
				bool flag = value == (this._audioLen == null);
				if (flag)
				{
					this._audioLen = (value ? new uint?(this.audioLen) : null);
				}
			}
		}

		private bool ShouldSerializeaudioLen()
		{
			return this.audioLenSpecified;
		}

		private void ResetaudioLen()
		{
			this.audioLenSpecified = false;
		}

		[ProtoMember(12, Name = "destList", DataFormat = DataFormat.Default)]
		public List<ChatSource> destList
		{
			get
			{
				return this._destList;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "isbroadcast", DataFormat = DataFormat.Default)]
		public bool isbroadcast
		{
			get
			{
				return this._isbroadcast ?? false;
			}
			set
			{
				this._isbroadcast = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbroadcastSpecified
		{
			get
			{
				return this._isbroadcast != null;
			}
			set
			{
				bool flag = value == (this._isbroadcast == null);
				if (flag)
				{
					this._isbroadcast = (value ? new bool?(this.isbroadcast) : null);
				}
			}
		}

		private bool ShouldSerializeisbroadcast()
		{
			return this.isbroadcastSpecified;
		}

		private void Resetisbroadcast()
		{
			this.isbroadcastSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(15, IsRequired = false, Name = "isRecruit", DataFormat = DataFormat.Default)]
		public bool isRecruit
		{
			get
			{
				return this._isRecruit ?? false;
			}
			set
			{
				this._isRecruit = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isRecruitSpecified
		{
			get
			{
				return this._isRecruit != null;
			}
			set
			{
				bool flag = value == (this._isRecruit == null);
				if (flag)
				{
					this._isRecruit = (value ? new bool?(this.isRecruit) : null);
				}
			}
		}

		private bool ShouldSerializeisRecruit()
		{
			return this.isRecruitSpecified;
		}

		private void ResetisRecruit()
		{
			this.isRecruitSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "isDragonGuildRecruit", DataFormat = DataFormat.Default)]
		public bool isDragonGuildRecruit
		{
			get
			{
				return this._isDragonGuildRecruit ?? false;
			}
			set
			{
				this._isDragonGuildRecruit = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isDragonGuildRecruitSpecified
		{
			get
			{
				return this._isDragonGuildRecruit != null;
			}
			set
			{
				bool flag = value == (this._isDragonGuildRecruit == null);
				if (flag)
				{
					this._isDragonGuildRecruit = (value ? new bool?(this.isDragonGuildRecruit) : null);
				}
			}
		}

		private bool ShouldSerializeisDragonGuildRecruit()
		{
			return this.isDragonGuildRecruitSpecified;
		}

		private void ResetisDragonGuildRecruit()
		{
			this.isDragonGuildRecruitSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "groupchatinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GroupChatTeamInfo groupchatinfo
		{
			get
			{
				return this._groupchatinfo;
			}
			set
			{
				this._groupchatinfo = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "groupchatnewrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatSource groupchatnewrole
		{
			get
			{
				return this._groupchatnewrole;
			}
			set
			{
				this._groupchatnewrole = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _channel;

		private ChatSource _source = null;

		private ChatDest _dest = null;

		private string _info;

		private readonly List<ChatParam> _param = new List<ChatParam>();

		private uint? _priority;

		private uint? _time;

		private bool? _issystem;

		private ulong? _storeKeyId;

		private ulong? _audioUid;

		private uint? _audioLen;

		private readonly List<ChatSource> _destList = new List<ChatSource>();

		private bool? _isbroadcast;

		private uint? _level;

		private bool? _isRecruit;

		private bool? _isDragonGuildRecruit;

		private GroupChatTeamInfo _groupchatinfo = null;

		private ChatSource _groupchatnewrole = null;

		private IExtension extensionObject;
	}
}
