using System;
using System.Collections;
using UnityEngine;

namespace XUpdater
{

	internal sealed class XBundle : MonoBehaviour
	{

		public void GetBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			base.StartCoroutine(this.LoadBundle(www, data, callback, load));
		}

		public void GetAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			base.StartCoroutine(this.LoadAsset(bundle, package, callback));
		}

		private IEnumerator LoadBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			AssetBundle bundle = null;
			if (load)
			{
				bool flag = www != null;
				if (flag)
				{
					bundle = www.assetBundle;
				}
				else
				{
					bundle = AssetBundle.LoadFromMemory(data);
				}
				yield return null;
			}
			bool flag2 = callback != null;
			if (flag2)
			{
				callback(bundle);
			}
			bool flag3 = www != null;
			if (flag3)
			{
				www.Dispose();
			}
			www = null;
			yield break;
		}

		private IEnumerator LoadAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			this._assetloader = bundle.LoadAssetAsync(base.name, XUpdater.Ass.GetType(package.type));
			yield return this._assetloader;
			bool flag = callback != null;
			if (flag)
			{
				callback(package, this._assetloader.asset);
			}
			this._assetloader = null;
			yield break;
		}

		private AssetBundleRequest _assetloader = null;
	}
}
