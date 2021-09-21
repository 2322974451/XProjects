using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000500 RID: 1280
	[ProtoContract(Name = "DailyTaskEventNtf")]
	[Serializable]
	public class DailyTaskEventNtf : IExtensible
	{
		// Token: 0x1700143F RID: 5183
		// (get) Token: 0x06004224 RID: 16932 RVA: 0x0007DEC0 File Offset: 0x0007C0C0
		// (set) Token: 0x06004225 RID: 16933 RVA: 0x0007DEEC File Offset: 0x0007C0EC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public DailyTaskIconType type
		{
			get
			{
				return this._type ?? DailyTaskIconType.DailyTaskIcon_AskHelp;
			}
			set
			{
				this._type = new DailyTaskIconType?(value);
			}
		}

		// Token: 0x17001440 RID: 5184
		// (get) Token: 0x06004226 RID: 16934 RVA: 0x0007DEFC File Offset: 0x0007C0FC
		// (set) Token: 0x06004227 RID: 16935 RVA: 0x0007DF1C File Offset: 0x0007C11C
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
					this._type = (value ? new DailyTaskIconType?(this.type) : null);
				}
			}
		}

		// Token: 0x06004228 RID: 16936 RVA: 0x0007DF60 File Offset: 0x0007C160
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004229 RID: 16937 RVA: 0x0007DF78 File Offset: 0x0007C178
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600422A RID: 16938 RVA: 0x0007DF84 File Offset: 0x0007C184
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400107E RID: 4222
		private DailyTaskIconType? _type;

		// Token: 0x0400107F RID: 4223
		private IExtension extensionObject;
	}
}
