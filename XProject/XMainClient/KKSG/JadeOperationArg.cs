using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000042 RID: 66
	[ProtoContract(Name = "JadeOperationArg")]
	[Serializable]
	public class JadeOperationArg : IExtensible
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0000B45C File Offset: 0x0000965C
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x0000B488 File Offset: 0x00009688
		[ProtoMember(1, IsRequired = false, Name = "OperationType", DataFormat = DataFormat.TwosComplement)]
		public uint OperationType
		{
			get
			{
				return this._OperationType ?? 0U;
			}
			set
			{
				this._OperationType = new uint?(value);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x0000B498 File Offset: 0x00009698
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x0000B4B8 File Offset: 0x000096B8
		[XmlIgnore]
		[Browsable(false)]
		public bool OperationTypeSpecified
		{
			get
			{
				return this._OperationType != null;
			}
			set
			{
				bool flag = value == (this._OperationType == null);
				if (flag)
				{
					this._OperationType = (value ? new uint?(this.OperationType) : null);
				}
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000B4FC File Offset: 0x000096FC
		private bool ShouldSerializeOperationType()
		{
			return this.OperationTypeSpecified;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000B514 File Offset: 0x00009714
		private void ResetOperationType()
		{
			this.OperationTypeSpecified = false;
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000B520 File Offset: 0x00009720
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x0000B54D File Offset: 0x0000974D
		[ProtoMember(2, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong EquipUniqueId
		{
			get
			{
				return this._EquipUniqueId ?? 0UL;
			}
			set
			{
				this._EquipUniqueId = new ulong?(value);
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000B55C File Offset: 0x0000975C
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x0000B57C File Offset: 0x0000977C
		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUniqueIdSpecified
		{
			get
			{
				return this._EquipUniqueId != null;
			}
			set
			{
				bool flag = value == (this._EquipUniqueId == null);
				if (flag)
				{
					this._EquipUniqueId = (value ? new ulong?(this.EquipUniqueId) : null);
				}
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000B5C0 File Offset: 0x000097C0
		private bool ShouldSerializeEquipUniqueId()
		{
			return this.EquipUniqueIdSpecified;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000B5D8 File Offset: 0x000097D8
		private void ResetEquipUniqueId()
		{
			this.EquipUniqueIdSpecified = false;
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000B5E4 File Offset: 0x000097E4
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000B611 File Offset: 0x00009811
		[ProtoMember(3, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong JadeUniqueId
		{
			get
			{
				return this._JadeUniqueId ?? 0UL;
			}
			set
			{
				this._JadeUniqueId = new ulong?(value);
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000B620 File Offset: 0x00009820
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x0000B640 File Offset: 0x00009840
		[XmlIgnore]
		[Browsable(false)]
		public bool JadeUniqueIdSpecified
		{
			get
			{
				return this._JadeUniqueId != null;
			}
			set
			{
				bool flag = value == (this._JadeUniqueId == null);
				if (flag)
				{
					this._JadeUniqueId = (value ? new ulong?(this.JadeUniqueId) : null);
				}
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000B684 File Offset: 0x00009884
		private bool ShouldSerializeJadeUniqueId()
		{
			return this.JadeUniqueIdSpecified;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000B69C File Offset: 0x0000989C
		private void ResetJadeUniqueId()
		{
			this.JadeUniqueIdSpecified = false;
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000B6A8 File Offset: 0x000098A8
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x0000B6D4 File Offset: 0x000098D4
		[ProtoMember(4, IsRequired = false, Name = "Pos", DataFormat = DataFormat.TwosComplement)]
		public uint Pos
		{
			get
			{
				return this._Pos ?? 0U;
			}
			set
			{
				this._Pos = new uint?(value);
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000B6E4 File Offset: 0x000098E4
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x0000B704 File Offset: 0x00009904
		[XmlIgnore]
		[Browsable(false)]
		public bool PosSpecified
		{
			get
			{
				return this._Pos != null;
			}
			set
			{
				bool flag = value == (this._Pos == null);
				if (flag)
				{
					this._Pos = (value ? new uint?(this.Pos) : null);
				}
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000B748 File Offset: 0x00009948
		private bool ShouldSerializePos()
		{
			return this.PosSpecified;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000B760 File Offset: 0x00009960
		private void ResetPos()
		{
			this.PosSpecified = false;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000B76C File Offset: 0x0000996C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400012B RID: 299
		private uint? _OperationType;

		// Token: 0x0400012C RID: 300
		private ulong? _EquipUniqueId;

		// Token: 0x0400012D RID: 301
		private ulong? _JadeUniqueId;

		// Token: 0x0400012E RID: 302
		private uint? _Pos;

		// Token: 0x0400012F RID: 303
		private IExtension extensionObject;
	}
}
