using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001F RID: 31
	[ProtoContract(Name = "FetchAchiveRes")]
	[Serializable]
	public class FetchAchiveRes : IExtensible
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600025F RID: 607 RVA: 0x000073EC File Offset: 0x000055EC
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00007418 File Offset: 0x00005618
		[ProtoMember(1, IsRequired = false, Name = "Result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode Result
		{
			get
			{
				return this._Result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._Result = new ErrorCode?(value);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00007428 File Offset: 0x00005628
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00007448 File Offset: 0x00005648
		[XmlIgnore]
		[Browsable(false)]
		public bool ResultSpecified
		{
			get
			{
				return this._Result != null;
			}
			set
			{
				bool flag = value == (this._Result == null);
				if (flag)
				{
					this._Result = (value ? new ErrorCode?(this.Result) : null);
				}
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000748C File Offset: 0x0000568C
		private bool ShouldSerializeResult()
		{
			return this.ResultSpecified;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000074A4 File Offset: 0x000056A4
		private void ResetResult()
		{
			this.ResultSpecified = false;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000074B0 File Offset: 0x000056B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000A2 RID: 162
		private ErrorCode? _Result;

		// Token: 0x040000A3 RID: 163
		private IExtension extensionObject;
	}
}
