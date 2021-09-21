using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040D RID: 1037
	[ProtoContract(Name = "TeamRequestPlatFreind2ClientData")]
	[Serializable]
	public class TeamRequestPlatFreind2ClientData : IExtensible
	{
		// Token: 0x170010F8 RID: 4344
		// (get) Token: 0x06003731 RID: 14129 RVA: 0x00069B7C File Offset: 0x00067D7C
		// (set) Token: 0x06003732 RID: 14130 RVA: 0x00069BA8 File Offset: 0x00067DA8
		[ProtoMember(1, IsRequired = false, Name = "userOffline", DataFormat = DataFormat.Default)]
		public bool userOffline
		{
			get
			{
				return this._userOffline ?? false;
			}
			set
			{
				this._userOffline = new bool?(value);
			}
		}

		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x06003733 RID: 14131 RVA: 0x00069BB8 File Offset: 0x00067DB8
		// (set) Token: 0x06003734 RID: 14132 RVA: 0x00069BD8 File Offset: 0x00067DD8
		[XmlIgnore]
		[Browsable(false)]
		public bool userOfflineSpecified
		{
			get
			{
				return this._userOffline != null;
			}
			set
			{
				bool flag = value == (this._userOffline == null);
				if (flag)
				{
					this._userOffline = (value ? new bool?(this.userOffline) : null);
				}
			}
		}

		// Token: 0x06003735 RID: 14133 RVA: 0x00069C1C File Offset: 0x00067E1C
		private bool ShouldSerializeuserOffline()
		{
			return this.userOfflineSpecified;
		}

		// Token: 0x06003736 RID: 14134 RVA: 0x00069C34 File Offset: 0x00067E34
		private void ResetuserOffline()
		{
			this.userOfflineSpecified = false;
		}

		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x06003737 RID: 14135 RVA: 0x00069C40 File Offset: 0x00067E40
		// (set) Token: 0x06003738 RID: 14136 RVA: 0x00069C61 File Offset: 0x00067E61
		[ProtoMember(2, IsRequired = false, Name = "openID", DataFormat = DataFormat.Default)]
		public string openID
		{
			get
			{
				return this._openID ?? "";
			}
			set
			{
				this._openID = value;
			}
		}

		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x06003739 RID: 14137 RVA: 0x00069C6C File Offset: 0x00067E6C
		// (set) Token: 0x0600373A RID: 14138 RVA: 0x00069C88 File Offset: 0x00067E88
		[XmlIgnore]
		[Browsable(false)]
		public bool openIDSpecified
		{
			get
			{
				return this._openID != null;
			}
			set
			{
				bool flag = value == (this._openID == null);
				if (flag)
				{
					this._openID = (value ? this.openID : null);
				}
			}
		}

		// Token: 0x0600373B RID: 14139 RVA: 0x00069CB8 File Offset: 0x00067EB8
		private bool ShouldSerializeopenID()
		{
			return this.openIDSpecified;
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x00069CD0 File Offset: 0x00067ED0
		private void ResetopenID()
		{
			this.openIDSpecified = false;
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x00069CDC File Offset: 0x00067EDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DAF RID: 3503
		private bool? _userOffline;

		// Token: 0x04000DB0 RID: 3504
		private string _openID;

		// Token: 0x04000DB1 RID: 3505
		private IExtension extensionObject;
	}
}
