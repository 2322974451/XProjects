using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleWatcherNtf")]
	[Serializable]
	public class BattleWatcherNtf : IExtensible
	{

		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<BattleStatisticsData> data
		{
			get
			{
				return this._data;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "watchinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageWatchInfo watchinfo
		{
			get
			{
				return this._watchinfo;
			}
			set
			{
				this._watchinfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "mvp", DataFormat = DataFormat.TwosComplement)]
		public ulong mvp
		{
			get
			{
				return this._mvp ?? 0UL;
			}
			set
			{
				this._mvp = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpSpecified
		{
			get
			{
				return this._mvp != null;
			}
			set
			{
				bool flag = value == (this._mvp == null);
				if (flag)
				{
					this._mvp = (value ? new ulong?(this.mvp) : null);
				}
			}
		}

		private bool ShouldSerializemvp()
		{
			return this.mvpSpecified;
		}

		private void Resetmvp()
		{
			this.mvpSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "winuid", DataFormat = DataFormat.TwosComplement)]
		public ulong winuid
		{
			get
			{
				return this._winuid ?? 0UL;
			}
			set
			{
				this._winuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winuidSpecified
		{
			get
			{
				return this._winuid != null;
			}
			set
			{
				bool flag = value == (this._winuid == null);
				if (flag)
				{
					this._winuid = (value ? new ulong?(this.winuid) : null);
				}
			}
		}

		private bool ShouldSerializewinuid()
		{
			return this.winuidSpecified;
		}

		private void Resetwinuid()
		{
			this.winuidSpecified = false;
		}

		[ProtoMember(5, Name = "star", DataFormat = DataFormat.Default)]
		public List<BattleStarData> star
		{
			get
			{
				return this._star;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "scenetype", DataFormat = DataFormat.TwosComplement)]
		public uint scenetype
		{
			get
			{
				return this._scenetype ?? 0U;
			}
			set
			{
				this._scenetype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scenetypeSpecified
		{
			get
			{
				return this._scenetype != null;
			}
			set
			{
				bool flag = value == (this._scenetype == null);
				if (flag)
				{
					this._scenetype = (value ? new uint?(this.scenetype) : null);
				}
			}
		}

		private bool ShouldSerializescenetype()
		{
			return this.scenetypeSpecified;
		}

		private void Resetscenetype()
		{
			this.scenetypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<BattleStatisticsData> _data = new List<BattleStatisticsData>();

		private StageWatchInfo _watchinfo = null;

		private ulong? _mvp;

		private ulong? _winuid;

		private readonly List<BattleStarData> _star = new List<BattleStarData>();

		private uint? _scenetype;

		private IExtension extensionObject;
	}
}
