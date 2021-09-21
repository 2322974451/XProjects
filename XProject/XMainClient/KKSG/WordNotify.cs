using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000511 RID: 1297
	[ProtoContract(Name = "WordNotify")]
	[Serializable]
	public class WordNotify : IExtensible
	{
		// Token: 0x1700146B RID: 5227
		// (get) Token: 0x060042C3 RID: 17091 RVA: 0x0007F0E8 File Offset: 0x0007D2E8
		// (set) Token: 0x060042C4 RID: 17092 RVA: 0x0007F109 File Offset: 0x0007D309
		[ProtoMember(1, IsRequired = false, Name = "hint", DataFormat = DataFormat.Default)]
		public string hint
		{
			get
			{
				return this._hint ?? "";
			}
			set
			{
				this._hint = value;
			}
		}

		// Token: 0x1700146C RID: 5228
		// (get) Token: 0x060042C5 RID: 17093 RVA: 0x0007F114 File Offset: 0x0007D314
		// (set) Token: 0x060042C6 RID: 17094 RVA: 0x0007F130 File Offset: 0x0007D330
		[XmlIgnore]
		[Browsable(false)]
		public bool hintSpecified
		{
			get
			{
				return this._hint != null;
			}
			set
			{
				bool flag = value == (this._hint == null);
				if (flag)
				{
					this._hint = (value ? this.hint : null);
				}
			}
		}

		// Token: 0x060042C7 RID: 17095 RVA: 0x0007F160 File Offset: 0x0007D360
		private bool ShouldSerializehint()
		{
			return this.hintSpecified;
		}

		// Token: 0x060042C8 RID: 17096 RVA: 0x0007F178 File Offset: 0x0007D378
		private void Resethint()
		{
			this.hintSpecified = false;
		}

		// Token: 0x060042C9 RID: 17097 RVA: 0x0007F184 File Offset: 0x0007D384
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010A7 RID: 4263
		private string _hint;

		// Token: 0x040010A8 RID: 4264
		private IExtension extensionObject;
	}
}
