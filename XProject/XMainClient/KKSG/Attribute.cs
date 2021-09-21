using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000561 RID: 1377
	[ProtoContract(Name = "Attribute")]
	[Serializable]
	public class Attribute : IExtensible
	{
		// Token: 0x17001586 RID: 5510
		// (get) Token: 0x0600467E RID: 18046 RVA: 0x00085E90 File Offset: 0x00084090
		[ProtoMember(1, Name = "basicAttribute", DataFormat = DataFormat.TwosComplement)]
		public List<double> basicAttribute
		{
			get
			{
				return this._basicAttribute;
			}
		}

		// Token: 0x17001587 RID: 5511
		// (get) Token: 0x0600467F RID: 18047 RVA: 0x00085EA8 File Offset: 0x000840A8
		[ProtoMember(2, Name = "percentAttribute", DataFormat = DataFormat.TwosComplement)]
		public List<double> percentAttribute
		{
			get
			{
				return this._percentAttribute;
			}
		}

		// Token: 0x17001588 RID: 5512
		// (get) Token: 0x06004680 RID: 18048 RVA: 0x00085EC0 File Offset: 0x000840C0
		[ProtoMember(3, Name = "attrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrID
		{
			get
			{
				return this._attrID;
			}
		}

		// Token: 0x06004681 RID: 18049 RVA: 0x00085ED8 File Offset: 0x000840D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001194 RID: 4500
		private readonly List<double> _basicAttribute = new List<double>();

		// Token: 0x04001195 RID: 4501
		private readonly List<double> _percentAttribute = new List<double>();

		// Token: 0x04001196 RID: 4502
		private readonly List<uint> _attrID = new List<uint>();

		// Token: 0x04001197 RID: 4503
		private IExtension extensionObject;
	}
}
