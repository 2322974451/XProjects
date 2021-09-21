using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000439 RID: 1081
	[ProtoContract(Name = "MobaAddExpData")]
	[Serializable]
	public class MobaAddExpData : IExtensible
	{
		// Token: 0x17001186 RID: 4486
		// (get) Token: 0x06003913 RID: 14611 RVA: 0x0006D33C File Offset: 0x0006B53C
		// (set) Token: 0x06003914 RID: 14612 RVA: 0x0006D370 File Offset: 0x0006B570
		[ProtoMember(1, IsRequired = false, Name = "addexp", DataFormat = DataFormat.TwosComplement)]
		public double addexp
		{
			get
			{
				return this._addexp ?? 0.0;
			}
			set
			{
				this._addexp = new double?(value);
			}
		}

		// Token: 0x17001187 RID: 4487
		// (get) Token: 0x06003915 RID: 14613 RVA: 0x0006D380 File Offset: 0x0006B580
		// (set) Token: 0x06003916 RID: 14614 RVA: 0x0006D3A0 File Offset: 0x0006B5A0
		[XmlIgnore]
		[Browsable(false)]
		public bool addexpSpecified
		{
			get
			{
				return this._addexp != null;
			}
			set
			{
				bool flag = value == (this._addexp == null);
				if (flag)
				{
					this._addexp = (value ? new double?(this.addexp) : null);
				}
			}
		}

		// Token: 0x06003917 RID: 14615 RVA: 0x0006D3E4 File Offset: 0x0006B5E4
		private bool ShouldSerializeaddexp()
		{
			return this.addexpSpecified;
		}

		// Token: 0x06003918 RID: 14616 RVA: 0x0006D3FC File Offset: 0x0006B5FC
		private void Resetaddexp()
		{
			this.addexpSpecified = false;
		}

		// Token: 0x17001188 RID: 4488
		// (get) Token: 0x06003919 RID: 14617 RVA: 0x0006D408 File Offset: 0x0006B608
		// (set) Token: 0x0600391A RID: 14618 RVA: 0x0006D434 File Offset: 0x0006B634
		[ProtoMember(2, IsRequired = false, Name = "posxz", DataFormat = DataFormat.TwosComplement)]
		public uint posxz
		{
			get
			{
				return this._posxz ?? 0U;
			}
			set
			{
				this._posxz = new uint?(value);
			}
		}

		// Token: 0x17001189 RID: 4489
		// (get) Token: 0x0600391B RID: 14619 RVA: 0x0006D444 File Offset: 0x0006B644
		// (set) Token: 0x0600391C RID: 14620 RVA: 0x0006D464 File Offset: 0x0006B664
		[XmlIgnore]
		[Browsable(false)]
		public bool posxzSpecified
		{
			get
			{
				return this._posxz != null;
			}
			set
			{
				bool flag = value == (this._posxz == null);
				if (flag)
				{
					this._posxz = (value ? new uint?(this.posxz) : null);
				}
			}
		}

		// Token: 0x0600391D RID: 14621 RVA: 0x0006D4A8 File Offset: 0x0006B6A8
		private bool ShouldSerializeposxz()
		{
			return this.posxzSpecified;
		}

		// Token: 0x0600391E RID: 14622 RVA: 0x0006D4C0 File Offset: 0x0006B6C0
		private void Resetposxz()
		{
			this.posxzSpecified = false;
		}

		// Token: 0x0600391F RID: 14623 RVA: 0x0006D4CC File Offset: 0x0006B6CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E2B RID: 3627
		private double? _addexp;

		// Token: 0x04000E2C RID: 3628
		private uint? _posxz;

		// Token: 0x04000E2D RID: 3629
		private IExtension extensionObject;
	}
}
