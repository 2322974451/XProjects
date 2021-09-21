using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A8 RID: 1448
	[ProtoContract(Name = "ChatParamLink")]
	[Serializable]
	public class ChatParamLink : IExtensible
	{
		// Token: 0x17001833 RID: 6195
		// (get) Token: 0x06004E70 RID: 20080 RVA: 0x00095320 File Offset: 0x00093520
		// (set) Token: 0x06004E71 RID: 20081 RVA: 0x0009534C File Offset: 0x0009354C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001834 RID: 6196
		// (get) Token: 0x06004E72 RID: 20082 RVA: 0x0009535C File Offset: 0x0009355C
		// (set) Token: 0x06004E73 RID: 20083 RVA: 0x0009537C File Offset: 0x0009357C
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
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06004E74 RID: 20084 RVA: 0x000953C0 File Offset: 0x000935C0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06004E75 RID: 20085 RVA: 0x000953D8 File Offset: 0x000935D8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001835 RID: 6197
		// (get) Token: 0x06004E76 RID: 20086 RVA: 0x000953E4 File Offset: 0x000935E4
		// (set) Token: 0x06004E77 RID: 20087 RVA: 0x00095405 File Offset: 0x00093605
		[ProtoMember(2, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
		public string content
		{
			get
			{
				return this._content ?? "";
			}
			set
			{
				this._content = value;
			}
		}

		// Token: 0x17001836 RID: 6198
		// (get) Token: 0x06004E78 RID: 20088 RVA: 0x00095410 File Offset: 0x00093610
		// (set) Token: 0x06004E79 RID: 20089 RVA: 0x0009542C File Offset: 0x0009362C
		[XmlIgnore]
		[Browsable(false)]
		public bool contentSpecified
		{
			get
			{
				return this._content != null;
			}
			set
			{
				bool flag = value == (this._content == null);
				if (flag)
				{
					this._content = (value ? this.content : null);
				}
			}
		}

		// Token: 0x06004E7A RID: 20090 RVA: 0x0009545C File Offset: 0x0009365C
		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		// Token: 0x06004E7B RID: 20091 RVA: 0x00095474 File Offset: 0x00093674
		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		// Token: 0x17001837 RID: 6199
		// (get) Token: 0x06004E7C RID: 20092 RVA: 0x00095480 File Offset: 0x00093680
		[ProtoMember(3, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> param
		{
			get
			{
				return this._param;
			}
		}

		// Token: 0x06004E7D RID: 20093 RVA: 0x00095498 File Offset: 0x00093698
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001366 RID: 4966
		private uint? _id;

		// Token: 0x04001367 RID: 4967
		private string _content;

		// Token: 0x04001368 RID: 4968
		private readonly List<ulong> _param = new List<ulong>();

		// Token: 0x04001369 RID: 4969
		private IExtension extensionObject;
	}
}
