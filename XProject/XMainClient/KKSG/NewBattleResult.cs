using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NewBattleResult")]
	[Serializable]
	public class NewBattleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "stageInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageResultInfo stageInfo
		{
			get
			{
				return this._stageInfo;
			}
			set
			{
				this._stageInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "specialStage", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpecialStageInfo specialStage
		{
			get
			{
				return this._specialStage;
			}
			set
			{
				this._specialStage = value;
			}
		}

		[ProtoMember(3, Name = "roleReward", DataFormat = DataFormat.Default)]
		public List<StageRoleResult> roleReward
		{
			get
			{
				return this._roleReward;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "isFinalResult", DataFormat = DataFormat.Default)]
		public bool isFinalResult
		{
			get
			{
				return this._isFinalResult ?? false;
			}
			set
			{
				this._isFinalResult = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFinalResultSpecified
		{
			get
			{
				return this._isFinalResult != null;
			}
			set
			{
				bool flag = value == (this._isFinalResult == null);
				if (flag)
				{
					this._isFinalResult = (value ? new bool?(this.isFinalResult) : null);
				}
			}
		}

		private bool ShouldSerializeisFinalResult()
		{
			return this.isFinalResultSpecified;
		}

		private void ResetisFinalResult()
		{
			this.isFinalResultSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "watchinfo", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = false, Name = "guildinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageGuildInfo guildinfo
		{
			get
			{
				return this._guildinfo;
			}
			set
			{
				this._guildinfo = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "isexpseal", DataFormat = DataFormat.Default)]
		public bool isexpseal
		{
			get
			{
				return this._isexpseal ?? false;
			}
			set
			{
				this._isexpseal = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isexpsealSpecified
		{
			get
			{
				return this._isexpseal != null;
			}
			set
			{
				bool flag = value == (this._isexpseal == null);
				if (flag)
				{
					this._isexpseal = (value ? new bool?(this.isexpseal) : null);
				}
			}
		}

		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private StageResultInfo _stageInfo = null;

		private SpecialStageInfo _specialStage = null;

		private readonly List<StageRoleResult> _roleReward = new List<StageRoleResult>();

		private bool? _isFinalResult;

		private StageWatchInfo _watchinfo = null;

		private StageGuildInfo _guildinfo = null;

		private bool? _isexpseal;

		private IExtension extensionObject;
	}
}
