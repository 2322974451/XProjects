using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000734 RID: 1844
	[ProtoContract(Name = "BattleFieldLeftAward")]
	[Serializable]
	public class BattleFieldLeftAward : IExtensible
	{
		// Token: 0x17002878 RID: 10360
		// (get) Token: 0x06007FA3 RID: 32675 RVA: 0x000F4170 File Offset: 0x000F2370
		// (set) Token: 0x06007FA4 RID: 32676 RVA: 0x000F419C File Offset: 0x000F239C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17002879 RID: 10361
		// (get) Token: 0x06007FA5 RID: 32677 RVA: 0x000F41AC File Offset: 0x000F23AC
		// (set) Token: 0x06007FA6 RID: 32678 RVA: 0x000F41CC File Offset: 0x000F23CC
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06007FA7 RID: 32679 RVA: 0x000F4210 File Offset: 0x000F2410
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007FA8 RID: 32680 RVA: 0x000F4228 File Offset: 0x000F2428
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700287A RID: 10362
		// (get) Token: 0x06007FA9 RID: 32681 RVA: 0x000F4234 File Offset: 0x000F2434
		// (set) Token: 0x06007FAA RID: 32682 RVA: 0x000F4260 File Offset: 0x000F2460
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x1700287B RID: 10363
		// (get) Token: 0x06007FAB RID: 32683 RVA: 0x000F4270 File Offset: 0x000F2470
		// (set) Token: 0x06007FAC RID: 32684 RVA: 0x000F4290 File Offset: 0x000F2490
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06007FAD RID: 32685 RVA: 0x000F42D4 File Offset: 0x000F24D4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06007FAE RID: 32686 RVA: 0x000F42EC File Offset: 0x000F24EC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06007FAF RID: 32687 RVA: 0x000F42F8 File Offset: 0x000F24F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DF0 RID: 7664
		private uint? _id;

		// Token: 0x04001DF1 RID: 7665
		private uint? _count;

		// Token: 0x04001DF2 RID: 7666
		private IExtension extensionObject;
	}
}
