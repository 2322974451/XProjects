using System;

namespace XMainClient
{

	internal enum PtcHeadFlag
	{

		PTC_TYPE_FLAG,

		RPC_TYPE_FLAG,

		RPC_TYPE_REPLY = 1,

		RPC_TYPE_ISREQUEST_MASK,

		RPC_TYPE_REQUEST,

		RPC_TYPE_COMPRESS,

		RPC_TYPE_RPCNULL = 8
	}
}
