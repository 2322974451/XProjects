// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.AssetBundlePathResolver
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System.IO;
using System.Text;
using UnityEngine;

namespace XUtliPoolLib
{
    public class AssetBundlePathResolver
    {
        public static AssetBundlePathResolver instance;
        private string cachePath = (string)null;
        private string cachePathWWW = (string)null;
        private StringBuilder pathSB = new StringBuilder();
        private DirectoryInfo cacheDir;

        public AssetBundlePathResolver() => AssetBundlePathResolver.instance = this;

        public virtual string BundleSaveDirName => "AssetBundles";

        public string AndroidBundleSavePath => "Assets/StreamingAssets/update/Android/" + this.BundleSaveDirName;

        public string iOSBundleSavePath => "Assets/StreamingAssets/update/iOS/" + this.BundleSaveDirName;

        public string DefaultBundleSavePath => "Assets/StreamingAssets/update/" + this.BundleSaveDirName;

        public virtual string AndroidHashCacheSaveFile => "Assets/AssetBundles/Android/cache.txt";

        public virtual string iOSHashCacheSaveFile => "Assets/AssetBundles/iOS/cache.txt";

        public virtual string DefaultHashCacheSaveFile => "Assets/AssetBundles/cache.txt";

        public virtual string GetEditorModePath(string abName)
        {
            abName = abName.Replace(".", "/");
            int length = abName.LastIndexOf("/");
            return length == -1 ? abName : string.Format("{0}.{1}", (object)abName.Substring(0, length), (object)abName.Substring(length + 1));
        }

        public virtual string GetBundleSourceFile(string path, bool forWWW = true)
        {
            if (forWWW)
            {
                if (this.cachePathWWW == null)
                {
                    switch (Application.platform)
                    {
                        case RuntimePlatform.IPhonePlayer:
                            this.cachePathWWW = string.Format("file://{0}/Raw/update/iOS/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                        case RuntimePlatform.Android:
                            this.cachePathWWW = string.Format("jar:file://{0}!/assets/update/Android/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                        default:
                            this.cachePathWWW = string.Format("file://{0}/StreamingAssets/update/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                    }
                }
                this.pathSB.Length = 0;
                this.pathSB.Append(this.cachePathWWW);
            }
            else
            {
                if (this.cachePath == null)
                {
                    switch (Application.platform)
                    {
                        case RuntimePlatform.IPhonePlayer:
                            this.cachePath = string.Format("{0}/Raw/update/iOS/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                        case RuntimePlatform.Android:
                            this.cachePath = string.Format("{0}!assets/update/Android/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                        default:
                            this.cachePath = string.Format("{0}/StreamingAssets/update/{1}/", (object)Application.dataPath, (object)this.BundleSaveDirName);
                            break;
                    }
                }
                this.pathSB.Length = 0;
                this.pathSB.Append(this.cachePath);
            }
            this.pathSB.Append(path);
            return this.pathSB.ToString();
        }

        public virtual string DependFileName => "dep.all";

        public virtual string BundleCacheDir
        {
            get
            {
                if (this.cacheDir == null)
                {
                    string path;
                    switch (Application.platform)
                    {
                        case RuntimePlatform.IPhonePlayer:
                            path = string.Format("{0}/update/AssetBundles", (object)Application.persistentDataPath);
                            break;
                        case RuntimePlatform.Android:
                            path = string.Format("{0}/update/AssetBundles", (object)Application.persistentDataPath);
                            break;
                        default:
                            switch (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom())
                            {
                                case XPlatformType.IOS:
                                    path = string.Format("{0}/update/iOS/AssetBundles", (object)Application.streamingAssetsPath);
                                    break;
                                case XPlatformType.Android:
                                    path = string.Format("{0}/update/Android/AssetBundles", (object)Application.streamingAssetsPath);
                                    break;
                                default:
                                    path = string.Format("{0}/update/AssetBundles", (object)Application.streamingAssetsPath);
                                    break;
                            }
                            break;
                    }
                    this.cacheDir = new DirectoryInfo(path);
                    if (!this.cacheDir.Exists)
                        this.cacheDir.Create();
                }
                return this.cacheDir.FullName;
            }
        }
    }
}
