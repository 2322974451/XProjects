using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CD RID: 973
	[ProtoContract(Name = "LoginActivityStatus")]
	[Serializable]
	public class LoginActivityStatus : IExtensible
	{
		// Token: 0x17000FFD RID: 4093
		// (get) Token: 0x060033EB RID: 13291 RVA: 0x00063A44 File Offset: 0x00061C44
		// (set) Token: 0x060033EC RID: 13292 RVA: 0x00063A70 File Offset: 0x00061C70
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		public bool state
		{
			get
			{
				return this._state ?? false;
			}
			set
			{
				this._state = new bool?(value);
			}
		}

		// Token: 0x17000FFE RID: 4094
		// (get) Token: 0x060033ED RID: 13293 RVA: 0x00063A80 File Offset: 0x00061C80
		// (set) Token: 0x060033EE RID: 13294 RVA: 0x00063AA0 File Offset: 0x00061CA0
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new bool?(this.state) : null);
				}
			}
		}

		// Token: 0x060033EF RID: 13295 RVA: 0x00063AE4 File Offset: 0x00061CE4
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060033F0 RID: 13296 RVA: 0x00063AFC File Offset: 0x00061CFC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060033F1 RID: 13297 RVA: 0x00063B08 File Offset: 0x00061D08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CE5 RID: 3301
		private bool? _state;

		// Token: 0x04000CE6 RID: 3302
		private IExtension extensionObject;
	}
}
