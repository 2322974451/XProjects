using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000600 RID: 1536
	[ProtoContract(Name = "OnlyOnceGuildBonusData")]
	[Serializable]
	public class OnlyOnceGuildBonusData : IExtensible
	{
		// Token: 0x17001CC6 RID: 7366
		// (get) Token: 0x06005BE4 RID: 23524 RVA: 0x000AF088 File Offset: 0x000AD288
		// (set) Token: 0x06005BE5 RID: 23525 RVA: 0x000AF0B4 File Offset: 0x000AD2B4
		[ProtoMember(1, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusType
		{
			get
			{
				return this._bonusType ?? 0U;
			}
			set
			{
				this._bonusType = new uint?(value);
			}
		}

		// Token: 0x17001CC7 RID: 7367
		// (get) Token: 0x06005BE6 RID: 23526 RVA: 0x000AF0C4 File Offset: 0x000AD2C4
		// (set) Token: 0x06005BE7 RID: 23527 RVA: 0x000AF0E4 File Offset: 0x000AD2E4
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusTypeSpecified
		{
			get
			{
				return this._bonusType != null;
			}
			set
			{
				bool flag = value == (this._bonusType == null);
				if (flag)
				{
					this._bonusType = (value ? new uint?(this.bonusType) : null);
				}
			}
		}

		// Token: 0x06005BE8 RID: 23528 RVA: 0x000AF128 File Offset: 0x000AD328
		private bool ShouldSerializebonusType()
		{
			return this.bonusTypeSpecified;
		}

		// Token: 0x06005BE9 RID: 23529 RVA: 0x000AF140 File Offset: 0x000AD340
		private void ResetbonusType()
		{
			this.bonusTypeSpecified = false;
		}

		// Token: 0x17001CC8 RID: 7368
		// (get) Token: 0x06005BEA RID: 23530 RVA: 0x000AF14C File Offset: 0x000AD34C
		// (set) Token: 0x06005BEB RID: 23531 RVA: 0x000AF178 File Offset: 0x000AD378
		[ProtoMember(2, IsRequired = false, Name = "bonusVar", DataFormat = DataFormat.TwosComplement)]
		public uint bonusVar
		{
			get
			{
				return this._bonusVar ?? 0U;
			}
			set
			{
				this._bonusVar = new uint?(value);
			}
		}

		// Token: 0x17001CC9 RID: 7369
		// (get) Token: 0x06005BEC RID: 23532 RVA: 0x000AF188 File Offset: 0x000AD388
		// (set) Token: 0x06005BED RID: 23533 RVA: 0x000AF1A8 File Offset: 0x000AD3A8
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusVarSpecified
		{
			get
			{
				return this._bonusVar != null;
			}
			set
			{
				bool flag = value == (this._bonusVar == null);
				if (flag)
				{
					this._bonusVar = (value ? new uint?(this.bonusVar) : null);
				}
			}
		}

		// Token: 0x06005BEE RID: 23534 RVA: 0x000AF1EC File Offset: 0x000AD3EC
		private bool ShouldSerializebonusVar()
		{
			return this.bonusVarSpecified;
		}

		// Token: 0x06005BEF RID: 23535 RVA: 0x000AF204 File Offset: 0x000AD404
		private void ResetbonusVar()
		{
			this.bonusVarSpecified = false;
		}

		// Token: 0x06005BF0 RID: 23536 RVA: 0x000AF210 File Offset: 0x000AD410
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400165C RID: 5724
		private uint? _bonusType;

		// Token: 0x0400165D RID: 5725
		private uint? _bonusVar;

		// Token: 0x0400165E RID: 5726
		private IExtension extensionObject;
	}
}
