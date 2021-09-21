using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010F RID: 271
	[ProtoContract(Name = "GetClassifyDesignationReq")]
	[Serializable]
	public class GetClassifyDesignationReq : IExtensible
	{
		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x00023140 File Offset: 0x00021340
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x0002316C File Offset: 0x0002136C
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

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x0002317C File Offset: 0x0002137C
		// (set) Token: 0x0600112D RID: 4397 RVA: 0x0002319C File Offset: 0x0002139C
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

		// Token: 0x0600112E RID: 4398 RVA: 0x000231E0 File Offset: 0x000213E0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x000231F8 File Offset: 0x000213F8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x00023204 File Offset: 0x00021404
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400044B RID: 1099
		private uint? _type;

		// Token: 0x0400044C RID: 1100
		private IExtension extensionObject;
	}
}
