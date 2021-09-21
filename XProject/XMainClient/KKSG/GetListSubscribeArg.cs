using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038D RID: 909
	[ProtoContract(Name = "GetListSubscribeArg")]
	[Serializable]
	public class GetListSubscribeArg : IExtensible
	{
		// Token: 0x17000F3D RID: 3901
		// (get) Token: 0x06003146 RID: 12614 RVA: 0x0005EF10 File Offset: 0x0005D110
		// (set) Token: 0x06003147 RID: 12615 RVA: 0x0005EF31 File Offset: 0x0005D131
		[ProtoMember(1, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x17000F3E RID: 3902
		// (get) Token: 0x06003148 RID: 12616 RVA: 0x0005EF3C File Offset: 0x0005D13C
		// (set) Token: 0x06003149 RID: 12617 RVA: 0x0005EF58 File Offset: 0x0005D158
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x0005EF88 File Offset: 0x0005D188
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x0600314B RID: 12619 RVA: 0x0005EFA0 File Offset: 0x0005D1A0
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x0600314C RID: 12620 RVA: 0x0005EFAC File Offset: 0x0005D1AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C3C RID: 3132
		private string _token;

		// Token: 0x04000C3D RID: 3133
		private IExtension extensionObject;
	}
}
