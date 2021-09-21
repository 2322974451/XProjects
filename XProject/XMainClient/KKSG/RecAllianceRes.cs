using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034F RID: 847
	[ProtoContract(Name = "RecAllianceRes")]
	[Serializable]
	public class RecAllianceRes : IExtensible
	{
		// Token: 0x17000E5C RID: 3676
		// (get) Token: 0x06002E4A RID: 11850 RVA: 0x00059794 File Offset: 0x00057994
		// (set) Token: 0x06002E4B RID: 11851 RVA: 0x000597C0 File Offset: 0x000579C0
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000E5D RID: 3677
		// (get) Token: 0x06002E4C RID: 11852 RVA: 0x000597D0 File Offset: 0x000579D0
		// (set) Token: 0x06002E4D RID: 11853 RVA: 0x000597F0 File Offset: 0x000579F0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06002E4E RID: 11854 RVA: 0x00059834 File Offset: 0x00057A34
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002E4F RID: 11855 RVA: 0x0005984C File Offset: 0x00057A4C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000E5E RID: 3678
		// (get) Token: 0x06002E50 RID: 11856 RVA: 0x00059858 File Offset: 0x00057A58
		// (set) Token: 0x06002E51 RID: 11857 RVA: 0x00059885 File Offset: 0x00057A85
		[ProtoMember(2, IsRequired = false, Name = "allianceId", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceId
		{
			get
			{
				return this._allianceId ?? 0UL;
			}
			set
			{
				this._allianceId = new ulong?(value);
			}
		}

		// Token: 0x17000E5F RID: 3679
		// (get) Token: 0x06002E52 RID: 11858 RVA: 0x00059894 File Offset: 0x00057A94
		// (set) Token: 0x06002E53 RID: 11859 RVA: 0x000598B4 File Offset: 0x00057AB4
		[XmlIgnore]
		[Browsable(false)]
		public bool allianceIdSpecified
		{
			get
			{
				return this._allianceId != null;
			}
			set
			{
				bool flag = value == (this._allianceId == null);
				if (flag)
				{
					this._allianceId = (value ? new ulong?(this.allianceId) : null);
				}
			}
		}

		// Token: 0x06002E54 RID: 11860 RVA: 0x000598F8 File Offset: 0x00057AF8
		private bool ShouldSerializeallianceId()
		{
			return this.allianceIdSpecified;
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x00059910 File Offset: 0x00057B10
		private void ResetallianceId()
		{
			this.allianceIdSpecified = false;
		}

		// Token: 0x06002E56 RID: 11862 RVA: 0x0005991C File Offset: 0x00057B1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B82 RID: 2946
		private ErrorCode? _errorcode;

		// Token: 0x04000B83 RID: 2947
		private ulong? _allianceId;

		// Token: 0x04000B84 RID: 2948
		private IExtension extensionObject;
	}
}
