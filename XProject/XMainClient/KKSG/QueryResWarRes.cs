using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029D RID: 669
	[ProtoContract(Name = "QueryResWarRes")]
	[Serializable]
	public class QueryResWarRes : IExtensible
	{
		// Token: 0x17000B96 RID: 2966
		// (get) Token: 0x06002548 RID: 9544 RVA: 0x000489D8 File Offset: 0x00046BD8
		// (set) Token: 0x06002549 RID: 9545 RVA: 0x000489F0 File Offset: 0x00046BF0
		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarGuildBrief data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x0600254A RID: 9546 RVA: 0x000489FC File Offset: 0x00046BFC
		// (set) Token: 0x0600254B RID: 9547 RVA: 0x00048A28 File Offset: 0x00046C28
		[ProtoMember(2, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x0600254C RID: 9548 RVA: 0x00048A38 File Offset: 0x00046C38
		// (set) Token: 0x0600254D RID: 9549 RVA: 0x00048A58 File Offset: 0x00046C58
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x0600254E RID: 9550 RVA: 0x00048A9C File Offset: 0x00046C9C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600254F RID: 9551 RVA: 0x00048AB4 File Offset: 0x00046CB4
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x06002550 RID: 9552 RVA: 0x00048AC0 File Offset: 0x00046CC0
		// (set) Token: 0x06002551 RID: 9553 RVA: 0x00048AD8 File Offset: 0x00046CD8
		[ProtoMember(3, IsRequired = false, Name = "finalrank", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarFinalAll finalrank
		{
			get
			{
				return this._finalrank;
			}
			set
			{
				this._finalrank = value;
			}
		}

		// Token: 0x06002552 RID: 9554 RVA: 0x00048AE4 File Offset: 0x00046CE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400093C RID: 2364
		private ResWarGuildBrief _data = null;

		// Token: 0x0400093D RID: 2365
		private ErrorCode? _error;

		// Token: 0x0400093E RID: 2366
		private ResWarFinalAll _finalrank = null;

		// Token: 0x0400093F RID: 2367
		private IExtension extensionObject;
	}
}
