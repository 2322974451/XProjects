using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FD RID: 253
	[ProtoContract(Name = "NewBattleResult")]
	[Serializable]
	public class NewBattleResult : IExtensible
	{
		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06001047 RID: 4167 RVA: 0x00021714 File Offset: 0x0001F914
		// (set) Token: 0x06001048 RID: 4168 RVA: 0x0002172C File Offset: 0x0001F92C
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

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06001049 RID: 4169 RVA: 0x00021738 File Offset: 0x0001F938
		// (set) Token: 0x0600104A RID: 4170 RVA: 0x00021750 File Offset: 0x0001F950
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

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x0600104B RID: 4171 RVA: 0x0002175C File Offset: 0x0001F95C
		[ProtoMember(3, Name = "roleReward", DataFormat = DataFormat.Default)]
		public List<StageRoleResult> roleReward
		{
			get
			{
				return this._roleReward;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x0600104C RID: 4172 RVA: 0x00021774 File Offset: 0x0001F974
		// (set) Token: 0x0600104D RID: 4173 RVA: 0x000217A0 File Offset: 0x0001F9A0
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

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x000217B0 File Offset: 0x0001F9B0
		// (set) Token: 0x0600104F RID: 4175 RVA: 0x000217D0 File Offset: 0x0001F9D0
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

		// Token: 0x06001050 RID: 4176 RVA: 0x00021814 File Offset: 0x0001FA14
		private bool ShouldSerializeisFinalResult()
		{
			return this.isFinalResultSpecified;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x0002182C File Offset: 0x0001FA2C
		private void ResetisFinalResult()
		{
			this.isFinalResultSpecified = false;
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x00021838 File Offset: 0x0001FA38
		// (set) Token: 0x06001053 RID: 4179 RVA: 0x00021850 File Offset: 0x0001FA50
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

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x0002185C File Offset: 0x0001FA5C
		// (set) Token: 0x06001055 RID: 4181 RVA: 0x00021874 File Offset: 0x0001FA74
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

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06001056 RID: 4182 RVA: 0x00021880 File Offset: 0x0001FA80
		// (set) Token: 0x06001057 RID: 4183 RVA: 0x000218AC File Offset: 0x0001FAAC
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

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06001058 RID: 4184 RVA: 0x000218BC File Offset: 0x0001FABC
		// (set) Token: 0x06001059 RID: 4185 RVA: 0x000218DC File Offset: 0x0001FADC
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

		// Token: 0x0600105A RID: 4186 RVA: 0x00021920 File Offset: 0x0001FB20
		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00021938 File Offset: 0x0001FB38
		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00021944 File Offset: 0x0001FB44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400040F RID: 1039
		private StageResultInfo _stageInfo = null;

		// Token: 0x04000410 RID: 1040
		private SpecialStageInfo _specialStage = null;

		// Token: 0x04000411 RID: 1041
		private readonly List<StageRoleResult> _roleReward = new List<StageRoleResult>();

		// Token: 0x04000412 RID: 1042
		private bool? _isFinalResult;

		// Token: 0x04000413 RID: 1043
		private StageWatchInfo _watchinfo = null;

		// Token: 0x04000414 RID: 1044
		private StageGuildInfo _guildinfo = null;

		// Token: 0x04000415 RID: 1045
		private bool? _isexpseal;

		// Token: 0x04000416 RID: 1046
		private IExtension extensionObject;
	}
}
