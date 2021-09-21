using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000432 RID: 1074
	[ProtoContract(Name = "GetMobaBattleBriefRecordRes")]
	[Serializable]
	public class GetMobaBattleBriefRecordRes : IExtensible
	{
		// Token: 0x17001173 RID: 4467
		// (get) Token: 0x060038D1 RID: 14545 RVA: 0x0006CBC4 File Offset: 0x0006ADC4
		// (set) Token: 0x060038D2 RID: 14546 RVA: 0x0006CBF0 File Offset: 0x0006ADF0
		[ProtoMember(1, IsRequired = false, Name = "totalnum", DataFormat = DataFormat.TwosComplement)]
		public uint totalnum
		{
			get
			{
				return this._totalnum ?? 0U;
			}
			set
			{
				this._totalnum = new uint?(value);
			}
		}

		// Token: 0x17001174 RID: 4468
		// (get) Token: 0x060038D3 RID: 14547 RVA: 0x0006CC00 File Offset: 0x0006AE00
		// (set) Token: 0x060038D4 RID: 14548 RVA: 0x0006CC20 File Offset: 0x0006AE20
		[XmlIgnore]
		[Browsable(false)]
		public bool totalnumSpecified
		{
			get
			{
				return this._totalnum != null;
			}
			set
			{
				bool flag = value == (this._totalnum == null);
				if (flag)
				{
					this._totalnum = (value ? new uint?(this.totalnum) : null);
				}
			}
		}

		// Token: 0x060038D5 RID: 14549 RVA: 0x0006CC64 File Offset: 0x0006AE64
		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		// Token: 0x060038D6 RID: 14550 RVA: 0x0006CC7C File Offset: 0x0006AE7C
		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		// Token: 0x17001175 RID: 4469
		// (get) Token: 0x060038D7 RID: 14551 RVA: 0x0006CC88 File Offset: 0x0006AE88
		// (set) Token: 0x060038D8 RID: 14552 RVA: 0x0006CCB4 File Offset: 0x0006AEB4
		[ProtoMember(2, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		// Token: 0x17001176 RID: 4470
		// (get) Token: 0x060038D9 RID: 14553 RVA: 0x0006CCC4 File Offset: 0x0006AEC4
		// (set) Token: 0x060038DA RID: 14554 RVA: 0x0006CCE4 File Offset: 0x0006AEE4
		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		// Token: 0x060038DB RID: 14555 RVA: 0x0006CD28 File Offset: 0x0006AF28
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x0006CD40 File Offset: 0x0006AF40
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x17001177 RID: 4471
		// (get) Token: 0x060038DD RID: 14557 RVA: 0x0006CD4C File Offset: 0x0006AF4C
		[ProtoMember(3, Name = "brief", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameBrief> brief
		{
			get
			{
				return this._brief;
			}
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x0006CD64 File Offset: 0x0006AF64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E19 RID: 3609
		private uint? _totalnum;

		// Token: 0x04000E1A RID: 3610
		private uint? _winnum;

		// Token: 0x04000E1B RID: 3611
		private readonly List<MobaBattleOneGameBrief> _brief = new List<MobaBattleOneGameBrief>();

		// Token: 0x04000E1C RID: 3612
		private IExtension extensionObject;
	}
}
