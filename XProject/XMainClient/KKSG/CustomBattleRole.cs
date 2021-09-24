using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleRole")]
	[Serializable]
	public class CustomBattleRole : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "configid", DataFormat = DataFormat.TwosComplement)]
		public uint configid
		{
			get
			{
				return this._configid ?? 0U;
			}
			set
			{
				this._configid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool configidSpecified
		{
			get
			{
				return this._configid != null;
			}
			set
			{
				bool flag = value == (this._configid == null);
				if (flag)
				{
					this._configid = (value ? new uint?(this.configid) : null);
				}
			}
		}

		private bool ShouldSerializeconfigid()
		{
			return this.configidSpecified;
		}

		private void Resetconfigid()
		{
			this.configidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		private void Resetwin()
		{
			this.winSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleRoleState state
		{
			get
			{
				return this._state ?? CustomBattleRoleState.CustomBattle_RoleState_Ready;
			}
			set
			{
				this._state = new CustomBattleRoleState?(value);
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
					this._state = (value ? new CustomBattleRoleState?(this.state) : null);
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

		[ProtoMember(8, IsRequired = false, Name = "rewardcd", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcd
		{
			get
			{
				return this._rewardcd ?? 0U;
			}
			set
			{
				this._rewardcd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcdSpecified
		{
			get
			{
				return this._rewardcd != null;
			}
			set
			{
				bool flag = value == (this._rewardcd == null);
				if (flag)
				{
					this._rewardcd = (value ? new uint?(this.rewardcd) : null);
				}
			}
		}

		private bool ShouldSerializerewardcd()
		{
			return this.rewardcdSpecified;
		}

		private void Resetrewardcd()
		{
			this.rewardcdSpecified = false;
		}

		[ProtoMember(9, Name = "records", DataFormat = DataFormat.TwosComplement)]
		public List<uint> records
		{
			get
			{
				return this._records;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _configid;

		private uint? _lose;

		private uint? _win;

		private uint? _point;

		private uint? _rank;

		private CustomBattleRoleState? _state;

		private uint? _rewardcd;

		private readonly List<uint> _records = new List<uint>();

		private uint? _draw;

		private IExtension extensionObject;
	}
}
