using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000592 RID: 1426
	[ProtoContract(Name = "BagExpandData")]
	[Serializable]
	public class BagExpandData : IExtensible
	{
		// Token: 0x17001751 RID: 5969
		// (get) Token: 0x06004BC7 RID: 19399 RVA: 0x000901E0 File Offset: 0x0008E3E0
		// (set) Token: 0x06004BC8 RID: 19400 RVA: 0x0009020C File Offset: 0x0008E40C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public BagType type
		{
			get
			{
				return this._type ?? BagType.EquipBag;
			}
			set
			{
				this._type = new BagType?(value);
			}
		}

		// Token: 0x17001752 RID: 5970
		// (get) Token: 0x06004BC9 RID: 19401 RVA: 0x0009021C File Offset: 0x0008E41C
		// (set) Token: 0x06004BCA RID: 19402 RVA: 0x0009023C File Offset: 0x0008E43C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new BagType?(this.type) : null);
				}
			}
		}

		// Token: 0x06004BCB RID: 19403 RVA: 0x00090280 File Offset: 0x0008E480
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004BCC RID: 19404 RVA: 0x00090298 File Offset: 0x0008E498
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001753 RID: 5971
		// (get) Token: 0x06004BCD RID: 19405 RVA: 0x000902A4 File Offset: 0x0008E4A4
		// (set) Token: 0x06004BCE RID: 19406 RVA: 0x000902D0 File Offset: 0x0008E4D0
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x17001754 RID: 5972
		// (get) Token: 0x06004BCF RID: 19407 RVA: 0x000902E0 File Offset: 0x0008E4E0
		// (set) Token: 0x06004BD0 RID: 19408 RVA: 0x00090300 File Offset: 0x0008E500
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x06004BD1 RID: 19409 RVA: 0x00090344 File Offset: 0x0008E544
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06004BD2 RID: 19410 RVA: 0x0009035C File Offset: 0x0008E55C
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x17001755 RID: 5973
		// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x00090368 File Offset: 0x0008E568
		// (set) Token: 0x06004BD4 RID: 19412 RVA: 0x00090394 File Offset: 0x0008E594
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001756 RID: 5974
		// (get) Token: 0x06004BD5 RID: 19413 RVA: 0x000903A4 File Offset: 0x0008E5A4
		// (set) Token: 0x06004BD6 RID: 19414 RVA: 0x000903C4 File Offset: 0x0008E5C4
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

		// Token: 0x06004BD7 RID: 19415 RVA: 0x00090408 File Offset: 0x0008E608
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06004BD8 RID: 19416 RVA: 0x00090420 File Offset: 0x0008E620
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06004BD9 RID: 19417 RVA: 0x0009042C File Offset: 0x0008E62C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012D0 RID: 4816
		private BagType? _type;

		// Token: 0x040012D1 RID: 4817
		private uint? _num;

		// Token: 0x040012D2 RID: 4818
		private uint? _count;

		// Token: 0x040012D3 RID: 4819
		private IExtension extensionObject;
	}
}
