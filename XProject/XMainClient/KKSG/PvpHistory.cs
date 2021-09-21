using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000685 RID: 1669
	[ProtoContract(Name = "PvpHistory")]
	[Serializable]
	public class PvpHistory : IExtensible
	{
		// Token: 0x17002207 RID: 8711
		// (get) Token: 0x06006B80 RID: 27520 RVA: 0x000CDAA4 File Offset: 0x000CBCA4
		[ProtoMember(1, Name = "recs", DataFormat = DataFormat.Default)]
		public List<PvpOneRec> recs
		{
			get
			{
				return this._recs;
			}
		}

		// Token: 0x06006B81 RID: 27521 RVA: 0x000CDABC File Offset: 0x000CBCBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019D9 RID: 6617
		private readonly List<PvpOneRec> _recs = new List<PvpOneRec>();

		// Token: 0x040019DA RID: 6618
		private IExtension extensionObject;
	}
}
