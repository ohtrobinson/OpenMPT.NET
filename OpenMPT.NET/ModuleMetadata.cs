using System;
using System.Text;
using static OpenMPT.NET.MptNative;

namespace OpenMPT.NET;

public struct ModuleMetadata
{
    public string Type;

    public string TypeLong;

    public string OriginalType;

    public string OriginalTypeLong;

    public string Container;

    public string ContainerLong;

    public string Tracker;
    
    public string Artist;
    
    public string Title;

    public string Date;

    public string Message;

    public string MessageRaw;

    public string Warnings;

    public static unsafe ModuleMetadata FromModule(IntPtr module)
    {
        // This entire thing is horribly inefficient. Perfect! Send it to production.
        
        string keysList = new string(ModuleGetMetadataKeys(module));
        string[] keys = keysList.Split(';');

        ModuleMetadata metadata = new ModuleMetadata();
        
        foreach (string key in keys)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            string data;
            
            fixed (byte* pKey = keyBytes)
                data = new string(ModuleGetMetadata(module, (sbyte*) pKey));
            
            switch (key)
            {
                case "type":
                    metadata.Type = data;
                    break;
                case "type_long":
                    metadata.TypeLong = data;
                    break;
                case "originaltype":
                    metadata.OriginalType = data;
                    break;
                case "originaltype_long":
                    metadata.OriginalTypeLong = data;
                    break;
                case "container":
                    metadata.Container = data;
                    break;
                case "container_long":
                    metadata.ContainerLong = data;
                    break;
                case "tracker":
                    metadata.Tracker = data;
                    break;
                case "artist":
                    metadata.Artist = data;
                    break;
                case "title":
                    metadata.Title = data;
                    break;
                case "date":
                    metadata.Date = data;
                    break;
                case "message":
                    metadata.Message = data;
                    break;
                case "message_raw":
                    metadata.MessageRaw = data;
                    break;
                case "warnings":
                    metadata.Warnings = data;
                    break;
            }
        }

        return metadata;
    }
}