using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000345 RID: 837
	[ProtoContract(Name = "HeroBattleSyncData")]
	[Serializable]
	public class HeroBattleSyncData : IExtensible
	{
		// Token: 0x17000E32 RID: 3634
		// (get) Token: 0x06002DC0 RID: 11712 RVA: 0x0005880C File Offset: 0x00056A0C
		// (set) Token: 0x06002DC1 RID: 11713 RVA: 0x00058838 File Offset: 0x00056A38
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

		// Token: 0x17000E33 RID: 3635
		// (get) Token: 0x06002DC2 RID: 11714 RVA: 0x00058848 File Offset: 0x00056A48
		// (set) Token: 0x06002DC3 RID: 11715 RVA: 0x00058868 File Offset: 0x00056A68
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

		// Token: 0x06002DC4 RID: 11716 RVA: 0x000588AC File Offset: 0x00056AAC
		private bool ShouldSerializeoccupant()
		{
			return this.occupantSpecified;
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x000588C4 File Offset: 0x00056AC4
		private void Resetoccupant()
		{
			this.occupantSpecified = false;
		}

		// Token: 0x17000E34 RID: 3636
		// (get) Token: 0x06002DC6 RID: 11718 RVA: 0x000588D0 File Offset: 0x00056AD0
		// (set) Token: 0x06002DC7 RID: 11719 RVA: 0x000588FC File Offset: 0x00056AFC
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

		// Token: 0x17000E35 RID: 3637
		// (get) Token: 0x06002DC8 RID: 11720 RVA: 0x0005890C File Offset: 0x00056B0C
		// (set) Token: 0x06002DC9 RID: 11721 RVA: 0x0005892C File Offset: 0x00056B2C
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

		// Token: 0x06002DCA RID: 11722 RVA: 0x00058970 File Offset: 0x00056B70
		private bool ShouldSerializelootTeam()
		{
			return this.lootTeamSpecified;
		}

		// Token: 0x06002DCB RID: 11723 RVA: 0x00058988 File Offset: 0x00056B88
		private void ResetlootTeam()
		{
			this.lootTeamSpecified = false;
		}

		// Token: 0x17000E36 RID: 3638
		// (get) Token: 0x06002DCC RID: 11724 RVA: 0x00058994 File Offset: 0x00056B94
		// (set) Token: 0x06002DCD RID: 11725 RVA: 0x000589C4 File Offset: 0x00056BC4
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

		// Token: 0x17000E37 RID: 3639
		// (get) Token: 0x06002DCE RID: 11726 RVA: 0x000589D4 File Offset: 0x00056BD4
		// (set) Token: 0x06002DCF RID: 11727 RVA: 0x000589F4 File Offset: 0x00056BF4
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

		// Token: 0x06002DD0 RID: 11728 RVA: 0x00058A38 File Offset: 0x00056C38
		private bool ShouldSerializelootProgress()
		{
			return this.lootProgressSpecified;
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x00058A50 File Offset: 0x00056C50
		private void ResetlootProgress()
		{
			this.lootProgressSpecified = false;
		}

		// Token: 0x17000E38 RID: 3640
		// (get) Token: 0x06002DD2 RID: 11730 RVA: 0x00058A5C File Offset: 0x00056C5C
		// (set) Token: 0x06002DD3 RID: 11731 RVA: 0x00058A88 File Offset: 0x00056C88
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

		// Token: 0x17000E39 RID: 3641
		// (get) Token: 0x06002DD4 RID: 11732 RVA: 0x00058A98 File Offset: 0x00056C98
		// (set) Token: 0x06002DD5 RID: 11733 RVA: 0x00058AB8 File Offset: 0x00056CB8
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

		// Token: 0x06002DD6 RID: 11734 RVA: 0x00058AFC File Offset: 0x00056CFC
		private bool ShouldSerializeisInFight()
		{
			return this.isInFightSpecified;
		}

		// Token: 0x06002DD7 RID: 11735 RVA: 0x00058B14 File Offset: 0x00056D14
		private void ResetisInFight()
		{
			this.isInFightSpecified = false;
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x00058B20 File Offset: 0x00056D20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B61 RID: 2913
		private uint? _occupant;

		// Token: 0x04000B62 RID: 2914
		private uint? _lootTeam;

		// Token: 0x04000B63 RID: 2915
		private float? _lootProgress;

		// Token: 0x04000B64 RID: 2916
		private bool? _isInFight;

		// Token: 0x04000B65 RID: 2917
		private IExtension extensionObject;
	}
}
