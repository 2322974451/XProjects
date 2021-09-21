using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000359 RID: 857
	[ProtoContract(Name = "NoticeGuildTerrWar")]
	[Serializable]
	public class NoticeGuildTerrWar : IExtensible
	{
		// Token: 0x17000E93 RID: 3731
		// (get) Token: 0x06002F02 RID: 12034 RVA: 0x0005AC9C File Offset: 0x00058E9C
		// (set) Token: 0x06002F03 RID: 12035 RVA: 0x0005ACC8 File Offset: 0x00058EC8
		[ProtoMember(1, IsRequired = false, Name = "isbegin", DataFormat = DataFormat.Default)]
		public bool isbegin
		{
			get
			{
				return this._isbegin ?? false;
			}
			set
			{
				this._isbegin = new bool?(value);
			}
		}

		// Token: 0x17000E94 RID: 3732
		// (get) Token: 0x06002F04 RID: 12036 RVA: 0x0005ACD8 File Offset: 0x00058ED8
		// (set) Token: 0x06002F05 RID: 12037 RVA: 0x0005ACF8 File Offset: 0x00058EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool isbeginSpecified
		{
			get
			{
				return this._isbegin != null;
			}
			set
			{
				bool flag = value == (this._isbegin == null);
				if (flag)
				{
					this._isbegin = (value ? new bool?(this.isbegin) : null);
				}
			}
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x0005AD3C File Offset: 0x00058F3C
		private bool ShouldSerializeisbegin()
		{
			return this.isbeginSpecified;
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x0005AD54 File Offset: 0x00058F54
		private void Resetisbegin()
		{
			this.isbeginSpecified = false;
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x0005AD60 File Offset: 0x00058F60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BA8 RID: 2984
		private bool? _isbegin;

		// Token: 0x04000BA9 RID: 2985
		private IExtension extensionObject;
	}
}
