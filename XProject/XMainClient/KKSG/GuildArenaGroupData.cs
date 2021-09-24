using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildArenaGroupData")]
	[Serializable]
	public class GuildArenaGroupData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "battleId", DataFormat = DataFormat.TwosComplement)]
		public uint battleId
		{
			get
			{
				return this._battleId ?? 0U;
			}
			set
			{
				this._battleId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battleIdSpecified
		{
			get
			{
				return this._battleId != null;
			}
			set
			{
				bool flag = value == (this._battleId == null);
				if (flag)
				{
					this._battleId = (value ? new uint?(this.battleId) : null);
				}
			}
		}

		private bool ShouldSerializebattleId()
		{
			return this.battleIdSpecified;
		}

		private void ResetbattleId()
		{
			this.battleIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildOneId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildOneId
		{
			get
			{
				return this._guildOneId ?? 0UL;
			}
			set
			{
				this._guildOneId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildOneIdSpecified
		{
			get
			{
				return this._guildOneId != null;
			}
			set
			{
				bool flag = value == (this._guildOneId == null);
				if (flag)
				{
					this._guildOneId = (value ? new ulong?(this.guildOneId) : null);
				}
			}
		}

		private bool ShouldSerializeguildOneId()
		{
			return this.guildOneIdSpecified;
		}

		private void ResetguildOneId()
		{
			this.guildOneIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guildTwoId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildTwoId
		{
			get
			{
				return this._guildTwoId ?? 0UL;
			}
			set
			{
				this._guildTwoId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildTwoIdSpecified
		{
			get
			{
				return this._guildTwoId != null;
			}
			set
			{
				bool flag = value == (this._guildTwoId == null);
				if (flag)
				{
					this._guildTwoId = (value ? new ulong?(this.guildTwoId) : null);
				}
			}
		}

		private bool ShouldSerializeguildTwoId()
		{
			return this.guildTwoIdSpecified;
		}

		private void ResetguildTwoId()
		{
			this.guildTwoIdSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "winerId", DataFormat = DataFormat.TwosComplement)]
		public ulong winerId
		{
			get
			{
				return this._winerId ?? 0UL;
			}
			set
			{
				this._winerId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winerIdSpecified
		{
			get
			{
				return this._winerId != null;
			}
			set
			{
				bool flag = value == (this._winerId == null);
				if (flag)
				{
					this._winerId = (value ? new ulong?(this.winerId) : null);
				}
			}
		}

		private bool ShouldSerializewinerId()
		{
			return this.winerIdSpecified;
		}

		private void ResetwinerId()
		{
			this.winerIdSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "warstate", DataFormat = DataFormat.TwosComplement)]
		public uint warstate
		{
			get
			{
				return this._warstate ?? 0U;
			}
			set
			{
				this._warstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool warstateSpecified
		{
			get
			{
				return this._warstate != null;
			}
			set
			{
				bool flag = value == (this._warstate == null);
				if (flag)
				{
					this._warstate = (value ? new uint?(this.warstate) : null);
				}
			}
		}

		private bool ShouldSerializewarstate()
		{
			return this.warstateSpecified;
		}

		private void Resetwarstate()
		{
			this.warstateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "watchId", DataFormat = DataFormat.TwosComplement)]
		public uint watchId
		{
			get
			{
				return this._watchId ?? 0U;
			}
			set
			{
				this._watchId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool watchIdSpecified
		{
			get
			{
				return this._watchId != null;
			}
			set
			{
				bool flag = value == (this._watchId == null);
				if (flag)
				{
					this._watchId = (value ? new uint?(this.watchId) : null);
				}
			}
		}

		private bool ShouldSerializewatchId()
		{
			return this.watchIdSpecified;
		}

		private void ResetwatchId()
		{
			this.watchIdSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _battleId;

		private ulong? _guildOneId;

		private ulong? _guildTwoId;

		private ulong? _winerId;

		private uint? _warstate;

		private uint? _watchId;

		private uint? _state;

		private IExtension extensionObject;
	}
}
