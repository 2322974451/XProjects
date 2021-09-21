using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AC RID: 1708
	[ProtoContract(Name = "LiveIconData")]
	[Serializable]
	public class LiveIconData : IExtensible
	{
		// Token: 0x17002345 RID: 9029
		// (get) Token: 0x06006F6C RID: 28524 RVA: 0x000D5344 File Offset: 0x000D3544
		// (set) Token: 0x06006F6D RID: 28525 RVA: 0x000D5370 File Offset: 0x000D3570
		[ProtoMember(1, IsRequired = false, Name = "liveType", DataFormat = DataFormat.TwosComplement)]
		public int liveType
		{
			get
			{
				return this._liveType ?? 0;
			}
			set
			{
				this._liveType = new int?(value);
			}
		}

		// Token: 0x17002346 RID: 9030
		// (get) Token: 0x06006F6E RID: 28526 RVA: 0x000D5380 File Offset: 0x000D3580
		// (set) Token: 0x06006F6F RID: 28527 RVA: 0x000D53A0 File Offset: 0x000D35A0
		[XmlIgnore]
		[Browsable(false)]
		public bool liveTypeSpecified
		{
			get
			{
				return this._liveType != null;
			}
			set
			{
				bool flag = value == (this._liveType == null);
				if (flag)
				{
					this._liveType = (value ? new int?(this.liveType) : null);
				}
			}
		}

		// Token: 0x06006F70 RID: 28528 RVA: 0x000D53E4 File Offset: 0x000D35E4
		private bool ShouldSerializeliveType()
		{
			return this.liveTypeSpecified;
		}

		// Token: 0x06006F71 RID: 28529 RVA: 0x000D53FC File Offset: 0x000D35FC
		private void ResetliveType()
		{
			this.liveTypeSpecified = false;
		}

		// Token: 0x17002347 RID: 9031
		// (get) Token: 0x06006F72 RID: 28530 RVA: 0x000D5408 File Offset: 0x000D3608
		// (set) Token: 0x06006F73 RID: 28531 RVA: 0x000D5434 File Offset: 0x000D3634
		[ProtoMember(2, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public int liveID
		{
			get
			{
				return this._liveID ?? 0;
			}
			set
			{
				this._liveID = new int?(value);
			}
		}

		// Token: 0x17002348 RID: 9032
		// (get) Token: 0x06006F74 RID: 28532 RVA: 0x000D5444 File Offset: 0x000D3644
		// (set) Token: 0x06006F75 RID: 28533 RVA: 0x000D5464 File Offset: 0x000D3664
		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new int?(this.liveID) : null);
				}
			}
		}

		// Token: 0x06006F76 RID: 28534 RVA: 0x000D54A8 File Offset: 0x000D36A8
		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		// Token: 0x06006F77 RID: 28535 RVA: 0x000D54C0 File Offset: 0x000D36C0
		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		// Token: 0x17002349 RID: 9033
		// (get) Token: 0x06006F78 RID: 28536 RVA: 0x000D54CC File Offset: 0x000D36CC
		// (set) Token: 0x06006F79 RID: 28537 RVA: 0x000D54E4 File Offset: 0x000D36E4
		[ProtoMember(3, IsRequired = false, Name = "liveInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo liveInfo
		{
			get
			{
				return this._liveInfo;
			}
			set
			{
				this._liveInfo = value;
			}
		}

		// Token: 0x06006F7A RID: 28538 RVA: 0x000D54F0 File Offset: 0x000D36F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AA8 RID: 6824
		private int? _liveType;

		// Token: 0x04001AA9 RID: 6825
		private int? _liveID;

		// Token: 0x04001AAA RID: 6826
		private OneLiveRecordInfo _liveInfo = null;

		// Token: 0x04001AAB RID: 6827
		private IExtension extensionObject;
	}
}
