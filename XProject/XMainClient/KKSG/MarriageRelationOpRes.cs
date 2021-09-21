using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000478 RID: 1144
	[ProtoContract(Name = "MarriageRelationOpRes")]
	[Serializable]
	public class MarriageRelationOpRes : IExtensible
	{
		// Token: 0x17001254 RID: 4692
		// (get) Token: 0x06003BC8 RID: 15304 RVA: 0x000723C8 File Offset: 0x000705C8
		// (set) Token: 0x06003BC9 RID: 15305 RVA: 0x000723F4 File Offset: 0x000705F4
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17001255 RID: 4693
		// (get) Token: 0x06003BCA RID: 15306 RVA: 0x00072404 File Offset: 0x00070604
		// (set) Token: 0x06003BCB RID: 15307 RVA: 0x00072424 File Offset: 0x00070624
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06003BCC RID: 15308 RVA: 0x00072468 File Offset: 0x00070668
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06003BCD RID: 15309 RVA: 0x00072480 File Offset: 0x00070680
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17001256 RID: 4694
		// (get) Token: 0x06003BCE RID: 15310 RVA: 0x0007248C File Offset: 0x0007068C
		// (set) Token: 0x06003BCF RID: 15311 RVA: 0x000724B9 File Offset: 0x000706B9
		[ProtoMember(2, IsRequired = false, Name = "oppoRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong oppoRoleID
		{
			get
			{
				return this._oppoRoleID ?? 0UL;
			}
			set
			{
				this._oppoRoleID = new ulong?(value);
			}
		}

		// Token: 0x17001257 RID: 4695
		// (get) Token: 0x06003BD0 RID: 15312 RVA: 0x000724C8 File Offset: 0x000706C8
		// (set) Token: 0x06003BD1 RID: 15313 RVA: 0x000724E8 File Offset: 0x000706E8
		[XmlIgnore]
		[Browsable(false)]
		public bool oppoRoleIDSpecified
		{
			get
			{
				return this._oppoRoleID != null;
			}
			set
			{
				bool flag = value == (this._oppoRoleID == null);
				if (flag)
				{
					this._oppoRoleID = (value ? new ulong?(this.oppoRoleID) : null);
				}
			}
		}

		// Token: 0x06003BD2 RID: 15314 RVA: 0x0007252C File Offset: 0x0007072C
		private bool ShouldSerializeoppoRoleID()
		{
			return this.oppoRoleIDSpecified;
		}

		// Token: 0x06003BD3 RID: 15315 RVA: 0x00072544 File Offset: 0x00070744
		private void ResetoppoRoleID()
		{
			this.oppoRoleIDSpecified = false;
		}

		// Token: 0x17001258 RID: 4696
		// (get) Token: 0x06003BD4 RID: 15316 RVA: 0x00072550 File Offset: 0x00070750
		// (set) Token: 0x06003BD5 RID: 15317 RVA: 0x00072571 File Offset: 0x00070771
		[ProtoMember(3, IsRequired = false, Name = "oppoRoleName", DataFormat = DataFormat.Default)]
		public string oppoRoleName
		{
			get
			{
				return this._oppoRoleName ?? "";
			}
			set
			{
				this._oppoRoleName = value;
			}
		}

		// Token: 0x17001259 RID: 4697
		// (get) Token: 0x06003BD6 RID: 15318 RVA: 0x0007257C File Offset: 0x0007077C
		// (set) Token: 0x06003BD7 RID: 15319 RVA: 0x00072598 File Offset: 0x00070798
		[XmlIgnore]
		[Browsable(false)]
		public bool oppoRoleNameSpecified
		{
			get
			{
				return this._oppoRoleName != null;
			}
			set
			{
				bool flag = value == (this._oppoRoleName == null);
				if (flag)
				{
					this._oppoRoleName = (value ? this.oppoRoleName : null);
				}
			}
		}

		// Token: 0x06003BD8 RID: 15320 RVA: 0x000725C8 File Offset: 0x000707C8
		private bool ShouldSerializeoppoRoleName()
		{
			return this.oppoRoleNameSpecified;
		}

		// Token: 0x06003BD9 RID: 15321 RVA: 0x000725E0 File Offset: 0x000707E0
		private void ResetoppoRoleName()
		{
			this.oppoRoleNameSpecified = false;
		}

		// Token: 0x06003BDA RID: 15322 RVA: 0x000725EC File Offset: 0x000707EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EDF RID: 3807
		private ErrorCode? _error;

		// Token: 0x04000EE0 RID: 3808
		private ulong? _oppoRoleID;

		// Token: 0x04000EE1 RID: 3809
		private string _oppoRoleName;

		// Token: 0x04000EE2 RID: 3810
		private IExtension extensionObject;
	}
}
