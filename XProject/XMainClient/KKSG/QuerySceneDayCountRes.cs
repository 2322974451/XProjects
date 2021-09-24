using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QuerySceneDayCountRes")]
	[Serializable]
	public class QuerySceneDayCountRes : IExtensible
	{

		[ProtoMember(1, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sceneid
		{
			get
			{
				return this._sceneid;
			}
		}

		[ProtoMember(2, Name = "scenecout", DataFormat = DataFormat.TwosComplement)]
		public List<uint> scenecout
		{
			get
			{
				return this._scenecout;
			}
		}

		[ProtoMember(3, Name = "scenebuycount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> scenebuycount
		{
			get
			{
				return this._scenebuycount;
			}
		}

		[ProtoMember(4, Name = "chestOpenedScene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chestOpenedScene
		{
			get
			{
				return this._chestOpenedScene;
			}
		}

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

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _sceneid = new List<uint>();

		private readonly List<uint> _scenecout = new List<uint>();

		private readonly List<uint> _scenebuycount = new List<uint>();

		private readonly List<uint> _chestOpenedScene = new List<uint>();

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
