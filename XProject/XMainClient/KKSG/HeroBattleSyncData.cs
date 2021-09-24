using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleSyncData")]
	[Serializable]
	public class HeroBattleSyncData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "occupant", DataFormat = DataFormat.TwosComplement)]
		public uint occupant
		{
			get
			{
				return this._occupant ?? 0U;
			}
			set
			{
				this._occupant = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool occupantSpecified
		{
			get
			{
				return this._occupant != null;
			}
			set
			{
				bool flag = value == (this._occupant == null);
				if (flag)
				{
					this._occupant = (value ? new uint?(this.occupant) : null);
				}
			}
		}

		private bool ShouldSerializeoccupant()
		{
			return this.occupantSpecified;
		}

		private void Resetoccupant()
		{
			this.occupantSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lootTeam", DataFormat = DataFormat.TwosComplement)]
		public uint lootTeam
		{
			get
			{
				return this._lootTeam ?? 0U;
			}
			set
			{
				this._lootTeam = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lootTeamSpecified
		{
			get
			{
				return this._lootTeam != null;
			}
			set
			{
				bool flag = value == (this._lootTeam == null);
				if (flag)
				{
					this._lootTeam = (value ? new uint?(this.lootTeam) : null);
				}
			}
		}

		private bool ShouldSerializelootTeam()
		{
			return this.lootTeamSpecified;
		}

		private void ResetlootTeam()
		{
			this.lootTeamSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lootProgress", DataFormat = DataFormat.FixedSize)]
		public float lootProgress
		{
			get
			{
				return this._lootProgress ?? 0f;
			}
			set
			{
				this._lootProgress = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lootProgressSpecified
		{
			get
			{
				return this._lootProgress != null;
			}
			set
			{
				bool flag = value == (this._lootProgress == null);
				if (flag)
				{
					this._lootProgress = (value ? new float?(this.lootProgress) : null);
				}
			}
		}

		private bool ShouldSerializelootProgress()
		{
			return this.lootProgressSpecified;
		}

		private void ResetlootProgress()
		{
			this.lootProgressSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isInFight", DataFormat = DataFormat.Default)]
		public bool isInFight
		{
			get
			{
				return this._isInFight ?? false;
			}
			set
			{
				this._isInFight = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isInFightSpecified
		{
			get
			{
				return this._isInFight != null;
			}
			set
			{
				bool flag = value == (this._isInFight == null);
				if (flag)
				{
					this._isInFight = (value ? new bool?(this.isInFight) : null);
				}
			}
		}

		private bool ShouldSerializeisInFight()
		{
			return this.isInFightSpecified;
		}

		private void ResetisInFight()
		{
			this.isInFightSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _occupant;

		private uint? _lootTeam;

		private float? _lootProgress;

		private bool? _isInFight;

		private IExtension extensionObject;
	}
}
