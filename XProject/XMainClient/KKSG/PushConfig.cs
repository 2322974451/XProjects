using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000659 RID: 1625
	[ProtoContract(Name = "PushConfig")]
	[Serializable]
	public class PushConfig : IExtensible
	{
		// Token: 0x17001FEA RID: 8170
		// (get) Token: 0x06006527 RID: 25895 RVA: 0x000C113C File Offset: 0x000BF33C
		// (set) Token: 0x06006528 RID: 25896 RVA: 0x000C1168 File Offset: 0x000BF368
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17001FEB RID: 8171
		// (get) Token: 0x06006529 RID: 25897 RVA: 0x000C1178 File Offset: 0x000BF378
		// (set) Token: 0x0600652A RID: 25898 RVA: 0x000C1198 File Offset: 0x000BF398
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x0600652B RID: 25899 RVA: 0x000C11DC File Offset: 0x000BF3DC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600652C RID: 25900 RVA: 0x000C11F4 File Offset: 0x000BF3F4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001FEC RID: 8172
		// (get) Token: 0x0600652D RID: 25901 RVA: 0x000C1200 File Offset: 0x000BF400
		// (set) Token: 0x0600652E RID: 25902 RVA: 0x000C122C File Offset: 0x000BF42C
		[ProtoMember(2, IsRequired = false, Name = "forbid", DataFormat = DataFormat.Default)]
		public bool forbid
		{
			get
			{
				return this._forbid ?? false;
			}
			set
			{
				this._forbid = new bool?(value);
			}
		}

		// Token: 0x17001FED RID: 8173
		// (get) Token: 0x0600652F RID: 25903 RVA: 0x000C123C File Offset: 0x000BF43C
		// (set) Token: 0x06006530 RID: 25904 RVA: 0x000C125C File Offset: 0x000BF45C
		[XmlIgnore]
		[Browsable(false)]
		public bool forbidSpecified
		{
			get
			{
				return this._forbid != null;
			}
			set
			{
				bool flag = value == (this._forbid == null);
				if (flag)
				{
					this._forbid = (value ? new bool?(this.forbid) : null);
				}
			}
		}

		// Token: 0x06006531 RID: 25905 RVA: 0x000C12A0 File Offset: 0x000BF4A0
		private bool ShouldSerializeforbid()
		{
			return this.forbidSpecified;
		}

		// Token: 0x06006532 RID: 25906 RVA: 0x000C12B8 File Offset: 0x000BF4B8
		private void Resetforbid()
		{
			this.forbidSpecified = false;
		}

		// Token: 0x06006533 RID: 25907 RVA: 0x000C12C4 File Offset: 0x000BF4C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001887 RID: 6279
		private uint? _type;

		// Token: 0x04001888 RID: 6280
		private bool? _forbid;

		// Token: 0x04001889 RID: 6281
		private IExtension extensionObject;
	}
}
