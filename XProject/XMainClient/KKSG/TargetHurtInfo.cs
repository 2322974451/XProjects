using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000580 RID: 1408
	[ProtoContract(Name = "TargetHurtInfo")]
	[Serializable]
	public class TargetHurtInfo : IExtensible
	{
		// Token: 0x17001672 RID: 5746
		// (get) Token: 0x0600491E RID: 18718 RVA: 0x0008AF90 File Offset: 0x00089190
		// (set) Token: 0x0600491F RID: 18719 RVA: 0x0008AFBD File Offset: 0x000891BD
		[ProtoMember(1, IsRequired = false, Name = "UnitID", DataFormat = DataFormat.TwosComplement)]
		public ulong UnitID
		{
			get
			{
				return this._UnitID ?? 0UL;
			}
			set
			{
				this._UnitID = new ulong?(value);
			}
		}

		// Token: 0x17001673 RID: 5747
		// (get) Token: 0x06004920 RID: 18720 RVA: 0x0008AFCC File Offset: 0x000891CC
		// (set) Token: 0x06004921 RID: 18721 RVA: 0x0008AFEC File Offset: 0x000891EC
		[XmlIgnore]
		[Browsable(false)]
		public bool UnitIDSpecified
		{
			get
			{
				return this._UnitID != null;
			}
			set
			{
				bool flag = value == (this._UnitID == null);
				if (flag)
				{
					this._UnitID = (value ? new ulong?(this.UnitID) : null);
				}
			}
		}

		// Token: 0x06004922 RID: 18722 RVA: 0x0008B030 File Offset: 0x00089230
		private bool ShouldSerializeUnitID()
		{
			return this.UnitIDSpecified;
		}

		// Token: 0x06004923 RID: 18723 RVA: 0x0008B048 File Offset: 0x00089248
		private void ResetUnitID()
		{
			this.UnitIDSpecified = false;
		}

		// Token: 0x17001674 RID: 5748
		// (get) Token: 0x06004924 RID: 18724 RVA: 0x0008B054 File Offset: 0x00089254
		// (set) Token: 0x06004925 RID: 18725 RVA: 0x0008B06C File Offset: 0x0008926C
		[ProtoMember(2, IsRequired = false, Name = "Result", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DamageResult Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				this._Result = value;
			}
		}

		// Token: 0x06004926 RID: 18726 RVA: 0x0008B078 File Offset: 0x00089278
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001246 RID: 4678
		private ulong? _UnitID;

		// Token: 0x04001247 RID: 4679
		private DamageResult _Result = null;

		// Token: 0x04001248 RID: 4680
		private IExtension extensionObject;
	}
}
