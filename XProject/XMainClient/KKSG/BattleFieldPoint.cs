using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000676 RID: 1654
	[ProtoContract(Name = "BattleFieldPoint")]
	[Serializable]
	public class BattleFieldPoint : IExtensible
	{
		// Token: 0x17002171 RID: 8561
		// (get) Token: 0x060069B8 RID: 27064 RVA: 0x000CA208 File Offset: 0x000C8408
		// (set) Token: 0x060069B9 RID: 27065 RVA: 0x000CA234 File Offset: 0x000C8434
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

		// Token: 0x17002172 RID: 8562
		// (get) Token: 0x060069BA RID: 27066 RVA: 0x000CA244 File Offset: 0x000C8444
		// (set) Token: 0x060069BB RID: 27067 RVA: 0x000CA264 File Offset: 0x000C8464
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

		// Token: 0x060069BC RID: 27068 RVA: 0x000CA2A8 File Offset: 0x000C84A8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060069BD RID: 27069 RVA: 0x000CA2C0 File Offset: 0x000C84C0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002173 RID: 8563
		// (get) Token: 0x060069BE RID: 27070 RVA: 0x000CA2CC File Offset: 0x000C84CC
		// (set) Token: 0x060069BF RID: 27071 RVA: 0x000CA2F8 File Offset: 0x000C84F8
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

		// Token: 0x17002174 RID: 8564
		// (get) Token: 0x060069C0 RID: 27072 RVA: 0x000CA308 File Offset: 0x000C8508
		// (set) Token: 0x060069C1 RID: 27073 RVA: 0x000CA328 File Offset: 0x000C8528
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

		// Token: 0x060069C2 RID: 27074 RVA: 0x000CA36C File Offset: 0x000C856C
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060069C3 RID: 27075 RVA: 0x000CA384 File Offset: 0x000C8584
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060069C4 RID: 27076 RVA: 0x000CA390 File Offset: 0x000C8590
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001979 RID: 6521
		private uint? _id;

		// Token: 0x0400197A RID: 6522
		private uint? _count;

		// Token: 0x0400197B RID: 6523
		private IExtension extensionObject;
	}
}
