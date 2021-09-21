using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000014 RID: 20
	[ProtoContract(Name = "SceneCfg")]
	[Serializable]
	public class SceneCfg : IExtensible
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00005BF8 File Offset: 0x00003DF8
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00005C24 File Offset: 0x00003E24
		[ProtoMember(1, IsRequired = false, Name = "SceneID", DataFormat = DataFormat.TwosComplement)]
		public uint SceneID
		{
			get
			{
				return this._SceneID ?? 0U;
			}
			set
			{
				this._SceneID = new uint?(value);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00005C34 File Offset: 0x00003E34
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00005C54 File Offset: 0x00003E54
		[XmlIgnore]
		[Browsable(false)]
		public bool SceneIDSpecified
		{
			get
			{
				return this._SceneID != null;
			}
			set
			{
				bool flag = value == (this._SceneID == null);
				if (flag)
				{
					this._SceneID = (value ? new uint?(this.SceneID) : null);
				}
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00005C98 File Offset: 0x00003E98
		private bool ShouldSerializeSceneID()
		{
			return this.SceneIDSpecified;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00005CB0 File Offset: 0x00003EB0
		private void ResetSceneID()
		{
			this.SceneIDSpecified = false;
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00005CBC File Offset: 0x00003EBC
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00005CE8 File Offset: 0x00003EE8
		[ProtoMember(2, IsRequired = false, Name = "SyncMode", DataFormat = DataFormat.TwosComplement)]
		public int SyncMode
		{
			get
			{
				return this._SyncMode ?? 0;
			}
			set
			{
				this._SyncMode = new int?(value);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00005CF8 File Offset: 0x00003EF8
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00005D18 File Offset: 0x00003F18
		[XmlIgnore]
		[Browsable(false)]
		public bool SyncModeSpecified
		{
			get
			{
				return this._SyncMode != null;
			}
			set
			{
				bool flag = value == (this._SyncMode == null);
				if (flag)
				{
					this._SyncMode = (value ? new int?(this.SyncMode) : null);
				}
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00005D5C File Offset: 0x00003F5C
		private bool ShouldSerializeSyncMode()
		{
			return this.SyncModeSpecified;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00005D74 File Offset: 0x00003F74
		private void ResetSyncMode()
		{
			this.SyncModeSpecified = false;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00005D80 File Offset: 0x00003F80
		[ProtoMember(3, Name = "enemyWaves", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> enemyWaves
		{
			get
			{
				return this._enemyWaves;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00005D98 File Offset: 0x00003F98
		[ProtoMember(4, Name = "doodads", DataFormat = DataFormat.Default)]
		public List<DoodadInfo> doodads
		{
			get
			{
				return this._doodads;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00005DB0 File Offset: 0x00003FB0
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00005DDD File Offset: 0x00003FDD
		[ProtoMember(5, IsRequired = false, Name = "ownerID", DataFormat = DataFormat.TwosComplement)]
		public ulong ownerID
		{
			get
			{
				return this._ownerID ?? 0UL;
			}
			set
			{
				this._ownerID = new ulong?(value);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00005DEC File Offset: 0x00003FEC
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00005E0C File Offset: 0x0000400C
		[XmlIgnore]
		[Browsable(false)]
		public bool ownerIDSpecified
		{
			get
			{
				return this._ownerID != null;
			}
			set
			{
				bool flag = value == (this._ownerID == null);
				if (flag)
				{
					this._ownerID = (value ? new ulong?(this.ownerID) : null);
				}
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00005E50 File Offset: 0x00004050
		private bool ShouldSerializeownerID()
		{
			return this.ownerIDSpecified;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005E68 File Offset: 0x00004068
		private void ResetownerID()
		{
			this.ownerIDSpecified = false;
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00005E74 File Offset: 0x00004074
		[ProtoMember(6, Name = "preloadEnemyIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> preloadEnemyIDs
		{
			get
			{
				return this._preloadEnemyIDs;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00005E8C File Offset: 0x0000408C
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00005EB8 File Offset: 0x000040B8
		[ProtoMember(7, IsRequired = false, Name = "isWatcher", DataFormat = DataFormat.Default)]
		public bool isWatcher
		{
			get
			{
				return this._isWatcher ?? false;
			}
			set
			{
				this._isWatcher = new bool?(value);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00005EC8 File Offset: 0x000040C8
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00005EE8 File Offset: 0x000040E8
		[XmlIgnore]
		[Browsable(false)]
		public bool isWatcherSpecified
		{
			get
			{
				return this._isWatcher != null;
			}
			set
			{
				bool flag = value == (this._isWatcher == null);
				if (flag)
				{
					this._isWatcher = (value ? new bool?(this.isWatcher) : null);
				}
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00005F2C File Offset: 0x0000412C
		private bool ShouldSerializeisWatcher()
		{
			return this.isWatcherSpecified;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005F44 File Offset: 0x00004144
		private void ResetisWatcher()
		{
			this.isWatcherSpecified = false;
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00005F50 File Offset: 0x00004150
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00005F7C File Offset: 0x0000417C
		[ProtoMember(8, IsRequired = false, Name = "canMorph", DataFormat = DataFormat.Default)]
		public bool canMorph
		{
			get
			{
				return this._canMorph ?? false;
			}
			set
			{
				this._canMorph = new bool?(value);
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00005F8C File Offset: 0x0000418C
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00005FAC File Offset: 0x000041AC
		[XmlIgnore]
		[Browsable(false)]
		public bool canMorphSpecified
		{
			get
			{
				return this._canMorph != null;
			}
			set
			{
				bool flag = value == (this._canMorph == null);
				if (flag)
				{
					this._canMorph = (value ? new bool?(this.canMorph) : null);
				}
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005FF0 File Offset: 0x000041F0
		private bool ShouldSerializecanMorph()
		{
			return this.canMorphSpecified;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00006008 File Offset: 0x00004208
		private void ResetcanMorph()
		{
			this.canMorphSpecified = false;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00006014 File Offset: 0x00004214
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400006A RID: 106
		private uint? _SceneID;

		// Token: 0x0400006B RID: 107
		private int? _SyncMode;

		// Token: 0x0400006C RID: 108
		private readonly List<UnitAppearance> _enemyWaves = new List<UnitAppearance>();

		// Token: 0x0400006D RID: 109
		private readonly List<DoodadInfo> _doodads = new List<DoodadInfo>();

		// Token: 0x0400006E RID: 110
		private ulong? _ownerID;

		// Token: 0x0400006F RID: 111
		private readonly List<uint> _preloadEnemyIDs = new List<uint>();

		// Token: 0x04000070 RID: 112
		private bool? _isWatcher;

		// Token: 0x04000071 RID: 113
		private bool? _canMorph;

		// Token: 0x04000072 RID: 114
		private IExtension extensionObject;
	}
}
