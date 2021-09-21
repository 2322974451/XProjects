using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BC RID: 444
	[ProtoContract(Name = "GetWorldBossTimeLeftRes")]
	[Serializable]
	public class GetWorldBossTimeLeftRes : IExtensible
	{
		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x000333D4 File Offset: 0x000315D4
		// (set) Token: 0x060019D9 RID: 6617 RVA: 0x00033400 File Offset: 0x00031600
		[ProtoMember(1, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x060019DA RID: 6618 RVA: 0x00033410 File Offset: 0x00031610
		// (set) Token: 0x060019DB RID: 6619 RVA: 0x00033430 File Offset: 0x00031630
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x00033474 File Offset: 0x00031674
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x0003348C File Offset: 0x0003168C
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x060019DE RID: 6622 RVA: 0x00033498 File Offset: 0x00031698
		// (set) Token: 0x060019DF RID: 6623 RVA: 0x000334C4 File Offset: 0x000316C4
		[ProtoMember(2, IsRequired = false, Name = "guildrolecount", DataFormat = DataFormat.TwosComplement)]
		public uint guildrolecount
		{
			get
			{
				return this._guildrolecount ?? 0U;
			}
			set
			{
				this._guildrolecount = new uint?(value);
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x000334D4 File Offset: 0x000316D4
		// (set) Token: 0x060019E1 RID: 6625 RVA: 0x000334F4 File Offset: 0x000316F4
		[XmlIgnore]
		[Browsable(false)]
		public bool guildrolecountSpecified
		{
			get
			{
				return this._guildrolecount != null;
			}
			set
			{
				bool flag = value == (this._guildrolecount == null);
				if (flag)
				{
					this._guildrolecount = (value ? new uint?(this.guildrolecount) : null);
				}
			}
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x00033538 File Offset: 0x00031738
		private bool ShouldSerializeguildrolecount()
		{
			return this.guildrolecountSpecified;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x00033550 File Offset: 0x00031750
		private void Resetguildrolecount()
		{
			this.guildrolecountSpecified = false;
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x0003355C File Offset: 0x0003175C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400066F RID: 1647
		private uint? _timeleft;

		// Token: 0x04000670 RID: 1648
		private uint? _guildrolecount;

		// Token: 0x04000671 RID: 1649
		private IExtension extensionObject;
	}
}
