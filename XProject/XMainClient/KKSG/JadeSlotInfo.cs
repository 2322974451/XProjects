using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000555 RID: 1365
	[ProtoContract(Name = "JadeSlotInfo")]
	[Serializable]
	public class JadeSlotInfo : IExtensible
	{
		// Token: 0x1700154E RID: 5454
		// (get) Token: 0x060045C1 RID: 17857 RVA: 0x000848E4 File Offset: 0x00082AE4
		// (set) Token: 0x060045C2 RID: 17858 RVA: 0x00084910 File Offset: 0x00082B10
		[ProtoMember(1, IsRequired = false, Name = "operatorType", DataFormat = DataFormat.TwosComplement)]
		public uint operatorType
		{
			get
			{
				return this._operatorType ?? 0U;
			}
			set
			{
				this._operatorType = new uint?(value);
			}
		}

		// Token: 0x1700154F RID: 5455
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x00084920 File Offset: 0x00082B20
		// (set) Token: 0x060045C4 RID: 17860 RVA: 0x00084940 File Offset: 0x00082B40
		[XmlIgnore]
		[Browsable(false)]
		public bool operatorTypeSpecified
		{
			get
			{
				return this._operatorType != null;
			}
			set
			{
				bool flag = value == (this._operatorType == null);
				if (flag)
				{
					this._operatorType = (value ? new uint?(this.operatorType) : null);
				}
			}
		}

		// Token: 0x060045C5 RID: 17861 RVA: 0x00084984 File Offset: 0x00082B84
		private bool ShouldSerializeoperatorType()
		{
			return this.operatorTypeSpecified;
		}

		// Token: 0x060045C6 RID: 17862 RVA: 0x0008499C File Offset: 0x00082B9C
		private void ResetoperatorType()
		{
			this.operatorTypeSpecified = false;
		}

		// Token: 0x17001550 RID: 5456
		// (get) Token: 0x060045C7 RID: 17863 RVA: 0x000849A8 File Offset: 0x00082BA8
		// (set) Token: 0x060045C8 RID: 17864 RVA: 0x000849D4 File Offset: 0x00082BD4
		[ProtoMember(2, IsRequired = false, Name = "jadeSlot", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSlot
		{
			get
			{
				return this._jadeSlot ?? 0U;
			}
			set
			{
				this._jadeSlot = new uint?(value);
			}
		}

		// Token: 0x17001551 RID: 5457
		// (get) Token: 0x060045C9 RID: 17865 RVA: 0x000849E4 File Offset: 0x00082BE4
		// (set) Token: 0x060045CA RID: 17866 RVA: 0x00084A04 File Offset: 0x00082C04
		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSlotSpecified
		{
			get
			{
				return this._jadeSlot != null;
			}
			set
			{
				bool flag = value == (this._jadeSlot == null);
				if (flag)
				{
					this._jadeSlot = (value ? new uint?(this.jadeSlot) : null);
				}
			}
		}

		// Token: 0x060045CB RID: 17867 RVA: 0x00084A48 File Offset: 0x00082C48
		private bool ShouldSerializejadeSlot()
		{
			return this.jadeSlotSpecified;
		}

		// Token: 0x060045CC RID: 17868 RVA: 0x00084A60 File Offset: 0x00082C60
		private void ResetjadeSlot()
		{
			this.jadeSlotSpecified = false;
		}

		// Token: 0x060045CD RID: 17869 RVA: 0x00084A6C File Offset: 0x00082C6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400116B RID: 4459
		private uint? _operatorType;

		// Token: 0x0400116C RID: 4460
		private uint? _jadeSlot;

		// Token: 0x0400116D RID: 4461
		private IExtension extensionObject;
	}
}
