using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043A RID: 1082
	[ProtoContract(Name = "EnterBMReadySceneArg")]
	[Serializable]
	public class EnterBMReadySceneArg : IExtensible
	{
		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x06003921 RID: 14625 RVA: 0x0006D4EC File Offset: 0x0006B6EC
		// (set) Token: 0x06003922 RID: 14626 RVA: 0x0006D518 File Offset: 0x0006B718
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public int param
		{
			get
			{
				return this._param ?? 0;
			}
			set
			{
				this._param = new int?(value);
			}
		}

		// Token: 0x1700118B RID: 4491
		// (get) Token: 0x06003923 RID: 14627 RVA: 0x0006D528 File Offset: 0x0006B728
		// (set) Token: 0x06003924 RID: 14628 RVA: 0x0006D548 File Offset: 0x0006B748
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new int?(this.param) : null);
				}
			}
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x0006D58C File Offset: 0x0006B78C
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x0006D5A4 File Offset: 0x0006B7A4
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06003927 RID: 14631 RVA: 0x0006D5B0 File Offset: 0x0006B7B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E2E RID: 3630
		private int? _param;

		// Token: 0x04000E2F RID: 3631
		private IExtension extensionObject;
	}
}
