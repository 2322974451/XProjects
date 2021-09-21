using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BF RID: 447
	[ProtoContract(Name = "QuitRoom")]
	[Serializable]
	public class QuitRoom : IExtensible
	{
		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06001A0E RID: 6670 RVA: 0x000339DC File Offset: 0x00031BDC
		// (set) Token: 0x06001A0F RID: 6671 RVA: 0x00033A09 File Offset: 0x00031C09
		[ProtoMember(1, IsRequired = false, Name = "roomID", DataFormat = DataFormat.TwosComplement)]
		public long roomID
		{
			get
			{
				return this._roomID ?? 0L;
			}
			set
			{
				this._roomID = new long?(value);
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06001A10 RID: 6672 RVA: 0x00033A18 File Offset: 0x00031C18
		// (set) Token: 0x06001A11 RID: 6673 RVA: 0x00033A38 File Offset: 0x00031C38
		[XmlIgnore]
		[Browsable(false)]
		public bool roomIDSpecified
		{
			get
			{
				return this._roomID != null;
			}
			set
			{
				bool flag = value == (this._roomID == null);
				if (flag)
				{
					this._roomID = (value ? new long?(this.roomID) : null);
				}
			}
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x00033A7C File Offset: 0x00031C7C
		private bool ShouldSerializeroomID()
		{
			return this.roomIDSpecified;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x00033A94 File Offset: 0x00031C94
		private void ResetroomID()
		{
			this.roomIDSpecified = false;
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06001A14 RID: 6676 RVA: 0x00033AA0 File Offset: 0x00031CA0
		// (set) Token: 0x06001A15 RID: 6677 RVA: 0x00033ACC File Offset: 0x00031CCC
		[ProtoMember(2, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public int memberID
		{
			get
			{
				return this._memberID ?? 0;
			}
			set
			{
				this._memberID = new int?(value);
			}
		}

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06001A16 RID: 6678 RVA: 0x00033ADC File Offset: 0x00031CDC
		// (set) Token: 0x06001A17 RID: 6679 RVA: 0x00033AFC File Offset: 0x00031CFC
		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new int?(this.memberID) : null);
				}
			}
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x00033B40 File Offset: 0x00031D40
		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x00033B58 File Offset: 0x00031D58
		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x00033B64 File Offset: 0x00031D64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400067A RID: 1658
		private long? _roomID;

		// Token: 0x0400067B RID: 1659
		private int? _memberID;

		// Token: 0x0400067C RID: 1660
		private IExtension extensionObject;
	}
}
