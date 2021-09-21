using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000427 RID: 1063
	[ProtoContract(Name = "EntityTargetData")]
	[Serializable]
	public class EntityTargetData : IExtensible
	{
		// Token: 0x1700114E RID: 4430
		// (get) Token: 0x06003851 RID: 14417 RVA: 0x0006BCC0 File Offset: 0x00069EC0
		// (set) Token: 0x06003852 RID: 14418 RVA: 0x0006BCED File Offset: 0x00069EED
		[ProtoMember(1, IsRequired = false, Name = "entityUID", DataFormat = DataFormat.TwosComplement)]
		public ulong entityUID
		{
			get
			{
				return this._entityUID ?? 0UL;
			}
			set
			{
				this._entityUID = new ulong?(value);
			}
		}

		// Token: 0x1700114F RID: 4431
		// (get) Token: 0x06003853 RID: 14419 RVA: 0x0006BCFC File Offset: 0x00069EFC
		// (set) Token: 0x06003854 RID: 14420 RVA: 0x0006BD1C File Offset: 0x00069F1C
		[XmlIgnore]
		[Browsable(false)]
		public bool entityUIDSpecified
		{
			get
			{
				return this._entityUID != null;
			}
			set
			{
				bool flag = value == (this._entityUID == null);
				if (flag)
				{
					this._entityUID = (value ? new ulong?(this.entityUID) : null);
				}
			}
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x0006BD60 File Offset: 0x00069F60
		private bool ShouldSerializeentityUID()
		{
			return this.entityUIDSpecified;
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x0006BD78 File Offset: 0x00069F78
		private void ResetentityUID()
		{
			this.entityUIDSpecified = false;
		}

		// Token: 0x17001150 RID: 4432
		// (get) Token: 0x06003857 RID: 14423 RVA: 0x0006BD84 File Offset: 0x00069F84
		// (set) Token: 0x06003858 RID: 14424 RVA: 0x0006BDB1 File Offset: 0x00069FB1
		[ProtoMember(2, IsRequired = false, Name = "targetUID", DataFormat = DataFormat.TwosComplement)]
		public ulong targetUID
		{
			get
			{
				return this._targetUID ?? 0UL;
			}
			set
			{
				this._targetUID = new ulong?(value);
			}
		}

		// Token: 0x17001151 RID: 4433
		// (get) Token: 0x06003859 RID: 14425 RVA: 0x0006BDC0 File Offset: 0x00069FC0
		// (set) Token: 0x0600385A RID: 14426 RVA: 0x0006BDE0 File Offset: 0x00069FE0
		[XmlIgnore]
		[Browsable(false)]
		public bool targetUIDSpecified
		{
			get
			{
				return this._targetUID != null;
			}
			set
			{
				bool flag = value == (this._targetUID == null);
				if (flag)
				{
					this._targetUID = (value ? new ulong?(this.targetUID) : null);
				}
			}
		}

		// Token: 0x0600385B RID: 14427 RVA: 0x0006BE24 File Offset: 0x0006A024
		private bool ShouldSerializetargetUID()
		{
			return this.targetUIDSpecified;
		}

		// Token: 0x0600385C RID: 14428 RVA: 0x0006BE3C File Offset: 0x0006A03C
		private void ResettargetUID()
		{
			this.targetUIDSpecified = false;
		}

		// Token: 0x0600385D RID: 14429 RVA: 0x0006BE48 File Offset: 0x0006A048
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DFA RID: 3578
		private ulong? _entityUID;

		// Token: 0x04000DFB RID: 3579
		private ulong? _targetUID;

		// Token: 0x04000DFC RID: 3580
		private IExtension extensionObject;
	}
}
