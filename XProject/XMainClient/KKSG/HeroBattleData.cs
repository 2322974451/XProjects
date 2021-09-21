using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033A RID: 826
	[ProtoContract(Name = "HeroBattleData")]
	[Serializable]
	public class HeroBattleData : IExtensible
	{
		// Token: 0x17000E12 RID: 3602
		// (get) Token: 0x06002D5A RID: 11610 RVA: 0x00057C40 File Offset: 0x00055E40
		[ProtoMember(1, Name = "groupData", DataFormat = DataFormat.Default)]
		public List<HeroBattleGroupData> groupData
		{
			get
			{
				return this._groupData;
			}
		}

		// Token: 0x17000E13 RID: 3603
		// (get) Token: 0x06002D5B RID: 11611 RVA: 0x00057C58 File Offset: 0x00055E58
		// (set) Token: 0x06002D5C RID: 11612 RVA: 0x00057C84 File Offset: 0x00055E84
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

		// Token: 0x17000E14 RID: 3604
		// (get) Token: 0x06002D5D RID: 11613 RVA: 0x00057C94 File Offset: 0x00055E94
		// (set) Token: 0x06002D5E RID: 11614 RVA: 0x00057CB4 File Offset: 0x00055EB4
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

		// Token: 0x06002D5F RID: 11615 RVA: 0x00057CF8 File Offset: 0x00055EF8
		private bool ShouldSerializeoccupant()
		{
			return this.occupantSpecified;
		}

		// Token: 0x06002D60 RID: 11616 RVA: 0x00057D10 File Offset: 0x00055F10
		private void Resetoccupant()
		{
			this.occupantSpecified = false;
		}

		// Token: 0x17000E15 RID: 3605
		// (get) Token: 0x06002D61 RID: 11617 RVA: 0x00057D1C File Offset: 0x00055F1C
		// (set) Token: 0x06002D62 RID: 11618 RVA: 0x00057D48 File Offset: 0x00055F48
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

		// Token: 0x17000E16 RID: 3606
		// (get) Token: 0x06002D63 RID: 11619 RVA: 0x00057D58 File Offset: 0x00055F58
		// (set) Token: 0x06002D64 RID: 11620 RVA: 0x00057D78 File Offset: 0x00055F78
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

		// Token: 0x06002D65 RID: 11621 RVA: 0x00057DBC File Offset: 0x00055FBC
		private bool ShouldSerializelootTeam()
		{
			return this.lootTeamSpecified;
		}

		// Token: 0x06002D66 RID: 11622 RVA: 0x00057DD4 File Offset: 0x00055FD4
		private void ResetlootTeam()
		{
			this.lootTeamSpecified = false;
		}

		// Token: 0x17000E17 RID: 3607
		// (get) Token: 0x06002D67 RID: 11623 RVA: 0x00057DE0 File Offset: 0x00055FE0
		// (set) Token: 0x06002D68 RID: 11624 RVA: 0x00057E10 File Offset: 0x00056010
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

		// Token: 0x17000E18 RID: 3608
		// (get) Token: 0x06002D69 RID: 11625 RVA: 0x00057E20 File Offset: 0x00056020
		// (set) Token: 0x06002D6A RID: 11626 RVA: 0x00057E40 File Offset: 0x00056040
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

		// Token: 0x06002D6B RID: 11627 RVA: 0x00057E84 File Offset: 0x00056084
		private bool ShouldSerializelootProgress()
		{
			return this.lootProgressSpecified;
		}

		// Token: 0x06002D6C RID: 11628 RVA: 0x00057E9C File Offset: 0x0005609C
		private void ResetlootProgress()
		{
			this.lootProgressSpecified = false;
		}

		// Token: 0x17000E19 RID: 3609
		// (get) Token: 0x06002D6D RID: 11629 RVA: 0x00057EA8 File Offset: 0x000560A8
		// (set) Token: 0x06002D6E RID: 11630 RVA: 0x00057ED4 File Offset: 0x000560D4
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

		// Token: 0x17000E1A RID: 3610
		// (get) Token: 0x06002D6F RID: 11631 RVA: 0x00057EE4 File Offset: 0x000560E4
		// (set) Token: 0x06002D70 RID: 11632 RVA: 0x00057F04 File Offset: 0x00056104
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

		// Token: 0x06002D71 RID: 11633 RVA: 0x00057F48 File Offset: 0x00056148
		private bool ShouldSerializeisInfight()
		{
			return this.isInfightSpecified;
		}

		// Token: 0x06002D72 RID: 11634 RVA: 0x00057F60 File Offset: 0x00056160
		private void ResetisInfight()
		{
			this.isInfightSpecified = false;
		}

		// Token: 0x17000E1B RID: 3611
		// (get) Token: 0x06002D73 RID: 11635 RVA: 0x00057F6C File Offset: 0x0005616C
		[ProtoMember(6, Name = "roleInCircle", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleInCircle
		{
			get
			{
				return this._roleInCircle;
			}
		}

		// Token: 0x06002D74 RID: 11636 RVA: 0x00057F84 File Offset: 0x00056184
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B42 RID: 2882
		private readonly List<HeroBattleGroupData> _groupData = new List<HeroBattleGroupData>();

		// Token: 0x04000B43 RID: 2883
		private uint? _occupant;

		// Token: 0x04000B44 RID: 2884
		private uint? _lootTeam;

		// Token: 0x04000B45 RID: 2885
		private float? _lootProgress;

		// Token: 0x04000B46 RID: 2886
		private bool? _isInfight;

		// Token: 0x04000B47 RID: 2887
		private readonly List<ulong> _roleInCircle = new List<ulong>();

		// Token: 0x04000B48 RID: 2888
		private IExtension extensionObject;
	}
}
