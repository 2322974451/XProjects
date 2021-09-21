using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000176 RID: 374
	[ProtoContract(Name = "InvUnfState")]
	[Serializable]
	public class InvUnfState : IExtensible
	{
		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06001669 RID: 5737 RVA: 0x0002CDE0 File Offset: 0x0002AFE0
		// (set) Token: 0x0600166A RID: 5738 RVA: 0x0002CE0C File Offset: 0x0002B00C
		[ProtoMember(1, IsRequired = false, Name = "inviteID", DataFormat = DataFormat.TwosComplement)]
		public int inviteID
		{
			get
			{
				return this._inviteID ?? 0;
			}
			set
			{
				this._inviteID = new int?(value);
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x0002CE1C File Offset: 0x0002B01C
		// (set) Token: 0x0600166C RID: 5740 RVA: 0x0002CE3C File Offset: 0x0002B03C
		[XmlIgnore]
		[Browsable(false)]
		public bool inviteIDSpecified
		{
			get
			{
				return this._inviteID != null;
			}
			set
			{
				bool flag = value == (this._inviteID == null);
				if (flag)
				{
					this._inviteID = (value ? new int?(this.inviteID) : null);
				}
			}
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0002CE80 File Offset: 0x0002B080
		private bool ShouldSerializeinviteID()
		{
			return this.inviteIDSpecified;
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x0002CE98 File Offset: 0x0002B098
		private void ResetinviteID()
		{
			this.inviteIDSpecified = false;
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x0002CEA4 File Offset: 0x0002B0A4
		// (set) Token: 0x06001670 RID: 5744 RVA: 0x0002CED0 File Offset: 0x0002B0D0
		[ProtoMember(2, IsRequired = false, Name = "isdeleted", DataFormat = DataFormat.Default)]
		public bool isdeleted
		{
			get
			{
				return this._isdeleted ?? false;
			}
			set
			{
				this._isdeleted = new bool?(value);
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x06001671 RID: 5745 RVA: 0x0002CEE0 File Offset: 0x0002B0E0
		// (set) Token: 0x06001672 RID: 5746 RVA: 0x0002CF00 File Offset: 0x0002B100
		[XmlIgnore]
		[Browsable(false)]
		public bool isdeletedSpecified
		{
			get
			{
				return this._isdeleted != null;
			}
			set
			{
				bool flag = value == (this._isdeleted == null);
				if (flag)
				{
					this._isdeleted = (value ? new bool?(this.isdeleted) : null);
				}
			}
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0002CF44 File Offset: 0x0002B144
		private bool ShouldSerializeisdeleted()
		{
			return this.isdeletedSpecified;
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0002CF5C File Offset: 0x0002B15C
		private void Resetisdeleted()
		{
			this.isdeletedSpecified = false;
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x0002CF68 File Offset: 0x0002B168
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000590 RID: 1424
		private int? _inviteID;

		// Token: 0x04000591 RID: 1425
		private bool? _isdeleted;

		// Token: 0x04000592 RID: 1426
		private IExtension extensionObject;
	}
}
