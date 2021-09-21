using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000114 RID: 276
	[ProtoContract(Name = "GetAchieveClassifyInfoReq")]
	[Serializable]
	public class GetAchieveClassifyInfoReq : IExtensible
	{
		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x00023830 File Offset: 0x00021A30
		// (set) Token: 0x06001167 RID: 4455 RVA: 0x0002385C File Offset: 0x00021A5C
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

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x0002386C File Offset: 0x00021A6C
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x0002388C File Offset: 0x00021A8C
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

		// Token: 0x0600116A RID: 4458 RVA: 0x000238D0 File Offset: 0x00021AD0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x000238E8 File Offset: 0x00021AE8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x000238F4 File Offset: 0x00021AF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400045A RID: 1114
		private uint? _type;

		// Token: 0x0400045B RID: 1115
		private IExtension extensionObject;
	}
}
