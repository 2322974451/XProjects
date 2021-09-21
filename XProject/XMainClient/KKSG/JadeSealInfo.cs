using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000746 RID: 1862
	[ProtoContract(Name = "JadeSealInfo")]
	[Serializable]
	public class JadeSealInfo : IExtensible
	{
		// Token: 0x17002933 RID: 10547
		// (get) Token: 0x060081F1 RID: 33265 RVA: 0x000F8890 File Offset: 0x000F6A90
		// (set) Token: 0x060081F2 RID: 33266 RVA: 0x000F88BC File Offset: 0x000F6ABC
		[ProtoMember(1, IsRequired = false, Name = "equipPos", DataFormat = DataFormat.TwosComplement)]
		public uint equipPos
		{
			get
			{
				return this._equipPos ?? 0U;
			}
			set
			{
				this._equipPos = new uint?(value);
			}
		}

		// Token: 0x17002934 RID: 10548
		// (get) Token: 0x060081F3 RID: 33267 RVA: 0x000F88CC File Offset: 0x000F6ACC
		// (set) Token: 0x060081F4 RID: 33268 RVA: 0x000F88EC File Offset: 0x000F6AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool equipPosSpecified
		{
			get
			{
				return this._equipPos != null;
			}
			set
			{
				bool flag = value == (this._equipPos == null);
				if (flag)
				{
					this._equipPos = (value ? new uint?(this.equipPos) : null);
				}
			}
		}

		// Token: 0x060081F5 RID: 33269 RVA: 0x000F8930 File Offset: 0x000F6B30
		private bool ShouldSerializeequipPos()
		{
			return this.equipPosSpecified;
		}

		// Token: 0x060081F6 RID: 33270 RVA: 0x000F8948 File Offset: 0x000F6B48
		private void ResetequipPos()
		{
			this.equipPosSpecified = false;
		}

		// Token: 0x17002935 RID: 10549
		// (get) Token: 0x060081F7 RID: 33271 RVA: 0x000F8954 File Offset: 0x000F6B54
		// (set) Token: 0x060081F8 RID: 33272 RVA: 0x000F8980 File Offset: 0x000F6B80
		[ProtoMember(2, IsRequired = false, Name = "jadeSealID", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSealID
		{
			get
			{
				return this._jadeSealID ?? 0U;
			}
			set
			{
				this._jadeSealID = new uint?(value);
			}
		}

		// Token: 0x17002936 RID: 10550
		// (get) Token: 0x060081F9 RID: 33273 RVA: 0x000F8990 File Offset: 0x000F6B90
		// (set) Token: 0x060081FA RID: 33274 RVA: 0x000F89B0 File Offset: 0x000F6BB0
		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSealIDSpecified
		{
			get
			{
				return this._jadeSealID != null;
			}
			set
			{
				bool flag = value == (this._jadeSealID == null);
				if (flag)
				{
					this._jadeSealID = (value ? new uint?(this.jadeSealID) : null);
				}
			}
		}

		// Token: 0x060081FB RID: 33275 RVA: 0x000F89F4 File Offset: 0x000F6BF4
		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		// Token: 0x060081FC RID: 33276 RVA: 0x000F8A0C File Offset: 0x000F6C0C
		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		// Token: 0x060081FD RID: 33277 RVA: 0x000F8A18 File Offset: 0x000F6C18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E62 RID: 7778
		private uint? _equipPos;

		// Token: 0x04001E63 RID: 7779
		private uint? _jadeSealID;

		// Token: 0x04001E64 RID: 7780
		private IExtension extensionObject;
	}
}
