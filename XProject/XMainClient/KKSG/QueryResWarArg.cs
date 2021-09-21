using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029C RID: 668
	[ProtoContract(Name = "QueryResWarArg")]
	[Serializable]
	public class QueryResWarArg : IExtensible
	{
		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x06002540 RID: 9536 RVA: 0x000488DC File Offset: 0x00046ADC
		// (set) Token: 0x06002541 RID: 9537 RVA: 0x00048908 File Offset: 0x00046B08
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public QueryResWarEnum param
		{
			get
			{
				return this._param ?? QueryResWarEnum.RESWAR_FLOWAWARD;
			}
			set
			{
				this._param = new QueryResWarEnum?(value);
			}
		}

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x06002542 RID: 9538 RVA: 0x00048918 File Offset: 0x00046B18
		// (set) Token: 0x06002543 RID: 9539 RVA: 0x00048938 File Offset: 0x00046B38
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
					this._param = (value ? new QueryResWarEnum?(this.param) : null);
				}
			}
		}

		// Token: 0x06002544 RID: 9540 RVA: 0x0004897C File Offset: 0x00046B7C
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06002545 RID: 9541 RVA: 0x00048994 File Offset: 0x00046B94
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x000489A0 File Offset: 0x00046BA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400093A RID: 2362
		private QueryResWarEnum? _param;

		// Token: 0x0400093B RID: 2363
		private IExtension extensionObject;
	}
}
