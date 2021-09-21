using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E6 RID: 486
	[ProtoContract(Name = "titleChangeData")]
	[Serializable]
	public class titleChangeData : IExtensible
	{
		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x00037240 File Offset: 0x00035440
		// (set) Token: 0x06001BF1 RID: 7153 RVA: 0x0003726C File Offset: 0x0003546C
		[ProtoMember(1, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x0003727C File Offset: 0x0003547C
		// (set) Token: 0x06001BF3 RID: 7155 RVA: 0x0003729C File Offset: 0x0003549C
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x000372E0 File Offset: 0x000354E0
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x000372F8 File Offset: 0x000354F8
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x00037304 File Offset: 0x00035504
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006F4 RID: 1780
		private uint? _titleID;

		// Token: 0x040006F5 RID: 1781
		private IExtension extensionObject;
	}
}
