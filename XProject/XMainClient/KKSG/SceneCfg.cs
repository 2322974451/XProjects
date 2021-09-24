using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneCfg")]
	[Serializable]
	public class SceneCfg : IExtensible
	{

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

		private bool ShouldSerializeSceneID()
		{
			return this.SceneIDSpecified;
		}

		private void ResetSceneID()
		{
			this.SceneIDSpecified = false;
		}

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

		private bool ShouldSerializeSyncMode()
		{
			return this.SyncModeSpecified;
		}

		private void ResetSyncMode()
		{
			this.SyncModeSpecified = false;
		}

		[ProtoMember(3, Name = "enemyWaves", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> enemyWaves
		{
			get
			{
				return this._enemyWaves;
			}
		}

		[ProtoMember(4, Name = "doodads", DataFormat = DataFormat.Default)]
		public List<DoodadInfo> doodads
		{
			get
			{
				return this._doodads;
			}
		}

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

		private bool ShouldSerializeownerID()
		{
			return this.ownerIDSpecified;
		}

		private void ResetownerID()
		{
			this.ownerIDSpecified = false;
		}

		[ProtoMember(6, Name = "preloadEnemyIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> preloadEnemyIDs
		{
			get
			{
				return this._preloadEnemyIDs;
			}
		}

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

		private bool ShouldSerializeisWatcher()
		{
			return this.isWatcherSpecified;
		}

		private void ResetisWatcher()
		{
			this.isWatcherSpecified = false;
		}

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

		private bool ShouldSerializecanMorph()
		{
			return this.canMorphSpecified;
		}

		private void ResetcanMorph()
		{
			this.canMorphSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SceneID;

		private int? _SyncMode;

		private readonly List<UnitAppearance> _enemyWaves = new List<UnitAppearance>();

		private readonly List<DoodadInfo> _doodads = new List<DoodadInfo>();

		private ulong? _ownerID;

		private readonly List<uint> _preloadEnemyIDs = new List<uint>();

		private bool? _isWatcher;

		private bool? _canMorph;

		private IExtension extensionObject;
	}
}
