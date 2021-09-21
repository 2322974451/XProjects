using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049D RID: 1181
	[ProtoContract(Name = "ThemeActivityHintArg")]
	[Serializable]
	public class ThemeActivityHintArg : IExtensible
	{
		// Token: 0x170012D8 RID: 4824
		// (get) Token: 0x06003D7D RID: 15741 RVA: 0x000755D0 File Offset: 0x000737D0
		// (set) Token: 0x06003D7E RID: 15742 RVA: 0x000755FC File Offset: 0x000737FC
		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x170012D9 RID: 4825
		// (get) Token: 0x06003D7F RID: 15743 RVA: 0x0007560C File Offset: 0x0007380C
		// (set) Token: 0x06003D80 RID: 15744 RVA: 0x0007562C File Offset: 0x0007382C
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x06003D81 RID: 15745 RVA: 0x00075670 File Offset: 0x00073870
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x06003D82 RID: 15746 RVA: 0x00075688 File Offset: 0x00073888
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x06003D83 RID: 15747 RVA: 0x00075694 File Offset: 0x00073894
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F50 RID: 3920
		private uint? _actid;

		// Token: 0x04000F51 RID: 3921
		private IExtension extensionObject;
	}
}
