using System;


namespace RTS
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAssetAttribute : Attribute
    {
        public readonly string AssetName;
        
        public InjectAssetAttribute(string assetName = null)
        {
            AssetName = assetName;
        }
    }
}