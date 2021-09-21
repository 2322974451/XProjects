using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054D RID: 1357
	[ProtoContract(Name = "JadeOperationNewArg")]
	[Serializable]
	public class JadeOperationNewArg : IExtensible
	{
		// Token: 0x17001535 RID: 5429
		// (get) Token: 0x06004568 RID: 17768 RVA: 0x00083F28 File Offset: 0x00082128
		// (set) Token: 0x06004569 RID: 17769 RVA: 0x00083F54 File Offset: 0x00082154
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

		// Token: 0x17001536 RID: 5430
		// (get) Token: 0x0600456A RID: 17770 RVA: 0x00083F64 File Offset: 0x00082164
		// (set) Token: 0x0600456B RID: 17771 RVA: 0x00083F84 File Offset: 0x00082184
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

		// Token: 0x0600456C RID: 17772 RVA: 0x00083FC8 File Offset: 0x000821C8
		private bool ShouldSerializeOperationType()
		{
			return this.OperationTypeSpecified;
		}

		// Token: 0x0600456D RID: 17773 RVA: 0x00083FE0 File Offset: 0x000821E0
		private void ResetOperationType()
		{
			this.OperationTypeSpecified = false;
		}

		// Token: 0x17001537 RID: 5431
		// (get) Token: 0x0600456E RID: 17774 RVA: 0x00083FEC File Offset: 0x000821EC
		// (set) Token: 0x0600456F RID: 17775 RVA: 0x0008400D File Offset: 0x0008220D
		[ProtoMember(2, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.Default)]
		public string EquipUniqueId
		{
			get
			{
				return this._EquipUniqueId ?? "";
			}
			set
			{
				this._EquipUniqueId = value;
			}
		}

		// Token: 0x17001538 RID: 5432
		// (get) Token: 0x06004570 RID: 17776 RVA: 0x00084018 File Offset: 0x00082218
		// (set) Token: 0x06004571 RID: 17777 RVA: 0x00084034 File Offset: 0x00082234
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
					this._EquipUniqueId = (value ? this.EquipUniqueId : null);
				}
			}
		}

		// Token: 0x06004572 RID: 17778 RVA: 0x00084064 File Offset: 0x00082264
		private bool ShouldSerializeEquipUniqueId()
		{
			return this.EquipUniqueIdSpecified;
		}

		// Token: 0x06004573 RID: 17779 RVA: 0x0008407C File Offset: 0x0008227C
		private void ResetEquipUniqueId()
		{
			this.EquipUniqueIdSpecified = false;
		}

		// Token: 0x17001539 RID: 5433
		// (get) Token: 0x06004574 RID: 17780 RVA: 0x00084088 File Offset: 0x00082288
		// (set) Token: 0x06004575 RID: 17781 RVA: 0x000840A9 File Offset: 0x000822A9
		[ProtoMember(3, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.Default)]
		public string JadeUniqueId
		{
			get
			{
				return this._JadeUniqueId ?? "";
			}
			set
			{
				this._JadeUniqueId = value;
			}
		}

		// Token: 0x1700153A RID: 5434
		// (get) Token: 0x06004576 RID: 17782 RVA: 0x000840B4 File Offset: 0x000822B4
		// (set) Token: 0x06004577 RID: 17783 RVA: 0x000840D0 File Offset: 0x000822D0
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
					this._JadeUniqueId = (value ? this.JadeUniqueId : null);
				}
			}
		}

		// Token: 0x06004578 RID: 17784 RVA: 0x00084100 File Offset: 0x00082300
		private bool ShouldSerializeJadeUniqueId()
		{
			return this.JadeUniqueIdSpecified;
		}

		// Token: 0x06004579 RID: 17785 RVA: 0x00084118 File Offset: 0x00082318
		private void ResetJadeUniqueId()
		{
			this.JadeUniqueIdSpecified = false;
		}

		// Token: 0x1700153B RID: 5435
		// (get) Token: 0x0600457A RID: 17786 RVA: 0x00084124 File Offset: 0x00082324
		// (set) Token: 0x0600457B RID: 17787 RVA: 0x00084150 File Offset: 0x00082350
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

		// Token: 0x1700153C RID: 5436
		// (get) Token: 0x0600457C RID: 17788 RVA: 0x00084160 File Offset: 0x00082360
		// (set) Token: 0x0600457D RID: 17789 RVA: 0x00084180 File Offset: 0x00082380
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

		// Token: 0x0600457E RID: 17790 RVA: 0x000841C4 File Offset: 0x000823C4
		private bool ShouldSerializePos()
		{
			return this.PosSpecified;
		}

		// Token: 0x0600457F RID: 17791 RVA: 0x000841DC File Offset: 0x000823DC
		private void ResetPos()
		{
			this.PosSpecified = false;
		}

		// Token: 0x06004580 RID: 17792 RVA: 0x000841E8 File Offset: 0x000823E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001156 RID: 4438
		private uint? _OperationType;

		// Token: 0x04001157 RID: 4439
		private string _EquipUniqueId;

		// Token: 0x04001158 RID: 4440
		private string _JadeUniqueId;

		// Token: 0x04001159 RID: 4441
		private uint? _Pos;

		// Token: 0x0400115A RID: 4442
		private IExtension extensionObject;
	}
}
