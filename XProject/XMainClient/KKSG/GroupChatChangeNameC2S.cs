using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000489 RID: 1161
	[ProtoContract(Name = "GroupChatChangeNameC2S")]
	[Serializable]
	public class GroupChatChangeNameC2S : IExtensible
	{
		// Token: 0x1700129C RID: 4764
		// (get) Token: 0x06003CAD RID: 15533 RVA: 0x00073DF4 File Offset: 0x00071FF4
		// (set) Token: 0x06003CAE RID: 15534 RVA: 0x00073E21 File Offset: 0x00072021
		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		// Token: 0x1700129D RID: 4765
		// (get) Token: 0x06003CAF RID: 15535 RVA: 0x00073E30 File Offset: 0x00072030
		// (set) Token: 0x06003CB0 RID: 15536 RVA: 0x00073E50 File Offset: 0x00072050
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		// Token: 0x06003CB1 RID: 15537 RVA: 0x00073E94 File Offset: 0x00072094
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003CB2 RID: 15538 RVA: 0x00073EAC File Offset: 0x000720AC
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x1700129E RID: 4766
		// (get) Token: 0x06003CB3 RID: 15539 RVA: 0x00073EB8 File Offset: 0x000720B8
		// (set) Token: 0x06003CB4 RID: 15540 RVA: 0x00073ED9 File Offset: 0x000720D9
		[ProtoMember(2, IsRequired = false, Name = "newname", DataFormat = DataFormat.Default)]
		public string newname
		{
			get
			{
				return this._newname ?? "";
			}
			set
			{
				this._newname = value;
			}
		}

		// Token: 0x1700129F RID: 4767
		// (get) Token: 0x06003CB5 RID: 15541 RVA: 0x00073EE4 File Offset: 0x000720E4
		// (set) Token: 0x06003CB6 RID: 15542 RVA: 0x00073F00 File Offset: 0x00072100
		[XmlIgnore]
		[Browsable(false)]
		public bool newnameSpecified
		{
			get
			{
				return this._newname != null;
			}
			set
			{
				bool flag = value == (this._newname == null);
				if (flag)
				{
					this._newname = (value ? this.newname : null);
				}
			}
		}

		// Token: 0x06003CB7 RID: 15543 RVA: 0x00073F30 File Offset: 0x00072130
		private bool ShouldSerializenewname()
		{
			return this.newnameSpecified;
		}

		// Token: 0x06003CB8 RID: 15544 RVA: 0x00073F48 File Offset: 0x00072148
		private void Resetnewname()
		{
			this.newnameSpecified = false;
		}

		// Token: 0x06003CB9 RID: 15545 RVA: 0x00073F54 File Offset: 0x00072154
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F1B RID: 3867
		private ulong? _groupchatID;

		// Token: 0x04000F1C RID: 3868
		private string _newname;

		// Token: 0x04000F1D RID: 3869
		private IExtension extensionObject;
	}
}
