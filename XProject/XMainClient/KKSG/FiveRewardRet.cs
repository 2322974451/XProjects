using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012A RID: 298
	[ProtoContract(Name = "FiveRewardRet")]
	[Serializable]
	public class FiveRewardRet : IExtensible
	{
		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001279 RID: 4729 RVA: 0x00025818 File Offset: 0x00023A18
		// (set) Token: 0x0600127A RID: 4730 RVA: 0x00025844 File Offset: 0x00023A44
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x0600127B RID: 4731 RVA: 0x00025854 File Offset: 0x00023A54
		// (set) Token: 0x0600127C RID: 4732 RVA: 0x00025874 File Offset: 0x00023A74
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x000258B8 File Offset: 0x00023AB8
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x000258D0 File Offset: 0x00023AD0
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x000258DC File Offset: 0x00023ADC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400049D RID: 1181
		private ErrorCode? _ret;

		// Token: 0x0400049E RID: 1182
		private IExtension extensionObject;
	}
}
