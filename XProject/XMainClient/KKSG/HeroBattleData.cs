using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleData")]
	[Serializable]
	public class HeroBattleData : IExtensible
	{

		[ProtoMember(1, Name = "groupData", DataFormat = DataFormat.Default)]
		public List<HeroBattleGroupData> groupData
		{
			get
			{
				return this._groupData;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "occupant", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "lootTeam", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "lootProgress", DataFormat = DataFormat.FixedSize)]
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

		[ProtoMember(5, IsRequired = false, Name = "isInfight", DataFormat = DataFormat.Default)]
		public bool isInfight
		{
			get
			{
				return this._isInfight ?? false;
			}
			set
			{
				this._isInfight = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isInfightSpecified
		{
			get
			{
				return this._isInfight != null;
			}
			set
			{
				bool flag = value == (this._isInfight == null);
				if (flag)
				{
					this._isInfight = (value ? new bool?(this.isInfight) : null);
				}
			}
		}

		private bool ShouldSerializeisInfight()
		{
			return this.isInfightSpecified;
		}

		private void ResetisInfight()
		{
			this.isInfightSpecified = false;
		}

		[ProtoMember(6, Name = "roleInCircle", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleInCircle
		{
			get
			{
				return this._roleInCircle;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<HeroBattleGroupData> _groupData = new List<HeroBattleGroupData>();

		private uint? _occupant;

		private uint? _lootTeam;

		private float? _lootProgress;

		private bool? _isInfight;

		private readonly List<ulong> _roleInCircle = new List<ulong>();

		private IExtension extensionObject;
	}
}
