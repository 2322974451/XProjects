using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000643 RID: 1603
	[ProtoContract(Name = "SpActivityOne")]
	[Serializable]
	public class SpActivityOne : IExtensible
	{
		// Token: 0x17001F5D RID: 8029
		// (get) Token: 0x06006383 RID: 25475 RVA: 0x000BDF14 File Offset: 0x000BC114
		// (set) Token: 0x06006384 RID: 25476 RVA: 0x000BDF40 File Offset: 0x000BC140
		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x17001F5E RID: 8030
		// (get) Token: 0x06006385 RID: 25477 RVA: 0x000BDF50 File Offset: 0x000BC150
		// (set) Token: 0x06006386 RID: 25478 RVA: 0x000BDF70 File Offset: 0x000BC170
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x06006387 RID: 25479 RVA: 0x000BDFB4 File Offset: 0x000BC1B4
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x06006388 RID: 25480 RVA: 0x000BDFCC File Offset: 0x000BC1CC
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x17001F5F RID: 8031
		// (get) Token: 0x06006389 RID: 25481 RVA: 0x000BDFD8 File Offset: 0x000BC1D8
		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<SpActivityTask> task
		{
			get
			{
				return this._task;
			}
		}

		// Token: 0x17001F60 RID: 8032
		// (get) Token: 0x0600638A RID: 25482 RVA: 0x000BDFF0 File Offset: 0x000BC1F0
		// (set) Token: 0x0600638B RID: 25483 RVA: 0x000BE01C File Offset: 0x000BC21C
		[ProtoMember(3, IsRequired = false, Name = "getBigPrize", DataFormat = DataFormat.Default)]
		public bool getBigPrize
		{
			get
			{
				return this._getBigPrize ?? false;
			}
			set
			{
				this._getBigPrize = new bool?(value);
			}
		}

		// Token: 0x17001F61 RID: 8033
		// (get) Token: 0x0600638C RID: 25484 RVA: 0x000BE02C File Offset: 0x000BC22C
		// (set) Token: 0x0600638D RID: 25485 RVA: 0x000BE04C File Offset: 0x000BC24C
		[XmlIgnore]
		[Browsable(false)]
		public bool getBigPrizeSpecified
		{
			get
			{
				return this._getBigPrize != null;
			}
			set
			{
				bool flag = value == (this._getBigPrize == null);
				if (flag)
				{
					this._getBigPrize = (value ? new bool?(this.getBigPrize) : null);
				}
			}
		}

		// Token: 0x0600638E RID: 25486 RVA: 0x000BE090 File Offset: 0x000BC290
		private bool ShouldSerializegetBigPrize()
		{
			return this.getBigPrizeSpecified;
		}

		// Token: 0x0600638F RID: 25487 RVA: 0x000BE0A8 File Offset: 0x000BC2A8
		private void ResetgetBigPrize()
		{
			this.getBigPrizeSpecified = false;
		}

		// Token: 0x17001F62 RID: 8034
		// (get) Token: 0x06006390 RID: 25488 RVA: 0x000BE0B4 File Offset: 0x000BC2B4
		// (set) Token: 0x06006391 RID: 25489 RVA: 0x000BE0E0 File Offset: 0x000BC2E0
		[ProtoMember(4, IsRequired = false, Name = "startTime", DataFormat = DataFormat.TwosComplement)]
		public uint startTime
		{
			get
			{
				return this._startTime ?? 0U;
			}
			set
			{
				this._startTime = new uint?(value);
			}
		}

		// Token: 0x17001F63 RID: 8035
		// (get) Token: 0x06006392 RID: 25490 RVA: 0x000BE0F0 File Offset: 0x000BC2F0
		// (set) Token: 0x06006393 RID: 25491 RVA: 0x000BE110 File Offset: 0x000BC310
		[XmlIgnore]
		[Browsable(false)]
		public bool startTimeSpecified
		{
			get
			{
				return this._startTime != null;
			}
			set
			{
				bool flag = value == (this._startTime == null);
				if (flag)
				{
					this._startTime = (value ? new uint?(this.startTime) : null);
				}
			}
		}

		// Token: 0x06006394 RID: 25492 RVA: 0x000BE154 File Offset: 0x000BC354
		private bool ShouldSerializestartTime()
		{
			return this.startTimeSpecified;
		}

		// Token: 0x06006395 RID: 25493 RVA: 0x000BE16C File Offset: 0x000BC36C
		private void ResetstartTime()
		{
			this.startTimeSpecified = false;
		}

		// Token: 0x17001F64 RID: 8036
		// (get) Token: 0x06006396 RID: 25494 RVA: 0x000BE178 File Offset: 0x000BC378
		// (set) Token: 0x06006397 RID: 25495 RVA: 0x000BE1A4 File Offset: 0x000BC3A4
		[ProtoMember(5, IsRequired = false, Name = "actStage", DataFormat = DataFormat.TwosComplement)]
		public uint actStage
		{
			get
			{
				return this._actStage ?? 0U;
			}
			set
			{
				this._actStage = new uint?(value);
			}
		}

		// Token: 0x17001F65 RID: 8037
		// (get) Token: 0x06006398 RID: 25496 RVA: 0x000BE1B4 File Offset: 0x000BC3B4
		// (set) Token: 0x06006399 RID: 25497 RVA: 0x000BE1D4 File Offset: 0x000BC3D4
		[XmlIgnore]
		[Browsable(false)]
		public bool actStageSpecified
		{
			get
			{
				return this._actStage != null;
			}
			set
			{
				bool flag = value == (this._actStage == null);
				if (flag)
				{
					this._actStage = (value ? new uint?(this.actStage) : null);
				}
			}
		}

		// Token: 0x0600639A RID: 25498 RVA: 0x000BE218 File Offset: 0x000BC418
		private bool ShouldSerializeactStage()
		{
			return this.actStageSpecified;
		}

		// Token: 0x0600639B RID: 25499 RVA: 0x000BE230 File Offset: 0x000BC430
		private void ResetactStage()
		{
			this.actStageSpecified = false;
		}

		// Token: 0x17001F66 RID: 8038
		// (get) Token: 0x0600639C RID: 25500 RVA: 0x000BE23C File Offset: 0x000BC43C
		// (set) Token: 0x0600639D RID: 25501 RVA: 0x000BE254 File Offset: 0x000BC454
		[ProtoMember(6, IsRequired = false, Name = "argenta", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArgentaData argenta
		{
			get
			{
				return this._argenta;
			}
			set
			{
				this._argenta = value;
			}
		}

		// Token: 0x17001F67 RID: 8039
		// (get) Token: 0x0600639E RID: 25502 RVA: 0x000BE260 File Offset: 0x000BC460
		// (set) Token: 0x0600639F RID: 25503 RVA: 0x000BE278 File Offset: 0x000BC478
		[ProtoMember(7, IsRequired = false, Name = "ancient", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AncientTimes ancient
		{
			get
			{
				return this._ancient;
			}
			set
			{
				this._ancient = value;
			}
		}

		// Token: 0x17001F68 RID: 8040
		// (get) Token: 0x060063A0 RID: 25504 RVA: 0x000BE284 File Offset: 0x000BC484
		// (set) Token: 0x060063A1 RID: 25505 RVA: 0x000BE29C File Offset: 0x000BC49C
		[ProtoMember(8, IsRequired = false, Name = "theme", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ThemeActivityData theme
		{
			get
			{
				return this._theme;
			}
			set
			{
				this._theme = value;
			}
		}

		// Token: 0x17001F69 RID: 8041
		// (get) Token: 0x060063A2 RID: 25506 RVA: 0x000BE2A8 File Offset: 0x000BC4A8
		// (set) Token: 0x060063A3 RID: 25507 RVA: 0x000BE2C0 File Offset: 0x000BC4C0
		[ProtoMember(9, IsRequired = false, Name = "backflow", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowData backflow
		{
			get
			{
				return this._backflow;
			}
			set
			{
				this._backflow = value;
			}
		}

		// Token: 0x17001F6A RID: 8042
		// (get) Token: 0x060063A4 RID: 25508 RVA: 0x000BE2CC File Offset: 0x000BC4CC
		// (set) Token: 0x060063A5 RID: 25509 RVA: 0x000BE2E4 File Offset: 0x000BC4E4
		[ProtoMember(10, IsRequired = false, Name = "campduel", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampDuelData campduel
		{
			get
			{
				return this._campduel;
			}
			set
			{
				this._campduel = value;
			}
		}

		// Token: 0x17001F6B RID: 8043
		// (get) Token: 0x060063A6 RID: 25510 RVA: 0x000BE2F0 File Offset: 0x000BC4F0
		// (set) Token: 0x060063A7 RID: 25511 RVA: 0x000BE308 File Offset: 0x000BC508
		[ProtoMember(11, IsRequired = false, Name = "festival520", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Festival520Data festival520
		{
			get
			{
				return this._festival520;
			}
			set
			{
				this._festival520 = value;
			}
		}

		// Token: 0x17001F6C RID: 8044
		// (get) Token: 0x060063A8 RID: 25512 RVA: 0x000BE314 File Offset: 0x000BC514
		// (set) Token: 0x060063A9 RID: 25513 RVA: 0x000BE32C File Offset: 0x000BC52C
		[ProtoMember(12, IsRequired = false, Name = "shadowcat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ShadowCatData shadowcat
		{
			get
			{
				return this._shadowcat;
			}
			set
			{
				this._shadowcat = value;
			}
		}

		// Token: 0x060063AA RID: 25514 RVA: 0x000BE338 File Offset: 0x000BC538
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400181C RID: 6172
		private uint? _actid;

		// Token: 0x0400181D RID: 6173
		private readonly List<SpActivityTask> _task = new List<SpActivityTask>();

		// Token: 0x0400181E RID: 6174
		private bool? _getBigPrize;

		// Token: 0x0400181F RID: 6175
		private uint? _startTime;

		// Token: 0x04001820 RID: 6176
		private uint? _actStage;

		// Token: 0x04001821 RID: 6177
		private ArgentaData _argenta = null;

		// Token: 0x04001822 RID: 6178
		private AncientTimes _ancient = null;

		// Token: 0x04001823 RID: 6179
		private ThemeActivityData _theme = null;

		// Token: 0x04001824 RID: 6180
		private BackFlowData _backflow = null;

		// Token: 0x04001825 RID: 6181
		private CampDuelData _campduel = null;

		// Token: 0x04001826 RID: 6182
		private Festival520Data _festival520 = null;

		// Token: 0x04001827 RID: 6183
		private ShadowCatData _shadowcat = null;

		// Token: 0x04001828 RID: 6184
		private IExtension extensionObject;
	}
}
