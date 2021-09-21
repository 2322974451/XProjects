using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C3 RID: 963
	[ProtoContract(Name = "GetBackFlowSpActTimeRes")]
	[Serializable]
	public class GetBackFlowSpActTimeRes : IExtensible
	{
		// Token: 0x17000FD6 RID: 4054
		// (get) Token: 0x06003364 RID: 13156 RVA: 0x00062B14 File Offset: 0x00060D14
		// (set) Token: 0x06003365 RID: 13157 RVA: 0x00062B40 File Offset: 0x00060D40
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000FD7 RID: 4055
		// (get) Token: 0x06003366 RID: 13158 RVA: 0x00062B50 File Offset: 0x00060D50
		// (set) Token: 0x06003367 RID: 13159 RVA: 0x00062B70 File Offset: 0x00060D70
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

		// Token: 0x06003368 RID: 13160 RVA: 0x00062BB4 File Offset: 0x00060DB4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003369 RID: 13161 RVA: 0x00062BCC File Offset: 0x00060DCC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000FD8 RID: 4056
		// (get) Token: 0x0600336A RID: 13162 RVA: 0x00062BD8 File Offset: 0x00060DD8
		// (set) Token: 0x0600336B RID: 13163 RVA: 0x00062BF9 File Offset: 0x00060DF9
		[ProtoMember(2, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.Default)]
		public string lefttime
		{
			get
			{
				return this._lefttime ?? "";
			}
			set
			{
				this._lefttime = value;
			}
		}

		// Token: 0x17000FD9 RID: 4057
		// (get) Token: 0x0600336C RID: 13164 RVA: 0x00062C04 File Offset: 0x00060E04
		// (set) Token: 0x0600336D RID: 13165 RVA: 0x00062C20 File Offset: 0x00060E20
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? this.lefttime : null);
				}
			}
		}

		// Token: 0x0600336E RID: 13166 RVA: 0x00062C50 File Offset: 0x00060E50
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x0600336F RID: 13167 RVA: 0x00062C68 File Offset: 0x00060E68
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06003370 RID: 13168 RVA: 0x00062C74 File Offset: 0x00060E74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CC7 RID: 3271
		private ErrorCode? _errorcode;

		// Token: 0x04000CC8 RID: 3272
		private string _lefttime;

		// Token: 0x04000CC9 RID: 3273
		private IExtension extensionObject;
	}
}
