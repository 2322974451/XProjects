using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F5 RID: 245
	[ProtoContract(Name = "AllyMatchRoleID")]
	[Serializable]
	public class AllyMatchRoleID : IExtensible
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000FB0 RID: 4016 RVA: 0x0002049C File Offset: 0x0001E69C
		// (set) Token: 0x06000FB1 RID: 4017 RVA: 0x000204C9 File Offset: 0x0001E6C9
		[ProtoMember(1, IsRequired = false, Name = "allyID", DataFormat = DataFormat.TwosComplement)]
		public ulong allyID
		{
			get
			{
				return this._allyID ?? 0UL;
			}
			set
			{
				this._allyID = new ulong?(value);
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x000204D8 File Offset: 0x0001E6D8
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x000204F8 File Offset: 0x0001E6F8
		[XmlIgnore]
		[Browsable(false)]
		public bool allyIDSpecified
		{
			get
			{
				return this._allyID != null;
			}
			set
			{
				bool flag = value == (this._allyID == null);
				if (flag)
				{
					this._allyID = (value ? new ulong?(this.allyID) : null);
				}
			}
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0002053C File Offset: 0x0001E73C
		private bool ShouldSerializeallyID()
		{
			return this.allyIDSpecified;
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00020554 File Offset: 0x0001E754
		private void ResetallyID()
		{
			this.allyIDSpecified = false;
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x00020560 File Offset: 0x0001E760
		// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x0002058D File Offset: 0x0001E78D
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x0002059C File Offset: 0x0001E79C
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x000205BC File Offset: 0x0001E7BC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00020600 File Offset: 0x0001E800
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x00020618 File Offset: 0x0001E818
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x00020624 File Offset: 0x0001E824
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003EB RID: 1003
		private ulong? _allyID;

		// Token: 0x040003EC RID: 1004
		private ulong? _roleID;

		// Token: 0x040003ED RID: 1005
		private IExtension extensionObject;
	}
}
