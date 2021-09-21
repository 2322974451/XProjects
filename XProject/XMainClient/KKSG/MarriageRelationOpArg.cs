using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000477 RID: 1143
	[ProtoContract(Name = "MarriageRelationOpArg")]
	[Serializable]
	public class MarriageRelationOpArg : IExtensible
	{
		// Token: 0x1700124E RID: 4686
		// (get) Token: 0x06003BB4 RID: 15284 RVA: 0x0007215C File Offset: 0x0007035C
		// (set) Token: 0x06003BB5 RID: 15285 RVA: 0x00072188 File Offset: 0x00070388
		[ProtoMember(1, IsRequired = false, Name = "opType", DataFormat = DataFormat.TwosComplement)]
		public MarriageOpType opType
		{
			get
			{
				return this._opType ?? MarriageOpType.MarriageOpType_MarryApply;
			}
			set
			{
				this._opType = new MarriageOpType?(value);
			}
		}

		// Token: 0x1700124F RID: 4687
		// (get) Token: 0x06003BB6 RID: 15286 RVA: 0x00072198 File Offset: 0x00070398
		// (set) Token: 0x06003BB7 RID: 15287 RVA: 0x000721B8 File Offset: 0x000703B8
		[XmlIgnore]
		[Browsable(false)]
		public bool opTypeSpecified
		{
			get
			{
				return this._opType != null;
			}
			set
			{
				bool flag = value == (this._opType == null);
				if (flag)
				{
					this._opType = (value ? new MarriageOpType?(this.opType) : null);
				}
			}
		}

		// Token: 0x06003BB8 RID: 15288 RVA: 0x000721FC File Offset: 0x000703FC
		private bool ShouldSerializeopType()
		{
			return this.opTypeSpecified;
		}

		// Token: 0x06003BB9 RID: 15289 RVA: 0x00072214 File Offset: 0x00070414
		private void ResetopType()
		{
			this.opTypeSpecified = false;
		}

		// Token: 0x17001250 RID: 4688
		// (get) Token: 0x06003BBA RID: 15290 RVA: 0x00072220 File Offset: 0x00070420
		// (set) Token: 0x06003BBB RID: 15291 RVA: 0x0007224C File Offset: 0x0007044C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		// Token: 0x17001251 RID: 4689
		// (get) Token: 0x06003BBC RID: 15292 RVA: 0x0007225C File Offset: 0x0007045C
		// (set) Token: 0x06003BBD RID: 15293 RVA: 0x0007227C File Offset: 0x0007047C
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
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003BBE RID: 15294 RVA: 0x000722C0 File Offset: 0x000704C0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003BBF RID: 15295 RVA: 0x000722D8 File Offset: 0x000704D8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001252 RID: 4690
		// (get) Token: 0x06003BC0 RID: 15296 RVA: 0x000722E4 File Offset: 0x000704E4
		// (set) Token: 0x06003BC1 RID: 15297 RVA: 0x00072311 File Offset: 0x00070511
		[ProtoMember(3, IsRequired = false, Name = "destRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong destRoleID
		{
			get
			{
				return this._destRoleID ?? 0UL;
			}
			set
			{
				this._destRoleID = new ulong?(value);
			}
		}

		// Token: 0x17001253 RID: 4691
		// (get) Token: 0x06003BC2 RID: 15298 RVA: 0x00072320 File Offset: 0x00070520
		// (set) Token: 0x06003BC3 RID: 15299 RVA: 0x00072340 File Offset: 0x00070540
		[XmlIgnore]
		[Browsable(false)]
		public bool destRoleIDSpecified
		{
			get
			{
				return this._destRoleID != null;
			}
			set
			{
				bool flag = value == (this._destRoleID == null);
				if (flag)
				{
					this._destRoleID = (value ? new ulong?(this.destRoleID) : null);
				}
			}
		}

		// Token: 0x06003BC4 RID: 15300 RVA: 0x00072384 File Offset: 0x00070584
		private bool ShouldSerializedestRoleID()
		{
			return this.destRoleIDSpecified;
		}

		// Token: 0x06003BC5 RID: 15301 RVA: 0x0007239C File Offset: 0x0007059C
		private void ResetdestRoleID()
		{
			this.destRoleIDSpecified = false;
		}

		// Token: 0x06003BC6 RID: 15302 RVA: 0x000723A8 File Offset: 0x000705A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EDB RID: 3803
		private MarriageOpType? _opType;

		// Token: 0x04000EDC RID: 3804
		private WeddingType? _type;

		// Token: 0x04000EDD RID: 3805
		private ulong? _destRoleID;

		// Token: 0x04000EDE RID: 3806
		private IExtension extensionObject;
	}
}
