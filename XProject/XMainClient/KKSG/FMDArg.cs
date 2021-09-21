using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000160 RID: 352
	[ProtoContract(Name = "FMDArg")]
	[Serializable]
	public class FMDArg : IExtensible
	{
		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001569 RID: 5481 RVA: 0x0002B0B4 File Offset: 0x000292B4
		// (set) Token: 0x0600156A RID: 5482 RVA: 0x0002B0E1 File Offset: 0x000292E1
		[ProtoMember(1, IsRequired = false, Name = "quitRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong quitRoleID
		{
			get
			{
				return this._quitRoleID ?? 0UL;
			}
			set
			{
				this._quitRoleID = new ulong?(value);
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x0600156B RID: 5483 RVA: 0x0002B0F0 File Offset: 0x000292F0
		// (set) Token: 0x0600156C RID: 5484 RVA: 0x0002B110 File Offset: 0x00029310
		[XmlIgnore]
		[Browsable(false)]
		public bool quitRoleIDSpecified
		{
			get
			{
				return this._quitRoleID != null;
			}
			set
			{
				bool flag = value == (this._quitRoleID == null);
				if (flag)
				{
					this._quitRoleID = (value ? new ulong?(this.quitRoleID) : null);
				}
			}
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0002B154 File Offset: 0x00029354
		private bool ShouldSerializequitRoleID()
		{
			return this.quitRoleIDSpecified;
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0002B16C File Offset: 0x0002936C
		private void ResetquitRoleID()
		{
			this.quitRoleIDSpecified = false;
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x0600156F RID: 5487 RVA: 0x0002B178 File Offset: 0x00029378
		// (set) Token: 0x06001570 RID: 5488 RVA: 0x0002B199 File Offset: 0x00029399
		[ProtoMember(2, IsRequired = false, Name = "quitRoleName", DataFormat = DataFormat.Default)]
		public string quitRoleName
		{
			get
			{
				return this._quitRoleName ?? "";
			}
			set
			{
				this._quitRoleName = value;
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001571 RID: 5489 RVA: 0x0002B1A4 File Offset: 0x000293A4
		// (set) Token: 0x06001572 RID: 5490 RVA: 0x0002B1C0 File Offset: 0x000293C0
		[XmlIgnore]
		[Browsable(false)]
		public bool quitRoleNameSpecified
		{
			get
			{
				return this._quitRoleName != null;
			}
			set
			{
				bool flag = value == (this._quitRoleName == null);
				if (flag)
				{
					this._quitRoleName = (value ? this.quitRoleName : null);
				}
			}
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0002B1F0 File Offset: 0x000293F0
		private bool ShouldSerializequitRoleName()
		{
			return this.quitRoleNameSpecified;
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0002B208 File Offset: 0x00029408
		private void ResetquitRoleName()
		{
			this.quitRoleNameSpecified = false;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0002B214 File Offset: 0x00029414
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000551 RID: 1361
		private ulong? _quitRoleID;

		// Token: 0x04000552 RID: 1362
		private string _quitRoleName;

		// Token: 0x04000553 RID: 1363
		private IExtension extensionObject;
	}
}
