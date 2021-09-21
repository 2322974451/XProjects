using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FB RID: 763
	[ProtoContract(Name = "QueryQQFriendsVipInfoArg")]
	[Serializable]
	public class QueryQQFriendsVipInfoArg : IExtensible
	{
		// Token: 0x17000CF9 RID: 3321
		// (get) Token: 0x060029D7 RID: 10711 RVA: 0x000512A4 File Offset: 0x0004F4A4
		// (set) Token: 0x060029D8 RID: 10712 RVA: 0x000512C5 File Offset: 0x0004F4C5
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

		// Token: 0x17000CFA RID: 3322
		// (get) Token: 0x060029D9 RID: 10713 RVA: 0x000512D0 File Offset: 0x0004F4D0
		// (set) Token: 0x060029DA RID: 10714 RVA: 0x000512EC File Offset: 0x0004F4EC
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

		// Token: 0x060029DB RID: 10715 RVA: 0x0005131C File Offset: 0x0004F51C
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x00051334 File Offset: 0x0004F534
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x17000CFB RID: 3323
		// (get) Token: 0x060029DD RID: 10717 RVA: 0x00051340 File Offset: 0x0004F540
		[ProtoMember(2, Name = "friendopenids", DataFormat = DataFormat.Default)]
		public List<string> friendopenids
		{
			get
			{
				return this._friendopenids;
			}
		}

		// Token: 0x060029DE RID: 10718 RVA: 0x00051358 File Offset: 0x0004F558
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A63 RID: 2659
		private string _token;

		// Token: 0x04000A64 RID: 2660
		private readonly List<string> _friendopenids = new List<string>();

		// Token: 0x04000A65 RID: 2661
		private IExtension extensionObject;
	}
}
