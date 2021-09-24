using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClientQueryRankListArg")]
	[Serializable]
	public class ClientQueryRankListArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "RankType", DataFormat = DataFormat.TwosComplement)]
		public uint RankType
		{
			get
			{
				return this._RankType ?? 0U;
			}
			set
			{
				this._RankType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RankTypeSpecified
		{
			get
			{
				return this._RankType != null;
			}
			set
			{
				bool flag = value == (this._RankType == null);
				if (flag)
				{
					this._RankType = (value ? new uint?(this.RankType) : null);
				}
			}
		}

		private bool ShouldSerializeRankType()
		{
			return this.RankTypeSpecified;
		}

		private void ResetRankType()
		{
			this.RankTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp ?? 0U;
			}
			set
			{
				this._TimeStamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TimeStampSpecified
		{
			get
			{
				return this._TimeStamp != null;
			}
			set
			{
				bool flag = value == (this._TimeStamp == null);
				if (flag)
				{
					this._TimeStamp = (value ? new uint?(this.TimeStamp) : null);
				}
			}
		}

		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "firstPassID", DataFormat = DataFormat.TwosComplement)]
		public int firstPassID
		{
			get
			{
				return this._firstPassID ?? 0;
			}
			set
			{
				this._firstPassID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassIDSpecified
		{
			get
			{
				return this._firstPassID != null;
			}
			set
			{
				bool flag = value == (this._firstPassID == null);
				if (flag)
				{
					this._firstPassID = (value ? new int?(this.firstPassID) : null);
				}
			}
		}

		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "sendPunishData", DataFormat = DataFormat.TwosComplement)]
		public uint sendPunishData
		{
			get
			{
				return this._sendPunishData ?? 0U;
			}
			set
			{
				this._sendPunishData = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendPunishDataSpecified
		{
			get
			{
				return this._sendPunishData != null;
			}
			set
			{
				bool flag = value == (this._sendPunishData == null);
				if (flag)
				{
					this._sendPunishData = (value ? new uint?(this.sendPunishData) : null);
				}
			}
		}

		private bool ShouldSerializesendPunishData()
		{
			return this.sendPunishDataSpecified;
		}

		private void ResetsendPunishData()
		{
			this.sendPunishDataSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "onlySelfData", DataFormat = DataFormat.Default)]
		public bool onlySelfData
		{
			get
			{
				return this._onlySelfData ?? false;
			}
			set
			{
				this._onlySelfData = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlySelfDataSpecified
		{
			get
			{
				return this._onlySelfData != null;
			}
			set
			{
				bool flag = value == (this._onlySelfData == null);
				if (flag)
				{
					this._onlySelfData = (value ? new bool?(this.onlySelfData) : null);
				}
			}
		}

		private bool ShouldSerializeonlySelfData()
		{
			return this.onlySelfDataSpecified;
		}

		private void ResetonlySelfData()
		{
			this.onlySelfDataSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _RankType;

		private uint? _TimeStamp;

		private uint? _profession;

		private ulong? _guildid;

		private int? _firstPassID;

		private uint? _sendPunishData;

		private bool? _onlySelfData;

		private IExtension extensionObject;
	}
}
