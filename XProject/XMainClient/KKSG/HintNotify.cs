using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CD RID: 205
	[ProtoContract(Name = "HintNotify")]
	[Serializable]
	public class HintNotify : IExtensible
	{
		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x0001BB88 File Offset: 0x00019D88
		[ProtoMember(1, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> systemid
		{
			get
			{
				return this._systemid;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x0001BBA0 File Offset: 0x00019DA0
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x0001BBCC File Offset: 0x00019DCC
		[ProtoMember(2, IsRequired = false, Name = "isremove", DataFormat = DataFormat.Default)]
		public bool isremove
		{
			get
			{
				return this._isremove ?? false;
			}
			set
			{
				this._isremove = new bool?(value);
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000D44 RID: 3396 RVA: 0x0001BBDC File Offset: 0x00019DDC
		// (set) Token: 0x06000D45 RID: 3397 RVA: 0x0001BBFC File Offset: 0x00019DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool isremoveSpecified
		{
			get
			{
				return this._isremove != null;
			}
			set
			{
				bool flag = value == (this._isremove == null);
				if (flag)
				{
					this._isremove = (value ? new bool?(this.isremove) : null);
				}
			}
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0001BC40 File Offset: 0x00019E40
		private bool ShouldSerializeisremove()
		{
			return this.isremoveSpecified;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0001BC58 File Offset: 0x00019E58
		private void Resetisremove()
		{
			this.isremoveSpecified = false;
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0001BC64 File Offset: 0x00019E64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000354 RID: 852
		private readonly List<uint> _systemid = new List<uint>();

		// Token: 0x04000355 RID: 853
		private bool? _isremove;

		// Token: 0x04000356 RID: 854
		private IExtension extensionObject;
	}
}
