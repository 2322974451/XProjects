using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042D RID: 1069
	[ProtoContract(Name = "DHRArg")]
	[Serializable]
	public class DHRArg : IExtensible
	{
		// Token: 0x17001165 RID: 4453
		// (get) Token: 0x060038A0 RID: 14496 RVA: 0x0006C618 File Offset: 0x0006A818
		// (set) Token: 0x060038A1 RID: 14497 RVA: 0x0006C644 File Offset: 0x0006A844
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public DHRReqOp op
		{
			get
			{
				return this._op ?? DHRReqOp.DHR_OP_LIST;
			}
			set
			{
				this._op = new DHRReqOp?(value);
			}
		}

		// Token: 0x17001166 RID: 4454
		// (get) Token: 0x060038A2 RID: 14498 RVA: 0x0006C654 File Offset: 0x0006A854
		// (set) Token: 0x060038A3 RID: 14499 RVA: 0x0006C674 File Offset: 0x0006A874
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new DHRReqOp?(this.op) : null);
				}
			}
		}

		// Token: 0x060038A4 RID: 14500 RVA: 0x0006C6B8 File Offset: 0x0006A8B8
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x060038A5 RID: 14501 RVA: 0x0006C6D0 File Offset: 0x0006A8D0
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17001167 RID: 4455
		// (get) Token: 0x060038A6 RID: 14502 RVA: 0x0006C6DC File Offset: 0x0006A8DC
		// (set) Token: 0x060038A7 RID: 14503 RVA: 0x0006C708 File Offset: 0x0006A908
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		// Token: 0x17001168 RID: 4456
		// (get) Token: 0x060038A8 RID: 14504 RVA: 0x0006C718 File Offset: 0x0006A918
		// (set) Token: 0x060038A9 RID: 14505 RVA: 0x0006C738 File Offset: 0x0006A938
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		// Token: 0x060038AA RID: 14506 RVA: 0x0006C77C File Offset: 0x0006A97C
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060038AB RID: 14507 RVA: 0x0006C794 File Offset: 0x0006A994
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x060038AC RID: 14508 RVA: 0x0006C7A0 File Offset: 0x0006A9A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E0C RID: 3596
		private DHRReqOp? _op;

		// Token: 0x04000E0D RID: 3597
		private int? _id;

		// Token: 0x04000E0E RID: 3598
		private IExtension extensionObject;
	}
}
