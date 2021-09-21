using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042F RID: 1071
	[ProtoContract(Name = "GetMobaBattleGameRecordArg")]
	[Serializable]
	public class GetMobaBattleGameRecordArg : IExtensible
	{
		// Token: 0x17001170 RID: 4464
		// (get) Token: 0x060038C3 RID: 14531 RVA: 0x0006CA58 File Offset: 0x0006AC58
		// (set) Token: 0x060038C4 RID: 14532 RVA: 0x0006CA84 File Offset: 0x0006AC84
		[ProtoMember(1, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		// Token: 0x17001171 RID: 4465
		// (get) Token: 0x060038C5 RID: 14533 RVA: 0x0006CA94 File Offset: 0x0006AC94
		// (set) Token: 0x060038C6 RID: 14534 RVA: 0x0006CAB4 File Offset: 0x0006ACB4
		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x0006CAF8 File Offset: 0x0006ACF8
		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x0006CB10 File Offset: 0x0006AD10
		private void Resettag()
		{
			this.tagSpecified = false;
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x0006CB1C File Offset: 0x0006AD1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E14 RID: 3604
		private uint? _tag;

		// Token: 0x04000E15 RID: 3605
		private IExtension extensionObject;
	}
}
