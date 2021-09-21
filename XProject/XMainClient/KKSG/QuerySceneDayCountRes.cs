using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000032 RID: 50
	[ProtoContract(Name = "QuerySceneDayCountRes")]
	[Serializable]
	public class QuerySceneDayCountRes : IExtensible
	{
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00009294 File Offset: 0x00007494
		[ProtoMember(1, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sceneid
		{
			get
			{
				return this._sceneid;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600035F RID: 863 RVA: 0x000092AC File Offset: 0x000074AC
		[ProtoMember(2, Name = "scenecout", DataFormat = DataFormat.TwosComplement)]
		public List<uint> scenecout
		{
			get
			{
				return this._scenecout;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000360 RID: 864 RVA: 0x000092C4 File Offset: 0x000074C4
		[ProtoMember(3, Name = "scenebuycount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> scenebuycount
		{
			get
			{
				return this._scenebuycount;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000361 RID: 865 RVA: 0x000092DC File Offset: 0x000074DC
		[ProtoMember(4, Name = "chestOpenedScene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chestOpenedScene
		{
			get
			{
				return this._chestOpenedScene;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000362 RID: 866 RVA: 0x000092F4 File Offset: 0x000074F4
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00009320 File Offset: 0x00007520
		[ProtoMember(5, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00009330 File Offset: 0x00007530
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00009350 File Offset: 0x00007550
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00009394 File Offset: 0x00007594
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000093AC File Offset: 0x000075AC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000093B8 File Offset: 0x000075B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000E4 RID: 228
		private readonly List<uint> _sceneid = new List<uint>();

		// Token: 0x040000E5 RID: 229
		private readonly List<uint> _scenecout = new List<uint>();

		// Token: 0x040000E6 RID: 230
		private readonly List<uint> _scenebuycount = new List<uint>();

		// Token: 0x040000E7 RID: 231
		private readonly List<uint> _chestOpenedScene = new List<uint>();

		// Token: 0x040000E8 RID: 232
		private ErrorCode? _errorcode;

		// Token: 0x040000E9 RID: 233
		private IExtension extensionObject;
	}
}
